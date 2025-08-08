using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;
using WebApplication1.Repositories.Implementation;
using WebApplication1.Repositories.Interface;
using static iTextSharp.text.pdf.events.IndexEvents;

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
        private readonly RoleManager<IdentityRole> _roleManager;


        public AuthController(RoleManager<IdentityRole> roleManager, ApplicationDBContext dbcontext, UserManager<ApplicationUser> userManager1, IConfiguration configuration1, ITokenRepository tokenrepository, ILogger<AuthController> logger)
        {
            this.dbcontext = dbcontext;
            this.userManager1 = userManager1;
            this.configuration1 = configuration1;
            this.tokenrepository = tokenrepository;
            Logger = logger;
            _roleManager = roleManager;
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
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var identityUser = await userManager1.FindByEmailAsync(request.Email);

            if (identityUser is not null)
            {

                var checkpasswordresult = await userManager1.CheckPasswordAsync(identityUser, request.Password);
                Logger.LogInformation($"Password check result: {checkpasswordresult}");

                if (checkpasswordresult)
                {




                    var roles = await userManager1.GetRolesAsync(identityUser);
                    var jwttoken = tokenrepository.CreateJwttoken(identityUser, roles.ToList());
                    var response = new LoginResponseDto
                    {
                        Email = request.Email,
                        Roles = roles.ToList(),
                        Token = jwttoken



                    };

                    return Ok(response);
                }

            }
            ModelState.AddModelError("", "Email or Password is incorrect");

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

        public class Addtobomfromestimationrv1
        {
            public string userid { get; set; }
            public string passcode { get; set; }
            public List<int> festimation { get; set; }
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
                    po.postatusid = 3;
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





        //[HttpPost("RegisterRE")]
        //public async Task<IActionResult> RegisterRE([FromBody] RegisterREclass request)
        //{
        //    if (request == null || string.IsNullOrEmpty(request.UserId))
        //    {
        //        return BadRequest("Invalid request data");
        //    }

        //    var user = await userManager1.FindByIdAsync(request.UserId) ??
        //               await userManager1.FindByEmailAsync(request.UserId);
        //    if (user == null)
        //    {
        //        return Ok(new { Message = "User not found." });
        //    }

        //    using (var transaction = await dbcontext.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            foreach (var entry in request.redetails)
        //            {
        //                var purchaseDetails = await dbcontext.Purchasedetails
        //                                                     .FirstOrDefaultAsync(pd => pd.potblid == entry.potblid);

        //                if (purchaseDetails == null)
        //                {
        //                   // return NotFound($"Purchase details not found for potblid {entry.potblid}.");
        //                    return Ok(new { Message = $"Purchase details not found for potblid {entry.potblid}.", Success = true });
        //                }

        //                var receivedHeader = await dbcontext.ReceivedEntry
        //                                                    .FirstOrDefaultAsync(rh => rh.REID == request.reno);

        //                if (receivedHeader == null)
        //                {
        //                  //  return NotFound($"Received header not found for rtblid {entry.rtblid}.");
        //                    return Ok(new { Message = $"Received header not found for rtblid {entry.rtblid}." });
        //                }

        //                // ✅ Check if already registered
        //                if (receivedHeader.isregistered == 1)
        //                {
        //                   // return BadRequest($"Received entry {entry.rtblid} is already registered.");

        //                    return Ok(new { Message = $"Received entry {entry.rtblid} is already registered." });
        //                }

        //                // ✅ Validate quantity
        //                var newReceivedQty = purchaseDetails.receivedentryqty + entry.receivedqty;

        //                if (newReceivedQty > purchaseDetails.poquantity)
        //                {
        //                   // return BadRequest($"Received quantity for potblid {entry.potblid} exceeds the ordered quantity ({purchaseDetails.poquantity}).");

        //                    return Ok(new { Message = $"Received quantity for potblid {entry.potblid} exceeds the ordered quantity ({purchaseDetails.poquantity})." });
        //                }

        //                purchaseDetails.receivedentryqty = newReceivedQty;
        //                receivedHeader.isregistered = 1;
        //            }

        //            await dbcontext.SaveChangesAsync();
        //            await transaction.CommitAsync();

        //           // return Ok("Purchase details and received headers updated successfully.");
        //            return Ok(new { Message = "Purchase details and received headers updated successfully" });
        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync();
        //            return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
        //        }
        //    }
        //}





        //[HttpPost("RegisterRE")]
        //public async Task<IActionResult> RegisterRE([FromBody] RegisterREclass request)
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

        //    // Assuming you have a context object to interact with the database
        //    using (var transaction = await dbcontext.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            foreach (var entry in request.redetails)
        //            {
        //                var purchaseDetails = await dbcontext.Purchasedetails
        //                                                     .FirstOrDefaultAsync(pd => pd.potblid == entry.potblid);

        //                if (purchaseDetails == null)
        //                {
        //                    return NotFound($"Purchase details not found for potblid {entry.potblid}.");
        //                }

        //                // Validate quantity
        //                var newReceivedQty = purchaseDetails.receivedentryqty + entry.receivedqty;

        //                if (newReceivedQty > purchaseDetails.poquantity)
        //                {
        //                    return BadRequest($"Received quantity for potblid {entry.potblid} exceeds the ordered quantity ({purchaseDetails.poquantity}).");
        //                }

        //                purchaseDetails.receivedentryqty = newReceivedQty;

        //                var receivedHeader = await dbcontext.ReceivedEntry
        //                                                    .FirstOrDefaultAsync(rh => rh.REID == request.reno);

        //                if (receivedHeader == null)
        //                {
        //                    return NotFound($"Received header not found for rtblid {entry.rtblid}.");
        //                }

        //                receivedHeader.isregistered = 1;
        //            }

        //            // Save changes to the database
        //            await dbcontext.SaveChangesAsync();

        //            // Commit the transaction
        //            await transaction.CommitAsync();

        //            return Ok("Purchase details and received headers updated successfully.");
        //        }
        //        catch (Exception ex)
        //        {
        //            // Roll back the transaction if any error occurs
        //            await transaction.RollbackAsync();
        //            return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
        //        }
        //    }
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
                        var maxBatchId = await dbcontext.Inventory
    .MaxAsync(inv => (int?)inv.batchid) ?? 0;

                        var nextBatchId = maxBatchId + 1;
                        var inventory = new Inventory
                        {
                            productid = entry.itemcode,
                            batchid = nextBatchId,
                            jobid = purchaseheader.jobid,
                            pono = grnheader.pono,
                            quantity = entry.grnqty * (decimal)entry.multiplyingfactor,
                            Entrydate = DateTime.UtcNow.Date,
                            uomid = entry.inventoryuomid,
                            invcurrencyid = 1,
                            invprice = entry.pounitprice * purchaseheader.poexchangerate,
                            location = entry.location,
                            billofentrydate = grnheader.billofentrydate,
                            billofentryno = grnheader.billofentryno,

                            actualgrndate = DateTime.UtcNow.Date,

                        };

                        dbcontext.Inventory.Add(inventory);
                        await dbcontext.SaveChangesAsync();
                        var inventoryWithId1 = await dbcontext.Inventory
                   .Where(inv => inv.productid == entry.itemcode && inv.pono == grnheader.pono)
                   .OrderByDescending(inv => inv.Entrydate)
                   .FirstOrDefaultAsync();

                        if (inventoryWithId1 == null)
                        {
                            return StatusCode(500, "Failed to retrieve the generated inventory ID.");
                        }

                        var inventoryhis = new InventoryHistory
                        {
                            productid = entry.itemcode,
                            batchid = nextBatchId,
                            jobid = purchaseheader.jobid,
                            pono = grnheader.pono,
                            quantity = entry.grnqty * (decimal)entry.multiplyingfactor,
                            Entrydate = DateTime.UtcNow.Date,
                            uomid = entry.inventoryuomid,
                            invcurrencyid = 1,
                            invprice = entry.pounitprice * purchaseheader.poexchangerate,
                            location = entry.location,
                            invid = inventoryWithId1.invid
                        };

                        dbcontext.InventoryHistory.Add(inventoryhis);
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
                            grncurrencyid = 1,
                            grnunitprice = entry.pounitprice * purchaseheader.poexchangerate,
                            location = entry.location,
                            billofentrydate = grnheader.billofentrydate,
                            billofentryno = grnheader.billofentryno,

                            actualgrndate = DateTime.UtcNow.Date,

                        };

                        dbcontext.grntracking.Add(grntrack);
                    }

                    await dbcontext.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return Ok(new { Message = "GRN updated successfully.", Success = true });
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


        public class RegisterIssuereturnclassrv1
        {
            public int issuereturnref { get; set; }


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
            public decimal grnqty { get; set; }
            public int pouomid { get; set; }
            public int inventoryuomid { get; set; }
            public decimal multiplyingfactor { get; set; }
            public int itemcode { get; set; }
            public decimal pounitprice { get; set; }
            public string? location { get; set; }

        }































        public class RegisterPOIssuereturnclass
        {
            public int issuereturnno { get; set; }
        }



        [HttpPost("RegisterPOIssuereturn")]
        public async Task<IActionResult> RegisterPOIssuereturn([FromBody] RegisterPOIssuereturnclass request)
        {
            // Start a database transaction to ensure all operations are atomic
            // If any step fails, the entire transaction will be rolled back.
            using (var transaction = await dbcontext.Database.BeginTransactionAsync())
            {
                try
                {
                    // 1. Fetch the Issue Return Header entity for direct modification
                    var issuereturnheader = await dbcontext.Issuereturn
                        .FirstOrDefaultAsync(po => po.issuereturnref == request.issuereturnno);
                    if (issuereturnheader == null)
                    {
                        await transaction.RollbackAsync();
                        return NotFound("Issue Return header not found.");
                    }

                    // 2. Check if already registered
                    if (issuereturnheader.isregistered == 1)
                    {
                        await transaction.RollbackAsync();
                        return BadRequest("Issue Return is already registered.");
                    }

                    // 3. Update Issue Return Header: Set IsRegistered to true
                    issuereturnheader.isregistered = 1;
                    // dbcontext.Issuereturn.Update(issuereturnheader); // No need for explicit Update call if entity is tracked and modified

                    // 4. Fetch the combined data using Joins for inventory processing
                    //var combinedData = await dbcontext.Issuereturn
                    //    .Join(dbcontext.POissuereturndetails,
                    //          header => header.issuereturnref,
                    //          detail => detail.issuereturnref,
                    //          (header, detail) => new { Header = header, Detail = detail })
                    //    .Join(dbcontext.POIssueReturnDetailIssueTracking,
                    //          combined => combined.Detail.issuereturndetailid,
                    //          link => link.issuereturndetailid,
                    //          (combined, link) => new { combined.Header, combined.Detail, Link = link })
                    //    .Join(dbcontext.Issuetracking,
                    //          combined => combined.Link.issuetrackid,
                    //          issue => issue.issuetrackid,
                    //          (combined, issue) => new { combined.Header, combined.Detail, combined.Link, Issue = issue })
                    //    .Where(result => result.Header.issuereturnref == request.issuereturnno)
                    //    .Select(result => new
                    //    {
                    //        HeaderJobId = result.Header.jobid,
                    //        headerissueretunrefid = result.Header.issuereturnref,
                    //        POIssueReturnDetailId = result.Detail.issuereturndetailid,
                    //        ProductCode = result.Detail.productcode,
                    //        ReturnQty = result.Issue.totalreturnedqty, // Assuming this is the actual quantity being returned
                    //        IssueReturnUnitPrice = result.Detail.issuereturnunitprice,
                    //        location = result.Detail.location, // Location from the POIssueReturnDetail
                    //        OriginalIssueId = result.Issue.issuetrackid,
                    //        OriginalIssueUomId = result.Issue.issueuomid,
                    //        OriginalIssueCurrencyId = result.Issue.issuecurrencyid,
                    //        OriginalIssueJobId = result.Issue.jobid,
                    //        originalbillofentrydate = result.Issue.billofentrydate,
                    //        originalbillofentryno = result.Issue.billofentryno,
                    //       originalinvid = result.Issue.invid
                    //        // Get original issue jobid if needed for inventory
                    //    })
                    //    .ToListAsync();

                    var combinedData = await (
    from detail in dbcontext.POissuereturndetails
    join link in dbcontext.POIssueReturnDetailIssueTracking
        on detail.issuereturndetailid equals link.issuereturndetailid
    join issue in dbcontext.Issuetracking
        on link.issuetrackid equals issue.issuetrackid
    where detail.issuereturnref == request.issuereturnno
    select new
    {
        POIssueReturnDetailId = detail.issuereturndetailid,
        ProductCode = detail.productcode,
        ReturnQty = detail.returnqty, // This should come from POissuereturndetails, not issuetracking
        IssueReturnUnitPrice = detail.issuereturnunitprice,
        location = detail.location,

        OriginalIssueId = issue.issuetrackid,
        OriginalIssueUomId = issue.issueuomid,
        OriginalIssueCurrencyId = issue.issuecurrencyid,
        OriginalIssueJobId = issue.jobid,
        OriginalInvoiceId = issue.invid,
        OriginalBillOfEntryNo = issue.billofentryno,
        OriginalBillOfEntryDate = issue.billofentrydate
    }
).ToListAsync();


                    // 5. Process each detail line and insert into Inventory and issuereturntracking

                    // Determine the next batch ID before the loop for consistency if it's a global sequence
                    // Or, if batchid is specific to the Inventory table and auto-incrementing, EF handles it.
                    // If 'batchid' is truly an auto-incrementing PK/Identity column, you don't need to manually find max and increment.
                    // If 'batchid' is a logical sequence you manage, ensure it's unique and incremented correctly.
                    // For this example, assuming 'batchid' is a logical sequence for new entries.
                    var maxBatchId = await dbcontext.Inventory.MaxAsync(inv => (int?)inv.batchid) ?? 0;
                    // Note: If batchid is an IDENTITY column, you should remove this manual maxBatchId logic.
                    // EF will populate it after SaveChangesAsync.

                    foreach (var item in combinedData)
                    {
                        // Increment batchId for each new entry if it's a logical sequence managed by you.
                        // If it's an auto-incrementing DB identity, remove this line and rely on EF.
                        maxBatchId++; // Use this if you're manually managing batch IDs for new entries

                        // Create a new Inventory entry for the returned item
                        var inventoryEntry = new Inventory
                        {
                            productid = item.ProductCode,
                            quantity = item.ReturnQty,
                            Entrydate = DateTime.UtcNow.Date,
                            uomid = item.OriginalIssueUomId,
                            invcurrencyid = item.OriginalIssueCurrencyId, // Use currency from original issue
                            invprice = item.IssueReturnUnitPrice,
                            jobid = 500001, // Use the jobid from the original issue, or a specific return job if different
                            pono = 1, // Still hardcoded. Consider if this should come from request or combinedData.
                            reservedqty = 0.00m,
                            type = "PORETURN",
                            batchid = maxBatchId, // Assign the incremented batch ID
                            location = item.location,
                            billofentryno = item.OriginalBillOfEntryNo,
                            billofentrydate = item.OriginalBillOfEntryDate,
                            


                            
                        };

                        await dbcontext.Inventory.AddAsync(inventoryEntry);
                        // IMPORTANT: SaveChangesAsync() here to persist the Inventory entry
                        // and get its auto-generated invid (if invid is an identity column).
                        await dbcontext.SaveChangesAsync(); // <--- THIS IS THE CRUCIAL CHANGE

                        // Now, inventoryEntry.invid will be populated with the database-generated ID
                        // You no longer need the separate query to find it.

                        var issuereturnTrackingEntry = new issuereturntracking
                        {
                            invid = inventoryEntry.invid, // Use the newly generated invid from the Inventory table
                            jobid = 500001, // Use jobid from the PO Issue Return Header
                            issuereturnno = request.issuereturnno,
                            issuereturndate = DateTime.UtcNow.Date,
                            issuereturnqty = item.ReturnQty,
                            productid = item.ProductCode,
                            issuereturnunitprice = item.IssueReturnUnitPrice,
                            issuecurrencyid = item.OriginalIssueCurrencyId, // Use currency from original issue
                            uomid = item.OriginalIssueUomId,
                            location = item.location,
                            billofentryno = item.OriginalBillOfEntryNo,
                            billofentrydate = item.OriginalBillOfEntryDate,


                        };
                        await dbcontext.issuereturntracking.AddAsync(issuereturnTrackingEntry);
                    }

                    // 6. Save all remaining changes (issuereturntracking entries)
                    // The issuereturnheader update was implicitly tracked by EF.
                    await dbcontext.SaveChangesAsync();

                    // 7. Commit the transaction if all operations were successful
                    await transaction.CommitAsync();

                    return Ok(new { Message = $"Issue Return  registered and inventory updated successfully." });
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if any error occurs
                    await transaction.RollbackAsync();
                    Console.Error.WriteLine($"Error registering PO Issue Return {request.issuereturnno}: {ex.Message}");
                    Console.Error.WriteLine($"Stack Trace: {ex.StackTrace}");

                    return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
                }
            }
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

                            Entrydate = DateTime.UtcNow.Date,
                            uomid = entry.iruomid,
                            invcurrencyid = entry.ircurrencyid,
                            invprice = entry.irunitprice,

                            type = "RETURN"
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
                            issuereturnqty = entry.quantityreturned,
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






        [HttpPost("Registerissuereturnrv1")]
        public async Task<IActionResult> Registerissuereturnrv1([FromBody] RegisterIssuereturnclassrv1 request)
        {
            // 1. Find the Issue Return Header
            var issuereturnheader = await dbcontext.Issuereturn
                .Where(po => po.issuereturnref == request.issuereturnref)
                .FirstOrDefaultAsync();

            if (issuereturnheader == null)
            {
                return NotFound("Issue Return header not found.");
            }



            // 2. Retrieve ALL associated Issue Return Details from the database.
            // These details define *what* is being returned based on the pre-existing return order.
            var issuereturndetailsFromDb = await dbcontext.Issuereturndetails
                .Where(detail => detail.issuereturnref == issuereturnheader.issuereturnref)
                // IMPORTANT: If Issuereturndetails links to Issuereturn via IssuereturnId (int PK), use this instead:
                // .Where(detail => detail.IssuereturnId == issuereturnheader.Id)
                .ToListAsync();

            if (!issuereturndetailsFromDb.Any())
            {
                return NotFound("No details found in the database for the specified Issue Return. Cannot process an empty return.");
            }

            using (var transaction = await dbcontext.Database.BeginTransactionAsync())
            {



                try
                {

                    if (issuereturnheader.isregistered == 1)
                    {
                        await transaction.RollbackAsync();
                        return BadRequest("Issue Return is already registered.");
                    }
                    // 3. Update the header's status
                    issuereturnheader.isregistered = 1;
                    dbcontext.Issuereturn.Update(issuereturnheader);

                    // 4. Loop through the *database's own details* for this return.
                    // 'detailEntry' (from Issuereturndetails) now contains all necessary data.
                    foreach (var detailEntry in issuereturndetailsFromDb)
                    {
                        // --- TRACE THE ORIGINAL BILL OF ENTRY VIA issueNoteRef ---
                        string targetBillOfEntryNo = null;
                        DateTime? targetBillOfEntryDate = null;

                        // Step A: Find the corresponding record in IssuedetailsfromStock using issuedetailtblid
                        var issuedetailAndReservation = await (from ids in dbcontext.IssuedetailsfromStock // Your DbSet for IssuedetailsfromStock
                                                               join ir in dbcontext.Inventoryreservation // Your DbSet for InventoryReservation
                                                               on ids.rid equals ir.RId                  // Joining on the common 'rid' column
                                                               where ids.issuedetailid == detailEntry.issuedetailtblid
                                                               select new
                                                               {
                                                                   Issuedetail = ids,
                                                                   Reservation = ir // You can select the entire reservation object or specific properties
                                                               })
                                       .FirstOrDefaultAsync();

                        if (issuedetailAndReservation == null)
                        {
                            await transaction.RollbackAsync();
                            return BadRequest($"Original issuedetail (ID: {detailEntry.issuedetailtblid}) not found in 'IssuedetailsfromStock' for returned product {detailEntry.productid}. Data inconsistency detected.");
                        }

                        // Step B: Now, using the issuenoteref and productid from IssuedetailsfromStock,
                        // find the corresponding Bill of Entry from issuetracking.
                        // Given 'issuetracking' has issuenoteref and not issuedetailid,
                        // and assuming "issued first should be returned" principle:
                        // We find the OLDEST Bill of Entry associated with this specific product and issue note.
                        var originalIssueTrackingForBoE = await dbcontext.Issuetracking
                            .Where(it => it.issuenoteno == issuedetailAndReservation.Issuedetail.issuenoteref && // Link by issue note reference
                                         it.productid == issuedetailAndReservation.Issuedetail.itemid)                                // Ensure it was an issue transaction
                            .OrderBy(it => it.billofentrydate)                                // Order by date to get the oldest BoE
                            .FirstOrDefaultAsync();

                        if (originalIssueTrackingForBoE == null)
                        {
                            await transaction.RollbackAsync();
                            return BadRequest($"Original issue tracking record for issue note '{issuedetailAndReservation.Issuedetail.issuenoteref}' and product '{issuedetailAndReservation.Issuedetail.itemid}' not found. Cannot determine Bill of Entry.");
                        }

                        targetBillOfEntryNo = originalIssueTrackingForBoE.billofentryno;
                        targetBillOfEntryDate = originalIssueTrackingForBoE.billofentrydate;

                        // --- UPDATE INVENTORY (Stock On Hand) ---
                        // Find the existing lot in inventory using the *traced* Bill of Entry No.

                        // Create a new inventory record for this specific Bill of Entry.
                        // This happens if the original lot was fully depleted and now some is returned.
                        var newInventoryRecord = new Inventory
                        {
                            productid = detailEntry.productid,
                            batchid = 1, // Re-evaluate if this should be dynamic or derived
                            jobid = issuedetailAndReservation.Reservation.fromjobid, // Assuming 'fromjobid' is on Issuereturndetails
                            pono = 1,    // Re-evaluate if this should be dynamic
                            quantity = detailEntry.quantityreturned, // Use quantityreturned from Issuereturndetails
                            Entrydate = DateTime.UtcNow.Date, // This is the date of the return itself
                            uomid = detailEntry.iruomid, // Assuming 'iruomid' is on Issuereturndetails
                            invcurrencyid = detailEntry.ircurrencyid, // Assuming 'ircurrencyid' is on Issuereturndetails
                            invprice = detailEntry.irunitprice, // Assuming 'irunitprice' is on Issuereturndetails
                            type = "RETURN",
                            billofentryno = targetBillOfEntryNo,
                            billofentrydate = targetBillOfEntryDate
                        };
                        dbcontext.Inventory.Add(newInventoryRecord);


                        // 5. Save changes to ensure Inventory is updated and its 'invid' is available
                        await dbcontext.SaveChangesAsync();

                        // 6. Get the ID of the updated/added inventory record.
                        var inventoryRecordForTracking = await dbcontext.Inventory
                            .Where(inv => inv.productid == detailEntry.productid && inv.billofentryno == targetBillOfEntryNo)
                            .OrderByDescending(inv => inv.Entrydate) // In case multiple records match, get the most recent one (e.g., if a new one was just added)
                            .FirstOrDefaultAsync();

                        if (inventoryRecordForTracking == null)
                        {
                            await transaction.RollbackAsync();
                            return StatusCode(500, $"Failed to retrieve the associated inventory ID for Product ID {detailEntry.productid} with BoE {targetBillOfEntryNo} after return processing.");
                        }

                        // 7. Create Issue Return Tracking record
                        var issuetrack = new issuereturntracking
                        {
                            productid = detailEntry.productid,
                            jobid = issuedetailAndReservation.Reservation.fromjobid, // Assuming 'fromjobid' is on Issuereturndetails
                            issuereturnno = issuereturnheader.issuereturnref,
                            issuereturnqty = detailEntry.quantityreturned, // Use quantityreturned from Issuereturndetails
                            issuereturndate = DateTime.UtcNow.Date,
                            invid = inventoryRecordForTracking.invid, // Link to the inventory record that was updated/created
                            uomid = detailEntry.iruomid, // Assuming 'iruomid' is on Issuereturndetails
                            issuecurrencyid = detailEntry.ircurrencyid, // Assuming 'ircurrencyid' is on Issuereturndetails
                            issuereturnunitprice = detailEntry.irunitprice, // Assuming 'irunitprice' is on Issuereturndetails
                            billofentryno = targetBillOfEntryNo, // Store the traced BoE
                            billofentrydate = targetBillOfEntryDate // Store the traced BoE Date
                        };

                        dbcontext.issuereturntracking.Add(issuetrack);
                    } // End of foreach (var detailEntry in issuereturndetailsFromDb)

                    // 8. Save all new issuereturntracking records
                    await dbcontext.SaveChangesAsync();

                    // 9. Commit the transaction
                    await transaction.CommitAsync();

                    return Ok(new { Message = "Issue return registered and inventory updated successfully.", Success = true });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    // Log the full exception details (ex.Message, ex.InnerException, ex.StackTrace) for proper debugging
                    return StatusCode(500, $"An error occurred while processing your request: {ex.Message}. {(ex.InnerException != null ? "Inner Exception: " + ex.InnerException.Message : "")}");
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














        [HttpPost("Addtobomfromestimation")]
        public async Task<IActionResult> Addtobomfromestimation([FromBody] Addtobomfromestimationrv1 request)
        {
            if (request == null || string.IsNullOrEmpty(request.userid) || request.festimation == null || request.festimation.Count == 0)
            {
                return BadRequest("Invalid request data.");
            }

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

            using var transaction = await dbcontext.Database.BeginTransactionAsync();

            try
            {
                var estimationList = await dbcontext.estimation
                    .Where(e => request.festimation.Contains(e.estimationid) && e.isconvertedtobom == 0)
                    .ToListAsync();

                if (!estimationList.Any())
                {
                    return BadRequest("No new estimation records to process.");
                }

                foreach (var estimation in estimationList)
                {
                    // Insert new record into BOM table
                    var newBom = new Bom
                    {
                        bomrevno = estimation.revision,

                        itemid = estimation.itemid,
                        bomqty = estimation.quantity,
                        bomuomid = estimation.uomid,
                        price = estimation.price,
                        currencyid = estimation.currencyid,
                        jobid = estimation.jobid,
                        prodstageid = estimation.applicationid, // Mapping applicationid to prodstageid
                        bomstatus = 1, // Default status
                        prcreatedqty = 0, // Initially set to zero
                        bomnumber = 1 // Assuming default value
                    };

                    dbcontext.Bom.Add(newBom);

                    // Mark estimation as converted
                    estimation.isconvertedtobom = 1;
                }

                await dbcontext.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { message = "Estimation records successfully added to BOM." });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }























        [HttpPost("submitpr")]
        public async Task<IActionResult> SubmitPr(int prid)
        {
            using var transaction = await dbcontext.Database.BeginTransactionAsync();

            try
            {
                var pr = await dbcontext.PR.FirstOrDefaultAsync(p => p.PRID == prid);
                if (pr == null)
                {
                    return NotFound("PR not found.");
                }

                pr.prstatusid = 2;
                // Optional: track modified date

                await dbcontext.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { message = "PR status updated to 2" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // Optionally log ex here
                return StatusCode(500, "Error updating PR status.");
            }
        }







        [HttpPost("assign-roles")]
        public async Task<IActionResult> AssignRoles([FromBody] AssignRolesDto model)
        {
            var user = await userManager1.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound("User not found");



            // Assign new roles
            var result = await userManager1.AddToRolesAsync(user, model.Roles);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("Roles assigned successfully");
        }

        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            var roles = _roleManager.Roles.Select(r => new { r.Id, r.Name }).ToList();
            return Ok(roles);
        }


        [HttpGet("GetUserRolesperuser/{userId}")]
        public async Task<IActionResult> GetUserRolesperuser(string userId)
        {
            var user = await userManager1.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            var roles = await userManager1.GetRolesAsync(user);
            return Ok(roles); // returns List<string> of role names
        }



        [HttpPost("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleDto model)
        {
            var user = await userManager1.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound();

            if (model.Assign)
            {
                if (!await userManager1.IsInRoleAsync(user, model.RoleName))
                {
                    var result = await userManager1.AddToRoleAsync(user, model.RoleName);
                    if (!result.Succeeded)
                        return BadRequest(result.Errors);
                }
            }
            else
            {
                if (await userManager1.IsInRoleAsync(user, model.RoleName))
                {
                    var result = await userManager1.RemoveFromRoleAsync(user, model.RoleName);
                    if (!result.Succeeded)
                        return BadRequest(result.Errors);
                }
            }

            return Ok();
        }

        public class UpdateUserRoleDto
        {
            public string UserId { get; set; }
            public string RoleName { get; set; }
            public bool Assign { get; set; }
        }





        [HttpPost("RegisterRE")]
        public async Task<IActionResult> RegisterRE([FromBody] RegisterREclass request)
        {
            if (request == null || string.IsNullOrEmpty(request.UserId))
            {
                return Ok(new { Message = "Invalid request data: UserId is required.", Success = false });
            }

            var user = await userManager1.FindByIdAsync(request.UserId) ??
                       await userManager1.FindByEmailAsync(request.UserId);
            if (user == null)
            {
                return Ok(new { Message = "User not found.", Success = false });
            }

            var messages = new List<string>();
            bool allEntriesProcessedSuccessfully = true; // Track if all lines were processed without critical errors

            // --- FETCH RECEIVED HEADER ONCE OUTSIDE THE LOOP ---
            var receivedHeader = await dbcontext.ReceivedEntry
                .FirstOrDefaultAsync(rh => rh.REID == request.reno); // Use request.reno for the header

            if (receivedHeader == null)
            {
                return NotFound($"Received Entry header not found for REID: {request.reno}.");
            }

            if (receivedHeader.isregistered == 1)
            {
                return Ok(new { Message = $"Received Entry {request.reno} is already registered.", Success = false }); // Return early if already registered
            }

            using (var transaction = await dbcontext.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var entry in request.redetails)
                    {
                        var purchaseDetails = await dbcontext.Purchasedetails
                            .FirstOrDefaultAsync(pd => pd.potblid == entry.potblid);

                        if (purchaseDetails == null)
                        {
                            messages.Add($"Purchase details not found for potblid {entry.potblid}. This line item will be skipped.");
                            allEntriesProcessedSuccessfully = false; // Mark that not all lines were perfect
                            continue; // Skip to the next entry
                        }

                        // Validate quantity received
                        var totalAfterReceive = purchaseDetails.receivedentryqty + entry.receivedqty;
                        var maxAllowed = purchaseDetails.poquantity + purchaseDetails.insprejectedqty; // Assuming insprejectedqty is an allowance

                        if (totalAfterReceive > maxAllowed)
                        {
                            messages.Add($"Cannot receive {entry.receivedqty} for Product ID {purchaseDetails.poitemid} (PO Detail ID: {entry.potblid}) as it exceeds PO quantity + rejected allowance ({maxAllowed}). This line item will be skipped.");
                            allEntriesProcessedSuccessfully = false; // Mark that not all lines were perfect
                            continue; // Skip to the next entry
                        }

                        // ✅ All checks passed for this line item: update purchase details
                        purchaseDetails.receivedentryqty = totalAfterReceive;
                        // Mark the entity as modified so EF Core knows to update it
                        dbcontext.Purchasedetails.Update(purchaseDetails);

                        // Optionally, you might want to create a GRN tracking entry or similar here
                        // For example:
                        // var grnTracking = new GrnTracking
                        // {
                        //     PurchaseDetailId = purchaseDetails.potblid,
                        //     ReceivedQty = entry.receivedqty,
                        //     ReceivedDate = DateTime.UtcNow.Date,
                        //     // ... other fields like REID, UserId, etc.
                        // };
                        // dbcontext.GrnTracking.Add(grnTracking);
                    }

                    // --- AFTER PROCESSING ALL DETAIL LINES ---
                    // Mark the main ReceivedEntry header as registered
                    receivedHeader.isregistered = 1;
                    dbcontext.ReceivedEntry.Update(receivedHeader);

                    // Save all changes (PurchaseDetails updates, ReceivedEntry header update, and any new tracking entries)
                    await dbcontext.SaveChangesAsync();
                    await transaction.CommitAsync();

                    // Determine final success message
                    if (allEntriesProcessedSuccessfully)
                    {
                        return Ok(new { Message = "Received Entry and all line items registered and updated successfully.", Success = true });
                    }
                    else
                    {
                        // If some lines had issues but the header was registered, provide details.
                        messages.Insert(0, $"Received Entry {request.reno} registered, but some line items had validation issues.");
                        return Ok(new { Success = true, Messages = messages }); // Still Success=true if header registered, but with warnings
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    // Log the full exception for debugging purposes
                    // Console.WriteLine(ex.ToString());
                    return StatusCode(500, new { Success = false, Message = $"An error occurred while processing your request: {ex.Message}. {(ex.InnerException != null ? "Inner Exception: " + ex.InnerException.Message : "")}" });
                }
            }
        }
       
   




        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            var user = await userManager1.FindByEmailAsync(model.Email);
            if (user == null)
                return NotFound("User not found");
            var token = await userManager1.GeneratePasswordResetTokenAsync(user);

            // Optional: Encode token for use in URL
            var encodedToken = System.Net.WebUtility.UrlEncode(token);
            var result = await userManager1.ResetPasswordAsync(user, token, model.NewPassword);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { message = "Password has been reset successfully" });
        }


        public class ResetPasswordDto
        {
            public string Email { get; set; }
          
            public string NewPassword { get; set; }
        }

    }
}
