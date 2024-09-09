using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Migrations;
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
                                         .Where(p => p.itemid == productId)
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
    .Include(b => b.UOM)  // Eager load the UOM related entity
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

            // Return a success result
            return Ok("Job has been frozen successfully.");
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
            return Ok("Job has been Un frozen successfully.");
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
            var PR = await dbcontext.PR
                            .SingleOrDefaultAsync(j => j.PRID == prid);

            // Check if the job was found
            if (PR == null)
            {
                return NotFound(); // Return a 404 response if the job is not found
            }

            // Return the job details with a 200 OK response
            return Ok(PR);
        }



        [HttpGet("GetPRlineDetailsbyPRID")]
        public async Task<ActionResult<PRDetails>> GetPRlineDetailsbyPRID(int prid)
        {
            try
            {
                var prdetails = await dbcontext.PRDetails.Include(i=>i.Product)
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


    }
}
