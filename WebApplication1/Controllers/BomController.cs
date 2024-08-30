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





        [HttpPost("AddBom")]
        public async Task<IActionResult> AddBom(AddBom request)
        {
            var bom = new Bom
            {
             currencyid = request.currencyid,
             bomqty = request.bomqty,
             bomuomid = request.bomuomid,   
             itemid = request.itemid    ,
             prodstageid = request.prodstageid ,
             RequiredDate = request.RequiredDate    ,
             price= request.price 
             

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
               bomid = request.bomid 
          




            };

            return Ok(response);
        }








    }
}
