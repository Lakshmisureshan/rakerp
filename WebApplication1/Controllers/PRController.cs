using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PRController : ControllerBase
    {
        private readonly ApplicationDBContext dbcontext;

        public PRController(ApplicationDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }



        [HttpGet("GetMaxPridAsync")]
        public async Task<int?> GetMaxPridAsync()
        {
            // Get the maximum PR ID from the PurchaseRequest table
            int maxPridPlusOne = (await dbcontext.PR.MaxAsync(pr => (int?)pr.PRID) ?? 1000) + 1;

            return maxPridPlusOne;
        }







        [HttpPost("AddPrheader")]
        public async Task<IActionResult> AddPrheader(AddPrDto request)
        {
            try
            {
                var pr = new PR
                {
                    jobid = request.jobid,
                    Prdate = request.Prdate,
                    PRID = request.PRID,
                    remarks = request.remarks,
                    prcreatedbyid =request.prcreatedbyid
                };

                await dbcontext.PR.AddAsync(pr);
                await dbcontext.SaveChangesAsync();

                var response = new PrDto
                {
                    remarks = pr.remarks,
                    PRID = pr.PRID,
                    jobid = request.jobid,
                    Prdate = request.Prdate,
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // e.g., logger.LogError(ex, "An error occurred while adding PR header");

                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }





        [HttpPost("AddPrDetails")]
        public async Task<IActionResult> AddPrDetails(AddPrdetails request)
        {
            // Step 1: Create and add the PRDetails entity
            var prdetails = new PRDetails
            {
                bomid = request.bomid,
                prid = request.prid,
                pritemid = request.pritemid,
                prqty = request.prqty,
                pruomid=request.pruomid


            };

            await dbcontext.PRDetails.AddAsync(prdetails);

            // Step 2: Retrieve the corresponding BOM record
            var bom = await dbcontext.Bom.FindAsync(request.bomid);

            if (bom == null)
            {
                return NotFound(new { Message = "BOM not found" });
            }

            // Step 3: Update the BOM quantity
            bom.prcreatedqty = request.prqty; // Assuming bomqty is the field you want to update

            // Step 4: Save changes to both PRDetails and BOM table
            await dbcontext.SaveChangesAsync();

            // Step 5: Prepare the response DTO
            var response = new PrdetailsDto
            {
                bomid = prdetails.bomid,
                prid = prdetails.prid,
                prqty = prdetails.prqty,
                pritemid = prdetails.pritemid,
            };

            return Ok(response);
        }











    




        [HttpGet("GetPRheader")]
        public async Task<IActionResult> GetPRheader()
        {
            var prheader = await (from pr1 in dbcontext.PR
                                   join ps in dbcontext.PRstatus on pr1.prstatusid equals ps.prstatusid
                                   join jj in dbcontext.Job on pr1.jobid equals jj.Jobid
                              
                                  select new
                            {
                               pr1.PRID,
                            
                               pr1.jobid,
                               pr1.Prdate,
                               pr1.PRstatus,
                               ps.prstatusid,
                               jj.projectname,
                               pr1.prverificationdate,
                               pr1.verifiedbyid,
                               pr1.verifiedby,
                               pr1.prcreatedby,
                               pr1.prcreatedbyid
                              
                             

                               
                            }).ToListAsync();

            // Apply multiple conditions
            if (prheader == null)
            {
                return NotFound("PR  not found");
            }
            return Ok(prheader);
        }




        [HttpGet("GetAllprstatus")]
        public async Task<IActionResult> GetAllprstatus()
        {
            var prstatus = await (from pr1 in dbcontext.PRstatus
                               
                                  select new
                                  {
                                      pr1.prstatusid,

                                      pr1.prstatusname,
                                  
                                  }).ToListAsync();
            // Apply multiple conditions
            if (prstatus == null)
            {
                return NotFound("PR  not found");
            }
            return Ok(prstatus);
        }

    }
}
