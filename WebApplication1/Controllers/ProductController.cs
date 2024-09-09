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

        [HttpGet("GetAllBudgetheaders")]
        public async Task<IActionResult> GetAllBudgetheaders()
        {
            var budgetheader = await dbcontext.BudgettHeader.ToListAsync();
            return Ok(budgetheader);
        }

        [HttpPost("CreateProductMaster")]
        public async Task<IActionResult> CreateProductMaster(AddProductdto request)
        {
            var product = new Product
            {
                itemcode = request.itemcode,    
                itemdescription = request.itemdescription,  
                itemname = request.itemname,    
                standarduomid = request.standarduomid ,
                itembudgetheaderid = request.itembudgetheaderid ,   
                
                
            };
            await dbcontext.Product.AddAsync(product);
            await dbcontext.SaveChangesAsync();
            var response = new ProductDto
            {
            itemcode= product.itemcode,
            itemdescription= product.itemdescription,
            standarduomid= product.standarduomid,
            itemname= product.itemname, 
            price = product.price   
            
            };

            return Ok(response);
        }









        [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            var product = await dbcontext.Product.ToListAsync();
            return Ok(product);
        }













    }
}
