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
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDBContext dbcontext;
        public CustomerController(ApplicationDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(AddCustomerDto request)
        {
            var customer = new Customer
            {
              countryid = request.countryid,
              ccode = request.ccode,    
             Customername = request.Customername,
             email = request.email  ,
             IEC = request.IEC  ,
             location = request.location ,  
             remarks = request.remarks,
             shortname = request.shortname  ,
             web = request.web  ,
             phone = request.phone ,    
             pobox = request.pobox ,    
             Trnno = request.Trnno  
             
            };
            await dbcontext.Customer.AddAsync(customer);
            await dbcontext.SaveChangesAsync();
            var response = new CustomerDto
            {
              Trnno= customer.Trnno,
              pobox= customer.pobox,
              phone= customer.phone,
              web= customer.web,
              shortname= customer.shortname,
              remarks= customer.remarks,
              location= customer.location ,
              IEC= customer. IEC ,
              ccode= customer.ccode ,
              countryid= customer.countryid,    
              Customername = customer.Customername ,
              email= customer.email ,   
            };

            return Ok(response);
        }




        [HttpGet("GetAllCountryList")]
        //[Authorize(Roles ="Writer")]
        public async Task<IActionResult> GetAllCountryList()
        {
            var response = new List<CountryDto>();
            var countrys = await dbcontext.Country.ToListAsync();
            foreach (var item in countrys)
            {
                response.Add(new CountryDto
                {
                   countryid = item.countryid,
                   countryname = item.countryname,
                });

            }
            return Ok(response);
        }





        [HttpGet("GetAllCustomer")]
        //[Authorize(Roles ="Writer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var response = new List<CustomerDto>();
            var countrys = await dbcontext.Customer.ToListAsync();
            foreach (var item in countrys)
            {
                response.Add(new CustomerDto
                {Customername = item.Customername,  
                   ccode = item.ccode,  
                   countryid = item.countryid,  
                   customerid = item.customerid, 
                   email= item.email,
                   IEC=item.IEC,
                   web = item.web   ,
                   location = item.location ,
                   phone = item.phone,
                   pobox = item.pobox , 
                   remarks = item.remarks , 
                   shortname = item.shortname,  
                   Trnno = item.Trnno   


                });

            }
            return Ok(response);
        }

















    }
}
