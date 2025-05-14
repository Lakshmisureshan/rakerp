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
                email = request.email,
                IEC = request.IEC,
                location = request.location,
                remarks = request.remarks,
                shortname = request.shortname,
                web = request.web,
                phone = request.phone,
                pobox = request.pobox,
                Trnno = request.Trnno,
                address = request.address,

            };
            await dbcontext.Customer.AddAsync(customer);
            await dbcontext.SaveChangesAsync();
            var response = new CustomerDto
            {
                Trnno = customer.Trnno,
                pobox = customer.pobox,
                phone = customer.phone,
                web = customer.web,
                shortname = customer.shortname,
                remarks = customer.remarks,
                location = customer.location,
                IEC = customer.IEC,
                ccode = customer.ccode,
                countryid = customer.countryid,
                Customername = customer.Customername,
                email = customer.email,
                address = customer.address,
            };

            return Ok(response);
        }


        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto request)
        {
            if (request.customerid <= 0)
            {
                return BadRequest(new { message = "Invalid customer ID for update." });
            }

            var customer = await dbcontext.Customer.FindAsync(request.customerid);
            if (customer == null)
            {
                return NotFound(new { message = "Customer not found." });
            }

            // Update fields
            customer.countryid = request.countryid;
            customer.ccode = request.ccode;
            customer.Customername = request.customername;
            customer.email = request.email;
            customer.IEC = request.iec;
            customer.location = request.location;
            customer.remarks = request.remarks;
            customer.shortname = request.shortname;
            customer.web = request.web;
            customer.phone = request.phone;
            customer.pobox = request.pobox;
            customer.Trnno = request.trnno;
            customer.address = request.address;

            dbcontext.Customer.Update(customer);
            await dbcontext.SaveChangesAsync();

            return Ok(new { message = "Customer updated successfully." });
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



        [HttpGet("GetAllSuppliers")]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var response = new List<SupplierDto>();
            var suppliers = await dbcontext.Supplier.ToListAsync();
            foreach (var item in suppliers)
            {
                response.Add(new SupplierDto
                {
                   supplierid = item.supplierid,
                   suppliername=item.suppliername,  

                });

            }
            return Ok(response);
        }


        [HttpGet("GetSupplierContactbySupplierid")]
        public async Task<IActionResult> GetSupplierContactbySupplierid( int supplierid )
        {
            var suppliercontact = await dbcontext.SupplierContact.Where (x=>x.supplierid == supplierid).ToListAsync();
            if ( suppliercontact == null )
            {
                return BadRequest();
            }
           return Ok(suppliercontact);
        }




        [HttpGet("GetSupplierDetailsbySupplierid")]
        public async Task<IActionResult> GetSupplierDetailsbySupplierid(int supplierid)
        {
            if (supplierid <= 0)
            {
                return BadRequest("Invalid supplier ID");
            }

            var supplierdetails = await dbcontext.Supplier
                                                 .FirstOrDefaultAsync(x => x.supplierid == supplierid);

            if (supplierdetails == null)
            {
                return NotFound("Supplier not found");
            }

            return Ok(supplierdetails);
        }





        [HttpGet("GetCurrencyDetailsbyCurrencyid")]
        public async Task<IActionResult> GetCurrencyDetailsbyCurrencyid(int currencyid)
        {
            if (currencyid <= 0)
            {
                return BadRequest("Invalid Currency");
            }
            var currencydetails = await dbcontext.Currency
             .FirstOrDefaultAsync(x => x.currencyid == currencyid);

            if (currencydetails == null)
            {
                return NotFound("Currency not found");
            }
            return Ok(currencydetails);
        }


















        [HttpGet("GetMaxPONumber")]
        public async Task<IActionResult> GetMaxPONumber()
        {
            var maxPoNumber = await dbcontext.PO.MaxAsync(po => (int?)po.Orderid) ?? 0;
            var nextPoNumber = maxPoNumber + 1;
            return Ok(nextPoNumber);
        }

        [HttpGet("GetJobDetails")]
        public async Task<IActionResult> GetJobDetails()
        {
            var jobdetails = await dbcontext.Job.ToListAsync();
        
            return Ok(jobdetails);
        }

        [HttpGet("GetPOdeliveryterms")]
        public async Task<IActionResult> GetPOdeliveryterms()
        {
            var pODeliveryTerms = await dbcontext.PODeliveryTerms.ToListAsync();
            return Ok(pODeliveryTerms);
        }


        [HttpGet("GetPOPaymentTerms")]
        public async Task<IActionResult> GetPOPaymentTerms()
        {
            var pODeliveryTerms = await dbcontext.POPaymentterms.ToListAsync();
            return Ok(pODeliveryTerms);
        }


        [HttpGet("GetPOPaymentDays")]
        public async Task<IActionResult> GetPOPaymentDays()
        {
            var POPaymentDays = await dbcontext.PaymenttermsDays.ToListAsync();
            return Ok(POPaymentDays);
        }

        [HttpGet("GetPOPaymentTerms2")]
        public async Task<IActionResult> GetPOPaymentTerms2()
        {
            var POPaymentDays2 = await dbcontext.Popaymentterms2.ToListAsync();
            return Ok(POPaymentDays2);
        }

        [HttpGet("Getcustomerdetailsbycustomerid/{customerid}")]
        public async Task<IActionResult> Getcustomerdetailsbycustomerid(int customerid)
        {
            var customer = await dbcontext.Customer
                .FirstOrDefaultAsync(c => c.customerid == customerid);

            if (customer == null)
            {
                return NotFound(new { message = "Customer not found" });
            }

            return Ok(customer);
        }
   





        [HttpPost("AddCustomerContact")]
        public async Task<IActionResult> AddCustomerContact(Addorupdatecustomercontactdto request)
        {
            using (var transaction = await dbcontext.Database.BeginTransactionAsync()) // Start a transaction
            {
                try
                {
                   foreach (var item in request.contactdetails)
                    {

                        // Insert new detail if rtblid doesn't exist
                        var newcustomercontact = new customercontact
                        {
                            customerid = item.customerid,
                            name = item.name,
                            designation = item.designation,
                            phone = item.phone,
                            mobile = item.mobile,
                            email = item.email



                        };

                        await dbcontext.customercontact.AddAsync(newcustomercontact);
                    }
                    await dbcontext.SaveChangesAsync(); // Save received entry details
                    await transaction.CommitAsync(); // Commit transaction if everything succeeds
                    return StatusCode(201, new { Message = "New Customer Contact Added Successfully" });

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(); // Rollback transaction on failure

                    return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
                }


            }
        }



























    }
}
