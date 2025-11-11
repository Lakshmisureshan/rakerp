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






        [HttpGet("GetBudgetHeadersforBom1")]
        public async Task<IActionResult> GetBudgetHeadersforBom1()
        {
            // Hardcoded list of allowed BudgetHeaderIds
            var allowedBudgetHeaderIds = new List<int> { 1, 3, 4, 5 }; // 👈 Your specific IDs

            var products = await dbcontext.Product
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .Include(p => p.UOM)
                 .Include(p => p.BudgettHeader)
                .Where(p => allowedBudgetHeaderIds.Contains(p.BudgettHeader.budgetheaderid)) // 👈 Filter
                .ToListAsync();

            return Ok(products);
        }





        [HttpGet("GetBudgetHeadersforBom2")]
        public async Task<IActionResult> GetBudgetHeadersforBom2()
        {
            // Hardcoded list of allowed BudgetHeaderIds
            var allowedBudgetHeaderIds = new List<int> { 6,12,16,17 }; // 👈 Your specific IDs

            var products = await dbcontext.Product
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .Include(p => p.UOM)
                 .Include(p => p.BudgettHeader)
                .Where(p => allowedBudgetHeaderIds.Contains(p.BudgettHeader.budgetheaderid)) // 👈 Filter
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("GetBudgetHeadersforBom6")]
        public async Task<IActionResult> GetBudgetHeadersforBom6()
        {
            // Hardcoded list of allowed BudgetHeaderIds
            var allowedBudgetHeaderIds = new List<int> { 2}; // 👈 Your specific IDs

            var products = await dbcontext.Product
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .Include(p => p.UOM)
                 .Include(p => p.BudgettHeader)
                .Where(p => allowedBudgetHeaderIds.Contains(p.BudgettHeader.budgetheaderid)) // 👈 Filter
                .ToListAsync();

            return Ok(products);
        }


        [HttpGet("GetBudgetHeadersforBom4")]
        public async Task<IActionResult> GetBudgetHeadersforBom4()
        {
            // Hardcoded list of allowed BudgetHeaderIds
            var allowedBudgetHeaderIds = new List<int> { 13,7,15,23 }; // 👈 Your specific IDs

            var products = await dbcontext.Product
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .Include(p => p.UOM)
                 .Include(p => p.BudgettHeader)
                .Where(p => allowedBudgetHeaderIds.Contains(p.BudgettHeader.budgetheaderid)) // 👈 Filter
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("GetBudgetHeadersforBom5")]
        public async Task<IActionResult> GetBudgetHeadersforBom5()
        {
            // Hardcoded list of allowed BudgetHeaderIds
            var allowedBudgetHeaderIds = new List<int> { 22 }; // 👈 Your specific IDs

            var products = await dbcontext.Product
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .Include(p => p.UOM)
                 .Include(p => p.BudgettHeader)
                .Where(p => allowedBudgetHeaderIds.Contains(p.BudgettHeader.budgetheaderid)) // 👈 Filter
                .ToListAsync();

            return Ok(products);
        }




        [HttpGet("GetBudgetHeadersforBom3")]
        public async Task<IActionResult> GetBudgetHeadersforBom3()
        {
            // Hardcoded list of allowed BudgetHeaderIds
            var allowedBudgetHeaderIds = new List<int> { 8,9,10 }; // 👈 Your specific IDs

            var products = await dbcontext.Product
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .Include(p => p.UOM)
                 .Include(p => p.BudgettHeader)
                .Where(p => allowedBudgetHeaderIds.Contains(p.BudgettHeader.budgetheaderid)) // 👈 Filter
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

        [HttpGet("getAllConsumbalecategoryproduct")]
        public async Task<IActionResult> GetAllConsumbaleCategoryProduct()
        {
            var products = await dbcontext.Product
            
                .Include(p => p.Category)
                .Include(p => p.BudgettHeader)
                .Include(p => p.SubCategory)
                .Include(p => p.UOM)

                    .Where(p => p.BudgettHeader.budgetheaderid == 13)
                .ToListAsync();
            return Ok(products);
        }



        















    }
}
