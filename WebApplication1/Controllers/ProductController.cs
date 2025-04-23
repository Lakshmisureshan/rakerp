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
                productcode = request.productcode ,
                price = request.price ,
                categoryid = request.categoryid ,
                subcategoryid=request.subcategoryid,
                reorderlevel =request.reorderlevel,
                reorderqty = request.reorderqty,
                itembname = request.itembname,


            };
            await dbcontext.Product.AddAsync(product);
            await dbcontext.SaveChangesAsync();
            var response = new ProductDto
            {
            itemcode= product.itemcode,
            itemdescription= product.itemdescription,
            standarduomid= product.standarduomid,
            itemname= product.itemname, 
            price = product.price ,
            productcode= product.productcode 
            
            
            };

            return Ok(response);
        }









        [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            var products = await dbcontext.Product
      .Include(p => p.Category)
      .Include(c => c.SubCategory) // If Subcategory is inside Category
      .Include(p => p.UOM) // Include Unit of Measurement (UOM)
      .ToListAsync();

            return Ok(products);
        }






        [HttpGet("GetMaxProductCodeAsync")]
        public async Task<int> GetMaxProductCodeAsync()
        {
            // Get the maximum product code from the database
            var maxProductCode = await dbcontext.Product
                .MaxAsync(p => (int?)p.productcode); // Use nullable int to handle no records case

            // Return the maximum product code or 10001 if no products exist
            return maxProductCode+1 ?? 10000 + 1; // Return 10001 if maxProductCode is null
        }






    }
}
