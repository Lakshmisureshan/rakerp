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

        [HttpGet("GetNextJobNoAsync")]
        public async Task<int> GetNextJobNoAsync(int jobTypeId)
        {
            // Retrieve the maximum job number for the specified job type
            var maxJobNo = await dbcontext.Job
                .Where(j => j.jobtypeid == jobTypeId)
                .MaxAsync(j => (int?)j.Jobid);

            // Define default values based on job type
            int defaultJobNo = GetDefaultJobNoForType(jobTypeId);

            return (maxJobNo ?? defaultJobNo) + 1; // Increment maxJobNo or use default if maxJobNo is null
        }



        [HttpGet("GetAllJobNosbyCustomerid")]
        public async Task<IActionResult> GetAllJobNosbyCustomerid(int customerid)
        {
            // Retrieve the maximum job number for the specified job type
            var jobdetails = await dbcontext.Job
       .Where(j => j.customerid == customerid && j.jobtypeid != 4 && j.jobtypeid != 7)
       .ToListAsync();


            return Ok(jobdetails);// Increment maxJobNo or use default if maxJobNo is null
        }









        private int GetDefaultJobNoForType(int jobTypeId)
        {
            // You can use a switch case or a dictionary for mapping
            return jobTypeId switch
            {
                1 => 300000, // Example default value for job type 1
                2 => 600000, // Example default value for job type 2
               5 => 700000, // Example default value for job type 3
                4 => 400000,
                6 => 800000,
                7 => 900000,
                3 => 500000,
                // Default value for other job types
            };
        }



















    }
}
