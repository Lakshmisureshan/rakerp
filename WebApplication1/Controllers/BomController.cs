using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BomController : ControllerBase
    {
        private readonly ApplicationDBContext dbcontext;
        public BomController(ApplicationDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }



        [HttpGet("GetProductionStages")]
      
        public async Task<IActionResult> GetProductionStages()
        {
            var stages = await dbcontext.ProductionStages.ToListAsync();
            return Ok(stages);
        }

        [HttpGet("GetAllUom")]
        public async Task<IActionResult> GetAllUom()
        {
            var uom = await dbcontext.UOM.ToListAsync();
            return Ok(uom);
        }



        [HttpGet("GetUomByProductId/{productId}")]
        public async Task<IActionResult> GetUomByProductId(int productId)
        {
            var product = await dbcontext.Product
                                         .Where(p => p.productcode == productId)
                                         .Select(p => new {
                                             p.standarduomid
                                         })
                                         .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product.standarduomid);
        }





       
     



        [HttpPost("AddBom")]
        public async Task<IActionResult> AddBom(AddBomDto request)
        {
            var bom = new Bom
            {
             currencyid = request.currencyid,
             bomqty = request.bomqty,
             bomuomid = request.bomuomid,   
             itemid = request.itemid    ,
             prodstageid = request.prodstageid ,
             RequiredDate = request.RequiredDate    ,
             price= request.price ,
             jobid = request.jobid ,    
             bomrevno= request.bomrevno

            };
            await dbcontext.Bom.AddAsync(bom);
            await dbcontext.SaveChangesAsync();
            var response = new bomdto
            {
               price = request.price,
               RequiredDate = request.RequiredDate,
               prodstageid=request.prodstageid,
               itemid=request.itemid ,
               bomuomid=request.bomuomid,
               bomqty=request.bomqty,
               currencyid=request.currencyid,
               bomid = request.bomid ,
              jobid = request.jobid    

            };

            return Ok(response);
        }

        [HttpGet("GetAllBOMbyJobid")]
        public async Task<IActionResult> GetAllBOMbyJobid(int jobid)
        {
            var bom = await dbcontext.Bom
    .Include(b => b.UOM) 
     .Include(b => b.Product).
    Include(c=>c.currency)// Eager load the UOM related entity
    .Where(p => p.jobid == jobid)
    .ToListAsync();

            if (bom == null )
            {
                return NotFound("Bom  not found");
            }
            return Ok(bom);
        }

        [HttpPost("FreezeBom")]
        public async Task<IActionResult> FreezeJobAsync(int jobid)
        {
            // Retrieve the job based on job ID
            var job = await dbcontext.Job
                .FirstOrDefaultAsync(j => j.Jobid == jobid);

            if (job == null)
            {
                // Return a NotFound result if the job is not found
                return NotFound($"Job with ID {jobid} not found.");
            }

            var boms = await dbcontext.Bom
                .Where(b => b.jobid == jobid)
                .ToListAsync();

            foreach (var bom in boms)
            {
                bom.bomstatus = 1;  // Set bomstatus to 1
            }

            // Increment the revision number in the job table
            job.bomjobrevno += 1;

            // Set the job status to frozen (assuming 1 means frozen)
            job.bomjobstatusid = 1;

            try
            {
                // Save the changes to the database
                await dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during save
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            // Return a success result with JSON response
            return Ok(new { message = "Job has been frozen successfully", jobid });
        }

        [HttpGet("IsJobFrozenAsync")]
        public async Task<bool> IsJobFrozenAsync(int jobid)
        
        {
            // Retrieve the job status
            var job = await dbcontext.Job
                .Where(j => j.Jobid == jobid)
                .Select(j => new { j.bomjobstatusid })
                .FirstOrDefaultAsync();

            // Check if job is null
            if (job == null)
            {
                // Handle the case where the job is not found
                // For example, you can return false or throw an exception if desired
                return false; // Assuming that if the job is not found, it's not frozen
            }

            // Return true if the job status indicates that it's frozen (status = 1)
            return job.bomjobstatusid==1;
        }


        [HttpGet("GetLastBomRev")]
        public async Task<int> GetLastBomRev(int jobid)

        {
            // Retrieve the job status
            var job = await dbcontext.Job
                .Where(j => j.Jobid == jobid)
                .Select(j => new { j.bomjobrevno })
                .FirstOrDefaultAsync();

            // Check if job is null
            if (job == null)
            {
                // Handle the case where the job is not found
                // For example, you can return false or throw an exception if desired
                return 0; // Assuming that if the job is not found, it's not frozen
            }

            // Return true if the job status indicates that it's frozen (status = 1)
            return job.bomjobrevno;
        }













        [HttpPost("UnFreezeBom")]
        public async Task<IActionResult> UnFreezeBom(int jobid)
        {
            // Retrieve the job based on job ID
            var job = await dbcontext.Job
                .FirstOrDefaultAsync(j => j.Jobid == jobid);

            if (job == null)
            {
                // Return a NotFound result if the job is not found
                return NotFound($"Job with ID {jobid} not found.");
            }
       

         
            // Increment the revision number in the job table
            job.bomjobstatusid =0;
;

            try
            {
                // Save the changes to the database
                await dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during save
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            // Return a success result
            return Ok(new { message = "Job has been Un frozen successfully", jobid });
        }












        [HttpGet("GetAllbombybudgetheaderid")]
        public async Task<IActionResult> GetAllbombybudgetheaderid(int jobid)
        {
            var query = from t1 in dbcontext.Bom
                        join t2 in dbcontext.Product on t1.itemid equals t2.itemid
                        where t1.jobid == jobid && t1.bomstatus == 1
                        group t1 by new { t2.itembudgetheaderid } into g
                        select new
                        {
                            budgetheaderid = g.Key.itembudgetheaderid,
                            TotalPrice = g.Sum(x => x.price) // Summing the price from t1 (Bom)
                        };

            var result = await query.ToListAsync();

            return Ok(result);
        }



        [HttpGet("GetPRDetailsbyPRID")]
        public async Task<ActionResult<PR>> GetPRDetailsbyPRID(int prid)
        {
            // Query the database for a job with the specified jobId
            var pr = await dbcontext.PR
                                  .Include(p => p.verifiedby) // Include the related ApplicationUser
                                  .SingleOrDefaultAsync(j => j.PRID == prid);

            // Check if the job was found
            if (pr == null)
            {
                return NotFound(); // Return a 404 response if the job is not found
            }

            // Return the job details with a 200 OK response
            return Ok(pr);
        }



        [HttpGet("GetPRlineDetailsbyPRID")]
        public async Task<ActionResult> GetPRlineDetailsbyPRID(int prid)
        {
            try
            {
                var prdetails = await dbcontext.PRDetails.Include(i=>i.Product)
                    .Include(i => i.Bom)
                                              .Where(pr => pr.prid == prid)
                                              .ToListAsync();

                if (prdetails == null || prdetails.Count == 0)
                {
                    return NotFound();
                }

                return Ok(prdetails);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, ex.Message);
            }
        }












        [HttpDelete("DeleteBom/{bomid}")]
        public async Task<IActionResult> DeleteBom(int bomid)
        {
            // Find the BOM by ID
            var bom = await dbcontext.Bom
                            .Where(b => b.bomid == bomid)
                            .FirstOrDefaultAsync();
            if (bom == null)
            {
                return NotFound();
            }

            // Remove the BOM from the database
            dbcontext.Bom.Remove(bom);
            await dbcontext.SaveChangesAsync();

            return NoContent();
        }










        [HttpDelete("DeletePrdetails/{prtblid}")]
        public async Task<IActionResult> DeletePrdetails(int prtblid)
        {
        // Find the BOM by ID
            var prdetails = await dbcontext.PRDetails
         .FirstOrDefaultAsync(pr => pr.prtblid == prtblid);
            if (prdetails == null)
            {
                return NotFound();
            }

            var bom = await dbcontext.Bom.FirstOrDefaultAsync(b => b.bomid == prdetails.bomid);
            if (bom != null)
            {
                // Update the BOM quantity
                bom.prcreatedqty -= prdetails.prqty; // Adjust the quantity update logic as per your requirement
                dbcontext.Bom.Update(bom);
            }




            // Remove the BOM from the database
            dbcontext.PRDetails.Remove(prdetails);
            await dbcontext.SaveChangesAsync();

            return NoContent();
        }






        [HttpPut("UpdatePRAsync")]

        public async Task<updateprdto> UpdatePRAsync(int prId, updateprdto pr)
        {
            var existingPr = await dbcontext.PR.FindAsync(prId);
            if (existingPr == null)
            {
                throw new KeyNotFoundException("PR not found.");
            }

            existingPr.Prdate = pr.Prdate;
            existingPr.remarks = pr.remarks;
          

            dbcontext.PR.Update(existingPr);
            await dbcontext.SaveChangesAsync();

            return pr;
        }













        [HttpPost("update-status")]
        public async Task<IActionResult> UpdatePrStatus(int prid)
        {
            // Find the existing PR by its ID
            var existingPr = await dbcontext.PR.FindAsync(prid);

            // Check if the PR exists
            if (existingPr == null)
            {
                // Return a NotFound response if the PR does not exist
                return NotFound(new { Message = "PR not found." });
            }

            // Update the prstatusid to 2
            existingPr.prstatusid = 2;

            // Save the changes to the database
            try
            {
                await dbcontext.SaveChangesAsync();
                // Return an Ok response indicating success
                return Ok(new { Message = "PR status updated successfully." });
            }
            catch (Exception ex)
            {
                // Handle potential errors and return an error response
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating the PR status.", Error = ex.Message });
            }
        }




        [HttpGet("IsJobFrozenbom2Async")]
        public async Task<bool> IsJobFrozenbom2Async(int jobid)

        {
            // Retrieve the job status
            var job = await dbcontext.Job
                .Where(j => j.Jobid == jobid)
                .Select(j => new { j.bomjobstatusid2 })
                .FirstOrDefaultAsync();

            // Check if job is null
            if (job == null)
            {
                // Handle the case where the job is not found
                // For example, you can return false or throw an exception if desired
                return false; // Assuming that if the job is not found, it's not frozen
            }

            // Return true if the job status indicates that it's frozen (status = 1)
            return job.bomjobstatusid2 == 1;
        }













        [HttpGet("GetLastBomRevbom2")]
        public async Task<int> GetLastBomRevbom2(int jobid)

        {
            // Retrieve the job status
            var job = await dbcontext.Job
                .Where(j => j.Jobid == jobid)
                .Select(j => new { j.bomjobrevno2 })
                .FirstOrDefaultAsync();

            // Check if job is null
            if (job == null)
            {
                // Handle the case where the job is not found
                // For example, you can return false or throw an exception if desired
                return 0; // Assuming that if the job is not found, it's not frozen
            }

            // Return true if the job status indicates that it's frozen (status = 1)
            return job.bomjobrevno2;
        }







        public class AddorUpdateBomDetails
        {
            public ICollection<Addbomdetails> bomdetails { get; set; }
        }











        [HttpPost("Addorupdatebomdetails")]
        public async Task<IActionResult> Addorupdatebomdetails(AddorUpdateBomDetails dto)
        {
            try
            {
           

                // Insert or update details
                foreach (var item in dto.bomdetails)
                {
                    var detail = new Bom
                    {


                        currencyid = item.currencyid,
                        bomqty = item.bomqty,
                        bomuomid = item.bomuomid,
                        itemid = item.itemid,
                        prodstageid = item.prodstageid,
                        RequiredDate = item.requireddate,
                        price = item.price,
                        jobid = item.jobid,
                        bomrevno = item.bomrevno,
                        bomnumber=item.bomnumber

                    };

                    await dbcontext.Bom.AddAsync(detail);

























                }

                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Bom saved successfully!" });
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                // Log.Error(ex, "An error occurred while processing the received entry details.");

                // Return a generic error message to the client
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }


























        }










        [HttpGet("getAllBom2byJobId")]
        public async Task<IActionResult> getAllBom2byJobId(int jobid, int bomnumber)
        {
            var bom = await dbcontext.Bom
                .Include(b => b.UOM)
                .Include(b => b.Product)
                .Include(c => c.currency) // Eager load the UOM related entity
                .Where(p => p.jobid == jobid && p.bomnumber == bomnumber)
                .OrderBy(b => b.bomrevno) // Order by revision field
                .ToListAsync();

            if (bom == null || bom.Count == 0)
            {
                return NotFound("Bom not found");
            }
            return Ok(bom);
        }





        [HttpPost("FreezeBom2")]
        public async Task<IActionResult> FreezeBom2(int jobid)
        {
            // Retrieve the job based on job ID
            var job = await dbcontext.Job
                .FirstOrDefaultAsync(j => j.Jobid == jobid);

            if (job == null)
            {
                // Return a NotFound result if the job is not found
                return NotFound($"Job with ID {jobid} not found.");
            }

            var boms = await dbcontext.Bom
                .Where(b => b.jobid == jobid && b.bomnumber ==2)
                .ToListAsync();

            foreach (var bom in boms)
            {
                bom.bomstatus = 1;  // Set bomstatus to 1
            }

            // Increment the revision number in the job table
            job.bomjobrevno2 += 1;

            // Set the job status to frozen (assuming 1 means frozen)
            job.bomjobstatusid2 = 1;

            try
            {
                // Save the changes to the database
                await dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during save
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            // Return a success result with JSON response
            return Ok(new { message = "Job has been frozen successfully", jobid });
        }




        [HttpPost("UnFreezeBom2")]
        public async Task<IActionResult> UnFreezeBom2(int jobid)
        {
            // Retrieve the job based on job ID
            var job = await dbcontext.Job
                .FirstOrDefaultAsync(j => j.Jobid == jobid);

            if (job == null)
            {
                // Return a NotFound result if the job is not found
                return NotFound($"Job with ID {jobid} not found.");
            }



            // Increment the revision number in the job table
            job.bomjobstatusid2 = 0;
            ;

            try
            {
                // Save the changes to the database
                await dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during save
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            // Return a success result
            return Ok(new { message = "Job has been Un frozen successfully", jobid });
        }



        [HttpGet("GetProductbybudgetheaderid/{budgetheaderid}")]
        public async Task<IActionResult> GetProductbybudgetheaderid(int budgetheaderid)
        {
            var product = await dbcontext.Product
                                         .Where(p => p.itembudgetheaderid == budgetheaderid)

                                         .ToListAsync();

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

















        [HttpGet("GetFreezedBombyjobidprnotcreated/{jobid}")]
        public async Task<IActionResult> GetFreezedBombyjobidprnotcreated(int jobid)
        {
            var bom = await dbcontext.Bom
     .Include(b => b.UOM)
     .Include(b => b.Product).Include(b => b.UOM).Include(b => b.currency)
     // Eager load the UOM related entity
     .Where(p => p.jobid == jobid
                 && p.bomqty > p.prcreatedqty
                 && p.bomstatus == 1) // Apply multiple conditions
     .ToListAsync();

            if (bom == null)
            {
                return NotFound("Bom  not found");
            }
            return Ok(bom);

        }



        //[HttpGet("GetBudgetSummary")]

        //public List<BudgetSummary> GetBudgetSummary(int jobId)
        //{
        //    List<BudgetSummary> budgetSummaries = new List<BudgetSummary>();

        //    using (SqlConnection conn = new SqlConnection(_connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("sp_GetBudgetSummary", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@jobid", jobId);

        //            conn.Open();
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    budgetSummaries.Add(new BudgetSummary
        //                    {
        //                        BudgetHeadName = reader["budgetheadername"].ToString(),
        //                        BudgetHeaderId = Convert.ToInt32(reader["BudgetHeaderId"]),
        //                        JobId = Convert.ToInt32(reader["jobid"]),
        //                        Amount = Convert.ToDecimal(reader["Amount"])
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    return budgetSummaries;
        //}




        [HttpPost("UnFreezeBom3")]
        public async Task<IActionResult> UnFreezeBom3(int jobid)
        {
            // Retrieve the job based on job ID
            var job = await dbcontext.Job
                .FirstOrDefaultAsync(j => j.Jobid == jobid);

            if (job == null)
            {
                // Return a NotFound result if the job is not found
                return NotFound($"Job with ID {jobid} not found.");
            }



            // Increment the revision number in the job table
            job.bomjobstatusid3 = 0;
            ;

            try
            {
                // Save the changes to the database
                await dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during save
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            // Return a success result
            return Ok(new { message = "Job has been Un frozen successfully", jobid });
        }




        [HttpPost("FreezeBom3")]
        public async Task<IActionResult> FreezeBom3(int jobid)
        {
            // Retrieve the job based on job ID
            var job = await dbcontext.Job
                .FirstOrDefaultAsync(j => j.Jobid == jobid);

            if (job == null)
            {
                // Return a NotFound result if the job is not found
                return NotFound($"Job with ID {jobid} not found.");
            }

            var boms = await dbcontext.Bom
                .Where(b => b.jobid == jobid && b.bomnumber == 3)
                .ToListAsync();

            foreach (var bom in boms)
            {
                bom.bomstatus = 1;  // Set bomstatus to 1
            }

            // Increment the revision number in the job table
            job.bomjobrevno3 += 1;

            // Set the job status to frozen (assuming 1 means frozen)
            job.bomjobstatusid3 = 1;

            try
            {
                // Save the changes to the database
                await dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during save
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            // Return a success result with JSON response
            return Ok(new { message = "Job has been frozen successfully", jobid });
        }









        [HttpGet("IsJobFrozenbom3Async")]
        public async Task<bool> IsJobFrozenbom3Async(int jobid)

        {
            // Retrieve the job status
            var job = await dbcontext.Job
                .Where(j => j.Jobid == jobid)
                .Select(j => new { j.bomjobstatusid3 })
                .FirstOrDefaultAsync();

            // Check if job is null
            if (job == null)
            {
                // Handle the case where the job is not found
                // For example, you can return false or throw an exception if desired
                return false; // Assuming that if the job is not found, it's not frozen
            }

            // Return true if the job status indicates that it's frozen (status = 1)
            return job.bomjobstatusid3 == 1;
        }





        [HttpGet("GetLastBomRevbom3")]
        public async Task<int> GetLastBomRevbom3(int jobid)

        {
            // Retrieve the job status
            var job = await dbcontext.Job
                .Where(j => j.Jobid == jobid)
                .Select(j => new { j.bomjobrevno3 })
                .FirstOrDefaultAsync();

            // Check if job is null
            if (job == null)
            {
                // Handle the case where the job is not found
                // For example, you can return false or throw an exception if desired
                return 0; // Assuming that if the job is not found, it's not frozen
            }

            // Return true if the job status indicates that it's frozen (status = 1)
            return job.bomjobrevno3;
        }



        [HttpGet("getAllBom3byJobId")]
        public async Task<IActionResult> getAllBom3byJobId(int jobid, int bomnumber)
        {
            var bom = await dbcontext.Bom
                .Include(b => b.UOM)
                .Include(b => b.Product)
                .Include(c => c.currency) // Eager load the UOM related entity
                .Where(p => p.jobid == jobid && p.bomnumber == bomnumber)
                .OrderBy(b => b.bomrevno) // Order by revision field
                .ToListAsync();

            if (bom == null || bom.Count == 0)
            {
                return NotFound("Bom not found");
            }
            return Ok(bom);
        }



















    }
}
