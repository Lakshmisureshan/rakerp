using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;
using WebApplication1.Repositories.Implementation;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDBContext dbcontext;
        private readonly UserManager<ApplicationUser> userManager1;
        private readonly IConfiguration configuration1;
        private readonly ITokenRepository tokenrepository;

        public ILogger<AuthController> Logger { get; }

        public AuthController(ApplicationDBContext dbcontext,UserManager<ApplicationUser> userManager1,  IConfiguration configuration1,ITokenRepository  tokenrepository, ILogger<AuthController> logger)
        {
            this.dbcontext = dbcontext;
            this.userManager1 = userManager1;
            this.configuration1 = configuration1;
            this.tokenrepository = tokenrepository;
            Logger = logger;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var user = new ApplicationUser
            {
                UserName = request.Email?.Trim(),
                Email = request.Email?.Trim(),
                passcode = request.passcode.Trim(),
            };
            var identityResult = await userManager1.CreateAsync(user, request.Password);
            if (identityResult.Succeeded)
            {

                //add role to user (Reader)
                identityResult = await userManager1.AddToRoleAsync(user, "Reader");

                if (identityResult.Succeeded)
                {


                    return Ok();

                }

                else
                {
                    if (identityResult.Errors.Any())
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                    }



                }



            }


            else
            {
                if (identityResult.Errors.Any())
                {
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }



            }



            return ValidationProblem(ModelState);









        }


        [HttpGet("GetAllUsers")]

        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userManager1.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("GetUsernameByIdAsync")]
        public async Task<string> GetUsernameByIdAsync(string userId)
        {
            // Fetch the user by ID using the UserManager service
            var user = await userManager1.FindByIdAsync(userId);
            return user.UserName; // Return the username or null if user not found
        }
        [HttpGet("GetUserIdByEmail")]
        public async Task<IActionResult> GetUserIdByEmail(string email)
        {
            var user = await userManager1.FindByEmailAsync(email);
            if (user != null)
            {
                var userId = user.Id; // Access the user ID
                return Ok(new { userId }); // Return as a JSON object
            }
            return NotFound("User not found");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]  LoginRequestDto  request)
        {
          var identityUser = await userManager1.FindByEmailAsync(request.Email);
         
            if (identityUser is not null)
            {

                var checkpasswordresult = await userManager1.CheckPasswordAsync(identityUser, request.Password);
                Logger.LogInformation($"Password check result: {checkpasswordresult}");

                if (checkpasswordresult)
                {
               



                    var roles = await userManager1.GetRolesAsync(identityUser);
                  var jwttoken=  tokenrepository.CreateJwttoken(identityUser, roles.ToList());
                    var response = new LoginResponseDto
                    {
                        Email = request.Email,
                        Roles = roles.ToList(),
                        Token= jwttoken



                    };

                    return Ok(response);
                }

            }
            ModelState.AddModelError("","Email or Password is incorrect");

            return ValidationProblem(ModelState);

        }



        [HttpPost("VerifyPR")]
        public async Task<IActionResult> VerifyPR([FromBody] VerifyPRRequestDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.passcode) || string.IsNullOrEmpty(request.userid))
            {
                return BadRequest("Invalid input.");
            }

            // Find the user by UserId or Email
            var user = await userManager1.FindByIdAsync(request.userid) ??
                       await userManager1.FindByEmailAsync(request.userid);

            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            // Check the passcode
            if (user.passcode != request.passcode)
            {
                return Unauthorized("Invalid password or passcode.");
            }

            // Find the PR header
            var prheader = await dbcontext.PR.FirstOrDefaultAsync(p => p.PRID == request.prid);

            if (prheader == null)
            {
                return NotFound("PR header not found.");
            }

            // Update the PR status
            prheader.prstatusid = 3;
            prheader.verifiedbyid = request.userid;
            prheader.prverificationdate = DateTime.Now; 
            await dbcontext.SaveChangesAsync();

            return Ok(new { message = "verified" });
        }


        [HttpGet("GetUserRoles")]

        public async Task<ActionResult<List<string>>> GetUserRoles(string userId)
        
        {
            var user = await userManager1.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await userManager1.GetRolesAsync(user);
            return Ok(roles);
        }



        public class VerifyPORequest
        {
            public string UserId { get; set; }
            public string passcode { get; set; }    
            public List<int> ForderId { get; set; }
        }





        public class VerifyPRRequest
        {
            public string userid { get; set; }
            public string passcode { get; set; }
            public List<int> prid { get; set; }
        }






















        [HttpPost("VerifyPOs")]
        public async Task<IActionResult> VerifyPOs([FromBody] VerifyPORequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.UserId) || request.ForderId == null || request.ForderId.Count == 0)
            {
                return BadRequest("Invalid request data.");
            }


            var user = await userManager1.FindByIdAsync(request.UserId) ??
                    await userManager1.FindByEmailAsync(request.UserId);

            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            // Check the passcode
            if (user.passcode != request.passcode)
            {
                return Unauthorized("Invalid password or passcode.");
            }



            bool isVerified;
            // Perform the PO verification logic here
            try
            {
                var pos = await dbcontext.PO.Where(po => request.ForderId.Contains(po.Orderid)).ToListAsync();

                foreach (var po in pos)
                {
                    po.poverifiedbyid = request.UserId;
                    po.postatusid = 2;
                    po.poverifiedDate = DateTime.Now;
                }

                await dbcontext.SaveChangesAsync();
                isVerified = true;
            }
            catch (Exception ex)
            {
                // Log the exception and handle errors
                // logger.LogError(ex, "Error verifying POs");
                isVerified = false;
            }

            if (isVerified)
            {
                return Ok(new { message = "verified" });
            }
            else
            {
                return StatusCode(500, "An error occurred while verifying POs.");
            }
        }

        [HttpPost("authorizePOs")]
        public async Task<IActionResult> authorizePOs([FromBody] VerifyPORequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.UserId) || request.ForderId == null || request.ForderId.Count == 0)
            {
                return BadRequest("Invalid request data.");
            }

            var user = await userManager1.FindByIdAsync(request.UserId) ??
                    await userManager1.FindByEmailAsync(request.UserId);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            // Check the passcode
            if (user.passcode != request.passcode)
            {
                return Unauthorized("Invalid password or passcode.");
            }



            bool isauthorised;
            // Perform the PO verification logic here
            try
            {
                var pos = await dbcontext.PO.Where(po => request.ForderId.Contains(po.Orderid)).ToListAsync();

                foreach (var po in pos)
                {
                    po.PoAuthorizedbyid = request.UserId;
                    po.postatusid =3;
                    po.poauthorizedDate = DateTime.Now;
                }

                await dbcontext.SaveChangesAsync();
                isauthorised = true;
            }
            catch (Exception ex)
            {
                // Log the exception and handle errors
                // logger.LogError(ex, "Error verifying POs");
                isauthorised = false;
            }

            if (isauthorised)
            {
                return Ok(new { message = "authorized" });
            }
            else
            {
                return StatusCode(500, "An error occurred while authorizing POs.");
            }
        }











        [HttpPost("RegisterRE")]
        public async Task<IActionResult> RegisterRE([FromBody] RegisterREclass request)
        {
            if (request == null || string.IsNullOrEmpty(request.UserId))
            {
                return BadRequest("Invalid request data");
            }

            var user = await userManager1.FindByIdAsync(request.UserId) ??
                       await userManager1.FindByEmailAsync(request.UserId);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            // Assuming you have a context object to interact with the database
            using (var transaction = await dbcontext.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var entry in request.redetails)
                    {
                        // Retrieve the purchase details based on potblid
                        var purchaseDetails = await dbcontext.Purchasedetails
                                                             .FirstOrDefaultAsync(pd => pd.potblid == entry.potblid);

                        if (purchaseDetails == null)
                        {
                            return NotFound($"Purchase details not found for potblid {entry.potblid}.");
                        }

                        // Update the received quantity
                        purchaseDetails.receivedentryqty += entry.receivedqty;

                        // Retrieve the received header based on rtblid
                        var receivedHeader = await dbcontext.ReceivedEntry
                                                            .FirstOrDefaultAsync(rh => rh.REID == request.reno);

                        if (receivedHeader == null)
                        {
                            return NotFound($"Received header not found for rtblid {entry.rtblid}.");
                        }

                        // Update the isregistered field
                        receivedHeader.isregistered = 1;
                    }

                    // Save changes to the database
                    await dbcontext.SaveChangesAsync();

                    // Commit the transaction
                    await transaction.CommitAsync();

                    return Ok("Purchase details and received headers updated successfully.");
                }
                catch (Exception ex)
                {
                    // Roll back the transaction if any error occurs
                    await transaction.RollbackAsync();
                    return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
                }
            }
        }



        //[HttpPost("RegisterGRN")]
        //public async Task<IActionResult> RegisterGRN([FromBody] RegisterGRNclass request)
        //{
        //    if (request == null || string.IsNullOrEmpty(request.UserId))
        //    {
        //        return BadRequest("Invalid request data");
        //    }

        //    var user = await userManager1.FindByIdAsync(request.UserId) ??
        //               await userManager1.FindByEmailAsync(request.UserId);
        //    if (user == null)
        //    {
        //        return Unauthorized("User not found.");
        //    }



        //    var grnheader = await dbcontext.GRNHeader
        //  .Include(po => po.PO) // Include the Supplier related entity
        //  .Where(po => po.grnno == request.grnno)
        //  .FirstOrDefaultAsync();
        //    if (grnheader == null)
        //    {
        //        return Unauthorized("User not found.");
        //    }
        //    else
        //    {
        //        using (var transaction = await dbcontext.Database.BeginTransactionAsync())
        //        {
        //            try
        //            {





        //                foreach (var entry in request.details)
        //                {
        //                    // Retrieve the purchase details based on potblid
        //                    var purchaseDetails = await dbcontext.Purchasedetails
        //                                                         .FirstOrDefaultAsync(pd => pd.poitemid == entry.itemcode && pd.orderid == grnheader.pono);

        //                    if (purchaseDetails == null)
        //                    {
        //                        return NotFound($"Purchase details not found for potblid {grnheader.pono}.");
        //                    }
        //                    else
        //                    {

        //                        var purchaseheader = await dbcontext.PO
        //                                                         .FirstOrDefaultAsync(pd =>  pd.Orderid == grnheader.pono);
        //                        purchaseDetails.grncreatedqty = entry.grnqty;
        //                        if (purchaseheader == null)
        //                        {
        //                            return NotFound($"Purchase Header not found for potblid {grnheader.pono}.");
        //                        }
        //                        // Retrieve the received header based on rtblid


        //                        // Update the isregistered field
        //                        grnheader.isregistered = 1;



        //                        var inventory = new Inventory
        //                        {
        //                            productid = entry.itemcode,
        //                            batchid = 1, // Assuming batchid is part of the entry details
        //                            jobid = purchaseheader.jobid, // Assuming jobid is part of the entry details
        //                            pono = grnheader.pono,
        //                            quantity = entry.grnqty,
        //                            Entrydate = DateTime.UtcNow,
        //                            uomid = purchaseDetails.pouomid // Assuming pouomid is part of the purchase details
        //                        };

        //                        // Add the Inventory object to the context
        //                        dbcontext.Inventory.Add(inventory);
        //                    }

        //                    // Update the received quantity







        //                }

        //                // Save changes to the database
        //                await dbcontext.SaveChangesAsync();

        //                // Commit the transaction
        //                await transaction.CommitAsync();

        //                return Ok("Purchase details and received headers updated successfully.");
        //            }
        //            catch (Exception ex)
        //            {
        //                // Roll back the transaction if any error occurs
        //                await transaction.RollbackAsync();
        //                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
        //            }
        //        }

        //    }

        //    // Assuming you have a context object to interact with the database

        //}


        //[HttpPost("RegisterGRN")]
        //public async Task<IActionResult> RegisterGRN([FromBody] RegisterGRNclass request)
        //{
        //    if (request == null || string.IsNullOrEmpty(request.UserId))
        //    {
        //        return BadRequest("Invalid request data");
        //    }

        //    var user = await userManager1.FindByIdAsync(request.UserId) ??
        //               await userManager1.FindByEmailAsync(request.UserId);
        //    if (user == null)
        //    {
        //        return Unauthorized("User not found.");
        //    }

        //    var grnheader = await dbcontext.GRNHeader
        //        .Include(po => po.PO) // Include the Supplier related entity
        //        .Where(po => po.grnno == request.grnno)
        //        .FirstOrDefaultAsync();

        //    if (grnheader == null)
        //    {
        //        return NotFound("GRN header not found.");
        //    }

        //    using (var transaction = await dbcontext.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            foreach (var entry in request.details)
        //            {
        //                // Retrieve the purchase details based on potblid
        //                var purchaseDetails = await dbcontext.Purchasedetails
        //                                                     .FirstOrDefaultAsync(pd => pd.poitemid == entry.itemcode && pd.orderid == grnheader.pono);

        //                if (purchaseDetails == null)
        //                {
        //                    return NotFound($"Purchase details not found for item code {entry.itemcode} and PO {grnheader.pono}.");
        //                }

        //                var purchaseheader = await dbcontext.PO
        //                                                     .FirstOrDefaultAsync(ph => ph.Orderid == grnheader.pono);

        //                if (purchaseheader == null)
        //                {
        //                    return NotFound($"Purchase header not found for PO {grnheader.pono}.");
        //                }

        //                purchaseDetails.grncreatedqty = entry.grnqty;

        //                // Update the isregistered field
        //                grnheader.isregistered = 1;

        //                var inventory = new Inventory
        //                {
        //                    productid = entry.itemcode,
        //                    batchid = 1, // Assuming batchid is part of the entry details
        //                    jobid = purchaseheader.jobid, // Assuming jobid is part of the entry details
        //                    pono = grnheader.pono,
        //                    quantity = entry.grnqty * (decimal)entry.multiplyingfactor,

        //                    Entrydate = DateTime.UtcNow,
        //                    uomid = entry.inventoryuomid ,
        //                    invcurrencyid=request.invcurrencyid ,
        //                    invprice=entry.pounitprice
        //                    // Assuming pouomid is part of the purchase details
        //                };

        //                // Add the Inventory object to the context
        //                dbcontext.Inventory.Add(inventory);




        //                await dbcontext.SaveChangesAsync();

        //                // Retrieve the invid after saving
        //                var inventoryWithId = await dbcontext.Inventory
        //                                                       .Where(inv => inv.productid == entry.itemcode && inv.pono == grnheader.pono)
        //                                                       .OrderByDescending(inv => inv.Entrydate)
        //                                                       .FirstOrDefaultAsync();

        //                if (inventoryWithId == null)
        //                {
        //                    return StatusCode(500, "Failed to retrieve the generated inventory ID.");
        //                }

        //                // Now use the generated invid for the grntrack
        //                var grntrack = new grntracking
        //                {
        //                    productid = entry.itemcode,
        //                    jobid = purchaseheader.jobid, // Assuming jobid is part of the entry details
        //                    grnno = grnheader.grnno,
        //                    grnqty = entry.grnqty * (decimal)entry.multiplyingfactor,
        //                    grndate = DateTime.UtcNow.Date,
        //                    invid = inventoryWithId.invid ,
        //                    grnuomid = entry.inventoryuomid,
        //                    grncurrencyid = request.invcurrencyid,
        //                    grnunitprice = entry.pounitprice


        //                    // Assign the retrieved invid here
        //                };



        //                dbcontext.grntracking.Add(grntrack);














        //            }

































        //            // Save changes to the database
        //            await dbcontext.SaveChangesAsync();

        //            // Commit the transaction
        //            await transaction.CommitAsync();

        //            return Ok(new { Message = "Purchase details and received headers updated successfully.", Success = true });
        //        }
        //        catch (Exception ex)
        //        {
        //            // Roll back the transaction if any error occurs
        //            await transaction.RollbackAsync();
        //            return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
        //        }
        //    }
        //}











        [HttpPost("RegisterGRN")]
        public async Task<IActionResult> RegisterGRN([FromBody] RegisterGRNclass request)
        {
            if (request == null || string.IsNullOrEmpty(request.UserId))
            {
                return BadRequest("Invalid request data");
            }

            var user = await userManager1.FindByIdAsync(request.UserId) ??
                       await userManager1.FindByEmailAsync(request.UserId);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            var grnheader = await dbcontext.GRNHeader
                .Include(po => po.PO) // Include the Supplier related entity
                .Where(po => po.grnno == request.grnno)
                .FirstOrDefaultAsync();

            if (grnheader == null)
            {
                return NotFound("GRN header not found.");
            }

            using (var transaction = await dbcontext.Database.BeginTransactionAsync())
            {
                try
                {
                    // If request.details is null or empty, just update isregistered to 1
                    if (request.details == null || !request.details.Any())
                    {
                        grnheader.isregistered = 1;
                        await dbcontext.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return Ok(new { Message = "GRN registered successfully without details.", Success = true });
                    }

                    // Process details if available
                    foreach (var entry in request.details)
                    {
                        var purchaseDetails = await dbcontext.Purchasedetails
                            .FirstOrDefaultAsync(pd => pd.poitemid == entry.itemcode && pd.orderid == grnheader.pono);

                        if (purchaseDetails == null)
                        {
                            return NotFound($"Purchase details not found for item code {entry.itemcode} and PO {grnheader.pono}.");
                        }

                        var purchaseheader = await dbcontext.PO
                            .FirstOrDefaultAsync(ph => ph.Orderid == grnheader.pono);

                        if (purchaseheader == null)
                        {
                            return NotFound($"Purchase header not found for PO {grnheader.pono}.");
                        }

                        purchaseDetails.grncreatedqty = entry.grnqty;

                        // Update isregistered field
                        grnheader.isregistered = 1;

                        var inventory = new Inventory
                        {
                            productid = entry.itemcode,
                            batchid = 1,
                            jobid = purchaseheader.jobid,
                            pono = grnheader.pono,
                            quantity = entry.grnqty * (decimal)entry.multiplyingfactor,
                            Entrydate = DateTime.UtcNow,
                            uomid = entry.inventoryuomid,
                            invcurrencyid = request.invcurrencyid,
                            invprice = entry.pounitprice
                        };

                        dbcontext.Inventory.Add(inventory);
                        await dbcontext.SaveChangesAsync();

                        var inventoryWithId = await dbcontext.Inventory
                            .Where(inv => inv.productid == entry.itemcode && inv.pono == grnheader.pono)
                            .OrderByDescending(inv => inv.Entrydate)
                            .FirstOrDefaultAsync();

                        if (inventoryWithId == null)
                        {
                            return StatusCode(500, "Failed to retrieve the generated inventory ID.");
                        }

                        var grntrack = new grntracking
                        {
                            productid = entry.itemcode,
                            jobid = purchaseheader.jobid,
                            grnno = grnheader.grnno,
                            grnqty = entry.grnqty * (decimal)entry.multiplyingfactor,
                            grndate = DateTime.UtcNow.Date,
                            invid = inventoryWithId.invid,
                            grnuomid = entry.inventoryuomid,
                            grncurrencyid = request.invcurrencyid,
                            grnunitprice = entry.pounitprice
                        };

                        dbcontext.grntracking.Add(grntrack);
                    }

                    await dbcontext.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return Ok(new { Message = "Purchase details and received headers updated successfully.", Success = true });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
                }
            }
        }













        public class receivedentrysummary
        {

            public int potblid { get; set; }
            public int rtblid { get; set; }
            public decimal receivedqty { get; set; }

        }



  




        public class RegisterREclass
        {
            public int reno { get; set; }
            public string UserId { get; set; }
 
            public List<receivedentrysummary> redetails { get; set; }

        }

        public class RegisterGRNclass
        {
            public int grnno { get; set; }
            public string UserId { get; set; }
            public int invcurrencyid { get; set; }
            public List<grnsummary> details { get; set; }

        }









        public class RegisterIssuereturnclass
        {
           public int issuereturnref { get; set; }
           public List<issuereturnsummary> details { get; set; }

        }















        public class issuereturnsummary
        {
            public int fromjobid { get; set; }
            public int irtblid { get; set; }
            public int productid { get; set; }
            public string itemname { get; set; }
            public int quantityreturned { get; set; }
            public int tojobid { get; set; }

            public int ircurrencyid { get; set; }


            public int iruomid { get; set; }
            public decimal irunitprice { get; set; }


        }










        public class grnsummary
        {

            public int grntblid { get; set; }
            public decimal  grnqty { get; set; }
            public int pouomid { get; set; }
            public int inventoryuomid { get; set; }
            public double  multiplyingfactor { get; set; }
            public int itemcode { get; set; }
            public decimal pounitprice { get; set; }

        }










































        [HttpPost("Registerissuereturn")]
        public async Task<IActionResult> Registerissuereturn([FromBody] RegisterIssuereturnclass request)
        {
           

          

            var issuereturnheader = await dbcontext.Issuereturn
               // Include the Supplier related entity
                .Where(po => po.issuereturnref == request.issuereturnref)
                .FirstOrDefaultAsync();

            if (issuereturnheader == null)
            {
                return NotFound("Issue Return not found.");
            }

            using (var transaction = await dbcontext.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var entry in request.details)
                    {
                       // Update the isregistered field
                        issuereturnheader.isregistered = 1;
                        var inventory = new Inventory
                        {
                            productid = entry.productid,
                            batchid = 1, // Assuming batchid is part of the entry details
                            jobid = entry.fromjobid, // Assuming jobid is part of the entry details
                            pono = 2,
                            quantity = entry.quantityreturned,

                            Entrydate = DateTime.UtcNow,
                            uomid = entry.iruomid,
                            invcurrencyid = entry.ircurrencyid,
                            invprice = entry.irunitprice,

                            type="RETURN"
                            // Assuming pouomid is part of the purchase details
                        };

                        // Add the Inventory object to the context
                        dbcontext.Inventory.Add(inventory);
                        await dbcontext.SaveChangesAsync();
                      
                       var inventoryWithId = await dbcontext.Inventory
                                                              .Where(inv => inv.productid == entry.productid && inv.pono == 2)
                                                              .OrderByDescending(inv => inv.Entrydate)
                                                              .FirstOrDefaultAsync();

                        if (inventoryWithId == null)
                        {
                            return StatusCode(500, "Failed to retrieve the generated inventory ID.");
                        }
                        // Now use the generated invid for the grntrack
                        var issuetrack = new issuereturntracking
                        {
                            productid = entry.productid,
                            jobid = entry.fromjobid, // Assuming jobid is part of the entry details
                            issuereturnno = issuereturnheader.issuereturnref,
                            issuereturnqty = entry.quantityreturned ,
                            issuereturndate = DateTime.UtcNow.Date,
                            invid = inventoryWithId.invid,
                            uomid = entry.iruomid,
                            issuecurrencyid = entry.ircurrencyid,
                            issuereturnunitprice = entry.irunitprice
                            // Assign the retrieved invid here
                        };

                        dbcontext.issuereturntracking.Add(issuetrack);

                  }



                    // Save changes to the database
                    await dbcontext.SaveChangesAsync();

                    // Commit the transaction
                    await transaction.CommitAsync();

                    return Ok(new { Message = "Purchase details and received headers updated successfully.", Success = true });
                }
                catch (Exception ex)
                {
                    // Roll back the transaction if any error occurs
                    await transaction.RollbackAsync();
                    return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
                }
            }
        }


























        [HttpPost("VerifyPRs")]
        public async Task<IActionResult> VerifyPRs([FromBody] VerifyPRRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.passcode) || string.IsNullOrEmpty(request.userid))
            {
                return BadRequest("Invalid input.");
            }

            // Find the user by UserId or Email
            var user = await userManager1.FindByIdAsync(request.userid) ??
                       await userManager1.FindByEmailAsync(request.userid);

            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            // Check the passcode
            if (user.passcode != request.passcode)
            {
                return Unauthorized("Invalid password or passcode.");
            }

            // Find the PR header
            bool isVerified;
            // Perform the PO verification logic here
            try
            {
                var prs = await dbcontext.PR.Where(po => request.prid.Contains(po.PRID)).ToListAsync();

                foreach (var pr1 in prs)
                {
                    pr1.verifiedbyid = request.userid;
                    pr1.prstatusid = 3;
                    pr1.prverificationdate = DateTime.Now;
                }

                await dbcontext.SaveChangesAsync();
                isVerified = true;
            }
            catch (Exception ex)
            {
                // Log the exception and handle errors
                // logger.LogError(ex, "Error verifying POs");
                isVerified = false;
            }

            if (isVerified)
            {
                return Ok(new { message = "verified" });
            }
            else
            {
                return StatusCode(500, "An error occurred while verifying POs.");
            }
        }

    }
}
