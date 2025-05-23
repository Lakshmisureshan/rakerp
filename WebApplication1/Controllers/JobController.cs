﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly ApplicationDBContext dbcontext;

        public JobController(ApplicationDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }



        [HttpGet("GetManufacturingBay")]
        public async Task<IActionResult> GetManufacturingBay()
        {
            var manufacturingbay = await dbcontext.ManufacturingBay.ToListAsync();
            return Ok(manufacturingbay);
        }
        [HttpGet("GetProjectCategory")]
        public async Task<IActionResult> GetProjectCategory()
        {
            var projectCategory = await dbcontext.ProjectCategory.ToListAsync();
            return Ok(projectCategory);
        }
        [HttpGet("GetQualityLevel")]
        public async Task<IActionResult> GetQualityLevel()
        {
            var qualitylevel = await dbcontext.QualityLevel.ToListAsync();
            return Ok(qualitylevel);
        }

        [HttpGet("GetCurrency")]
        public async Task<IActionResult> GetCurrency()
        {
            var Currency = await dbcontext.Currency.ToListAsync();
            return Ok(Currency);
        }

        [HttpGet("check-name")]
        public async Task<IActionResult> CheckNameExists(string name)
        {
            var exists =  await dbcontext.Customer.AnyAsync(c => c.Customername == name);
            return Ok(exists);
        }
        [HttpGet("GetLDApplicable")]
        public async Task<IActionResult> GetLDApplicable()
        {
            var IsLDA = await dbcontext.IsLDApplicable.ToListAsync();
            return Ok(IsLDA);
        }



        [HttpPost("AddJob")]
        public async Task<IActionResult> AddJob(AddJobDto request)
        {
            try
            {
                var job = new Job
                {
                    isldapplicable = request.isldapplicable,
                    customerid = request.customerid,
                    deliveryterms = request.deliveryterms,
                    currencyid = request.currencyid,
                    exchangerate = request.exchangerate,
                    jobdate = request.jobdate,
                    jobtypeid = request.jobtypeid,
                    ldpercent = request.ldpercent,
                    Jobid = request.Jobid,
                    lpono = request.lpono,
                    manufacturingbayid = request.manufacturingbayid,
                    lpodate = request.lpodate,
                    ordervalue = request.ordervalue,
                    ordervaluebasecurrency = request.ordervaluebasecurrency,
                    podeliverydate = request.podeliverydate,
                    totalnumber = request.totalnumber,
                    projectengineerid = request.projectengineerid,
                    projectmanagerid = request.projectmanagerid,
                    projectname = request.projectname,
                    paymentterms = request.paymentterms,
                    projectcategoryid = request.projectcategoryid,
                    qualitylevelid = request.qualitylevelid,
                    warrantyterms = request.warrantyterms,
                    enduserid = request.enduserid,
                    jobdescription = request.jobdescription,
                };

                await dbcontext.Job.AddAsync(job);
                await dbcontext.SaveChangesAsync();

                var response = new JobDto
                {
                    projectengineerid = job.projectengineerid,
                    projectmanagerid = job.projectmanagerid,
                    warrantyterms = job.warrantyterms,
                    qualitylevelid = job.qualitylevelid,
                    projectcategoryid = job.projectcategoryid,
                    paymentterms = job.paymentterms,
                    projectname = job.projectname,
                    currencyid = job.currencyid,
                    customerid = job.customerid,
                    deliveryterms = job.deliveryterms,
                    exchangerate = job.exchangerate,
                    isldapplicable = job.isldapplicable,
                    jobdate = job.jobdate,
                    jobtypeid = job.jobtypeid,
                    Jobid = job.Jobid,
                    lpono = job.lpono,
                    ldpercent = job.ldpercent,
                    lpodate = job.lpodate,
                    manufacturingbayid = job.manufacturingbayid,
                    ordervalue = job.ordervalue,
                    ordervaluebasecurrency = job.ordervaluebasecurrency,
                    podeliverydate = job.podeliverydate,
                    totalnumber = job.totalnumber
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework)
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }


        [HttpGet("GetAllJob")]
        public async Task<IActionResult> GetAllJob()
        {
            var jobs = await dbcontext.Job
      .Include(j => j.Customer). Include(t => t.JobType)
      .Include(t => t.ProjectEngineer)
      .ToListAsync();
            return Ok(jobs);
        }


        [HttpGet("GetAllcustomernames")]
        public async Task<IActionResult> GetAllcustomernames()
        {
      var customers = await dbcontext.Customer
    
      .ToListAsync();
       return Ok(customers);
        }

        [HttpGet("GetJobDetailsbyjobid")]
        public async Task<ActionResult<Job>> GetJobDetailsbyjobid(int jobId)
        {
            // Query the database for a job with the specified jobId
            var job = await dbcontext.Job
                            .Include(j => j.Customer)
                            .Include(j => j.JobType).
                            Include(j => j.ManufacturingBay).
                             Include(j => j.ProjectCategory).
                              Include(j => j.QualityLevel).
                              Include(j => j.Currency)
                            .SingleOrDefaultAsync(j => j.Jobid == jobId);

            // Check if the job was found
            if (job == null)
            {
                return NotFound(); // Return a 404 response if the job is not found
            }

            // Return the job details with a 200 OK response
            return Ok(job);
        }




    }
}
