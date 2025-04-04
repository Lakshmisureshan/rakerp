using Microsoft.AspNetCore.Http;
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
                //Ensure podeliverydate is not null
                //if (request.podeliverydate == null)
                //{
                //    request.podeliverydate = DateTime.MinValue; // Assign default value
                //}

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
                    qualitylevelid = request.qualitylevelid == 0 ? null : request.qualitylevelid,
                    projectcategoryid = request.projectcategoryid == 0 ? null : request.projectcategoryid,
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
                    qualitylevelid = job.qualitylevelid == 0 ? null : job.qualitylevelid,
                    projectcategoryid = job.projectcategoryid == 0 ? null : job.projectcategoryid,
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
                // Log the exception (consider using ILogger for better logging)
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
        public async Task<ActionResult> GetJobDetailsbyjobid(int jobId)
        {
            // Query the database for a job with the specified jobId
            var job = await dbcontext.Job
                .Include(j => j.Customer)
                .Include(j => j.JobType)
                .Include(j => j.ManufacturingBay)
                .Include(j => j.ProjectCategory)
                .Include(j => j.QualityLevel)
                .Include(j => j.Currency)
                .Include(j => j.ProjectEngineer)
                .Include(j => j.ProjectManager)
                .SingleOrDefaultAsync(j => j.Jobid == jobId);

            // Check if the job was found
            if (job == null)
            {
                return NotFound(new { Message = "Job not found", JobId = jobId });
            }

            // Return the job details with a 200 OK response
            var response = new
            {
                jobid = job.Jobid,
                Customer = job.Customer,
                JobType = job.JobType,
                ManufacturingBay = job.ManufacturingBay != null
                    ? new ManufacturingBayDto
                    {
                        BayId = job.ManufacturingBay.BayId,
                        BayName = job.ManufacturingBay.BayName
                    }
                    : null,
                ProjectCategory = job.ProjectCategory != null
                    ? new ProjectCategory
                    {
                        projectcategoryid = job.ProjectCategory.projectcategoryid,
                        projectcategoryname = job.ProjectCategory.projectcategoryname
                    }
                    : null,
                QualityLevel = job.QualityLevel != null
                    ? new QualityLevel
                    {
                        qualitylevelid = job.QualityLevel.qualitylevelid,
                        qualitylevelname = job.QualityLevel.qualitylevelname
                    }
                    : null,
                Currency = job.Currency,
                jobdate = job.jobdate,
                podeliverydate = job.podeliverydate, // No need for '?? null', it's redundant
                projectname = job.projectname ?? "No Name Assigned",
                ordervalue = job.ordervalue,
                exchangerate = job.exchangerate,
                isldapplicable = job.isldapplicable,
                ordervaluebasecurrency = job.ordervaluebasecurrency,
                totalnumber = job.totalnumber,
                paymentterms = job.paymentterms ?? "N/A",
                warrantyterms = job.warrantyterms ?? "N/A",
                deliveryterms = job.deliveryterms ?? "N/A",
                jobdescription = job.jobdescription ?? "No description provided",
                ProjectEngineer = job.ProjectEngineer,
                ProjectManager = job.ProjectManager
            };

            return Ok(response);
        }
        [HttpGet("GetJobFiles/{jobNo}")]
        public IActionResult GetJobFiles(string jobNo)
        {
            var jobFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "JobLPO", jobNo);

            if (!Directory.Exists(jobFolderPath))
            {
                return NotFound("Job folder not found.");
            }

            var files = Directory.GetFiles(jobFolderPath)
                                 .Select(Path.GetFileName)
                                 .ToList();

            if (files.Count == 0)
            {
                return NotFound("No files found in this job folder.");
            }

            return Ok(files);
        }

        [HttpGet("DownloadJobFile/{jobNo}/{fileName}")]
        public IActionResult DownloadJobFile(string jobNo, string fileName)
        {
            var jobFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "JobLPO", jobNo);
            var filePath = Path.Combine(jobFolderPath, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", fileName);
        }

















        [HttpGet("GetJobFile/{jobNo}")]
        public IActionResult GetJobFile(string jobNo)
        {
            var jobFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "JobLPO", jobNo);

            if (!Directory.Exists(jobFolderPath))
            {
                return NotFound("Job folder not found.");
            }

            var files = Directory.GetFiles(jobFolderPath, "*.pdf"); // Fetch only PDF files

            if (files.Length == 0)
            {
                return NotFound("No PDF file found in the job folder.");
            }

            var filePath = files[0]; // Get the first file
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var fileName = Path.GetFileName(filePath);

            return File(fileBytes, "application/pdf", fileName);
        }

    }
}
