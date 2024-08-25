using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTypeController : ControllerBase
    {
        private readonly ApplicationDBContext dbcontext;

        public JobTypeController(ApplicationDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
      

        [HttpPost]
        public async Task<IActionResult> CreateJobType(AddJobType request)
        {
            var jobtype = new JobType
            {
               JobtypeName= request.JobtypeName,    
            };
            await dbcontext.JobType.AddAsync(jobtype);
            await dbcontext.SaveChangesAsync();
            var response = new JobTypeDto
            {
                jobtypeid = jobtype.jobtypeid,
                JobtypeName = jobtype.JobtypeName, 
            };

            return Ok(response);
        }


        [HttpGet("GetJobType")]
        public async Task<IActionResult> GetJobTypes()
        {
            var jobTypes = await dbcontext.JobType.ToListAsync();
            return Ok(jobTypes);
        }



    }
}
