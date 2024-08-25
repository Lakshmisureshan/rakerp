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
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext dbcontext;

        public ProductController(ApplicationDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }


        [HttpGet("GetAllUom")]
        public async Task<IActionResult> GetAllUom()
        {
            var uom = await dbcontext.UOM.ToListAsync();
            return Ok(uom);
        }



        [HttpPost]
        public async Task<IActionResult> CreateProductMaster(Addp request)
        {
            var jobtype = new JobType
            {
                JobtypeName = request.JobtypeName,
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





















    }
}
