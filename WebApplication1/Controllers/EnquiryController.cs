using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class EnquiryController : Controller
    {

        private readonly ApplicationDBContext dbcontext;

        public EnquiryController(ApplicationDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }







        [HttpPost("addenquiry")]
        public async Task<IActionResult> addenquiry(Addenquiry request)
        {
            try
            {
                bool isNewEnquiry = false; // Flag to determine if it's a new job or an update
                Enquiry enquiryToProcess; // This will hold either the existing or new job entity

                // Check if a job with the same Jobid already exists
                var existingEnquiry = await dbcontext.Enquiry
                                               .FirstOrDefaultAsync(j => j.Enquiryref == request.Enquiryref);

                if (existingEnquiry != null)
                {
                    // Update the existing job
                    enquiryToProcess = existingEnquiry; // Assign existing job to process
                    enquiryToProcess.customerid = request.customerid;
                    enquiryToProcess.customercontactid = request.customercontactid;
                    enquiryToProcess.projectmanagerid = request.projectmanagerid;
                    enquiryToProcess.projectengineerid = request.projectengineerid;
                    //existingJob.currencyid = request.currencyid; // Un-comment if needed
                    //existingJob.exchangerate = request.exchangerate; // Un-comment if needed
                    enquiryToProcess.enquirytypeid = request.enquirytypeid;
                    enquiryToProcess.remarks = request.remarks;
              
                    //existingJob.vatpercent = request.vatpercent; // Un-comment if needed
                    //existingJob.ordervaluewithvat = request.ordervaluewithvat; // Un-comment if needed

                    // Mark the entity as modified (Entity Framework will track changes)
                    dbcontext.Enquiry.Update(enquiryToProcess);
                    isNewEnquiry = false; // It's an update
                }
                else
                {
                    // If the job does not exist, create a new one
                    enquiryToProcess = new Enquiry
                    {

                        Enquiryref = request.Enquiryref,
                      customerid = request.customerid,
                customercontactid = request.customercontactid,
                    projectmanagerid = request.projectmanagerid,
              projectengineerid = request.projectengineerid,

                    //existingJob.currencyid = request.currencyid; // Un-comment if needed
                    //existingJob.exchangerate = request.exchangerate; // Un-comment if needed
                    enquirytypeid = request.enquirytypeid,
                  remarks = request.remarks,

                        enquirydate = request.enquirydate,  
                    };

                    await dbcontext.Enquiry.AddAsync(enquiryToProcess);
                    isNewEnquiry = true; // It's a new job
                }

                // Save changes to the Job table first
                // This is important because if it's a new job, the jobToProcess.Id (primary key)
                // will be populated *after* SaveChangesAsync().
                await dbcontext.SaveChangesAsync();

                // --- Page Tracking Logic ---
                var pageTrackEntry = new Trackpage
                {
                    // Assuming 'Job Entry' or 'Job Update' as the page name
                    pagename = isNewEnquiry ? "New EnquiryRegistration" : "Enquiry Update",
                    docno = request.Enquiryref.ToString(), // Use the Jobid as the document number
                    createddate = DateTime.UtcNow, // Use UTC for consistency
                                                   // Get the current user's ID/username
                    createdbyuser = request.userid.ToString() // Placeholder: Replace with actual user ID/name
                                                              // If you have authentication:
                                                              // createdbyuser = User.Identity.Name ?? "Anonymous"
                                                              // or if injecting IHttpContextAccessor:
                                                              // createdbyuser = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Anonymous"
                };

                await dbcontext.Trackpage.AddAsync(pageTrackEntry);
                await dbcontext.SaveChangesAsync(); // Save the page track entry

                // Prepare the response DTO
                return Ok(new { Message = "Enquiry details and page track saved successfully.", enquiryid = enquiryToProcess.Enquiryref });
            }
            catch (Exception ex)
            {
                // Log the exception (consider using ILogger for better logging)
                // e.g., _logger.LogError(ex, "Error in AddJob for Jobid: {JobId}", request.Jobid);
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }





        [HttpGet("listenquiry")]
        public async Task<IActionResult> Getallenquiries()
        {
            var listenquiry = await dbcontext.Enquiry
                .Include(e => e.Customer)

                .Include(t => t.ProjectEngineer)
        .Include(t => t.ProjectManager)
             .Include(t => t.Enquirytype)
                // <-- This line includes the Customer data
                .ToListAsync();

            return Ok(listenquiry);
        }


        [HttpGet("GetEnquirydetailsbyenquiryno")]
        public async Task<IActionResult> GetEnquirydetailsbyenquiryno(int enquiryno)
        {

            try
            {

                var enquirydetails = await dbcontext.Enquiry
                      .Include(e => e.Customer)

                .Include(t => t.ProjectEngineer)
        .Include(t => t.ProjectManager)
             .Include(t => t.Enquirytype)
              .Include(t => t.customercontact)
              .Include(t => t.Enquirystatus)
              .Where(po => po.Enquiryref == enquiryno)
              .FirstOrDefaultAsync();
                if (enquirydetails == null)
                {
                    return NotFound();
                }
                return Ok(enquirydetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }











        [HttpGet("listcustomercontact")]
        public async Task<IActionResult> getallcustomercontacts()
        {
            var listcustomercontact = await dbcontext.customercontact
          
                // <-- This line includes the Customer data
                .ToListAsync();

            return Ok(listcustomercontact);
        }











        [HttpGet("GetEnquirystatus")]
        public async Task<IActionResult> GetEnquirystatus()
        {
            var enquirystatus = await dbcontext.Enquirystatus

                // <-- This line includes the Customer data
                .ToListAsync();

            return Ok(enquirystatus);
        }



        public class CompleteEnquiryRequest
        {
            [Required]
            public int EnquiryRef { get; set; }

            [Required]
            public string CompletedByUserId { get; set; }
        }





        [HttpGet("GetEnquirydetailsbyprojectengineer")]
        public async Task<IActionResult> GetEnquirydetailsbyprojectengineer(string userid)
        {
            try
            {
                var enquirydetails = await dbcontext.Enquiry
                    .Include(e => e.Customer)
                    .Include(t => t.ProjectEngineer)
                    .Include(t => t.ProjectManager)
                    .Include(t => t.Enquirytype)
                    .Include(t => t.customercontact)
                    .Include(t => t.Enquirystatus)
                    // --- NEW AND COMBINED WHERE CLAUSE ---
                    .Where(e => e.projectengineerid == userid && e.iscompleted == 0)
                    // -------------------------------------
                    .ToListAsync();

                // Note: ToListAsync() returns an empty list, not null, if no items are found.
                // The null check below is redundant for ToListAsync() but harmless.
                if (enquirydetails == null || enquirydetails.Count == 0)
                {
                    return NotFound("No incomplete enquiries found for this user.");
                }

                return Ok(enquirydetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }










        [HttpGet("GetEnquirydetailsbyprojectmanager")]
        public async Task<IActionResult> GetEnquirydetailsbyprojectmanager(string userid)
        {
            try
            {
                var enquirydetails = await dbcontext.Enquiry
                    .Include(e => e.Customer)
                    .Include(t => t.ProjectEngineer)
                    .Include(t => t.ProjectManager)
                    .Include(t => t.Enquirytype)
                    .Include(t => t.customercontact)
                    .Include(t => t.Enquirystatus)
                    // --- NEW AND COMBINED WHERE CLAUSE ---
                    .Where(e => e.projectmanagerid == userid && e.iscompleted == 1  && e.isverified ==0)
                    // -------------------------------------
                    .ToListAsync();

                // Note: ToListAsync() returns an empty list, not null, if no items are found.
                // The null check below is redundant for ToListAsync() but harmless.
                if (enquirydetails == null || enquirydetails.Count == 0)
                {
                    return NotFound("No incomplete enquiries found for this user.");
                }

                return Ok(enquirydetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }






























        [HttpPost("Complete")]
        public async Task<IActionResult> MarkEnquiryAsComplete([FromBody] CompleteEnquiryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Returns 400 if model validation fails
            }

            // 1. Find the enquiry in the database
            var enquiry = await dbcontext.Enquiry
                .FirstOrDefaultAsync(e => e.Enquiryref == request.EnquiryRef);

            if (enquiry == null)
            {
                return NotFound(new { message = $"Enquiry with reference '{request.EnquiryRef}' not found." }); // Returns 404
            }

            // Check if it's already completed
            if (enquiry.iscompleted==1)
            {
                return Conflict(new { message = $"Enquiry '{request.EnquiryRef}' is already completed." }); // Returns 409
            }

            // 2. Update the status fields
            enquiry.iscompleted = 1;
            enquiry.completedbybyuserid = request.CompletedByUserId;
            enquiry.completiondate = DateTime.UtcNow; // Use UTC for consistency

            // 3. Save changes to the database
            await dbcontext.SaveChangesAsync();

            // 4. Return success response
            // 200 OK is fine for an update, or 204 No Content for simplicity
            return Ok(new { success = true, message = "Enquiry successfully marked as complete." });
        }



    }
}
