using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using WebApplication1.Data;
//using WebApplication1.Migrations;
using WebApplication1.Models;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;
using iTextSharp.text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static WebApplication1.Controllers.AuthController;
using static WebApplication1.Controllers.POController;
using AddReceivedEntry = WebApplication1.Models.DTO.AddReceivedEntry;
using Document = iTextSharp.text.Document;
using Path = System.IO.Path;
using System.Net.Mime;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using static iTextSharp.text.pdf.AcroFields;
using System.Runtime.CompilerServices;
using static System.Reflection.Metadata.BlobBuilder;
using QuestPDF.Fluent;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POController : ControllerBase
    {
        private readonly ApplicationDBContext dbcontext;
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private readonly ILogger<JobController> _logger;
        private readonly IPdfService _pdfService;
        public POController(ApplicationDBContext dbcontext, IConfiguration configuration, ILogger<JobController> logger, IPdfService pdfService)
        {
            this.dbcontext = dbcontext;
            _connectionString = configuration.GetConnectionString("CodePlusConnectionStrings");
            _configuration = configuration;
            _logger = logger;
            _pdfService = pdfService;

        }

        [HttpGet("GetPOHeaderDetails")]

        public async Task<IActionResult> GetPOHeaderDetails()
        {
            var POheaderdetails = await dbcontext.PO.ToListAsync();
            return Ok(POheaderdetails);

        }




        [HttpGet("GetPOStatus")]
        public async Task<IActionResult> GetPOStatus()
        {
            var postatus = await dbcontext.postatus.ToListAsync();
            return Ok(postatus);
        }



        //[HttpPost("AddPOHeader")]
        //public async Task<IActionResult> AddpoHeader(AddPO request)
        //{
        //    DateTime currentDate = DateTime.Now;
        //    try
        //    {
        //        var PO = new PO
        //        {
        //            approveddrawings = request.approveddrawings,
        //            chineseorgin = request.chineseorgin,
        //            coorequired = request.coorequired,
        //            createddate = currentDate,
        //            createdbyid = request.createdbyid,
        //            jobid = request.jobid,
        //            extendedwarraty3years = request.extendedwarraty3years,
        //            deliverydate = request.deliverydate,
        //            mtcpriortodispatch = request.mtcpriortodispatch,
        //            warranty = request.warranty,
        //            suppliertrnno = request.suppliertrnno,
        //            Mtcrequired = request.Mtcrequired,
        //            Orderid = request.Orderid,
        //            Others = request.Others,
        //            supplierid = request.supplierid,
        //            popaymenttermsid = request.popaymenttermsid,
        //            POPaymentterms2id = request.POPaymentterms2id,
        //            podeliverytermsid = request.podeliverytermsid,
        //            PaymenttermsDaysid = request.PaymenttermsDaysid,
        //            pocurrencyid = request.pocurrencyid,
        //            Podate = request.Podate,

        //            predispatchinspection = request.predispatchinspection,
        //            Qtndate = request.Qtndate,
        //            Qtnref = request.Qtnref,
        //            supplieraddress = request.supplieraddress,
        //            Remarks = request.Remarks,
        //            qtnattached = request.qtnattached,
        //            suppliercontactid = request.suppliercontactid,
        //            qtnshippingdocs = request.qtnshippingdocs,
        //            poexchangerate = request.poexchangerate,









        //        };

        //        await dbcontext.PO.AddAsync(PO);
        //        await dbcontext.SaveChangesAsync();
        //        var response = new PODto
        //        {
        //            createdbyid = request.createdbyid,
        //            Orderid = request.Orderid

        //        };

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (optional)
        //        // e.g., logger.LogError(ex, "An error occurred while adding PR header");

        //        return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
        //    }
        //}










        [HttpPost("AddPOHeader")]
        public async Task<IActionResult> AddpoHeader(AddPO request)
        {
            DateTime currentDate = DateTime.Now;
            try
            {
                bool isNewJob = false;
                // Check if the PO already exists
                var existingPO = await dbcontext.PO.FirstOrDefaultAsync(po => po.Orderid == request.Orderid);

                if (existingPO != null)
                {
                    // If the PO exists, update it
                    isNewJob = false; // It's a new job
                    existingPO.approveddrawings = request.approveddrawings;
                    existingPO.chineseorgin = request.chineseorgin;
                    existingPO.coorequired = request.coorequired;
                    existingPO.createddate = currentDate; // Update the created date if needed
                    existingPO.createdbyid = request.createdbyid;
                    existingPO.jobid = request.jobid;
                    existingPO.extendedwarraty3years = request.extendedwarraty3years;
                    existingPO.deliverydate = request.deliverydate;
                    existingPO.mtcpriortodispatch = request.mtcpriortodispatch;
                    existingPO.warranty = request.warranty;
                    existingPO.suppliertrnno = request.suppliertrnno;
                    existingPO.Mtcrequired = request.Mtcrequired;
                    existingPO.Orderid = request.Orderid;
                    existingPO.Others = request.others;
                    existingPO.supplierid = request.supplierid;
                    existingPO.popaymenttermsid = request.popaymenttermsid;
                    existingPO.POPaymentterms2id = request.POPaymentterms2id;
                    existingPO.podeliverytermsid = request.podeliverytermsid;
                    existingPO.PaymenttermsDaysid = request.PaymenttermsDaysid;
                    existingPO.pocurrencyid = request.pocurrencyid;
                    existingPO.Podate = request.Podate;
                    existingPO.predispatchinspection = request.predispatchinspection;
                    existingPO.Qtndate = request.Qtndate;
                    existingPO.Qtnref = request.Qtnref;
                    existingPO.supplieraddress = request.supplieraddress;
                    existingPO.Remarks = request.Remarks;
                    existingPO.qtnattached = request.qtnattached;
                    existingPO.suppliercontactid = request.suppliercontactid;
                    existingPO.qtnshippingdocs = request.qtnshippingdocs;
                    existingPO.poexchangerate = request.poexchangerate;
                    existingPO.suppliertrnno = request.suppliertrnno;
                    existingPO.otherpaymentremarks = request.otherpaymentremarks;
                    existingPO.budgetheaderid = request.budgetheaderid;
                    existingPO.discount = request.discount;
                    existingPO.taxamount = request.taxamount;
                    existingPO.vatpercent = request.vatpercent;

                    // Save changes to the existing PO
                    await dbcontext.SaveChangesAsync();
                }
                else
                {
                    isNewJob = true;
                    // If the PO doesn't exist, create a new PO
                    var PO = new PO
                    {
                        suppliertrnno = request.suppliertrnno,
                        approveddrawings = request.approveddrawings,
                        chineseorgin = request.chineseorgin,
                        coorequired = request.coorequired,
                        createddate = currentDate,
                        createdbyid = request.createdbyid,
                        jobid = request.jobid,
                        extendedwarraty3years = request.extendedwarraty3years,
                        deliverydate = request.deliverydate,
                        mtcpriortodispatch = request.mtcpriortodispatch,
                        warranty = request.warranty,

                        Mtcrequired = request.Mtcrequired,
                        Orderid = request.Orderid,
                        Others = request.others,
                        supplierid = request.supplierid,
                        popaymenttermsid = request.popaymenttermsid,
                        POPaymentterms2id = request.POPaymentterms2id,
                        podeliverytermsid = request.podeliverytermsid,
                        PaymenttermsDaysid = request.PaymenttermsDaysid,
                        pocurrencyid = request.pocurrencyid,
                        Podate = request.Podate,
                        predispatchinspection = request.predispatchinspection,
                        Qtndate = request.Qtndate,
                        Qtnref = request.Qtnref,
                        supplieraddress = request.supplieraddress,
                        Remarks = request.Remarks,
                        qtnattached = request.qtnattached,
                        suppliercontactid = request.suppliercontactid,
                        qtnshippingdocs = request.qtnshippingdocs,
                        poexchangerate = request.poexchangerate,
                        otherpaymentremarks = request.otherpaymentremarks,
                        budgetheaderid = request.budgetheaderid

                    };

                    // Add the new PO to the database
                    await dbcontext.PO.AddAsync(PO);
                    await dbcontext.SaveChangesAsync();




















                }



                var pageTrackEntry = new Trackpage
                {
                    // Assuming 'Job Entry' or 'Job Update' as the page name
                    pagename = isNewJob ? "New PO" : "Update PO",
                    docno = request.Orderid.ToString(), // Use the Jobid as the document number
                    createddate = DateTime.UtcNow, // Use UTC for consistency
                                                   // Get the current user's ID/username
                    createdbyuser = request.createdbyid.ToString() // Placeholder: Replace with actual user ID/name
                                                                   // If you have authentication:
                                                                   // createdbyuser = User.Identity.Name ?? "Anonymous"
                                                                   // or if injecting IHttpContextAccessor:
                                                                   // createdbyuser = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Anonymous"
                };

                await dbcontext.Trackpage.AddAsync(pageTrackEntry);
                await dbcontext.SaveChangesAsync();






















                var response = new PODto
                {
                    createdbyid = request.createdbyid,
                    Orderid = request.Orderid
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }


























        [HttpGet("GetPrpendinglistwhereponotcreated")]

        public async Task<IActionResult> GetPrpendinglistwhereponotcreated(int jobid)
        {
            var result = from prHeader in dbcontext.PR
                         join prDetail in dbcontext.PRDetails on prHeader.PRID equals prDetail.prid
                         where ((decimal)(prDetail.pocreatedqty) + (decimal)(prDetail.prstockqty)) < (decimal)prDetail.prqty
                         && prHeader.prstatusid == 3 && prHeader.jobid == jobid

                         select new
                         {
                             prHeader.PRID,
                             prDetail.pritemid,
                             prDetail.prqty,
                             prDetail.pocreatedqty,
                             prDetail.prtblid,
                             prDetail.bomid,
                             prDetail.Product,
                             prDetail.pruomid,

                             prDetail.prstockqty

                             // Add other properties as needed
                         };

            var filteredData = await result.ToListAsync();

            return Ok(filteredData);

        }









        [HttpGet("GetPOHeaderDetailsbypoid")]
        public async Task<IActionResult> GetPOHeaderDetailsbypoid(int pono)
        {
            try
            {
                var POheaderdetails = await dbcontext.PO
      .Include(po => po.Supplier)


      .Include(po => po.PoAuthorizedby)
       .Include(po => po.Poverifiedby)
        .Include(po => po.SupplierContact)
         .Include(po => po.Currency)
          .Include(po => po.PODeliveryTerms)


           .Include(po => po.POPaymentterms)

           .Include(po => po.POPaymentterms2)
           .Include(po => po.PaymenttermsDays)
      .Include(po => po.postatus)// Include the Supplier related entity
      .Where(po => po.Orderid == pono)
      .FirstOrDefaultAsync();
                if (POheaderdetails == null)
                {
                    return NotFound();
                }
                return Ok(POheaderdetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }





        // [HttpGet("GetPOLinedetailsbyPOid")]
        // public async Task<IActionResult> GetPOLinedetailsbyPOid(int pono)
        //{
        //     var POlinedetails = await (from po in dbcontext.Purchasedetails
        //                                join prpo in dbcontext.PRPO on po.potblid equals prpo.Purchasedetailspotblid
        //                                join ii in dbcontext.Product on po.poitemid equals ii.itemid 
        //                                join pr in dbcontext.PRDetails on prpo.prdetailsprtblid equals pr.prtblid
        //                                where po.orderid == pono
        //                                select new
        //                                {
        //                                    pr.prid,
        //                                    po.potblid,
        //                                    po.orderid,
        //                                    po.poquantity,
        //                                    po.make,
        //                                    po.poitemid,
        //                                    ii.itemname,
        //                                    po.pounitprice,
        //                                    prpo.prdetailsprtblid,
        //                                    pr.pocreatedqty,
        //                                    pr.prqty,
        //                                    PRPODetails = prpo // You can include other fields from PRPO if needed
        //                                }).ToListAsync();
        //     if (POlinedetails == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(POlinedetails);
        // }



        [HttpGet("GetPOLinedetailsbyPOid")]
        public async Task<IActionResult> GetPOLinedetailsbyPOid(int pono)
        {
            var POlinedetails = await (from po in dbcontext.Purchasedetails
                                       join ii in dbcontext.Product on po.poitemid equals ii.productcode
                                       where po.orderid == pono
                                       select new
                                       {
                                           po.grncreatedqty,
                                           po.potblid,
                                           po.orderid,
                                           po.poquantity,
                                           po.make,
                                           po.poitemid,
                                           ii.itemname,
                                           po.pounitprice,


                                           totalamount = po.pounitprice * po.poquantity
                                           // You can include other fields from PRPO if needed
                                       }).ToListAsync();
            if (POlinedetails == null)
            {
                return NotFound();
            }
            return Ok(POlinedetails);
        }







        [HttpGet("GetGRnDetailsbygrnno")]
        public async Task<IActionResult> GetGRnDetailsbygrnno(int grnno)
        {
            var grnlinedetails = await (from po in dbcontext.GRNDetails
                                        join ii in dbcontext.Product on po.itemcode equals ii.productcode
                                        join pou in dbcontext.UOM on po.pouomid equals pou.uomid
                                        join invuom in dbcontext.UOM on po.inventoryuomid equals invuom.uomid

                                        where po.grnno == grnno
                                        select new
                                        {
                                            po.grntblid,
                                            po.Product.itemname,
                                            po.grnqty,

                                            pouomname = pou.uomname,
                                            invuomname = invuom.uomname,
                                            po.multiplyingfactor,
                                            po.pouomid,
                                            po.inventoryuomid,
                                            po.itemcode,
                                            po.pounitprice,
                                            po.location


                                            // You can include other fields from PRPO if needed
                                        }).ToListAsync();
            if (grnlinedetails == null)
            {
                return NotFound();
            }
            return Ok(grnlinedetails);
        }






        ////[HttpPost("Addpodetails")]
        ////public async Task<IActionResult> Addpodetails(AddPODetailsDto request)
        ////{
        ////    DateTime currentDate = DateTime.Now;
        ////    try
        ////    {
        ////        var Purchasedetails = new Purchasedetails
        ////        {
        ////           orderid=request.orderid,
        ////           poitemid=request.poitemid,
        ////           poquantity =request.poquantity,
        ////           pounitprice =request.pounitprice, 
        ////           make=request.make,   
        ////                     };

        ////        await dbcontext.Purchasedetails.AddAsync(Purchasedetails);
        ////        await dbcontext.SaveChangesAsync();
        ////        var response = new PODetailsDto
        ////        {
        ////          make = request.make,
        ////          pounitprice=request.pounitprice,
        ////          poquantity=request.poquantity,
        ////          poitemid = request.poitemid,
        ////          orderid=request.orderid,


        ////        };

        ////        return Ok(response);
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        // Log the exception (optional)
        ////        // e.g., logger.LogError(ex, "An error occurred while adding PR header");

        ////        return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
        ////    }
        ////}


        public class SavePOItemsRequest
        {
            public List<AddPODetailsDto> Data { get; set; }
            public List<Adddatatosavedinprdetails> Prdetails { get; set; }
        }


        [HttpPost("updatepodetails")]
        public async Task<IActionResult> updatepodetails([FromBody] UpdatePOdetails poDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using var transaction = await dbcontext.Database.BeginTransactionAsync();
            try
            {

                var existingPurchasedetails = await dbcontext.Purchasedetails
                  .FirstOrDefaultAsync(pr => pr.potblid == poDetail.potblid);
                if (existingPurchasedetails == null)
                {
                    return NotFound(new { Message = $"The specified PO details with id {poDetail.potblid} do not exist." });
                }

                //var existingprdetails = await dbcontext.PRDetails
                // .FirstOrDefaultAsync(pr => pr.prtblid == poDetail.prtblid);
                //if (existingprdetails == null)
                //{
                //    return NotFound(new { Message = $"The specified PR details with id {poDetail.prtblid} do not exist." });
                //}
                //if (existingPurchasedetails.poquantity > (decimal)poDetail.poquantity)
                //{

                //    existingprdetails.pocreatedqty = (float)((decimal)existingprdetails.pocreatedqty - ((decimal)existingPurchasedetails.poquantity - (decimal)poDetail.poquantity));
                //}

                //if (existingPurchasedetails.poquantity < (decimal)poDetail.poquantity)
                //{

                //    existingprdetails.pocreatedqty = (float)((decimal)existingprdetails.pocreatedqty + ((decimal)poDetail.poquantity) - (decimal)existingPurchasedetails.poquantity);
                //}


                //if (existingPurchasedetails.poquantity == (decimal)poDetail.poquantity)
                //{

                //    existingprdetails.pocreatedqty = existingprdetails.pocreatedqty;



                //}
                //existingPurchasedetails.poquantity = (decimal)poDetail.poquantity;
                existingPurchasedetails.pounitprice = (decimal)poDetail.pounitprice;
                existingPurchasedetails.make = poDetail.make;
                dbcontext.Purchasedetails.Update(existingPurchasedetails);
                // dbcontext.PRDetails.Update(existingprdetails);


                await dbcontext.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { Message = "Success" });
            }

            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }


        //[HttpPost("Addpodetails")]
        //public async Task<IActionResult> Addpodetails([FromBody] List<AddPODetailsDto> request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    using var transaction = await dbcontext.Database.BeginTransactionAsync();
        //    try
        //    {
        //        var purchasedetailsList = new List<Purchasedetails>();

        //        // First, group the items by poitemid and prtblid
        //        var groupedItems = request
        //            .GroupBy(item => new { item.poitemid, item.prtblid }) // Group by poitemid and prtblid
        //            .Select(g => new
        //            {
        //                PoItemId = g.Key.poitemid,
        //                PrTblId = g.Key.prtblid,
        //                TotalQuantity = g.Sum(x => x.poquantity), // Sum the quantities for items with the same poitemid
        //                UnitPrice = g.First().pounitprice, // Assuming unit price is the same for grouped items
        //                Make = g.First().make, // Assuming make is the same for grouped items
        //                OrderId = g.First().orderid // Assuming order id is the same for grouped items
        //            }).ToList();

        //        foreach (var item in groupedItems)
        //        {
        //            // Fetch the existing PR details for the current prtblid
        //            var existingPrDetails = await dbcontext.PRDetails
        //                .Include(pr => pr.Purchasedetails)
        //                .FirstOrDefaultAsync(pr => pr.prtblid == item.PrTblId);

        //            if (existingPrDetails == null)
        //            {
        //                return NotFound(new { Message = $"The specified PR details with id {item.PrTblId} do not exist." });
        //            }

        //            // Update pocreatedqty for existing PRDetails
        //            existingPrDetails.pocreatedqty += (float)item.TotalQuantity;

        //            // Create and insert a new purchase detail for the grouped item
        //            var purchaseDetails = new Purchasedetails
        //            {
        //                orderid = item.OrderId, // Use the order id from the grouped item
        //                poitemid = item.PoItemId,
        //                poquantity = (decimal)item.TotalQuantity, // Use the summed quantity
        //                pounitprice = (decimal)item.UnitPrice,
        //                make = item.Make
        //            };

        //            await dbcontext.Purchasedetails.AddAsync(purchaseDetails);
        //            purchasedetailsList.Add(purchaseDetails);

        //            // Link the purchaseDetails with the existing PRDetails
        //            existingPrDetails.Purchasedetails.Add(purchaseDetails);
        //        }

        //        await dbcontext.SaveChangesAsync();
        //        await transaction.CommitAsync();

        //        // Prepare the response DTO list
        //        var response = purchasedetailsList.Select(pd => new PODetailsDto
        //        {
        //            make = pd.make,
        //            pounitprice = (double)pd.pounitprice,
        //            poquantity = (double)pd.poquantity,
        //            poitemid = pd.poitemid,
        //            orderid = pd.orderid,
        //            potblid = pd.potblid, // This will be populated after saving
        //        }).ToList();

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync();
        //        return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
        //    }
        //}



        //[HttpPost("Addpodetails")]
        //public async Task<IActionResult> Addpodetails([FromBody] List<AddPODetailsDto> request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    using var transaction = await dbcontext.Database.BeginTransactionAsync();
        //    try
        //    {
        //        var purchasedetailsList = new List<Purchasedetails>();
        //        var groupedItems = new List<GroupedItem>();
        //        var existingPrDetails = new PRDetails();// Change here

        //        foreach (var prDetail in request)
        //        {
        //            existingPrDetails = await dbcontext.PRDetails
        //               .Include(pr => pr.Purchasedetails)
        //               .FirstOrDefaultAsync(pr => pr.prtblid == prDetail.prtblid);
        //            if (existingPrDetails == null)
        //            {
        //                return NotFound(new { Message = $"The specified PR details with id {prDetail.prtblid} do not exist." });
        //            }

        //            // Update pocreatedqty for existing PRDetails
        //            existingPrDetails.pocreatedqty += (float)prDetail.poquantity;

        //            // Group items by poitemid to sum the quantities
        //            groupedItems = request
        //                .GroupBy(item => item.poitemid)
        //                .Select(g => new GroupedItem // Use the concrete class here
        //                {
        //                    orderid = g.First().orderid,
        //                    TotalQuantity = g.Sum(x => x.poquantity),
        //                    UnitPrice = g.First().pounitprice,
        //                    Make = g.First().make,
        //                    PoItemId = g.Key,
        //                }).ToList();
        //        }

        //        foreach (var item in groupedItems)
        //        {
        //            var purchaseDetails = new Purchasedetails
        //            {
        //                orderid = item.orderid, // Assuming orderid can be derived from poitemid or needs to be handled differently
        //                poitemid = item.PoItemId,
        //                poquantity = (decimal)item.TotalQuantity, // Use the summed quantity
        //                pounitprice = (decimal)item.UnitPrice,
        //                make = item.Make
        //            };
        //            await dbcontext.Purchasedetails.AddAsync(purchaseDetails);
        //            purchasedetailsList.Add(purchaseDetails);

        //            // Link the purchaseDetails with the existing PRDetails
        //            existingPrDetails.Purchasedetails.Add(purchaseDetails);
        //        }

        //        foreach (var prDetail in request)
        //        {
        //            existingPrDetails = await dbcontext.PRDetails
        //               .Include(pr => pr.Purchasedetails)
        //               .FirstOrDefaultAsync(pr => pr.prtblid == prDetail.prtblid);
        //            if (existingPrDetails == null)
        //            {
        //                return NotFound(new { Message = $"The specified PR details with id {prDetail.prtblid} do not exist." });
        //            }

        //            // Update pocreatedqty for existing PRDetails
        //            existingPrDetails.pocreatedqty += (float)prDetail.poquantity;

        //            // Group items by poitemid to sum the quantities
        //            groupedItems = request
        //                .GroupBy(item => item.poitemid)
        //                .Select(g => new GroupedItem // Use the concrete class here
        //                {
        //                    orderid = g.First().orderid,
        //                    TotalQuantity = g.Sum(x => x.poquantity),
        //                    UnitPrice = g.First().pounitprice,
        //                    Make = g.First().make,
        //                    PoItemId = g.Key,
        //                }).ToList();
        //        }





        //        await dbcontext.SaveChangesAsync();
        //        await transaction.CommitAsync();

        //        // Prepare the response DTO list
        //        var response = purchasedetailsList.Select(pd => new PODetailsDto
        //        {
        //            make = pd.make,
        //            pounitprice = (double)pd.pounitprice,
        //            poquantity = (double)pd.poquantity,
        //            poitemid = pd.poitemid,
        //            orderid = pd.orderid,
        //            potblid = pd.potblid, // This will be populated after saving
        //        }).ToList();

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync();
        //        return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
        //    }
        //}
        //[HttpPost("Addpodetails")]
        //public async Task<IActionResult> Addpodetails([FromBody] SavePOItemsRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    using var transaction = await dbcontext.Database.BeginTransactionAsync();
        //    try
        //    {
        //        var purchasedetailsList = new List<Purchasedetails>();

        //        foreach (var prDetail in request.Prdetails)
        //        {
        //            var existingPrDetails = await dbcontext.PRDetails
        //                .Include(pr => pr.Purchasedetails)
        //                .FirstOrDefaultAsync(pr => pr.prtblid == prDetail.prtblid);

        //            if (existingPrDetails == null)
        //            {
        //                return NotFound(new { Message = $"The specified PR details with id {prDetail.prtblid} do not exist." });
        //            }

        //            // Update pocreatedqty
        //            existingPrDetails.pocreatedqty += prDetail.pocreatedqty;

        //            dbcontext.PRDetails.Update(existingPrDetails);

        //            foreach (var item in request.Data)
        //            {
        //                var purchaseDetails = new Purchasedetails
        //                {
        //                    orderid = item.orderid,
        //                    poitemid = item.poitemid,
        //                    poquantity = item.poquantity,
        //                    pounitprice = item.pounitprice,
        //                    make = item.make
        //                };

        //                await dbcontext.Purchasedetails.AddAsync(purchaseDetails);
        //                purchasedetailsList.Add(purchaseDetails);
        //                existingPrDetails.Purchasedetails.Add(purchaseDetails);
        //                Console.WriteLine($"Added purchase detail for OrderId: {item.orderid}");
        //            }
        //        }

        //        await dbcontext.SaveChangesAsync();
        //        Console.WriteLine($"Inserted {purchasedetailsList.Count} Purchasedetails."); // Check count after save

        //        foreach (var prDetail in request.Prdetails)
        //        {
        //            var existingPrDetails = await dbcontext.PRDetails
        //                .Include(pr => pr.Purchasedetails)
        //                .FirstOrDefaultAsync(pr => pr.prtblid == prDetail.prtblid);

        //            foreach (var pd in purchasedetailsList)
        //            {
        //                var prpo = new PRPO
        //                {
        //                    prdetailsprtblid = existingPrDetails.prtblid,
        //                    Purchasedetailspotblid = pd.potblid
        //                };
        //                await dbcontext.PRPO.AddAsync(prpo);
        //                Console.WriteLine($"Added PRPO with PRDetails ID: {existingPrDetails.prtblid} and Purchasedetails ID: {pd.potblid}");
        //            }
        //        }

        //        await dbcontext.SaveChangesAsync();
        //        await transaction.CommitAsync();

        //        var response = purchasedetailsList.Select(pd => new PODetailsDto
        //        {
        //            make = pd.make,
        //            pounitprice = pd.pounitprice,
        //            poquantity = pd.poquantity,
        //            poitemid = pd.poitemid,
        //            orderid = pd.orderid,
        //            potblid = pd.potblid,
        //        }).ToList();

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync();
        //        return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
        //    }
        //}






        //[HttpPost("Addpodetails")]
        //public async Task<IActionResult> Addpodetails([FromBody] List<AddPODetailsDto> request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    using var transaction = await dbcontext.Database.BeginTransactionAsync();
        //    try
        //    {
        //        var purchasedetailsList = new List<Purchasedetails>();
        //        var groupedItems = new List<GroupedItem>();
        //        var groupedItemswithpr = new List<GroupedItem>();
        //        foreach (var prDetail in request)
        //        {
        //            var existingPrDetails = await dbcontext.PRDetails
        //                .Include(pr => pr.Purchasedetails)
        //                .FirstOrDefaultAsync(pr => pr.prtblid == prDetail.prtblid);

        //            if (existingPrDetails == null)
        //            {
        //                return NotFound(new { Message = $"The specified PR details with id {prDetail.prtblid} do not exist." });
        //            }

        //            // Update pocreatedqty for existing PRDetails
        //            existingPrDetails.pocreatedqty += (float)prDetail.poquantity;
        //        }

        //        // Group items by poitemid to sum the quantities
        //        groupedItems = request
        //             .GroupBy(item => new { item.poitemid })
        //            .Select(g => new GroupedItem
        //            {
        //                PoItemId = g.Key.poitemid,

        //                                TotalQuantity = g.Sum(x => x.poquantity), // Sum the quantities for items with the same poitemid
        //                                UnitPrice = g.First().pounitprice, // Assuming unit price is the same for grouped items
        //                               Make = g.First().make, // Assuming make is the same for grouped items
        //                               orderid = g.First().orderid 
        //            }).ToList();

        //        groupedItemswithpr = request
        //             .GroupBy(item => new { item.poitemid, item.prtblid })
        //            .Select(g => new GroupedItem
        //            {
        //                PoItemId = g.Key.poitemid,

        //                TotalQuantity = g.Sum(x => x.poquantity), // Sum the quantities for items with the same poitemid
        //                UnitPrice = g.First().pounitprice, // Assuming unit price is the same for grouped items
        //                Make = g.First().make, // Assuming make is the same for grouped items
        //                orderid = g.First().orderid
        //            }).ToList();




        //        foreach (var item in groupedItems)
        //        {
        //            // Create and insert a new purchase detail for the grouped item
        //            var purchaseDetails = new Purchasedetails
        //            {
        //                orderid = item.orderid,
        //                poitemid = item.PoItemId,
        //                poquantity = (decimal)item.TotalQuantity,
        //                pounitprice = (decimal)item.UnitPrice,    
        //                make = item.Make
        //            };

        //            await dbcontext.Purchasedetails.AddAsync(purchaseDetails);
        //            purchasedetailsList.Add(purchaseDetails);

        //            // Link the purchaseDetails with the corresponding PRDetails
        //            //var existingPrDetail = await dbcontext.PRDetails
        //            //    .Include(pr => pr.Purchasedetails)
        //            //    .FirstOrDefaultAsync(pr => pr.prtblid == request.FirstOrDefault(r => r.poitemid == item.PoItemId)?.prtblid);

        //            //if (existingPrDetail != null)
        //            //{
        //            //    existingPrDetail.Purchasedetails.Add(purchaseDetails);    
        //            //}

        //                var matchingRequestItem = request.FirstOrDefault(r => r.poitemid == item1.PoItemId);

        //                // var matchingRequestItem = request.FirstOrDefault();
        //                // Only proceed if a matching item is found
        //                if (matchingRequestItem != null)
        //                {
        //                    var existingPrDetail = await dbcontext.PRDetails
        //                        .Include(pr => pr.Purchasedetails)
        //                        .FirstOrDefaultAsync(pr => pr.prtblid == matchingRequestItem.prtblid);

        //                    // Check if the existingPrDetail was found
        //                    if (existingPrDetail != null)
        //                    {
        //                        existingPrDetail.Purchasedetails.Add(purchaseDetails);
        //                    }
        //                }











        //            //// Create a new PRPO entry for each combination of prtblid and potblid
        //            //var prpo = new PRPO
        //            //{
        //            //    prdetailsprtblid = existingPrDetail.prtblid, // Use the existing PRDetails' ID
        //            //    Purchasedetailspotblid = purchaseDetails.potblid // The newly created Purchasedetails' ID
        //            //};

        //            //await dbcontext.PRPO.AddAsync(prpo);
        //        }


        //        await dbcontext.SaveChangesAsync();
        //        await transaction.CommitAsync();

        //        // Prepare the response DTO list
        //        var response = purchasedetailsList.Select(pd => new PODetailsDto
        //        {
        //            make = pd.make,
        //            pounitprice = (double)pd.pounitprice,
        //            poquantity = (double)pd.poquantity,
        //            poitemid = pd.poitemid,
        //            orderid = pd.orderid,
        //            potblid = pd.potblid, // This will be populated after saving
        //        }).ToList();

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync();
        //        return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
        //    }
        //}



        //[HttpPost("Addpodetails")]
        //public async Task<IActionResult> Addpodetails([FromBody] List<AddPODetailsDto> request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    using var transaction = await dbcontext.Database.BeginTransactionAsync();
        //    try
        //    {
        //        var purchasedetailsList = new List<Purchasedetails>();
        //        var groupedItems = new List<GroupedItem>();
        //        var groupedItemswithpr = new List<GroupedItem>();

        //        foreach (var prDetail in request)
        //        {
        //            var existingPrDetails = await dbcontext.PRDetails
        //                .Include(pr => pr.Purchasedetails)
        //                .FirstOrDefaultAsync(pr => pr.prtblid == prDetail.prtblid);

        //            if (existingPrDetails == null)
        //            {
        //                return NotFound(new { Message = $"The specified PR details with id {prDetail.prtblid} do not exist." });
        //            }

        //            // Update pocreatedqty for existing PRDetails
        //            existingPrDetails.pocreatedqty += (float)prDetail.poquantity;
        //        }

        //        // Group items by poitemid to sum the quantities
        //        groupedItems = request
        //            .GroupBy(item => new { item.poitemid })
        //            .Select(g => new GroupedItem
        //            {
        //                PoItemId = g.Key.poitemid,
        //                TotalQuantity = g.Sum(x => x.poquantity), // Sum the quantities for items with the same poitemid
        //                UnitPrice = g.First().pounitprice, // Assuming unit price is the same for grouped items
        //                Make = g.First().make, // Assuming make is the same for grouped items
        //                orderid = g.First().orderid
        //            }).ToList();

        //        // Group items by poitemid and prtblid to sum the quantities
        //        groupedItemswithpr = request
        //            .GroupBy(item => new { item.poitemid, item.prtblid })
        //            .Select(g => new GroupedItem
        //            {
        //                PoItemId = g.Key.poitemid,
        //                prtblid = g.Key.prtblid,
        //                TotalQuantity = g.Sum(x => x.poquantity), // Sum the quantities for items with the same poitemid
        //                UnitPrice = g.First().pounitprice, // Assuming unit price is the same for grouped items
        //                Make = g.First().make, // Assuming make is the same for grouped items
        //                orderid = g.First().orderid
        //            }).ToList();

        //        foreach (var item in groupedItems)
        //        {
        //            // Create and insert a new purchase detail for the grouped item
        //            var purchaseDetails = new Purchasedetails
        //            {
        //                orderid = item.orderid,
        //                poitemid = item.PoItemId,
        //                poquantity = (decimal)item.TotalQuantity,
        //                pounitprice = (decimal)item.UnitPrice,
        //                make = item.Make
        //            };

        //            await dbcontext.Purchasedetails.AddAsync(purchaseDetails);
        //            purchasedetailsList.Add(purchaseDetails);

        //            // Link the purchaseDetails with the corresponding PRDetails
        //            var matchingRequestItem = request.FirstOrDefault(r => r.poitemid == item.PoItemId);

        //            // Only proceed if a matching item is found
        //            if (matchingRequestItem != null)
        //            {
        //                var existingPrDetail = await dbcontext.PRDetails
        //                    .Include(pr => pr.Purchasedetails)
        //                    .FirstOrDefaultAsync(pr => pr.prtblid == matchingRequestItem.prtblid);

        //                // Check if the existingPrDetail was found
        //                if (existingPrDetail != null)
        //                {
        //                    existingPrDetail.Purchasedetails.Add(purchaseDetails);
        //                }
        //            }
        //        }

        //        // Track distinct prtblid and potblid combinations
        //        var prpoEntries = new HashSet<(int prtblid, int potblid)>();

        //        // Create and insert PRPO entries for each distinct prtblid and potblid combination
        //        foreach (var item1 in groupedItemswithpr)
        //        {
        //            var existingPrDetail = await dbcontext.PRDetails
        //                .Include(pr => pr.Purchasedetails)
        //                .FirstOrDefaultAsync(pr => pr.prtblid == item1.prtblid);

        //            if (existingPrDetail != null)
        //            {
        //                var purchaseDetail = purchasedetailsList.FirstOrDefault(pd => pd.poitemid == item1.PoItemId);
        //                if (purchaseDetail != null)
        //                {
        //                    var prpoEntry = (item1.prtblid, purchaseDetail.potblid);
        //                    if (!prpoEntries.Contains(prpoEntry))
        //                    {
        //                        prpoEntries.Add(prpoEntry);

        //                        // Create a new PRPO entry for each combination of prtblid and potblid
        //                        var prpo = new PRPO
        //                        {
        //                            prdetailsprtblid = item1.prtblid, // Use the existing PRDetails' ID
        //                            Purchasedetailspotblid = purchaseDetail.potblid // The newly created Purchasedetails' ID
        //                        };

        //                        await dbcontext.PRPO.AddAsync(prpo);
        //                    }
        //                }
        //            }
        //        }

        //        await dbcontext.SaveChangesAsync();
        //        await transaction.CommitAsync();

        //        // Prepare the response DTO list
        //        var response = purchasedetailsList.Select(pd => new PODetailsDto
        //        {
        //            make = pd.make,
        //            pounitprice = (double)pd.pounitprice,
        //            poquantity = (double)pd.poquantity,
        //            poitemid = pd.poitemid,
        //            orderid = pd.orderid,
        //            potblid = pd.potblid, // This will be populated after saving
        //        }).ToList();

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync();
        //        return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
        //    }
        //}

        //[HttpPost("Addpodetails")]
        //public async Task<IActionResult> Addpodetails([FromBody] List<AddPODetailsDto> request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    using var transaction = await dbcontext.Database.BeginTransactionAsync();
        //    try
        //    {
        //        var purchasedetailsList = new List<Purchasedetails>();
        //        var groupedItems = new List<GroupedItem>();
        //        var groupedItemswithpr = new List<GroupedItem>();

        //        foreach (var prDetail in request)
        //        {
        //            var existingPrDetails = await dbcontext.PRDetails
        //                .Include(pr => pr.Purchasedetails)
        //                .FirstOrDefaultAsync(pr => pr.prtblid == prDetail.prtblid);

        //            if (existingPrDetails == null)
        //            {
        //                return NotFound(new { Message = $"The specified PR details with id {prDetail.prtblid} do not exist." });
        //            }

        //            // Update pocreatedqty for existing PRDetails
        //            existingPrDetails.pocreatedqty += (float)prDetail.poquantity;
        //        }

        //        // Group items by poitemid to sum the quantities
        //        groupedItems = request
        //            .GroupBy(item => new { item.poitemid })
        //            .Select(g => new GroupedItem
        //            {
        //                PoItemId = g.Key.poitemid,
        //                TotalQuantity = g.Sum(x => x.poquantity), // Sum the quantities for items with the same poitemid
        //                UnitPrice = g.First().pounitprice, // Assuming unit price is the same for grouped items
        //                Make = g.First().make, // Assuming make is the same for grouped items
        //                orderid = g.First().orderid
        //            }).ToList();

        //        // Group items by poitemid and prtblid to sum the quantities
        //        groupedItemswithpr = request
        //            .GroupBy(item => new { item.poitemid, item.prtblid })
        //            .Select(g => new GroupedItem
        //            {
        //                PoItemId = g.Key.poitemid,
        //                prtblid = g.Key.prtblid,
        //                TotalQuantity = g.Sum(x => x.poquantity), // Sum the quantities for items with the same poitemid
        //                UnitPrice = g.First().pounitprice, // Assuming unit price is the same for grouped items
        //                Make = g.First().make, // Assuming make is the same for grouped items
        //                orderid = g.First().orderid
        //            }).ToList();

        //        // Save purchase details and generate potblid
        //        foreach (var item in groupedItems)
        //        {
        //            //// Create and insert a new purchase detail for the grouped item
        //            //var purchaseDetails = new Purchasedetails
        //            //{
        //            //    orderid = item.orderid,
        //            //    poitemid = item.PoItemId,
        //            //    poquantity = (decimal)item.TotalQuantity,
        //            //    pounitprice = (decimal)item.UnitPrice,
        //            //    make = item.Make
        //            //};

        //            //await dbcontext.Purchasedetails.AddAsync(purchaseDetails);
        //            //purchasedetailsList.Add(purchaseDetails);
        //            var existingPurchaseDetail = await dbcontext.Purchasedetails
        //       .FirstOrDefaultAsync(pd => pd.poitemid == item.PoItemId && pd.orderid == item.orderid);

        //            if (existingPurchaseDetail != null)
        //            {
        //                // Update the existing purchase detail
        //                existingPurchaseDetail.poquantity += (decimal)item.TotalQuantity; // Update the quantity
        //                existingPurchaseDetail.pounitprice = (decimal)item.UnitPrice; // Update the price if needed
        //            }
        //            else
        //            {
        //                // Create and insert a new purchase detail for the grouped item
        //                var purchaseDetails = new Purchasedetails
        //                {
        //                    orderid = item.orderid,
        //                    poitemid = item.PoItemId,
        //                    poquantity = (decimal)item.TotalQuantity,
        //                    pounitprice = (decimal)item.UnitPrice,
        //                    make = item.Make
        //                };

        //                await dbcontext.Purchasedetails.AddAsync(purchaseDetails);
        //                purchasedetailsList.Add(purchaseDetails);
        //            }
        //        }

        //        // Save changes to generate potblid values
        //        await dbcontext.SaveChangesAsync();

        //        // Link the purchaseDetails with the corresponding PRDetails
        //        foreach (var item in groupedItems)
        //        {
        //            var matchingRequestItem = request.FirstOrDefault(r => r.poitemid == item.PoItemId);

        //            if (matchingRequestItem != null)
        //            {
        //                var existingPrDetail = await dbcontext.PRDetails
        //                    .Include(pr => pr.Purchasedetails)
        //                    .FirstOrDefaultAsync(pr => pr.prtblid == matchingRequestItem.prtblid);

        //                if (existingPrDetail != null)
        //                {
        //                    var purchaseDetail = purchasedetailsList.FirstOrDefault(pd => pd.poitemid == item.PoItemId);
        //                    if (purchaseDetail != null)
        //                    {
        //                        existingPrDetail.Purchasedetails.Add(purchaseDetail);
        //                    }
        //                }
        //            }
        //        }

        //        // Track distinct prtblid and potblid combinations
        //        var prpoEntries = new HashSet<(int prtblid, int potblid)>();

        //        // Create and insert PRPO entries for each distinct prtblid and potblid combination
        //        foreach (var item1 in groupedItemswithpr)
        //        {
        //            var existingPrDetail = await dbcontext.PRDetails
        //                .Include(pr => pr.Purchasedetails)
        //                .FirstOrDefaultAsync(pr => pr.prtblid == item1.prtblid);

        //            if (existingPrDetail != null)
        //            {
        //                var purchaseDetail = purchasedetailsList.FirstOrDefault(pd => pd.poitemid == item1.PoItemId);
        //                if (purchaseDetail != null)
        //                {
        //                    var prpoEntry = (item1.prtblid, purchaseDetail.potblid);
        //                    if (!prpoEntries.Contains(prpoEntry))
        //                    {
        //                        prpoEntries.Add(prpoEntry);

        //                        // Create a new PRPO entry for each combination of prtblid and potblid
        //                        var prpo = new PRPO
        //                        {
        //                            prdetailsprtblid = item1.prtblid, // Use the existing PRDetails' ID
        //                            Purchasedetailspotblid = purchaseDetail.potblid // The newly created Purchasedetails' ID
        //                        };

        //                        await dbcontext.PRPO.AddAsync(prpo);
        //                    }
        //                }
        //            }
        //        }

        //        await dbcontext.SaveChangesAsync();
        //        await transaction.CommitAsync();

        //        // Prepare the response DTO list
        //        var response = purchasedetailsList.Select(pd => new PODetailsDto
        //        {
        //            make = pd.make,
        //            pounitprice = (double)pd.pounitprice,
        //            poquantity = (double)pd.poquantity,
        //            poitemid = pd.poitemid,
        //            orderid = pd.orderid,
        //            potblid = pd.potblid, // This will be populated after saving
        //        }).ToList();

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync();
        //        return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
        //    }
        //}

        [HttpPost("Addpodetails")]
        public async Task<IActionResult> Addpodetails([FromBody] List<AddPODetailsDto> request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using var transaction = await dbcontext.Database.BeginTransactionAsync();
            try
            {
                var purchasedetailsList = new List<Purchasedetails>();
                var groupedItems = new List<GroupedItem>();
                var groupedItemswithpr = new List<GroupedItem>();

                foreach (var prDetail in request)
                {
                    var existingPrDetails = await dbcontext.PRDetails
                        .Include(pr => pr.Purchasedetails)
                        .FirstOrDefaultAsync(pr => pr.prtblid == prDetail.prtblid);

                    if (existingPrDetails == null)
                    {
                        return NotFound(new { Message = $"The specified PR details with id {prDetail.prtblid} do not exist." });
                    }

                    // Update pocreatedqty for existing PRDetails
                    existingPrDetails.pocreatedqty += prDetail.poquantity;
                }

                // Group items by poitemid to sum the quantities
                groupedItems = request
                    .GroupBy(item => new { item.poitemid })
                    .Select(g => new GroupedItem
                    {
                        PoItemId = g.Key.poitemid,
                        TotalQuantity = g.Sum(x => x.poquantity), // Sum the quantities for items with the same poitemid
                        UnitPrice = g.First().pounitprice,
                        Make = g.First().make,
                        orderid = g.First().orderid,
                        pouomid = g.First().pouomid,
                    }).ToList();

                // Group items by poitemid and prtblid to sum the quantities
                groupedItemswithpr = request
                    .GroupBy(item => new { item.poitemid, item.prtblid })
                    .Select(g => new GroupedItem
                    {
                        PoItemId = g.Key.poitemid,
                        prtblid = g.Key.prtblid,
                        TotalQuantity = g.Sum(x => x.poquantity),
                        UnitPrice = g.First().pounitprice,
                        Make = g.First().make,
                        orderid = g.First().orderid,
                        pouomid = g.First().pouomid,
                    }).ToList();

                // Save purchase details or update existing ones
                foreach (var item in groupedItems)
                {
                    // Check if a purchase detail already exists for this poitemid
                    var existingPurchaseDetail = await dbcontext.Purchasedetails
                        .FirstOrDefaultAsync(pd => pd.poitemid == item.PoItemId && pd.orderid == item.orderid);

                    if (existingPurchaseDetail != null)
                    {
                        // Update the existing purchase detail
                        existingPurchaseDetail.poquantity += (decimal)item.TotalQuantity; // Update the quantity
                        existingPurchaseDetail.pounitprice = (decimal)item.UnitPrice; // Update the price if needed
                        purchasedetailsList.Add(existingPurchaseDetail);
                    }
                    else
                    {
                        // Create and insert a new purchase detail for the grouped item
                        var purchaseDetails = new Purchasedetails
                        {
                            orderid = item.orderid,
                            poitemid = item.PoItemId,
                            poquantity = (decimal)item.TotalQuantity,
                            pounitprice = (decimal)item.UnitPrice,
                            make = item.Make,
                            pouomid = item.pouomid,
                        };

                        await dbcontext.Purchasedetails.AddAsync(purchaseDetails);
                        purchasedetailsList.Add(purchaseDetails);
                    }
                }

                // Save changes to generate potblid values
                await dbcontext.SaveChangesAsync();

                // Link the purchaseDetails with the corresponding PRDetails
                foreach (var item in groupedItems)
                {
                    var matchingRequestItem = request.FirstOrDefault(r => r.poitemid == item.PoItemId);

                    if (matchingRequestItem != null)
                    {
                        var existingPrDetail = await dbcontext.PRDetails
                            .Include(pr => pr.Purchasedetails)
                            .FirstOrDefaultAsync(pr => pr.prtblid == matchingRequestItem.prtblid);

                        if (existingPrDetail != null)
                        {
                            var purchaseDetail = purchasedetailsList.FirstOrDefault(pd => pd.poitemid == item.PoItemId);
                            if (purchaseDetail != null)
                            {
                                existingPrDetail.Purchasedetails.Add(purchaseDetail);
                            }
                        }
                    }
                }

                // Track distinct prtblid and potblid combinations
                var prpoEntries = new HashSet<(int prtblid, int potblid)>();

                // Create and insert PRPO entries for each distinct prtblid and potblid combination
                foreach (var item1 in groupedItemswithpr)
                {
                    var existingPrDetail = await dbcontext.PRDetails
                        .Include(pr => pr.Purchasedetails)
                        .FirstOrDefaultAsync(pr => pr.prtblid == item1.prtblid);

                    if (existingPrDetail != null)
                    {
                        var purchaseDetail = purchasedetailsList.FirstOrDefault(pd => pd.poitemid == item1.PoItemId);
                        if (purchaseDetail != null)
                        {
                            var prpoEntry = (item1.prtblid, purchaseDetail.potblid);
                            if (!prpoEntries.Contains(prpoEntry))
                            {
                                prpoEntries.Add(prpoEntry);

                                // Create a new PRPO entry for each combination of prtblid and potblid
                                var prpo = new PRPO
                                {
                                    prdetailsprtblid = item1.prtblid,
                                    Purchasedetailspotblid = purchaseDetail.potblid
                                };

                                await dbcontext.PRPO.AddAsync(prpo);
                            }
                        }
                    }
                }

                await dbcontext.SaveChangesAsync();
                await transaction.CommitAsync();

                // Prepare the response DTO list
                var response = purchasedetailsList.Select(pd => new PODetailsDto
                {
                    make = pd.make,
                    pounitprice = (double)pd.pounitprice,
                    poquantity = (double)pd.poquantity,
                    poitemid = pd.poitemid,
                    orderid = pd.orderid,
                    potblid = pd.potblid, // This will be populated after saving
                }).ToList();

                return Ok(response);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }




        //[HttpDelete("Deletepoline/{potblid}")]
        //public async Task<IActionResult> DeletePoline(int potblid)
        //{
        //    // Check if the POLine item exists
        //    var purchaseDetail = await dbcontext.Purchasedetails.FindAsync(potblid);
        //    if (purchaseDetail == null)
        //    {
        //        return NotFound(new { Message = $"The POLine item with id {potblid} does not exist." });
        //    }

        //    // Remove the item
        //    dbcontext.Purchasedetails.Remove(purchaseDetail);

        //    // Save changes to the database
        //    await dbcontext.SaveChangesAsync();

        //    return NoContent(); // 204 No Content response
        //}










        // [HttpDelete("Deletepoline/{potblid}")]
        //public async Task<IActionResult> DeletePoline(int potblid)
        //{
        //    using var transaction = await dbcontext.Database.BeginTransactionAsync();
        //    try
        //    {
        //        // Step 1: Find the POLine item (Purchase Order Line)
        //        var purchaseDetail = await dbcontext.Purchasedetails.FindAsync(potblid);
        //        if (purchaseDetail == null)
        //        {
        //            return NotFound(new { Message = $"The POLine item with ID {potblid} does not exist." });
        //        }

        //        // Step 2: Find all related PRPO entries linked to `potblid`
        //        var prpoEntries = await dbcontext.PRPO.Where(p => p.Purchasedetailspotblid == potblid).ToListAsync();
        //        if (!prpoEntries.Any())
        //        {
        //            return NotFound(new { Message = $"No PRPO entries found for POLine ID {potblid}." });
        //        }

        //        // Step 3: Process each PRPO entry and update PRDetails
        //        foreach (var prpoEntry in prpoEntries)
        //        {
        //            // Find the related PRDetail using `prtblid` from PRPO
        //            var prDetail = await dbcontext.PRDetails.FindAsync(prpoEntry.prdetailsprtblid);
        //            if (prDetail != null)
        //            {
        //                // Subtract the `poquantity` from `pocreatedqty`
        //                prDetail.pocreatedqty -= (float)purchaseDetail.poquantity;
        //            }
        //        }
        //        // Step 4: Remove the POLine entry
        //        dbcontext.Purchasedetails.Remove(purchaseDetail);

        //        // Step 5: Save changes to both tables
        //        await dbcontext.SaveChangesAsync();

        //        // Step 6: Commit transaction
        //        await transaction.CommitAsync();

        //        return NoContent(); // 204 No Content response
        //    }
        //    catch (Exception ex)
        //    {
        //        // Step 7: Rollback transaction in case of failure
        //        await transaction.RollbackAsync();
        //        return StatusCode(500, new { Message = "An error occurred while deleting the POLine.", Error = ex.Message });
        //    }
        //}


        //[HttpDelete("Deletepoline/{potblid}")]
        //public async Task<IActionResult> DeletePoline(int potblid)
        //{
        //    using var transaction = await dbcontext.Database.BeginTransactionAsync();
        //    try
        //    {
        //        // Step 1: Find the POLine item (Purchase Order Line) with the given potblid
        //        var purchaseDetail = await dbcontext.Purchasedetails.FindAsync(potblid);
        //        if (purchaseDetail == null)
        //        {
        //            return NotFound(new { Message = $"The POLine item with ID {potblid} does not exist." });
        //        }

        //        // Step 2: Find all related PRPO entries linked to potblid
        //        var prpoEntries = await dbcontext.PRPO.Where(p => p.Purchasedetailspotblid == potblid).ToListAsync();

        //        // Step 3: Process each PRPO entry to update PRDetails before deletion
        //        foreach (var prpoEntry in prpoEntries)
        //        {
        //            // Find the related PRDetail using `prdetailsprtblid`
        //            var prDetail = await dbcontext.PRDetails.FindAsync(prpoEntry.prdetailsprtblid);
        //            if (prDetail != null)
        //            {
        //                // Ensure the value doesn't go below zero
        //                prDetail.pocreatedqty = Math.Max(0, prDetail.pocreatedqty - (float)purchaseDetail.poquantity);

        //                // Mark as modified so it gets updated in the database
        //                dbcontext.PRDetails.Update(prDetail);
        //            }
        //        }

        //        // Step 4: Remove all related PRPO entries first
        //        if (prpoEntries.Any())
        //        {
        //            dbcontext.PRPO.RemoveRange(prpoEntries);
        //        }

        //        // Step 5: Remove the specific Purchasedetails entry
        //        dbcontext.Purchasedetails.Remove(purchaseDetail);

        //        // Step 6: Save all changes
        //        await dbcontext.SaveChangesAsync();

        //        // Step 7: Commit the transaction
        //        await transaction.CommitAsync();

        //        return NoContent(); // Success (204 No Content)
        //    }
        //    catch (Exception ex)
        //    {
        //        // Step 8: Rollback transaction in case of failure
        //        await transaction.RollbackAsync();
        //        return StatusCode(500, new { Message = "An error occurred while deleting the POLine.", Error = ex.Message });
        //    }
        //}





        [HttpDelete("Deletepoline/{potblid}")]
        public async Task<IActionResult> DeletePoline(int potblid)
        {
            using var transaction = await dbcontext.Database.BeginTransactionAsync();
            try
            {
                Console.WriteLine($"[DEBUG] Deleting POLine with ID: {potblid}");

                // Step 1: Find the POLine item (Purchase Order Line)
                var purchaseDetail = await dbcontext.Purchasedetails.FindAsync(potblid);
                if (purchaseDetail == null)
                {
                    Console.WriteLine($"[DEBUG] No Purchasedetails found for ID: {potblid}");
                    return NotFound(new { Message = $"The POLine item with ID {potblid} does not exist." });
                }
                Console.WriteLine($"[DEBUG] Found Purchasedetail: {purchaseDetail.potblid}");

                // Step 2: Find related PRPO entries
                var prpoEntries = await dbcontext.PRPO.Where(p => p.Purchasedetailspotblid == potblid).ToListAsync();
                Console.WriteLine($"[DEBUG] Found {prpoEntries.Count} related PRPO entries for POLine ID: {potblid}");

                // Step 3: Update PRDetails before deleting PRPO
                foreach (var prpoEntry in prpoEntries)
                {
                    var prDetail = await dbcontext.PRDetails.FindAsync(prpoEntry.prdetailsprtblid);
                    if (prDetail != null)
                    {
                        Console.WriteLine($"[DEBUG] Updating PRDetails ID: {prDetail.prtblid} | Old pocreatedqty: {prDetail.pocreatedqty}");
                        prDetail.pocreatedqty = Math.Max(0, prDetail.pocreatedqty - purchaseDetail.poquantity);
                        Console.WriteLine($"[DEBUG] New pocreatedqty: {prDetail.pocreatedqty}");
                        dbcontext.PRDetails.Update(prDetail);
                    }
                }

                // Step 4: Delete related PRPO records first
                if (prpoEntries.Any())
                {
                    Console.WriteLine($"[DEBUG] Deleting PRPO records for potblid: {potblid}");
                    dbcontext.PRPO.RemoveRange(prpoEntries);
                }

                // Step 5: Remove the specific Purchasedetails entry
                Console.WriteLine($"[DEBUG] Deleting Purchasedetails with ID: {potblid}");
                dbcontext.Purchasedetails.Remove(purchaseDetail);

                // Step 6: Save all changes
                await dbcontext.SaveChangesAsync();

                // Step 7: Commit the transaction
                await transaction.CommitAsync();
                Console.WriteLine($"[DEBUG] Successfully deleted POLine {potblid}");

                return NoContent(); // Success (204 No Content)
            }
            catch (Exception ex)
            {
                // Step 8: Rollback transaction in case of failure
                await transaction.RollbackAsync();
                Console.WriteLine($"[ERROR] Deletion failed: {ex.Message}");
                return StatusCode(500, new { Message = "An error occurred while deleting the POLine.", Error = ex.Message });
            }
        }























        [HttpGet("GetAllPOS")]
        public async Task<IActionResult> GetAllPOS()
        {
            var groupedPOData = await dbcontext.PO
             .Join(dbcontext.Purchasedetails,
                   po => po.Orderid,
                   pod => pod.orderid,
                   (po, pod) => new { po, pod })
             .GroupBy(x => new
             {
                 x.po.Orderid,
                 x.po.Supplier.suppliername,
                 x.po.Currency.currencyname,
                 x.po.Podate,
                 x.po.jobid,
                 x.po.poverifiedbyid,
                 x.po.postatus.postatusname,
                 x.po.postatusid,
                 x.po.PoAuthorizedbyid,
                 x.po.Poverifiedby.UserName,
                 x.po.poverifiedDate,
                 x.po.supplierid
             })
             .Select(g => new PODto
             {
                 Orderid = g.Key.Orderid,
                 jobid = g.Key.jobid,
                 suppliername = g.Key.suppliername,
                 Podate = g.Key.Podate,
                 poverifiedbyid = g.Key.poverifiedbyid,
                 postatusname = g.Key.postatusname,
                 postatusid = g.Key.postatusid,
                 poauthorizedbyid = g.Key.PoAuthorizedbyid,
                 poverifiedusername = g.Key.UserName,
                 poverifiedDate = g.Key.poverifiedDate,
                 currencyname = g.Key.currencyname,
                 supplierid = g.Key.supplierid,
                 TotalAmount = (decimal)g.Sum(x => (decimal)x.pod.poquantity * (decimal)x.pod.pounitprice),
                 TotalAmountinbasecurrency = (decimal)g.Sum(x => (decimal)x.pod.poquantity * (decimal)x.pod.pounitprice * (decimal)x.po.poexchangerate),

             })
             .ToListAsync();
            return Ok(groupedPOData);
        }













        //[HttpGet("GetAllPOS")]
        //public async Task<IActionResult> GetAllPOS()
        //{
        //    var groupedPOData = await dbcontext.PO
        //        // 1. Use GroupJoin for a Left Join. It groups all matching Purchasedetails (podGroup)
        //        //    for each Purchase Order (po).
        //        .GroupJoin(dbcontext.Purchasedetails,
        //            po => po.Orderid,
        //            pod => pod.orderid,
        //            (po, podGroup) => new
        //            {
        //                PO = po,
        //                Purchasedetails = podGroup
        //            })
        //        // 2. Select the final DTO and perform the aggregation (Sum) on the Purchasedetails group.
        //        .Select(x => new PODto
        //        {
        //            Orderid = x.PO.Orderid,
        //            jobid = x.PO.jobid,
        //            suppliername = x.PO.Supplier.suppliername,
        //            Podate = x.PO.Podate,
        //            poverifiedbyid = x.PO.poverifiedbyid,
        //            postatusname = x.PO.postatus.postatusname,
        //            postatusid = x.PO.postatusid,
        //            poauthorizedbyid = x.PO.PoAuthorizedbyid,
        //            poverifiedusername = x.PO.Poverifiedby.UserName,
        //            poverifiedDate = x.PO.poverifiedDate,
        //            currencyname = x.PO.Currency.currencyname,
        //            supplierid = x.PO.supplierid,

        //            // Calculate TotalAmount: Sum the products in the Purchasedetails group.
        //            // Using (decimal?) and ?? 0M ensures the sum is 0 if a PO has no details.
        //            TotalAmount = (decimal)(x.Purchasedetails
        //                .Sum(pod => (decimal?)pod.poquantity * (decimal?)pod.pounitprice) ?? 0M),

        //            // Calculate TotalAmountinbasecurrency
        //            TotalAmountinbasecurrency = (decimal)(x.Purchasedetails
        //                .Sum(pod => (decimal?)pod.poquantity * (decimal?)pod.pounitprice * (decimal?)x.PO.poexchangerate) ?? 0M),
        //        })
        //        .ToListAsync();

        //    return Ok(groupedPOData);
        //}






















        //public class VerifyPORequest
        //{
        //    public string UserId { get; set; }
        //    public List<int> ForderId { get; set; }
        //}
        //[HttpPost("VerifyPOs")]
        //public async Task<IActionResult> VerifyPOs([FromBody] VerifyPORequest request)
        //{
        //    if (request == null || string.IsNullOrEmpty(request.UserId) || request.ForderId == null || request.ForderId.Count == 0)
        //    {
        //        return BadRequest("Invalid request data.");
        //    }
        //    bool isVerified;
        //    // Perform the PO verification logic here
        //    try
        //    {
        //        var pos = await dbcontext.PO.Where(po => request.ForderId.Contains(po.Orderid)).ToListAsync();

        //        foreach (var po in pos)
        //        {
        //            po.poverifiedbyid = request.UserId;
        //            po.postatusid = 2;
        //            po.poverifiedDate=DateTime.Now;
        //        }

        //        await dbcontext.SaveChangesAsync();
        //        isVerified= true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception and handle errors
        //        // logger.LogError(ex, "Error verifying POs");
        //        isVerified = false ;
        //    }

        //    if (isVerified)
        //    {
        //        return Ok(new { message = "POs verified successfully." });
        //    }
        //    else
        //    {
        //        return StatusCode(500, "An error occurred while verifying POs.");
        //    }
        //}












        [HttpGet("GetMaxReceivedEntry")]
        public async Task<int?> GetMaxReceivedEntry()

        {
            // Get the maximum PR ID from the PurchaseRequest table
            int maxrenoPlusOne = (await dbcontext.ReceivedEntry.MaxAsync(pr => (int?)pr.REID) ?? 5000) + 1;

            return maxrenoPlusOne;
        }








        [HttpGet("GetMaxReceiptVoucher")]
        public async Task<int?> GetMaxReceiptVoucher()

        {
            // Get the maximum PR ID from the PurchaseRequest table
            int maxrvnoPlusOne = (await dbcontext.ReceiptVoucher.MaxAsync(pr => (int?)pr.receiptid) ?? 5000) + 1;

            return maxrvnoPlusOne;
        }
























        [HttpGet("GetpodetailsbyPONO1")]
        public async Task<IActionResult> GetpodetailsbyPONO1([FromQuery] int pono)
        {

            var receivedItemCodes = await (from rh in dbcontext.ReceivedEntry
                                           join red in dbcontext.ReceivedEntryDetails on rh.REID equals red.RENO
                                           where rh.pono == pono // Filter ReceivedEntryHeader by PONO
                                           select red.itemid)  // Select ItemCode from ReceivedEntryDetails
                                .ToListAsync();
            var purchasedetails = await dbcontext.Purchasedetails
          .Where(p => p.orderid == pono
                      && p.poquantity > p.receivedentryqty
                      && !receivedItemCodes.Contains(p.poitemid)
                      && p.PO.postatusid == 3) // Assuming 'PO' is the navigation property for the PO table
          .Include(p => p.product) // Including the 'Product' navigation property
          .Include(p => p.PO) // Including the PO to filter based on postatusid
          .ToListAsync();
            return Ok(purchasedetails);
        }














        [HttpGet("GetpodetailsbyPONO2")]
        public async Task<IActionResult> GetpodetailsbyPONO2([FromQuery] int pono)
        {
            //+p.insprejectedqty

            var purchasedetails = await dbcontext.Purchasedetails
          .Where(p => p.orderid == pono
                      && (p.poquantity - p.receivedentryqty) > 0
                      && p.PO.postatusid == 3) // Assuming 'PO' is the navigation property for the PO table
          .Include(p => p.product) // Including the 'Product' navigation property
          .Include(p => p.PO) // Including the PO to filter based on postatusid
          .ToListAsync();
            return Ok(purchasedetails);
        }

















        [HttpGet("GetREheaderdetailsbyreno")]
        public async Task<IActionResult> GetREheaderdetailsbyreno([FromQuery] int reno)
        {
            var reheaderdetails = await dbcontext.ReceivedEntry
                .Include(re => re.PO) // Eagerly load the PurchaseOrderHeader
        .ThenInclude(po => po.Supplier)
                .Where(p => p.REID == reno) // Assuming PONO is a property in your Purchasedetails model
                .ToListAsync();
            return Ok(reheaderdetails);
        }





        [HttpPost("AddReceivedEntryHeader")]
        public async Task<IActionResult> AddReceivedEntryHeader(AddReceivedEntry request)
        {

            try
            {
                var receivedEntry = new ReceivedEntry
                {



                    location = request.location,
                    REID = request.REID,
                    pono = request.pono,
                    REDate = request.REDate,
                    Remarks = request.Remarks






                };

                await dbcontext.ReceivedEntry.AddAsync(receivedEntry);
                await dbcontext.SaveChangesAsync();
                var response = new ReceivedEntryDto
                {
                    Remarks = request.Remarks,
                    REDate = request.REDate,
                    pono = request.pono,
                    REID = request.REID,
                    location = request.location


                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // e.g., logger.LogError(ex, "An error occurred while adding PR header");

                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }



        //public async Task AddReceivedEntryDetailAsync(AddReceivedEntryDetails request)
        //{
        //    var entryDetails = new ReceivedEntryDetails
        //    {
        //        RENO = request.RENO,
        //        receivedqty = request.receivedqty,  


        //    });

        //    await _context.ReceivedEntryDetails.AddRangeAsync(entryDetails);
        //    await _context.SaveChangesAsync();
        //}














        [HttpPost("AddOrUpdateReceivedEntryDetailsAsync")]
        public async Task<IActionResult> AddOrUpdateReceivedEntryDetailsAsync(Addorupdatereceivedentrydetails dto)
        {
            try
            {
                // Find existing received entry
                var existingEntry = await dbcontext.ReceivedEntry
                    .FirstOrDefaultAsync(e => e.REID == dto.REID);

                if (existingEntry != null)
                {
                    // Update existing entry
                    existingEntry.pono = dto.pono;
                    existingEntry.REDate = dto.REDate;
                    existingEntry.location = dto.location;
                    existingEntry.Remarks = dto.Remarks;
                    dbcontext.ReceivedEntry.Update(existingEntry);
                }
                else
                {
                    // Create a new received entry
                    existingEntry = new ReceivedEntry
                    {
                        REID = dto.REID, // Assuming REID is generated elsewhere or provided
                        pono = dto.pono,
                        REDate = dto.REDate,
                        location = dto.location,
                        Remarks = dto.Remarks
                    };

                    await dbcontext.ReceivedEntry.AddAsync(existingEntry);
                }

                await dbcontext.SaveChangesAsync();

                // Insert or update details
                foreach (var item in dto.ReceivedEntryDetails)
                {
                    var detail = new ReceivedEntryDetails
                    {


                        potblid = item.potblid,
                        // Associate with the received entry
                        itemid = item.poitemid,
                        receivedqty = item.receivingqty,
                        RENO = item.RENO
                    };

                    await dbcontext.ReceivedEntryDetails.AddAsync(detail);
                }

                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Received entry and details saved successfully." });
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                // Log.Error(ex, "An error occurred while processing the received entry details.");

                // Return a generic error message to the client
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }
























































        [HttpGet("CheckUnregisteredReceivedEntries")]
        public async Task<IActionResult> CheckUnregisteredReceivedEntries(int pono)
        {
            var isUnregistered = await dbcontext.ReceivedEntry
                                               .Where(re => re.pono == pono && re.isregistered == 0)
                                               .AnyAsync();
            return Ok(isUnregistered);
        }






        [HttpGet("GetReceivedEntryLineDetailsbyReceivedID")]
        public async Task<IActionResult> GetReceivedEntryLineDetailsbyReceivedID(int reno)
        {
            var receivedentrydetails = await dbcontext.ReceivedEntryDetails
     .Where(p => p.RENO == reno)
     .Include(p => p.Product) // Assuming 'Product' is the navigation property in 'Purchasedetail'
     .ToListAsync();
            return Ok(receivedentrydetails);
        }

        [HttpDelete("DeleteReceivedEntryDetails")]
        public async Task<bool> DeleteReceivedEntryDetails(int rtblid)
        {
            var entry = await dbcontext.ReceivedEntryDetails.FindAsync(rtblid);
            if (entry == null)
            {
                return false;
            }

            dbcontext.ReceivedEntryDetails.Remove(entry);
            await dbcontext.SaveChangesAsync();
            return true;
        }

        [HttpGet("GetPendingGrnPurchaseDetails")]
        public async Task<IActionResult> GetPendingGrnPurchaseDetails()
        {
            var reheaderdetails = await dbcontext.Purchasedetails
                .Where(p => p.inspacceptedqty > p.grncreatedqty) // Filter where inspacceptedqty is greater than grncreatedqty
                .Include(p => p.PO)
                .Include(p => p.product)
                .Include(p => p.UOM)
                .Include(p => p.product.UOM)
                // Include related PurchaseOrder data
                .Where(p => p.PO.postatusid == 3) // Filter only authorized PurchaseOrders
                .ToListAsync();
            return Ok(reheaderdetails);
        }


        [HttpGet("GetMaxGRNNumber")]
        public async Task<IActionResult> GetMaxGRNNumber()

        {
            var maxgrnNumber = await dbcontext.GRNHeader.MaxAsync(po => (int?)po.grnno) ?? 200;
            var nextmaxgrnNumber = maxgrnNumber + 1;
            return Ok(nextmaxgrnNumber);
        }

        [HttpPost("AddOrUpdategrn")]
        public async Task<IActionResult> AddOrUpdategrn(AddorUpdateGRNDetails dto)
        {
            using var transaction = await dbcontext.Database.BeginTransactionAsync();
            try
            {
                var unregisteredGRNs = await dbcontext.GRNHeader
                    .Where(e => e.isregistered == 0 && e.grnno != dto.grnno)
                    .ToListAsync();

                if (unregisteredGRNs.Any())
                {
                    return BadRequest(new { Message = "Cannot save GRN because there are unregistered GRNs with the same GRN number." });
                }

                // Find existing received entry
                var existingEntry = await dbcontext.GRNHeader
                    .FirstOrDefaultAsync(e => e.grnno == dto.grnno);

                if (existingEntry != null)
                {
                    // Update existing entry
                    existingEntry.pono = dto.pono;
                    existingEntry.grndate = dto.grndate;
                    existingEntry.currencyid = dto.currencyid;
                    existingEntry.billofentrydate = dto.billofentrydate;
                    existingEntry.billofentryno = dto.billofentryno;
                    existingEntry.remarks = dto.remarks;
                    existingEntry.dono = dto.dono;
                    dbcontext.GRNHeader.Update(existingEntry);
                }
                else
                {
                    // Create a new received entry
                    existingEntry = new GRNHeader
                    {
                        pono = dto.pono,
                        grndate = dto.grndate,
                        grnno = dto.grnno,
                        currencyid = dto.currencyid,
                        billofentrydate = dto.billofentrydate,
                        billofentryno = dto.billofentryno,
                        dono = dto.dono,
                        remarks = dto.remarks,


                    };

                    await dbcontext.GRNHeader.AddAsync(existingEntry);
                }
                await dbcontext.SaveChangesAsync();
                // Insert or update details
                foreach (var item in dto.grndetails)
                {
                    var detail = new GRNDetails
                    {
                        grnno = dto.grnno,
                        itemcode = item.itemid,
                        grnqty = item.grnqty,
                        pouomid = item.pouomid,
                        inventoryuomid = item.inuomid,
                        multiplyingfactor = item.mf,
                        pounitprice = item.pounitprice,
                        location = item.location
                    };

                    await dbcontext.GRNDetails.AddAsync(detail);
                }

                await dbcontext.SaveChangesAsync();

                // Commit transaction after all operations succeed
                await transaction.CommitAsync();

                return Ok(new { Message = "GRN entry and details saved successfully." });
            }
            catch (Exception ex)
            {
                // Rollback transaction in case of an error
                await transaction.RollbackAsync();

                // Log the error for debugging purposes
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }





        [HttpGet("GetGRNHeaderDetailsbygrnno")]
        public async Task<IActionResult> GetGRNHeaderDetailsbygrnno(int grnno)
        {
            try
            {

                var grnheader = await dbcontext.GRNHeader
      .Include(po => po.PO)
      .Include(po => po.Currency)// Include the Supplier related entity
      .Where(po => po.grnno == grnno)
      .FirstOrDefaultAsync();
                if (grnheader == null)
                {
                    return NotFound();
                }
                return Ok(grnheader);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });

            }





        }







        [HttpDelete("Deletegrndetailsbygrnno")]
        public async Task<bool> Deletegrndetailsbygrnno(int grntblid)
        {
            var entry = await dbcontext.GRNDetails.FindAsync(grntblid);
            if (entry == null)
            {
                return false;
            }

            dbcontext.GRNDetails.Remove(entry);
            await dbcontext.SaveChangesAsync();
            return true;
        }





        [HttpGet("GetPOItemtobeissuedbyjobid")]
        public async Task<IActionResult> GetPOItemtobeissuedbyjobid([FromQuery] int jobid)
        {
            var poitemsissuedbyjobid = await (
      from rh in dbcontext.Inventory
      join red in dbcontext.Product on rh.productid equals red.productcode
      where rh.jobid == jobid
      group rh by red.productcode into grouped
      select new
      {
          ItemId = grouped.Key,
          ItemName = grouped.Select(g => g.Product.itemname).FirstOrDefault(),
          productcode = grouped.Select(g => g.productid),

          TotalQty = (double)grouped.Sum(x => x.quantity)
      }
  ).ToListAsync();

            return Ok(poitemsissuedbyjobid);
        }



        [HttpGet("GetissueHeaderDetailsbyissuenref")]
        public async Task<IActionResult> GetissueHeaderDetailsbyissuenref(int issueref)
        {

            try
            {

                var issueheader = await dbcontext.IssueNoteheader
              .Where(po => po.issueref == issueref)
              .FirstOrDefaultAsync();
                if (issueheader == null)
                {
                    return NotFound();
                }
                return Ok(issueheader);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }




        [HttpGet("GetListPOIssuenoteheader")]
        public async Task<IActionResult> GetListPOIssuenoteheader()

        {
            try
            {

                var issueheader = await dbcontext.IssueNoteheader
              .Where(po => po.issuetype == "PO")
              .ToListAsync();
                if (issueheader == null)
                {
                    return NotFound();
                }
                return Ok(issueheader);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }









        [HttpGet("listdeliverynote")]
        public async Task<IActionResult> listdeliverynote()

        {
            try
            {

                var deliverynotes = await dbcontext.DeliveryNote
             .Include(dn => dn.Customer)
              .ToListAsync();
                if (deliverynotes == null)
                {
                    return NotFound();
                }
                return Ok(deliverynotes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }


















        [HttpGet("listgrn")]
        public async Task<IActionResult> listgrn()

        {
            try
            {

                var grndetails = await dbcontext.GRNHeader

              .ToListAsync();
                if (grndetails == null)
                {
                    return NotFound();
                }
                return Ok(grndetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }



        [HttpGet("listissuereturn")]
        public async Task<IActionResult> listissuereturn()

        {
            try
            {

                var issuereturndetails = await dbcontext.Issuereturn
        .Where(x => x.issuereturntype == "Stock")
        .ToListAsync();
                if (issuereturndetails == null)
                {
                    return NotFound();
                }
                return Ok(issuereturndetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }



        [HttpGet("listpoissuereturn")]
        public async Task<IActionResult> listpoissuereturn()

        {
            try
            {

                var issuereturndetails = await dbcontext.Issuereturn
        .Where(x => x.issuereturntype == "PO")
        .ToListAsync();
                if (issuereturndetails == null)
                {
                    return NotFound();
                }
                return Ok(issuereturndetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }










        [HttpGet("listreceiptvoucher")]
        public async Task<IActionResult> listreceiptvoucher()

        {
            try
            {

                var receiptvoucher = await dbcontext.ReceiptVoucher
             .Include(dn => dn.Customer)
              .ToListAsync();
                if (receiptvoucher == null)
                {
                    return NotFound();
                }
                return Ok(receiptvoucher);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }





















        [HttpGet("GetMaxIssuenoteno")]
        public async Task<int?> GetMaxIssuenoteno()
        {
            // Get the maximum PR ID from the PurchaseRequest table
            int maxissuenoPlusOne = (await dbcontext.IssueNoteheader.MaxAsync(pr => (int?)pr.issueref) ?? 5000) + 1;
            return maxissuenoPlusOne;
        }



        [HttpPost("Addorupdateissuenote")]
        public async Task<IActionResult> Addorupdateissuenote(AddorupdateIssuenotedetails dto)
        {
            try
            {
                var unregisteredIssueNotes = await dbcontext.IssueNoteheader
      .Where(e => e.isregistered == 0 && e.issueref != dto.issueref && e.jobid == dto.jobid && e.issuetype == dto.issuetype)
      .ToListAsync();

                if (unregisteredIssueNotes.Any())
                {
                    // Return unregistered Issue Notes in the response and stop further processing
                    return Ok(new { Message = "UnregisteredIssuenote" });
                }


                // Find existing received entry
                var existingEntry = await dbcontext.IssueNoteheader
                    .FirstOrDefaultAsync(e => e.issueref == dto.issueref);

                if (existingEntry != null)
                {
                    // Update existing entry
                    existingEntry.issueref = dto.issueref;
                    existingEntry.jobid = dto.jobid;
                    existingEntry.issuedate = dto.issuedate;
                    existingEntry.Remarks = dto.Remarks;
                    existingEntry.issuedto = dto.issuedto;
                    dbcontext.IssueNoteheader.Update(existingEntry);
                }
                else
                {
                    // Create a new received entry
                    existingEntry = new IssueNoteheader
                    {
                        // Assuming REID is generated elsewhere or provided
                        issueref = dto.issueref,
                        jobid = dto.jobid,
                        issuedate = dto.issuedate,
                        Remarks = dto.Remarks,
                        issuedto = dto.issuedto,
                        issuetype = dto.issuetype,


                    };

                    await dbcontext.IssueNoteheader.AddAsync(existingEntry);
                }

                await dbcontext.SaveChangesAsync();

                // Insert or update details
                foreach (var item in dto.issuedetails)
                {
                    var detail = new Issuenotedetails
                    {


                        issuenoteref = dto.issueref,
                        // Associate with the received entry
                        itemid = item.itemid,
                        issueqty = item.issueqty,
                        issueunitprice = item.issueunitprice

                    };

                    await dbcontext.Issuenotedetails.AddAsync(detail);
                }

                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Issue note  entry and details saved successfully." });
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                // Log.Error(ex, "An error occurred while processing the received entry details.");

                // Return a generic error message to the client
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }


























        }














        [HttpGet("GetIssuenotedetailsbyissueno")]
        public async Task<IActionResult> GetIssuenotedetailsbyissueno(int issueref)
        {
            var issuedetails = await (from po in dbcontext.Issuenotedetails
                                      join ii in dbcontext.Product on po.itemid equals ii.productcode


                                      where po.issuenoteref == issueref
                                      select new
                                      {
                                          po.issuedetailid,
                                          po.Product.itemname,
                                          po.issueqty,
                                          po.itemid,
                                          po.issueunitprice,

                                          ii.productcode

                                          // You can include other fields from PRPO if needed
                                      }).ToListAsync();
            if (issuedetails == null)
            {
                return NotFound();
            }
            return Ok(issuedetails);
        }





        public class DeductInventoryRequest
        {
            public int ItemId { get; set; }
            public decimal RequestedQuantity { get; set; }
            public int Jobid { get; set; }
            public int issueref { get; set; }
        }
        public class DeductInventoryRequest12
        {
            public int ItemId { get; set; }
            public decimal qty { get; set; }

        }
        public class DeductInventoryRequestPO
        {
            public int ItemId { get; set; }
            public decimal qty { get; set; }

            public int jobid { get; set; }

        }


        [HttpPost("DeductInventory")]
        public IActionResult DeductInventory([FromBody] DeductInventoryRequest request)
        {
            using (var transaction = dbcontext.Database.BeginTransaction())
            {
                try
                {
                    var batches = new List<Batchrev1>();
                    var remainingQuantity = request.RequestedQuantity;

                    var inventoryItems = dbcontext.Inventory
                        .Where(i => i.productid == request.ItemId && i.jobid == request.Jobid)
                        .OrderBy(i => i.Entrydate)
                        .ToList();

                    foreach (var item in inventoryItems)
                    {
                        batches.Add(new Batchrev1(item.batchid, item.quantity, item.invid, item.invcurrencyid, item.uomid, item.invprice, item.billofentryno ?? "", item.billofentrydate));
                    }

                    foreach (var batch in batches)
                    {
                        if (remainingQuantity <= 0) break;

                        var quantityToDeduct = Math.Min(remainingQuantity, batch.Quantity);
                        DeductFromBatch(request.ItemId, batch.BatchID, quantityToDeduct, request.Jobid, request.issueref, batch.Invid, batch.Currencyid, batch.Uomid, batch.Price, batch.billofentryno ?? "", batch.billofentrydate);
                        remainingQuantity -= quantityToDeduct;
                    }
                    var issuenoteheader = dbcontext.IssueNoteheader
                        .FirstOrDefault(i => i.issueref == request.issueref);

                    if (issuenoteheader != null)
                    {
                        issuenoteheader.isregistered = 1;
                    }

                    dbcontext.SaveChanges();
                    transaction.Commit();


                    return Ok(new { Message = "Issue Note Registered" });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }

        private void DeductFromBatch(int itemId, int batchId, decimal quantity, int jobid, int issueref, int invid, int Currencyid, int Uomid, decimal Price, string billofentryno, DateTime? billofentrydate)
        {
            var inventoryItem = dbcontext.Inventory
                .FirstOrDefault(i => i.productid == itemId && i.batchid == batchId && i.jobid == jobid);

            if (inventoryItem != null)
            {
                inventoryItem.quantity -= quantity;

                var issuetrack = new Issuetracking
                {
                    productid = itemId,
                    jobid = jobid, // Assuming jobid is part of the entry details
                    issuenoteno = issueref,
                    issueqty = quantity,
                    issuedate = DateTime.UtcNow.Date,
                    invid = invid,
                    issuecurrencyid = Currencyid,
                    issueunitprice = Price,
                    issueuomid = Uomid,
                    billofentryno = billofentryno,
                    billofentrydate = billofentrydate


                    // Assign the retrieved invid here
                };



                dbcontext.Issuetracking.Add(issuetrack);
                if (inventoryItem.quantity <= 0)
                {
                    dbcontext.Inventory.Remove(inventoryItem);
                }














































            }


















        }





        [HttpGet("GetCategorydetailsbyBudgetheaderid")]
        public async Task<IActionResult> GetCategorydetailsbyBudgetheaderid(int budgetheaderid)
        {
            if (budgetheaderid <= 0)
            {
                return BadRequest("Invalid Budgetheaderid");
            }
            var categorydetails = await dbcontext.Category
       .Where(x => x.budgetheaderid == budgetheaderid)
       .ToListAsync();

            if (categorydetails == null)
            {
                return NotFound("Currency not found");
            }
            return Ok(categorydetails);

        }



        //[HttpGet("GetInvoiceRegistrationdetailsbyjobid")]
        //public async Task<IActionResult> GetInvoiceRegistrationdetailsbyjobid(int jobid)
        //{
        //    if (jobid <= 0)
        //    {
        //        return BadRequest("Invalid jobid");
        //    }

        //    var invoiceregdetails = await dbcontext.InvoiceReg
        //        .Include(i => i.Customer)
        //        .Include(i => i.Currency)
        //        .Where(x => x.jobid == jobid)
        //        .ToListAsync();

        //    if (!invoiceregdetails.Any())
        //    {
        //        return NotFound("Invoice registration details not found");
        //    }

        //    return Ok(invoiceregdetails);
        //}




        [HttpGet("GetInvoiceRegistrationdetailsbyjobid")]
        public async Task<IActionResult> GetInvoiceRegistrationdetailsbyjobid(int jobid)
        {
            if (jobid <= 0)
            {
                return BadRequest("Invalid jobid");
            }

            var invoiceregdetails = await (from aa in dbcontext.Invoice
                                           join bb in dbcontext.InvoiceReg on aa.invoiceno equals bb.invoiceno
                                           join ii in dbcontext.Invoicedetails on aa.invoiceno equals ii.invoiceno
                                           join jj in dbcontext.Job on aa.jobid equals jj.Jobid
                                           join cc in dbcontext.Currency on aa.invcurrencyid equals cc.currencyid
                                           where aa.jobid == jobid
                                           group new { ii, aa, cc, jj } by new { aa.invoiceno, cc.currencyname, jj.exchangerate } into g
                                           select new
                                           {
                                               Invoiceno = g.Key.invoiceno,
                                               CurrencyName = g.Key.currencyname,
                                               TotalAmountinbasecurrency = g.Sum(x => (string.IsNullOrEmpty(x.ii.amount) ? 0 : Convert.ToDecimal(x.ii.amount)) * x.jj.exchangerate),

                                               TotalAmount = g.Sum(x => (string.IsNullOrEmpty(x.ii.amount) ? 0 : Convert.ToDouble(x.ii.amount)))
                                           })
                                           .ToListAsync();

            if (!invoiceregdetails.Any())
            {
                return NotFound(new { message = "Invoice Registration not Found ." });
            }

            return Ok(invoiceregdetails);
        }

















        [HttpGet("GetCurrencyfromPO")]
        public async Task<IActionResult> GetCurrencyfromPO(int pono)

        {
            if (pono <= 0)
            {
                return BadRequest("Invalid");
            }
            var podetails = await dbcontext.PO
                .Include(po => po.Currency)
       .Where(x => x.Orderid == pono)
       .FirstOrDefaultAsync();

            if (podetails == null)
            {
                return NotFound("Currency not found");
            }
            return Ok(podetails);

        }







        [HttpGet("GetProductdetailsbyitemid")]
        public async Task<IActionResult> GetProductdetailsbyitemid(int itemid)

        {
            if (itemid <= 0)
            {
                return BadRequest("Invalid");
            }
            var podetails = await dbcontext.Product
                .Include(po => po.BudgettHeader)
                .Include(po => po.Category)
                .Include(po => po.SubCategory)
       .Where(x => x.itemid == itemid)
       .FirstOrDefaultAsync();

            if (podetails == null)
            {
                return NotFound("Product not found");
            }
            return Ok(podetails);

        }





























        [HttpGet("GetPRPendingList")]
        public async Task<IActionResult> GetPRPendingList()
        {
            var prpendinglist = await (from rh in dbcontext.PR
                                       join red in dbcontext.PRDetails on rh.PRID equals red.prid
                                       join ii in dbcontext.Product on red.pritemid equals ii.productcode
                                       join uu in dbcontext.UOM on red.pruomid equals uu.uomid

                                       where rh.prstatusid == 3 && red.prqty > (red.pocreatedqty + red.prstockqty)
                                       select new
                                       {
                                           rh.PRID,  // You may include other fields from PR as required
                                           ii.itemname,  // Product name
                                           ii.productcode,  // Product code
                                           red.prqty,  // Total quantity requested
                                           red.pocreatedqty,  // Quantity already created (PO created qty)
                                           uu.uomname,  // Unit of measure
                                           PendingQty = red.prqty - (red.pocreatedqty + red.prstockqty),  // Pending quantity calculation
                                           rh.jobid,  // Job ID
                                           red.prtblid,  // PR Details table ID
                                           itemid = ii.productcode,
                                           rh.prcreatedbyid,
                                           prcreatedbyname = rh.prcreatedby.UserName  // Assigns "N/A" if UserName is null
                                       }).ToListAsync();
            return Ok(prpendinglist);
        }
        public class PrPendingList
        {

            public decimal ivenbalance { get; set; }
            public int PRID { get; set; }
            public decimal totalinventory { get; set; }
            public string itemname { get; set; }
            public string productcode { get; set; }
            public decimal prqty { get; set; }
            public decimal pocreatedqty { get; set; }
            public string uomname { get; set; }
            public decimal PendingQty { get; set; } // Matches the CAST to FLOAT in SQL
            public int jobid { get; set; }
            public int prtblid { get; set; }
            public string itemid { get; set; } // Note: SQL selects 'productcode' as 'itemid'
            public string prcreatedbyid { get; set; } // Assuming GUID or string for AspNetUsers.Id
            public string prcreatedbyname { get; set; }
        }

        // GET: api/PR/GetPRPendingList


        [HttpGet("GetPRPendingList1")]
        public async Task<ActionResult<List<PrPendingList>>> GetPRPendingList1()
        {
            var prPendingList = new List<PrPendingList>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("SP_GetPRPendingListrv2", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // No parameters are needed for this stored procedure

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            prPendingList.Add(new PrPendingList
                            {
                                PRID = reader.GetInt32(reader.GetOrdinal("PRID")),
                                itemname = reader["itemname"].ToString(),
                                productcode = reader["productcode"].ToString(),

                                totalinventory = reader.GetDecimal(reader.GetOrdinal("totalinventory")),
                                ivenbalance = reader.GetDecimal(reader.GetOrdinal("ivenbalance")),

                                prqty = reader.GetDecimal(reader.GetOrdinal("prqty")),
                                pocreatedqty = reader.GetDecimal(reader.GetOrdinal("pocreatedqty")),
                                uomname = reader["uomname"].ToString(),
                                PendingQty = reader.GetDecimal(reader.GetOrdinal("PendingQty")), // Read as double
                                jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                prtblid = reader.GetInt32(reader.GetOrdinal("prtblid")),
                                itemid = reader["itemid"].ToString(), // Map to the aliased 'itemid'
                                prcreatedbyid = reader["prcreatedbyid"] == DBNull.Value ? null : reader["prcreatedbyid"].ToString(), // Handle potential null
                                prcreatedbyname = reader["prcreatedbyname"] == DBNull.Value ? null : reader["prcreatedbyname"].ToString() // Handle potential null
                            });
                        }
                    }
                }
            }

            if (prPendingList.Count == 0)
            {
                return NotFound("No pending PR items found.");
            }

            return Ok(prPendingList);
        }

        [HttpGet("GetPrdetailsbyprtblid")]
        public async Task<IActionResult> GetPrdetailsbyprtblid(int prtblid)
        {
            var prdetails = await (from po in dbcontext.PRDetails
                                   join ii in dbcontext.Product on po.pritemid equals ii.itemid
                                   join pou in dbcontext.UOM on po.pruomid equals pou.uomid
                                   join pr in dbcontext.PR on po.prid equals pr.PRID
                                   where po.prtblid == prtblid
                                   select new
                                   {
                                       pr.PRID,
                                       pr.jobid,
                                       po.prtblid,
                                       po.Product.itemname,
                                       po.prqty,
                                       pouomname = pou.uomname,
                                       po.prstockqty,
                                       po.pocreatedqty,
                                       // You can include other fields from PRPO if needed
                                   }).ToListAsync();
            if (prdetails == null)
            {
                return NotFound();
            }
            return Ok(prdetails);
        }














        [HttpGet("Getstorestockdetailsbyitemid")]
        public async Task<IActionResult> Getstorestockdetailsbyitemid(int itemid)
        {
            var stockdetails = await (from inv in dbcontext.Inventory
                                      join ii in dbcontext.Product on inv.productid equals ii.productcode
                                      join jj in dbcontext.Job on inv.jobid equals jj.Jobid
                                      join jy in dbcontext.JobType on jj.jobtypeid equals jy.jobtypeid
                                      where jy.JobtypeName == "Miscellaneous" && inv.productid == itemid
                                      && inv.quantity - inv.reservedqty > 0
                                      select new
                                      {
                                          inv.invid,  // You may include other fields from PR as required
                                          ii.itemname,  // Example, adjust to your actual column names
                                          ii.productcode,  // Assuming ItemCode is in PRDetails
                                          inv.quantity,  // Total quantity requested
                                          inv.jobid,
                                          inv.pono,
                                          inv.reservedqty,
                                          inv.Entrydate,


                                      }).ToListAsync();
            return Ok(stockdetails);
        }




        [HttpPost("Reservestock")]
        public IActionResult Reservestock([FromBody] ReserveStockRequest request)
        {
            using (var transaction = dbcontext.Database.BeginTransaction())
            {
                try
                {
                    var batches = new List<Batch1>();
                    var prqty = request.prqty;
                    //var inventoryItems = dbcontext.Inventory
                    //    .Where(i => i.productid == request.itemid && i.jobid == request.jobid)
                    //    .OrderBy(i => i.Entrydate)
                    //    .ToList();


                    var inventoryItems = (from inv in dbcontext.Inventory
                                          join ii in dbcontext.Product on inv.productid equals ii.productcode
                                          join jj in dbcontext.Job on inv.jobid equals jj.Jobid
                                          join jy in dbcontext.JobType on jj.jobtypeid equals jy.jobtypeid
                                          where jy.JobtypeName == "Miscellaneous" && inv.productid == request.itemid
                                          && inv.quantity - inv.reservedqty > 0
                                          orderby inv.Entrydate
                                          select new
                                          {
                                              inv.invid,  // You may include other fields from PR as required
                                              ii.itemname,  // Example, adjust to your actual column names
                                              ii.productcode,  // Assuming ItemCode is in PRDetails
                                              inv.quantity,  // Total quantity requested
                                              inv.jobid,
                                              inv.pono,
                                              inv.reservedqty,
                                              inv.Entrydate,
                                              inv.invprice,
                                              inv.uomid,
                                              inv.invcurrencyid

                                          }).ToList();

                    foreach (var item in inventoryItems)
                    {
                        batches.Add(new Batch1(item.quantity - item.reservedqty, item.invid, item.jobid, request.jobid, item.uomid, item.invprice, item.invcurrencyid));
                    }
                    foreach (var batch in batches)
                    {
                        if (prqty <= 0) break;
                        var quantityToreserve = Math.Min(prqty, batch.Quantity);
                        reserve(request.itemid, quantityToreserve, batch.Invid, request.prtblid, request.jobid, batch.Fromjobid, batch.Uomid, batch.Invunitprice, batch.Invcurrencyid);
                        prqty -= quantityToreserve;
                    }


                    dbcontext.SaveChanges();
                    transaction.Commit();

                    return Ok(new { Message = "ok" });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }

        private void reserve(int itemId, decimal quantity, int invid, int prtblid, int tojob, int fromjob, int uomid, decimal unitprice, int invcurrencyid)
        {
            var inventoryItem = dbcontext.Inventory
                .FirstOrDefault(i => i.productid == itemId && i.invid == invid);


            var prdetails = dbcontext.PRDetails
              .FirstOrDefault(i => i.prtblid == prtblid);

            if (inventoryItem != null)
            {
                inventoryItem.reservedqty += quantity;

                var inventoryReservation = new Inventoryreservation
                {
                    inventoryid = invid,  // Inventory ID
                    fromjobid = fromjob,  // From Job ID
                    tojobid = tojob,      // To Job ID
                    reservedqty = quantity,  // Reserved Quantity
                    productid = itemId,      // Product ID
                    uomid = uomid,           // Unit of Measure ID
                    invunitprice = unitprice,  // Unit Price
                    issuecreatedqty = 0,
                    reservationtime = DateTime.Now,
                    prtblid = prtblid,
                    invrcurrencyid = invcurrencyid

                    // Set initial value to 0 (or whatever the logic requires)
                };

                // Add the new Inventoryreservation to the context
                dbcontext.Inventoryreservation.Add(inventoryReservation);
















                dbcontext.SaveChanges();
            }
            if (prdetails != null)
            {
                prdetails.prstockqty += quantity;
                dbcontext.SaveChanges();
            }













        }


        public class ReserveStockRequest
        {
            public int itemid { get; set; }
            public decimal prqty { get; set; }
            public int prtblid { get; set; }
            public int jobid { get; set; }

        }










        public class InventoryResult
        {
            public int? invid { get; set; }
            public decimal inventory { get; set; }
            public decimal price { get; set; }
            public string uom { get; set; }
            public string currency { get; set; }
            public string itemname { get; set; }
            public int jobid { get; set; }
            public double rate { get; set; }
            public int jobtypeid { get; set; }
            public string jobtypename { get; set; }

            public int budgetheaderid { get; set; }

            public string budgetheadername { get; set; }
            public string categoryname { get; set; }
            public int categoryid { get; set; }

            public string subcategoryname { get; set; }
            public int subcategoryid { get; set; }

            public string location { get; set; }

            public string? billofentryno { get; set; }
            public DateTime? billofentrydate { get; set; }

            public int productcode { get; set; }

            public DateTime date { get; set; }

        }



        [HttpGet("GetJobStageByJobNo/{jobno}")]
        public async Task<IActionResult> GetJobStageByJobNo(int jobno)
        {
            var job = await dbcontext.Job
                .Where(j => j.Jobid == jobno)
                .Select(j => new { j.Jobid, j.jobstageid }) // Adjust property names as needed
                .FirstOrDefaultAsync();

            if (job == null)
                return NotFound("Job not found");

            return Ok(job);
        }



        //[HttpGet("GetInventoryAsOfDate")]
        //public async Task<List<InventoryResult>> GetInventoryAsOfDate(DateTime targetDate)
        //{
        //    var totalReceived = await (from grn in dbcontext.grntracking
        //                               join product in dbcontext.Product on grn.productid equals product.itemid
        //                               join currency in dbcontext.Currency on grn.grncurrencyid equals currency.currencyid
        //                               join uom in dbcontext.UOM on grn.grnuomid equals uom.uomid
        //                               where  grn.grndate <= targetDate
        //                               group grn by new { grn.invid, grn.grnunitprice, grn.grnuomid, grn.grncurrencyid, product.itemname, currency.currencyname, uom.uomname, currency.exchangerate } into g
        //                               select new
        //                               {
        //                                   Invid = g.Key.invid,
        //                                   TotalGrnQty = g.Sum(grn => grn.grnqty),
        //                                   Price = g.Key.grnunitprice,
        //                                   Uom = g.Key.uomname,
        //                                   Currency = g.Key.currencyname,
        //                                   Itemname = g.Key.itemname, 
        //                                   rate=g.Key.exchangerate, 
        //                               }).ToListAsync();

        //    var totalIssued = await (from issue in dbcontext.Issuetracking
        //                             join product in dbcontext.Product on issue.productid equals product.itemid
        //                             join currency in dbcontext.Currency on issue.issuecurrencyid equals currency.currencyid
        //                             join uom in dbcontext.UOM on issue.issueuomid equals uom.uomid
        //                             where  issue.issuedate <= targetDate
        //                             group issue by new { issue.invid, issue.issueunitprice, issue.issueuomid, issue.issuecurrencyid, product.itemname, currency.currencyname, uom.uomname, currency.exchangerate } into g
        //                             select new
        //                             {
        //                                 Invid = g.Key.invid,
        //                                 TotalissueQty = g.Sum(grn => grn.issueqty),
        //                                 Price = g.Key.issueunitprice,
        //                                 Uom = g.Key.uomname,
        //                                 Currency = g.Key.currencyname,
        //                                 Itemname = g.Key.itemname,
        //                                 rate = g.Key.exchangerate,
        //                             }).ToListAsync();

        //    var inventory = totalReceived
        //        .GroupJoin(totalIssued,
        //            r => r.Invid,
        //            i => i.Invid,
        //            (r, i) => new { Received = r, Issued = i.DefaultIfEmpty() })
        //        .SelectMany(
        //            x => x.Issued.Select(i => new InventoryResult
        //            {
        //                invid = x.Received.Invid,
        //                inventory = x.Received.TotalGrnQty - (i?.TotalissueQty ?? 0),
        //                price = x.Received.Price,
        //                uom = x.Received.Uom,
        //                currency = x.Received.Currency,
        //                itemname = x.Received.Itemname,
        //                rate=x.Received.rate


        //            }))
        //        .Union(totalIssued
        //            .Where(i => !totalReceived.Any(r => r.Invid == i.Invid))
        //            .Select(i => new InventoryResult
        //            {
        //                invid= i.Invid,
        //                inventory = 0 - i.TotalissueQty,
        //                price = i.Price,
        //                uom = i.Uom,
        //                currency = i.Currency,
        //                itemname = i.Itemname,
        //                rate = i.rate
        //            }))
        //        .OrderBy(result => result.invid)
        //        .ToList();

        //    return inventory;
        //}

        //[HttpGet("GetInventoryAsOfDate")]
        //public async Task<List<InventoryResult>> GetInventoryAsOfDate(DateTime targetDate)
        //{
        //    // Step 1: Get the total received, issued, and returned quantities,
        //    // grouped only by the inventory ID (invid) to ensure all transactions for an item are summed.
        //    // We convert these into dictionaries for efficient lookups later.

        //    // Total Received Quantities
        //    var receivedData = await (from grn in dbcontext.grntracking
        //                              where grn.grndate <= targetDate
        //                              group grn by grn.invid into g
        //                              select new
        //                              {
        //                                  Invid = g.Key,
        //                                  TotalGrnQty = g.Sum(grn => grn.grnqty)
        //                              }).ToDictionaryAsync(x => x.Invid, x => x.TotalGrnQty);

        //    // Total Issued Quantities
        //    var issuedData = await (from issue in dbcontext.Issuetracking
        //                            where issue.issuedate <= targetDate
        //                            group issue by issue.invid into g
        //                            select new
        //                            {
        //                                Invid = g.Key,
        //                                TotalIssueQty = g.Sum(issue => issue.issueqty)
        //                            }).ToDictionaryAsync(x => x.Invid, x => x.TotalIssueQty);

        //    // Total Returned Quantities
        //    var returnedData = await (from returnTrack in dbcontext.issuereturntracking
        //                              where returnTrack.issuereturndate <= targetDate
        //                              group returnTrack by returnTrack.invid into g
        //                              select new
        //                              {
        //                                  Invid = g.Key,
        //                                  TotalReturnQty = g.Sum(returnTrack => returnTrack.issuereturnqty)
        //                              }).ToDictionaryAsync(x => x.Invid, x => x.TotalReturnQty);

        //    // Step 2: Get all unique inventory items (invids) from all three transaction types
        //    // by adding the keys to a HashSet. This is an efficient and robust way to get a unique list.
        //    var allInvids = new HashSet<int>(receivedData.Keys);
        //    allInvids.UnionWith(issuedData.Keys);
        //    allInvids.UnionWith(returnedData.Keys);

        //    // Step 3: Get a representative GRN record for each unique invid to fetch descriptive properties.
        //    // We'll filter the grntracking table by our list of unique invids.
        //    var representativeGrnRecords = await (from grn in dbcontext.grntracking
        //                                          where allInvids.Contains(grn.invid)
        //                                          group grn by grn.invid into g
        //                                          select g.OrderByDescending(x => x.grndate).FirstOrDefault())
        //                                         .ToListAsync();

        //    // Step 4: Use a single LINQ query to calculate the final inventory and join with the descriptive records.
        //    var finalInventory = await (from invid in allInvids
        //                                    // Join with the representative GRN records we fetched
        //                                join grn in representativeGrnRecords on invid equals grn.invid
        //                                // Join with other descriptive tables
        //                                join product in dbcontext.Product on grn.productid equals product.productcode
        //                                join currency in dbcontext.Currency on grn.grncurrencyid equals currency.currencyid
        //                                join uom in dbcontext.UOM on grn.grnuomid equals uom.uomid
        //                                join jj in dbcontext.Job on grn.jobid equals jj.Jobid
        //                                join jt in dbcontext.JobType on jj.jobtypeid equals jt.jobtypeid
        //                                join bh in dbcontext.BudgettHeader on product.itembudgetheaderid equals bh.budgetheaderid
        //                                join ct in dbcontext.Category on product.categoryid equals ct.categoryid
        //                                join st in dbcontext.SubCategory on product.subcategoryid equals st.subcategoryid
        //                                select new InventoryResult
        //                                {
        //                                    invid = invid,
        //                                    inventory = (receivedData.ContainsKey(invid) ? receivedData[invid] : 0) -
        //                                                (issuedData.ContainsKey(invid) ? issuedData[invid] : 0) +
        //                                                (returnedData.ContainsKey(invid) ? returnedData[invid] : 0),
        //                                    price = grn.grnunitprice,
        //                                    uom = uom.uomname,
        //                                    currency = currency.currencyname,
        //                                    itemname = product.itemname,
        //                                    rate = currency.exchangerate,
        //                                    jobid = grn.jobid,
        //                                    jobtypename = jt.JobtypeName,
        //                                    jobtypeid = jt.jobtypeid,
        //                                    budgetheaderid = bh.budgetheaderid,
        //                                    budgetheadername = bh.budgetheadername,
        //                                    categoryname = ct.categoryname,
        //                                    categoryid = ct.categoryid,
        //                                    subcategoryname = st.subcategoryname,
        //                                    subcategoryid = st.subcategoryid,
        //                                    location = grn.location,
        //                                    billofentrydate = grn.billofentrydate,
        //                                    billofentryno = grn.billofentryno,
        //                                    productcode = product.productcode,
        //                                    date = grn.grndate
        //                                })
        //                                .Where(x => x.inventory != 0)
        //                                .OrderBy(result => result.invid)
        //                                .ToListAsync();

        //    return finalInventory;
        //}
        [HttpGet("GetInventoryAsOfDate")]
        public async Task<List<InventoryResult>> GetInventoryAsOfDate(DateTime targetDate)
        {
            // Total Received Quantities
            var totalReceived = await (from grn in dbcontext.grntracking
                                       join product in dbcontext.Product on grn.productid equals product.productcode
                                       join currency in dbcontext.Currency on grn.grncurrencyid equals currency.currencyid
                                       join uom in dbcontext.UOM on grn.grnuomid equals uom.uomid
                                       join jj in dbcontext.Job on grn.jobid equals jj.Jobid
                                       join jt in dbcontext.JobType on jj.jobtypeid equals jt.jobtypeid
                                       join bh in dbcontext.BudgettHeader on product.itembudgetheaderid equals bh.budgetheaderid
                                       join ct in dbcontext.Category on product.categoryid equals ct.categoryid
                                       join st in dbcontext.SubCategory on product.subcategoryid equals st.subcategoryid
                                       where grn.grndate <= targetDate
                                       group grn by new
                                       {
                                           grn.invid,
                                           grn.grnunitprice,
                                           grn.grnuomid,
                                           grn.grncurrencyid,
                                           product.itemname,
                                           product.productcode,
                                           grn.grndate,

                                           currency.currencyname,
                                           uom.uomname,
                                           currency.exchangerate,
                                           grn.jobid,
                                           grn.location,
                                           grn.billofentryno,
                                           grn.billofentrydate,
                                           jt.jobtypeid,
                                           jt.JobtypeName,
                                           bh.budgetheadername,
                                           bh.budgetheaderid,
                                           ct.categoryname,
                                           ct.categoryid,
                                           st.subcategoryid,
                                           st.subcategoryname

                                       } into g
                                       select new
                                       {
                                           Invid = g.Key.invid,
                                           TotalGrnQty = g.Sum(grn => grn.grnqty),
                                           Price = g.Key.grnunitprice,
                                           Uom = g.Key.uomname,
                                           Currency = g.Key.currencyname,
                                           Itemname = g.Key.itemname,

                                           productcode = g.Key.productcode,
                                           Rate = g.Key.exchangerate,
                                           jobid = g.Key.jobid,
                                           jobtypeid = g.Key.jobtypeid,
                                           location = g.Key.location,
                                           grndate = g.Key.grndate,
                                           billofentryno = g.Key.billofentryno,
                                           billofentrydate = g.Key.billofentrydate,
                                           jobtypename = g.Key.JobtypeName,


                                           budgetheadername = g.Key.budgetheadername,
                                           budgetheaderid = g.Key.budgetheaderid,
                                           categoryname = g.Key.categoryname,
                                           categoryid = g.Key.categoryid,

                                           subcategoryname = g.Key.subcategoryname,
                                           subcategoryid = g.Key.subcategoryid,
                                           date = g.Key.grndate,
                                           produtcode = g.Key.productcode



                                       }).ToListAsync();

            // Total Issued Quantities
            var totalIssued = await (from issue in dbcontext.Issuetracking
                                     join product in dbcontext.Product on issue.productid equals product.productcode
                                     join currency in dbcontext.Currency on issue.issuecurrencyid equals currency.currencyid
                                     join uom in dbcontext.UOM on issue.issueuomid equals uom.uomid

                                     join jj in dbcontext.Job on issue.jobid equals jj.Jobid
                                     join jt in dbcontext.JobType on jj.jobtypeid equals jt.jobtypeid
                                     join bh in dbcontext.BudgettHeader on product.itembudgetheaderid equals bh.budgetheaderid
                                     join ct in dbcontext.Category on product.categoryid equals ct.categoryid
                                     join st in dbcontext.SubCategory on product.subcategoryid equals st.subcategoryid

                                     where issue.issuedate <= targetDate
                                     group issue by new
                                     {
                                         issue.invid,
                                         issue.issueunitprice,
                                         issue.issueuomid,
                                         issue.issuecurrencyid,
                                         issue.location,
                                         product.itemname,
                                         product.productcode,
                                         currency.currencyname,
                                         uom.uomname,
                                         currency.exchangerate,
                                         issue.jobid,
                                         jt.JobtypeName,
                                         bh.budgetheadername,
                                         bh.budgetheaderid,
                                         jt.jobtypeid,
                                         ct.categoryname,
                                         ct.categoryid,
                                         st.subcategoryid,
                                         st.subcategoryname,
                                         issue.billofentrydate,
                                         issue.billofentryno,
                                         issue.issuedate,


                                     } into g
                                     select new
                                     {
                                         Invid = g.Key.invid,
                                         TotalIssueQty = g.Sum(issue => issue.issueqty),
                                         location = g.Key.location,
                                         Price = g.Key.issueunitprice,
                                         Uom = g.Key.uomname,
                                         Currency = g.Key.currencyname,
                                         Itemname = g.Key.itemname,
                                         Rate = g.Key.exchangerate,
                                         jobid = g.Key.jobid,
                                         jobtypename = g.Key.JobtypeName,
                                         budgetheadername = g.Key.budgetheadername,
                                         budgetheaderid = g.Key.budgetheaderid,
                                         jobtypeid = g.Key.jobtypeid,
                                         categoryid = g.Key.categoryid,
                                         categoryname = g.Key.categoryname,
                                         subcategoryid = g.Key.subcategoryid,
                                         subcategoryname = g.Key.subcategoryname,
                                         billofentryno = g.Key.billofentryno,
                                         billofentrydate = g.Key.billofentrydate,

                                         date = g.Key.issuedate,
                                         produtcode = g.Key.productcode


                                     }).ToListAsync();

            // Total Returned Quantities
            var totalReturned = await (from returnTrack in dbcontext.issuereturntracking
                                       join product in dbcontext.Product on returnTrack.productid equals product.productcode
                                       join currency in dbcontext.Currency on returnTrack.issuecurrencyid equals currency.currencyid
                                       join uom in dbcontext.UOM on returnTrack.uomid equals uom.uomid

                                       join jj in dbcontext.Job on returnTrack.jobid equals jj.Jobid
                                       join jt in dbcontext.JobType on jj.jobtypeid equals jt.jobtypeid
                                       join bh in dbcontext.BudgettHeader on product.itembudgetheaderid equals bh.budgetheaderid
                                       join ct in dbcontext.Category on product.categoryid equals ct.categoryid
                                       join st in dbcontext.SubCategory on product.subcategoryid equals st.subcategoryid
                                       where returnTrack.issuereturndate <= targetDate
                                       group returnTrack by new
                                       {
                                           returnTrack.invid,
                                           returnTrack.issuereturnunitprice,
                                           returnTrack.uomid,
                                           returnTrack.issuecurrencyid,

                                           returnTrack.location,
                                           returnTrack.billofentryno,
                                           returnTrack.billofentrydate,
                                           product.itemname,
                                           currency.currencyname,
                                           uom.uomname,
                                           currency.exchangerate,
                                           returnTrack.jobid,
                                           jt.JobtypeName,
                                           bh.budgetheadername,
                                           bh.budgetheaderid,
                                           jt.jobtypeid,
                                           ct.categoryname,
                                           ct.categoryid,
                                           st.subcategoryid,
                                           st.subcategoryname,
                                           returnTrack.issuereturndate,
                                           product.productcode
                                       } into g
                                       select new
                                       {
                                           Invid = g.Key.invid,
                                           TotalReturnQty = g.Sum(returnTrack => returnTrack.issuereturnqty),
                                           Price = g.Key.issuereturnunitprice,
                                           Uom = g.Key.uomname,
                                           Currency = g.Key.currencyname,
                                           Itemname = g.Key.itemname,
                                           Rate = g.Key.exchangerate,
                                           jobid = g.Key.jobid,

                                           jobtypename = g.Key.JobtypeName,
                                           budgetheadername = g.Key.budgetheadername,
                                           budgetheaderid = g.Key.budgetheaderid,
                                           jobtypeid = g.Key.jobtypeid,
                                           categoryid = g.Key.categoryid,
                                           categoryname = g.Key.categoryname,
                                           subcategoryid = g.Key.subcategoryid,
                                           subcategoryname = g.Key.subcategoryname,
                                           location = g.Key.location,
                                           billofentryno = g.Key.billofentryno,
                                           billofentrydate = g.Key.billofentrydate,
                                           date = g.Key.issuereturndate,
                                           produtcode = g.Key.productcode


                                       }).ToListAsync();

            // Adjust issued quantities by subtracting returned quantities
            var adjustedIssued = totalIssued.GroupJoin(
                totalReturned,
                issue => issue.Invid,
                returned => returned.Invid,
                (issue, returns) => new
                {
                    issue.Invid,
                    TotalAdjustedIssueQty = issue.TotalIssueQty - (returns?.Sum(r => r.TotalReturnQty) ?? 0),
                    issue.Price,
                    issue.Uom,
                    issue.Currency,
                    issue.Itemname,
                    issue.Rate,
                    issue.jobid,
                    issue.jobtypename,
                    issue.jobtypeid,
                    issue.budgetheaderid,
                    issue.budgetheadername,
                    issue.categoryname,
                    issue.categoryid,
                    issue.subcategoryname,
                    issue.subcategoryid,
                    issue.location,
                    issue.billofentrydate,
                    issue.billofentryno,
                    issue.produtcode,
                    issue.date


                }).ToList();

            // Inventory Calculation
            var inventory = totalReceived
                .GroupJoin(adjustedIssued,
                    r => r.Invid,
                    i => i.Invid,
                    (r, i) => new { Received = r, Issued = i.DefaultIfEmpty() })
                .SelectMany(
                    x => x.Issued.Select(i => new
                    {
                        Received = x.Received,
                        Issued = i,
                        Returned = totalReturned.FirstOrDefault(ir => ir.Invid == x.Received.Invid) // Match issuereturn
                    }))
                .Select(x => new InventoryResult
                {
                    invid = x.Received.Invid,
                    inventory = x.Received.TotalGrnQty
                                - (x.Issued?.TotalAdjustedIssueQty ?? 0)
                                + (x.Returned?.TotalReturnQty ?? 0), // Calculate inventory including returns
                    price = x.Received.Price,
                    uom = x.Received.Uom,
                    currency = x.Received.Currency,
                    itemname = x.Received.Itemname,
                    rate = x.Received.Rate,
                    jobid = x.Received.jobid,
                    jobtypename = x.Received.jobtypename,
                    jobtypeid = x.Received.jobtypeid,
                    budgetheaderid = x.Received.budgetheaderid,
                    budgetheadername = x.Received.budgetheadername,


                    categoryname = x.Received.categoryname,
                    categoryid = x.Received.categoryid,
                    subcategoryname = x.Received.subcategoryname,
                    subcategoryid = x.Received.subcategoryid,
                    location = x.Received.location,
                    billofentrydate = x.Received.billofentrydate,
                    billofentryno = x.Received.billofentryno,
                    productcode = x.Received.productcode,
                    date = x.Received.date


                })
                .Union(totalIssued
                    .Where(i => !totalReceived.Any(r => r.Invid == i.Invid))
                    .Select(i => new InventoryResult
                    {
                        invid = i.Invid,
                        inventory = 0 - i.TotalIssueQty
                                    + (totalReturned.FirstOrDefault(ir => ir.Invid == i.Invid)?.TotalReturnQty ?? 0), // Handle returns for issued-only items
                        price = i.Price,
                        uom = i.Uom,
                        currency = i.Currency,
                        itemname = i.Itemname,
                        rate = i.Rate,
                        jobid = i.jobid,
                        jobtypename = i.jobtypename,
                        jobtypeid = i.jobtypeid,
                        budgetheaderid = i.budgetheaderid,
                        budgetheadername = i.budgetheadername,

                        categoryid = i.categoryid,
                        categoryname = i.categoryname,
                        subcategoryid = i.subcategoryid,
                        subcategoryname = i.subcategoryname,
                        location = i.location,
                        billofentryno = i.billofentryno,
                        billofentrydate = i.billofentrydate,
                        productcode = i.produtcode,
                        date = i.date

                    }))
                .Union(totalReturned
                    .Where(r => !totalReceived.Any(grn => grn.Invid == r.Invid) && !totalIssued.Any(issue => issue.Invid == r.Invid))
                    .Select(r => new InventoryResult
                    {
                        invid = r.Invid,
                        inventory = r.TotalReturnQty, // Only returns are present
                        price = r.Price,
                        uom = r.Uom,
                        currency = r.Currency,
                        itemname = r.Itemname,
                        rate = r.Rate,
                        jobid = r.jobid,
                        jobtypename = r.jobtypename,
                        jobtypeid = r.jobtypeid,
                        budgetheaderid = r.budgetheaderid,
                        budgetheadername = r.budgetheadername,

                        categoryid = r.categoryid,
                        categoryname = r.categoryname,
                        subcategoryid = r.subcategoryid,
                        subcategoryname = r.subcategoryname,

                        location = r.location,

                        billofentryno = r.billofentryno,

                        billofentrydate = r.billofentrydate,
                        date = r.date,
                        productcode = r.produtcode




                    }))
                .OrderBy(result => result.invid)
                .Where(x => x.inventory != 0)
                .ToList();

            return inventory;
        }










        [HttpGet("GetStockdetailsbyjobandproductcode")]
        public async Task<IActionResult> GetStockdetailsbyjobandproductcode(
            [FromQuery] int productcode,
            [FromQuery] int jobid)
        {


            var stockQuery = await dbcontext.Inventory
    .Where(i => i.productid == productcode && i.jobid == jobid && i.quantity != 0)
    .Include(i => i.Product) // pulls in product table
    .ToListAsync();

            return Ok(stockQuery);
        }































        //[HttpGet("GetInventoryAsOfDateitemwise")]
        //public async Task<List<InventoryResult>> GetInventoryAsOfDateitemwise(DateTime targetDate)
        //{
        //    var totalReceived = await (from grn in dbcontext.grntracking
        //                               join product in dbcontext.Product on grn.productid equals product.productcode
        //                               join currency in dbcontext.Currency on grn.grncurrencyid equals currency.currencyid
        //                               join uom in dbcontext.UOM on grn.grnuomid equals uom.uomid
        //                               join bh in dbcontext.BudgettHeader on product.itembudgetheaderid equals bh.budgetheaderid
        //                               join ct in dbcontext.Category on product.categoryid equals ct.categoryid
        //                               join st in dbcontext.SubCategory on product.subcategoryid equals st.subcategoryid
        //                               where grn.grndate <= targetDate
        //                               group grn by new
        //                               {
        //                                   // Grouping by itemname and related static product info
        //                                   product.itemname,
        //                                   product.productcode, // Including productcode to represent invid if needed later
        //                                   // Removed grn.grnunitprice from group key
        //                                   // Removed grn.grnuomid, grn.grncurrencyid, currency.currencyname, uom.uomname, currency.exchangerate
        //                                   // These will need aggregation or a representative value
        //                                   bh.budgetheadername,
        //                                   bh.budgetheaderid,
        //                                   ct.categoryname,
        //                                   ct.categoryid,
        //                                   st.subcategoryid,
        //                                   st.subcategoryname
        //                               } into g
        //                               select new
        //                               {
        //                                   Itemname = g.Key.itemname,
        //                                   Invid = g.Key.productcode, // Taking a representative invid (productcode)
        //                                   TotalGrnQty = g.Sum(grn => grn.grnqty),
        //                                   // Calculating a weighted average price for received items
        //                                   Price = g.Sum(grn => grn.grnqty * grn.grnunitprice * currency.exc) / g.Sum(grn => grn.grnqty),
        //                                   // Taking representative UOM, Currency, Rate from the group.
        //                                   // This assumes UOM/Currency/Rate are consistent for a given itemname.
        //                                   // If not, you'll need to decide how to aggregate them (e.g., string.Join, pick first, etc.)
        //                                   Uom = g.First().UOM.uomname, // Assumes UOM is consistent for an itemname
        //                                   Currency = g.First().currency.currencyname, // Assumes Currency is consistent for an itemname
        //                                   Rate = g.First().currency.exchangerate, // Assumes Rate is consistent for an itemname
        //                                   budgetheadername = g.Key.budgetheadername,
        //                                   budgetheaderid = g.Key.budgetheaderid,
        //                                   categoryname = g.Key.categoryname,
        //                                   categoryid = g.Key.categoryid,
        //                                   subcategoryname = g.Key.subcategoryname,
        //                                   subcategoryid = g.Key.subcategoryid
        //                               }).ToListAsync();

        //    // Total Issued Quantities
        //    var totalIssued = await (from issue in dbcontext.Issuetracking
        //                             join product in dbcontext.Product on issue.productid equals product.productcode
        //                             join currency in dbcontext.Currency on issue.issuecurrencyid equals currency.currencyid
        //                             join uom in dbcontext.UOM on issue.issueuomid equals uom.uomid
        //                             join bh in dbcontext.BudgettHeader on product.itembudgetheaderid equals bh.budgetheaderid
        //                             join ct in dbcontext.Category on product.categoryid equals ct.categoryid
        //                             join st in dbcontext.SubCategory on product.subcategoryid equals st.subcategoryid
        //                             where issue.issuedate <= targetDate
        //                             group issue by new
        //                             {
        //                                 product.itemname,
        //                                 product.productcode,
        //                                 bh.budgetheadername,
        //                                 bh.budgetheaderid,
        //                                 ct.categoryname,
        //                                 ct.categoryid,
        //                                 st.subcategoryid,
        //                                 st.subcategoryname
        //                             } into g
        //                             select new
        //                             {
        //                                 Itemname = g.Key.itemname,
        //                                 Invid = g.Key.productcode,
        //                                 TotalIssueQty = g.Sum(issue => issue.issueqty),
        //                                 Price = g.Sum(issue => issue.issueqty * issue.issueunitprice) / g.Sum(issue => issue.issueqty),
        //                                 Uom = g.First().UOM.uomname,
        //                                 Currency = g.First().currency.currencyname,
        //                                 Rate = g.First().currency.exchangerate,
        //                                 budgetheadername = g.Key.budgetheadername,
        //                                 budgetheaderid = g.Key.budgetheaderid,
        //                                 categoryid = g.Key.categoryid,
        //                                 categoryname = g.Key.categoryname,
        //                                 subcategoryid = g.Key.subcategoryid,
        //                                 subcategoryname = g.Key.subcategoryname
        //                             }).ToListAsync();

        //    // Total Returned Quantities
        //    var totalReturned = await (from returnTrack in dbcontext.issuereturntracking
        //                               join product in dbcontext.Product on returnTrack.productid equals product.productcode
        //                               join currency in dbcontext.Currency on returnTrack.issuecurrencyid equals currency.currencyid
        //                               join uom in dbcontext.UOM on returnTrack.uomid equals uom.uomid
        //                               join bh in dbcontext.BudgettHeader on product.itembudgetheaderid equals bh.budgetheaderid
        //                               join ct in dbcontext.Category on product.categoryid equals ct.categoryid
        //                               join st in dbcontext.SubCategory on product.subcategoryid equals st.subcategoryid
        //                               where returnTrack.issuereturndate <= targetDate
        //                               group returnTrack by new
        //                               {
        //                                   product.itemname,
        //                                   product.productcode,
        //                                   bh.budgetheadername,
        //                                   bh.budgetheaderid,
        //                                   ct.categoryname,
        //                                   ct.categoryid,
        //                                   st.subcategoryid,
        //                                   st.subcategoryname
        //                               } into g
        //                               select new
        //                               {
        //                                   Itemname = g.Key.itemname,
        //                                   Invid = g.Key.productcode,
        //                                   TotalReturnQty = g.Sum(returnTrack => returnTrack.issuereturnqty),
        //                                   Price = g.Sum(returnTrack => returnTrack.issuereturnqty * returnTrack.issuereturnunitprice) / g.Sum(returnTrack => returnTrack.issuereturnqty),
        //                                   Uom = g.First().UOM.uomname,
        //                                   Currency = g.First().currency.currencyname,
        //                                   Rate = g.First().currency.exchangerate,
        //                                   budgetheadername = g.Key.budgetheadername,
        //                                   budgetheaderid = g.Key.budgetheaderid,
        //                                   categoryid = g.Key.categoryid,
        //                                   categoryname = g.Key.categoryname,
        //                                   subcategoryid = g.Key.subcategoryid,
        //                                   subcategoryname = g.Key.subcategoryname
        //                               }).ToListAsync();

        //    // Adjust issued quantities by subtracting returned quantities
        //    var adjustedIssued = totalIssued.GroupJoin(
        //        totalReturned,
        //        issue => issue.Itemname, // Join on Itemname
        //        returned => returned.Itemname, // Join on Itemname
        //        (issue, returns) => new
        //        {
        //            issue.Itemname,
        //            issue.Invid, // Keep Invid from issue side
        //            TotalAdjustedIssueQty = issue.TotalIssueQty - (returns?.Sum(r => r.TotalReturnQty) ?? 0),
        //            issue.Price, // Use adjustedIssued price
        //            issue.Uom,
        //            issue.Currency,
        //            issue.Rate,
        //            issue.budgetheaderid,
        //            issue.budgetheadername,
        //            issue.categoryname,
        //            issue.categoryid,
        //            issue.subcategoryname,
        //            issue.subcategoryid
        //        }).ToList();

        //    // Union all results based on Itemname
        //    var inventory = totalReceived
        //        .GroupJoin(adjustedIssued,
        //            r => r.Itemname, // Join on Itemname
        //            i => i.Itemname, // Join on Itemname
        //            (r, i) => new { Received = r, Issued = i.DefaultIfEmpty() })
        //        .SelectMany(
        //            x => x.Issued.Select(i => new
        //            {
        //                Received = x.Received,
        //                Issued = i,
        //                Returned = totalReturned.FirstOrDefault(ir => ir.Itemname == x.Received.Itemname) // Match by Itemname
        //            }))
        //        .Select(x => new InventoryResult
        //        {
        //            // If you want invid, you'll have to decide which one (e.g., from Received, or take a Min/Max of productcode)
        //            invid = x.Received?.Invid ?? x.Issued?.Invid ?? x.Returned?.Invid, // Take Invid from whichever is present
        //            inventory = (x.Received?.TotalGrnQty ?? 0)
        //                            - (x.Issued?.TotalAdjustedIssueQty ?? 0)
        //                            + (x.Returned?.TotalReturnQty ?? 0),
        //            // For price, you'll need to decide how to combine.
        //            // This is a simple average of received, issued, and returned prices,
        //            // but a weighted average across all movements is more accurate.
        //            // For simplicity, let's take received price if available, else issued, else returned.
        //            price = x.Received?.Price ?? x.Issued?.Price ?? x.Returned?.Price ?? 0,
        //            uom = x.Received?.Uom ?? x.Issued?.Uom ?? x.Returned?.Uom,
        //            currency = x.Received?.Currency ?? x.Issued?.Currency ?? x.Returned?.Currency,
        //            itemname = x.Received?.Itemname ?? x.Issued?.Itemname ?? x.Returned?.Itemname, // Itemname must be present
        //            rate = x.Received?.Rate ?? x.Issued?.Rate ?? x.Returned?.Rate ?? 0,
        //            budgetheaderid = x.Received?.budgetheaderid ?? x.Issued?.budgetheaderid ?? x.Returned?.budgetheaderid ?? 0,
        //            budgetheadername = x.Received?.budgetheadername ?? x.Issued?.budgetheadername ?? x.Returned?.budgetheadername,
        //            categoryname = x.Received?.categoryname ?? x.Issued?.categoryname ?? x.Returned?.categoryname,
        //            categoryid = x.Received?.categoryid ?? x.Issued?.categoryid ?? x.Returned?.categoryid ?? 0,
        //            subcategoryname = x.Received?.subcategoryname ?? x.Issued?.subcategoryname ?? x.Returned?.subcategoryname,
        //            subcategoryid = x.Received?.subcategoryid ?? x.Issued?.subcategoryid ?? x.Returned?.subcategoryid ?? 0,
        //        })
        //        // Use a custom equality comparer for Union or use GroupBy again
        //        .GroupBy(x => x.itemname) // Group one final time by itemname to remove duplicates
        //        .Select(g => new InventoryResult
        //        {
        //            invid = g.First().invid, // Take first invid, or aggregate (e.g., g.Min(x => x.invid))
        //            inventory = g.Sum(x => x.inventory), // Sum inventories for the same itemname
        //            price = g.First().price, // Take first price, or re-calculate average/weighted average
        //            uom = g.First().uom, // Take first UOM
        //            currency = g.First().currency, // Take first currency
        //            itemname = g.Key,
        //            rate = g.First().rate, // Take first rate
        //            budgetheaderid = g.First().budgetheaderid,
        //            budgetheadername = g.First().budgetheadername,
        //            categoryname = g.First().categoryname,
        //            categoryid = g.First().categoryid,
        //            subcategoryname = g.First().subcategoryname,
        //            subcategoryid = g.First().subcategoryid
        //        })
        //        .OrderBy(result => result.itemname) // Order by itemname now
        //        .Where(x => x.inventory != 0)
        //        .ToList();

        //    return inventory;
        //}
































        [HttpGet("GetStockItemstobeissuedbyJobid")]
        public async Task<IActionResult> GetStockItemstobeissuedbyJobid([FromQuery] int jobid)
        {
            var stockitemsissuedbyjobid = await (
        from rh in dbcontext.Inventoryreservation
        join red in dbcontext.Product on rh.productid equals red.itemid
        where rh.tojobid == jobid
        select new
        {
            ItemId = rh.productid,
            ItemName = red.itemname,
            qty = rh.reservedqty,
            fromjob = rh.fromjobid,
            tojob = rh.tojobid
        }
    ).ToListAsync();

            return Ok(stockitemsissuedbyjobid);
        }






        [HttpGet("GetStockissuepending")]
        public async Task<IActionResult> GetStockissuepending()
        {
            var stockitemsissuedbyjobid = await (
        from rh in dbcontext.Inventoryreservation
        join red in dbcontext.Product on rh.productid equals red.productcode
        where rh.reservedqty > rh.issuecreatedqty
        select new
        {
            ItemId = rh.productid,
            ItemName = red.itemname,
            qty = rh.reservedqty,
            fromjob = rh.fromjobid,
            tojob = rh.tojobid
        }
    ).ToListAsync();

            return Ok(stockitemsissuedbyjobid);
        }











































        [HttpGet("GetPendingPurchasedetailsbypono")]
        public async Task<IActionResult> GetPendingPurchasedetailsbypono(int grnno, int orderid)
        {
            var grndetails = await (
         from gd in dbcontext.GRNDetails
         join gh in dbcontext.GRNHeader on gd.grnno equals gh.grnno
         where gd.grnno == grnno
         select new
         {
             gh.pono,
             gd.grnno,
             gd.itemcode
         }
     ).ToListAsync();

            var grnItemIds = grndetails.Select(g => g.itemcode).ToList(); // Extract item codes for comparison

            var podetails = await dbcontext.Purchasedetails
                .Where(p => p.inspacceptedqty > p.grncreatedqty) // Filter where inspacceptedqty is greater than grncreatedqty
                .Include(p => p.PO)
                .Include(p => p.product)
                .Include(p => p.UOM)
                .Include(p => p.product.UOM) // Include related PurchaseOrder data
                .Where(p => p.PO.postatusid == 3 && p.PO.Orderid == orderid && !grnItemIds.Contains(p.poitemid)) // Corrected comparison
                .ToListAsync();
            return Ok(podetails);



        }





        [HttpGet("GetPendingPurchasedetailsbyponos")]
        public async Task<IActionResult> GetPendingPurchasedetailsbyponos(int pono)
        {


            var podetails = await dbcontext.Purchasedetails
                .Where(p => p.inspacceptedqty > p.grncreatedqty) // Filter where inspacceptedqty is greater than grncreatedqty
                .Include(p => p.PO)
                .Include(p => p.product)
                .Include(p => p.UOM)
                .Include(p => p.product.UOM) // Include related PurchaseOrder data
                .Where(p => p.PO.postatusid == 3 && p.PO.Orderid == pono) // Corrected comparison
                .ToListAsync();
            return Ok(podetails);



        }



        [HttpGet("Getremainingpotobeaddedtogrn")]
        public async Task<IActionResult> Getremainingpotobeaddedtogrn(int pono)
        {
            var podetails = await dbcontext.Purchasedetails
                .Where(p => p.inspacceptedqty > p.grncreatedqty) // Filter where inspacceptedqty is greater than grncreatedqty
                .Include(p => p.PO)
                .Include(p => p.product)
                .Include(p => p.UOM)
                .Include(p => p.product.UOM)
                 // Include related PurchaseOrder data
                 .Where(p => p.PO.postatusid == 3 && p.PO.Orderid == pono)  // Filter only authorized PurchaseOrders
                .ToListAsync();
            return Ok(podetails);






























        }






























        [HttpGet("GetReserveItemstobeissuedbyjobid")]
        public async Task<IActionResult> GetReserveItemstobeissuedbyjobid([FromQuery] int jobid)
        {
            var poitemsissuedbyjobid = await (
            from rh in dbcontext.Inventoryreservation
            join red in dbcontext.Product on rh.productid equals red.productcode
            where rh.tojobid == jobid && rh.reservedqty > rh.issuecreatedqty
            select new
            {
                rid = rh.RId,
                ItemId = rh.productid,
                ItemName = red.itemname,
                maxqantity = rh.reservedqty - rh.issuecreatedqty,
                unitprice = rh.invunitprice,
                fromjob = rh.fromjobid,
                tojob = rh.tojobid,
                rh.uomid,

                rh.invrcurrencyid

            }
        ).ToListAsync();
            return Ok(poitemsissuedbyjobid);
        }


















        [HttpPost("Addorupdatestockissuenote")]
        public async Task<IActionResult> Addorupdatestockissuenote(Addorupdatestockissuedetails dto)
        {
            try
            {
                var unregisteredIssueNotes = await dbcontext.IssueNoteheader
      .Where(e => e.isregistered == 0 && e.issueref != dto.issueref && e.jobid == dto.jobid)
      .ToListAsync();

                if (unregisteredIssueNotes.Any())
                {
                    // Return unregistered Issue Notes in the response and stop further processing
                    return Ok(new { Message = "UnregisteredIssuenote" });
                }


                // Find existing received entry
                var existingEntry = await dbcontext.IssueNoteheader
                    .FirstOrDefaultAsync(e => e.issueref == dto.issueref);

                if (existingEntry != null)
                {
                    // Update existing entry
                    existingEntry.issueref = dto.issueref;
                    existingEntry.jobid = dto.jobid;
                    existingEntry.issuedate = dto.issuedate;
                    existingEntry.Remarks = dto.Remarks;
                    existingEntry.issuedto = dto.issuedto;
                    dbcontext.IssueNoteheader.Update(existingEntry);
                }
                else
                {
                    // Create a new received entry
                    existingEntry = new IssueNoteheader
                    {
                        // Assuming REID is generated elsewhere or provided
                        issueref = dto.issueref,
                        jobid = dto.jobid,
                        issuedate = dto.issuedate,
                        Remarks = dto.Remarks,
                        issuedto = dto.issuedto,
                        issuetype = "Stock"

                    };

                    await dbcontext.IssueNoteheader.AddAsync(existingEntry);
                }

                await dbcontext.SaveChangesAsync();

                // Insert or update details
                foreach (var item in dto.issuedetails)
                {
                    var detail = new IssuedetailsfromStock
                    {


                        issuenoteref = dto.issueref,
                        // Associate with the received entry
                        itemid = item.itemid,
                        issueqty = item.issueqty,
                        rid = item.rid,
                        issueprice = item.issueprice,

                        issuecurrencyid = item.invrcurrencyid,

                        issueuomid = item.uomid,

                    };

                    await dbcontext.IssuedetailsfromStock.AddAsync(detail);




                    var inventoryReservation = await dbcontext.Inventoryreservation
    .FirstOrDefaultAsync(ir => ir.RId == item.rid);

                    if (inventoryReservation != null)
                    {
                        inventoryReservation.issuecreatedqty += item.issueqty;

                        // Optionally, you can also update other fields if needed
                        // inventoryReservation.lastissuedate = DateTime.Now;
                        // inventoryReservation.lastissueqty = item.issueqty;

                        dbcontext.Inventoryreservation.Update(inventoryReservation);
                    }





















                }

                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Issue note  entry and details saved successfully." });
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                // Log.Error(ex, "An error occurred while processing the received entry details.");

                // Return a generic error message to the client
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }


























        }















        [HttpGet("GetStockIssuenotedetailsbyissueno")]
        public async Task<IActionResult> GetStockIssuenotedetailsbyissueno(int issueref)
        {
            var issuedetails = await (from po in dbcontext.IssuedetailsfromStock
                                      join ii in dbcontext.Product on po.itemid equals ii.productcode
                                      join cc in dbcontext.Currency on po.issuecurrencyid equals cc.currencyid
                                      join ri in dbcontext.Inventoryreservation on po.rid equals ri.RId
                                      where po.issuenoteref == issueref
                                      select new
                                      {
                                          po.rid,
                                          po.issuedetailid,
                                          po.Product.itemname,
                                          po.issueqty,
                                          po.itemid,
                                          ri.fromjobid,
                                          ri.tojobid,
                                          issueprice = po.issueprice * (decimal)cc.exchangerate
                                          // You can include other fields from PRPO if needed
                                      }).ToListAsync();
            if (issuedetails == null)
            {
                return NotFound();
            }
            return Ok(issuedetails);
        }









        [HttpDelete("DeleteIssuedetails/{issuedetailsid}")]
        public async Task<IActionResult> DeleteIssuedetails(int issuedetailsid)
        {
            // Find the issuedetail by ID
            var issuedetail = await dbcontext.IssuedetailsfromStock.FindAsync(issuedetailsid);
            if (issuedetail == null)
            {
                return NotFound();
            }

            // Retrieve the rid from the issuedetail
            var rid = issuedetail.rid;

            // Find the corresponding record in the inventoryreservation table
            var inventoryReservation = await dbcontext.Inventoryreservation.FindAsync(rid);
            if (inventoryReservation == null)
            {
                return NotFound();
            }

            // Update the issueqty in the inventoryreservation table
            inventoryReservation.issuecreatedqty -= issuedetail.issueqty;
            if (inventoryReservation.issuecreatedqty < 0)
            {
                inventoryReservation.issuecreatedqty = 0; // Ensure issueqty doesn't go negative
            }

            // Remove the issuedetail
            dbcontext.IssuedetailsfromStock.Remove(issuedetail);

            // Save changes to the database
            await dbcontext.SaveChangesAsync();

            return NoContent();
        }




        [HttpPut("Addorupdatestockissuenoteupdate")]
        public async Task<IActionResult> Addorupdatestockissuenoteupdate(Addorupdatestockissuedetails dto)
        {
            try
            {
                var unregisteredIssueNotes = await dbcontext.IssueNoteheader
      .Where(e => e.isregistered == 0 && e.issueref != dto.issueref && e.jobid == dto.jobid)
      .ToListAsync();

                if (unregisteredIssueNotes.Any())
                {
                    // Return unregistered Issue Notes in the response and stop further processing
                    return Ok(new { Message = "UnregisteredIssuenote" });
                }


                // Find existing received entry
                var existingEntry = await dbcontext.IssueNoteheader
                    .FirstOrDefaultAsync(e => e.issueref == dto.issueref);

                if (existingEntry != null)
                {
                    // Update existing entry
                    existingEntry.issueref = dto.issueref;
                    existingEntry.jobid = dto.jobid;
                    existingEntry.issuedate = dto.issuedate;
                    existingEntry.Remarks = dto.Remarks;
                    existingEntry.issuedto = dto.issuedto;
                    dbcontext.IssueNoteheader.Update(existingEntry);
                }
                else
                {
                    // Create a new received entry
                    existingEntry = new IssueNoteheader
                    {
                        // Assuming REID is generated elsewhere or provided
                        issueref = dto.issueref,
                        jobid = dto.jobid,
                        issuedate = dto.issuedate,
                        Remarks = dto.Remarks,
                        issuedto = dto.issuedto


                    };

                    await dbcontext.IssueNoteheader.AddAsync(existingEntry);
                }

                await dbcontext.SaveChangesAsync();

                // Insert or update details
                foreach (var item in dto.issuedetails)
                {
                    var detail = new IssuedetailsfromStock
                    {


                        issuenoteref = dto.issueref,
                        // Associate with the received entry
                        itemid = item.itemid,
                        issueqty = item.issueqty,
                        rid = item.rid,
                        issueprice = item.issueprice,

                        issuecurrencyid = item.invrcurrencyid,
                        issueuomid = item.uomid



                    };

                    await dbcontext.IssuedetailsfromStock.AddAsync(detail);




                    var inventoryReservation = await dbcontext.Inventoryreservation
    .FirstOrDefaultAsync(ir => ir.RId == item.rid);

                    if (inventoryReservation != null)
                    {
                        inventoryReservation.issuecreatedqty += item.issueqty;

                        // Optionally, you can also update other fields if needed
                        // inventoryReservation.lastissuedate = DateTime.Now;
                        // inventoryReservation.lastissueqty = item.issueqty;

                        dbcontext.Inventoryreservation.Update(inventoryReservation);
                    }





















                }

                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Issue note  entry and details saved successfully." });
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                // Log.Error(ex, "An error occurred while processing the received entry details.");

                // Return a generic error message to the client
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }


























        }







        public class DeductStockInventoryRequest
        {
            public int ItemId { get; set; }
            public decimal RequestedQuantity { get; set; }
            public int Jobid { get; set; }
            public int issueref { get; set; }
            public int rid { get; set; }
        }

        [HttpPost("DeductstockInventory")]
        public async Task<IActionResult> DeductstockInventory([FromBody] DeductStockInventoryRequest request)
        {
            using (var transaction = dbcontext.Database.BeginTransaction())
            {
                try
                {

                    var batches = new List<Batchstock>();
                    var remainingQuantity = request.RequestedQuantity;

                    var issuedetails = await (from po in dbcontext.IssuedetailsfromStock
                                              join ii in dbcontext.Inventoryreservation on po.rid equals ii.RId
                                              where po.issuenoteref == request.issueref
                                              select new
                                              {
                                                  po.rid,
                                                  po.issuedetailid,
                                                  po.Product.itemname,
                                                  po.issueqty,
                                                  po.itemid,
                                                  ii.inventoryid
                                              }).ToListAsync();

                    if (issuedetails != null && issuedetails.Any())
                    {
                        var invids = issuedetails.Select(id => id.inventoryid).ToList();

                        var inventoryItems = dbcontext.Inventory
                            .Where(i => i.productid == request.ItemId && invids.Contains(i.invid))
                            .OrderBy(i => i.Entrydate)
                            .ToList();

                        foreach (var item in inventoryItems)
                        {
                            batches.Add(new Batchstock(item.batchid, item.quantity, item.invid, item.invcurrencyid, item.uomid, item.invprice, item.jobid, item.billofentryno, item.billofentrydate));
                        }

                        foreach (var batch in batches)
                        {
                            if (remainingQuantity <= 0) break;

                            var quantityToDeduct = Math.Min(remainingQuantity, batch.Quantity);
                            DeductFromBatchrv1(request.ItemId, batch.BatchID, quantityToDeduct, batch.Jobid, request.issueref, batch.Invid, batch.Currencyid, batch.Uomid, batch.Price, batch.billofentryno, batch.billofentrydate);
                            remainingQuantity -= quantityToDeduct;
                        }

                        var issuenoteheader = dbcontext.IssueNoteheader
                            .FirstOrDefault(i => i.issueref == request.issueref);

                        if (issuenoteheader != null)
                        {
                            issuenoteheader.isregistered = 1;
                        }

                        dbcontext.SaveChanges();
                        transaction.Commit();

                        return Ok(new { Message = "Issue Note Registered" });
                    }

                    return BadRequest(new { Message = "No issue details found for the provided reference." });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }



        private void DeductFromBatchrv1(int itemId, int batchId, decimal quantity, int jobid, int issueref, int invid, int Currencyid, int Uomid, decimal Price, string? billofentryno, DateTime? billofentrydate)
        {
            var inventoryItem = dbcontext.Inventory
                .FirstOrDefault(i => i.productid == itemId && i.batchid == batchId && i.jobid == jobid);

            if (inventoryItem != null)
            {
                inventoryItem.quantity -= quantity;
                inventoryItem.reservedqty -= quantity;
                var issuetrack = new Issuetracking
                {
                    productid = itemId,
                    jobid = jobid, // Assuming jobid is part of the entry details
                    issuenoteno = issueref,
                    issueqty = quantity,
                    issuedate = DateTime.UtcNow.Date,
                    invid = invid,
                    issuecurrencyid = Currencyid,
                    issueunitprice = Price,
                    issueuomid = Uomid,
                    billofentryno = billofentryno,
                    billofentrydate = billofentrydate


                    // Assign the retrieved invid here
                };



                dbcontext.Issuetracking.Add(issuetrack);
                if (inventoryItem.quantity <= 0)
                {
                    dbcontext.Inventory.Remove(inventoryItem);
                }














































            }


















        }





        public class AddRegisterIssuereturn
        {
            public int jobid { get; set; }
            public int issuereturnref { get; set; }
            public List<ItemRequest> items { get; set; }
        }











































        public class DeductStockInventoryRequest1
        {
            public int JobId { get; set; }
            public int IssueRef { get; set; }
            public List<ItemRequest> Items { get; set; }
        }

        public class ItemRequest
        {
            public int ItemId { get; set; }
            public int Rid { get; set; }
            public decimal issueqty { get; set; }
        }




        [HttpPost("DeductstockInventory123")]
        public async Task<IActionResult> DeductstockInventory123([FromBody] DeductStockInventoryRequest1 request)
        {
            using (var transaction = dbcontext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in request.Items)
                    {
                        var batches = new List<Batchstock>();
                        var remainingQuantity = item.issueqty;

                        var issuedetails = await (from po in dbcontext.IssuedetailsfromStock
                                                  join ii in dbcontext.Inventoryreservation on po.rid equals ii.RId
                                                  where po.issuenoteref == request.IssueRef
                                                  select new
                                                  {
                                                      po.rid,
                                                      po.issuedetailid,
                                                      po.Product.itemname,
                                                      po.issueqty,
                                                      po.itemid,
                                                      ii.inventoryid
                                                  }).ToListAsync();

                        if (issuedetails != null && issuedetails.Any())
                        {
                            var invids = issuedetails.Select(id => id.inventoryid).ToList();

                            var inventoryItems = dbcontext.Inventory
                                .Where(i => i.productid == item.ItemId && invids.Contains(i.invid))
                                .OrderBy(i => i.Entrydate)
                                .ToList();

                            foreach (var invItem in inventoryItems)
                            {
                                batches.Add(new Batchstock(invItem.batchid, invItem.quantity, invItem.invid, invItem.invcurrencyid, invItem.uomid, invItem.invprice, invItem.jobid, invItem.billofentryno, invItem.billofentrydate));
                            }

                            foreach (var batch in batches)
                            {
                                if (remainingQuantity <= 0) break;

                                var quantityToDeduct = Math.Min(remainingQuantity, batch.Quantity);
                                DeductFromBatchrv2(item.ItemId, batch.BatchID, quantityToDeduct, batch.Jobid, request.IssueRef, batch.Invid, batch.Currencyid, batch.Uomid, batch.Price, batch.billofentryno, batch.billofentrydate);
                                remainingQuantity -= quantityToDeduct;
                            }

                            var issuenoteheader = dbcontext.IssueNoteheader
                                .FirstOrDefault(i => i.issueref == request.IssueRef);

                            if (issuenoteheader != null)
                            {
                                issuenoteheader.isregistered = 1;
                            }
                        }

                        dbcontext.SaveChanges();
                    }

                    transaction.Commit();

                    return Ok(new { Message = "Issue Note Registered" });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }

        private void DeductFromBatchrv2(int itemId, int batchId, decimal quantity, int jobid, int issueref, int invid, int Currencyid, int Uomid, decimal Price, string? billofentryno, DateTime? billofentrydate)
        {
            var inventoryItem = dbcontext.Inventory
                .FirstOrDefault(i => i.productid == itemId && i.batchid == batchId && i.jobid == jobid);

            if (inventoryItem != null)
            {
                inventoryItem.quantity -= quantity;
                inventoryItem.reservedqty -= quantity;
                var issuetrack = new Issuetracking
                {
                    productid = itemId,
                    jobid = jobid,
                    issuenoteno = issueref,
                    issueqty = quantity,
                    issuedate = DateTime.UtcNow.Date,
                    invid = invid,
                    issuecurrencyid = Currencyid,
                    issueunitprice = Price,
                    issueuomid = Uomid,
                    billofentryno = billofentryno,
                    billofentrydate = billofentrydate
                };

                dbcontext.Issuetracking.Add(issuetrack);

                if (inventoryItem.quantity <= 0)
                {
                    dbcontext.Inventory.Remove(inventoryItem);
                }
            }
        }













        [HttpGet("Getitemsforissuereturnbyjobid")]
        public async Task<IActionResult> Getitemsforissuereturnbyjobid(int jobid)
        {
            var issuedetails = await (from po in dbcontext.IssuedetailsfromStock
                                      join ii in dbcontext.Product on po.itemid equals ii.productcode
                                      join ir in dbcontext.Inventoryreservation on po.rid equals ir.RId
                                      join ih in dbcontext.IssueNoteheader on po.issuenoteref equals ih.issueref
                                      where ih.jobid == jobid && ih.isregistered == 1 && po.issueqty > po.returnedqty
                                      select new
                                      {
                                          itemid = ii.productcode,
                                          po.rid,
                                          po.issuedetailid,
                                          ir.fromjobid,
                                          ir.tojobid,
                                          po.Product.itemname,
                                          po.issueqty,
                                          remainingQty = po.issueqty - po.returnedqty,

                                          ir.invunitprice,
                                          po.issuecurrencyid,
                                          po.issueuomid,



                                          // You can include other fields from PRPO if needed
                                      }).ToListAsync();
            if (issuedetails == null)
            {
                return NotFound();
            }
            return Ok(issuedetails);
        }





        [HttpGet("GetMaxIssuereturnno")]
        public async Task<int?> GetMaxIssuereturnno()

        {
            // Get the maximum PR ID from the PurchaseRequest table
            int maxrenoPlusOne = (await dbcontext.Issuereturn.MaxAsync(pr => (int?)pr.issuereturnref) ?? 300) + 1;

            return maxrenoPlusOne;
        }

        [HttpGet("GetMaxDeliveryno")]
        public async Task<int?> GetMaxDeliveryno()

        {
            // Get the maximum PR ID from the PurchaseRequest table
            int maxdeliveryno = (await dbcontext.DeliveryNote.MaxAsync(pr => (int?)pr.deliveryno) ?? 1000) + 1;

            return maxdeliveryno;
        }



        [HttpGet("GetIssuereturnstocklinedetails")]
        public async Task<IActionResult> GetIssuereturnstocklinedetails(int issuereturnref)
        {
            var issuereturndetails = await (from po in dbcontext.Issuereturndetails
                                            join ii in dbcontext.Product on po.productid equals ii.productcode
                                            join id in dbcontext.IssuedetailsfromStock on po.issuedetailtblid equals id.issuedetailid
                                            join ir in dbcontext.Inventoryreservation on id.rid equals ir.RId
                                            where po.issuereturnref == issuereturnref
                                            select new
                                            {
                                                ii.itemname,
                                                po.irtblid,
                                                ir.fromjobid,
                                                ir.tojobid,
                                                po.quantityreturned,
                                                po.productid,
                                                po.irunitprice,
                                                po.ircurrencyid,
                                                po.iruomid
                                                // You can include other fields from PRPO if needed
                                            }).ToListAsync();
            if (issuereturndetails == null)
            {
                return NotFound();
            }
            return Ok(issuereturndetails);
        }









































        [HttpPost("Addorupdateissuereturn")]
        public async Task<IActionResult> Addorupdateissuereturn(Addorupdateissuereturndetails dto)
        {
            try
            {
                var unregisteredIssueNotes = await dbcontext.Issuereturn
      .Where(e => e.isregistered == 0 && e.issuereturnref != dto.issuereturnref && e.jobid == dto.jobid)
      .ToListAsync();

                if (unregisteredIssueNotes.Any())
                {
                    // Return unregistered Issue Notes in the response and stop further processing
                    return Ok(new { Message = "UnregisteredIssuereturn" });
                }


                // Find existing received entry
                var existingEntry = await dbcontext.Issuereturn
                    .FirstOrDefaultAsync(e => e.issuereturnref == dto.issuereturnref);

                if (existingEntry != null)
                {
                    // Update existing entry
                    existingEntry.issuereturnref = dto.issuereturnref;
                    existingEntry.jobid = dto.jobid;
                    existingEntry.returndate = dto.returndate;
                    existingEntry.Remarks = dto.Remarks;
                    existingEntry.issuereturntype = "Stock";

                    dbcontext.Issuereturn.Update(existingEntry);
                }
                else
                {
                    // Create a new received entry
                    existingEntry = new Issuereturn
                    {
                        // Assuming REID is generated elsewhere or provided
                        issuereturnref = dto.issuereturnref,
                        jobid = dto.jobid,
                        returndate = dto.returndate,
                        Remarks = dto.Remarks,

                        issuereturntype = "Stock"
                    };

                    await dbcontext.Issuereturn.AddAsync(existingEntry);
                }

                await dbcontext.SaveChangesAsync();

                // Insert or update details
                foreach (var item in dto.issuereturndetails)
                {
                    var detail = new Issuereturndetails
                    {
                        irunitprice = item.irunitprice,
                        issuereturnref = dto.issuereturnref,
                        productid = item.itemid,
                        quantityreturned = item.issueqty,
                        issuedetailtblid = item.issuedetailtblid,

                        iruomid = item.issueuomid,
                        ircurrencyid = item.issuecurrencyid


                    };

                    await dbcontext.Issuereturndetails.AddAsync(detail);





                    var issuedetail = await dbcontext.IssuedetailsfromStock
              .FirstOrDefaultAsync(i => i.issuedetailid == item.issuedetailtblid);

                    if (issuedetail != null)
                    {
                        issuedetail.returnedqty += item.issueqty; // Adjust returnedqty
                        dbcontext.IssuedetailsfromStock.Update(issuedetail);
                    }

























                }

                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Issue note  entry and details saved successfully." });
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                // Log.Error(ex, "An error occurred while processing the received entry details.");

                // Return a generic error message to the client
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }





        }





        [HttpGet("GetissueReturnHeaderDetailsbyissuenref")]
        public async Task<IActionResult> GetissueReturnHeaderDetailsbyissuenref(int issueref)
        {

            try
            {

                var issuereturnheader = await dbcontext.Issuereturn
              .Where(po => po.issuereturnref == issueref)
              .FirstOrDefaultAsync();
                if (issuereturnheader == null)
                {
                    return NotFound();
                }
                return Ok(issuereturnheader);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }














        [HttpPut("Addorupdateprdetails")]
        public async Task<IActionResult> Addorupdateprdetails(Addorupdateprdetails dto)
        {
            try
            {
                var existingprheader = await dbcontext.PR
                 .FirstOrDefaultAsync(e => e.PRID == dto.prid);
                if (existingprheader != null)
                {
                    // Update existing entry
                    existingprheader.Prdate = dto.prdate;
                    existingprheader.remarks = dto.remarks;
                    dbcontext.PR.Update(existingprheader);
                }
                await dbcontext.SaveChangesAsync();
                // Insert or update details
                foreach (var item in dto.prlines)
                {
                    var existingprdetails = await dbcontext.PRDetails
                    .FirstOrDefaultAsync(e => e.prtblid == item.prtblid);
                    if (existingprdetails != null)
                    {
                        // Update existing entry


                        var bomdetails = await dbcontext.Bom
                                                          .FirstOrDefaultAsync(e => e.bomid == existingprdetails.bomid);
                        if (bomdetails != null)
                        {
                            bomdetails.prcreatedqty = (bomdetails.prcreatedqty - existingprdetails.prqty) + item.maxprqty;
                            dbcontext.Bom.Update(bomdetails);
                        }
                        existingprdetails.prqty = item.maxprqty;
                        dbcontext.PRDetails.Update(existingprdetails);


                    }

                }

                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Issue note  entry and details saved successfully." });
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                // Log.Error(ex, "An error occurred while processing the received entry details.");

                // Return a generic error message to the client
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }





        }





        ////[HttpPost("UploadFile")]
        ////public IActionResult UploadFile([FromForm] IFormFile file)
        ////{
        ////    if (file == null || file.Length == 0)
        ////        return BadRequest("No file uploaded.");

        ////    var filePath = Path.Combine("prUploads", file.FileName);

        ////    using (var stream = new FileStream(filePath, FileMode.Create))
        ////    {
        ////        file.CopyTo(stream);
        ////    }

        ////    return Ok(new { Message = "File uploaded successfully", FileName = file.FileName });
        ////}









        [HttpGet("GetJobDetailsbyjobid")]
        public async Task<IActionResult> GetJobDetailsbyjobid(int jobid)
        {
            try
            {
                var issueheader = await dbcontext.Job
                    .Include(po => po.Customer)
                      .Include(po => po.JobType)
                       .Include(po => po.ProjectEngineer)
                         .Include(po => po.ProjectManager)
                          .Include(po => po.ManufacturingBay)
                          .Include(po => po.ProjectCategory)
                           .Include(po => po.QualityLevel)
                             .Include(po => po.Currency)

                              .Include(po => po.JobStage)
              .Where(po => po.Jobid == jobid)
              .FirstOrDefaultAsync();
                if (issueheader == null)
                {
                    return NotFound();
                }
                return Ok(issueheader);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }











        [HttpGet("GetAllApprovedpolistforreceivedentry")]

        public async Task<IActionResult> GetAllApprovedpolistforreceivedentry()
        {
            var prdetails = await (from po in dbcontext.PO
                                   join ss in dbcontext.Supplier on po.supplierid equals ss.supplierid

                                   join pp in dbcontext.Purchasedetails on po.Orderid equals pp.orderid
                                   where po.postatusid == 3 && (pp.poquantity - pp.receivedentryqty + pp.insprejectedqty) > 0
                                   group po by new { po.Orderid, ss.suppliername, po.Podate } into grouped
                                   select new
                                   {
                                       grouped.Key.Orderid,
                                       grouped.Key.suppliername,
                                       grouped.Key.Podate
                                   }).ToListAsync();

            if (prdetails == null || !prdetails.Any()) // Handle empty list
            {
                return NotFound();
            }

            return Ok(prdetails);
        }


        [HttpGet("GetAllApprovedpolistforinspection")]

        public async Task<IActionResult> GetAllApprovedpolistforinspection()
        {
            var prdetails = await (from po in dbcontext.PO
                                   join ss in dbcontext.Supplier on po.supplierid equals ss.supplierid

                                   join pp in dbcontext.Purchasedetails on po.Orderid equals pp.orderid

                                   join re in dbcontext.ReceivedEntryDetails on pp.potblid equals re.potblid
                                   join ree in dbcontext.ReceivedEntry on re.RENO equals ree.REID
                                   where po.postatusid == 3
                                   && ree.isregistered == 1 && re.receivedqty - (re.acceptedqty + re.holdqty + re.rejectedqty) > 0
                                   group po by new { po.Orderid, ss.suppliername, po.Podate, re.RENO } into grouped
                                   select new
                                   {
                                       grouped.Key.Orderid,
                                       grouped.Key.suppliername,
                                       grouped.Key.Podate,
                                       grouped.Key.RENO
                                   }).ToListAsync();

            if (prdetails == null || !prdetails.Any()) // Handle empty list
            {
                return NotFound();
            }

            return Ok(prdetails);
        }




        [HttpGet("GetAllApprovedpendingmaterilinspectionbasedonreno")]

        public async Task<IActionResult> GetAllApprovedpendingmaterilinspectionbasedonreno(int reno)
        {
            var prdetails = await (from po in dbcontext.PO
                                   join ss in dbcontext.Supplier on po.supplierid equals ss.supplierid
                                   join pp in dbcontext.Purchasedetails on po.Orderid equals pp.orderid
                                   join re in dbcontext.ReceivedEntryDetails on pp.potblid equals re.potblid
                                   join ii in dbcontext.Product on re.itemid equals ii.productcode
                                   join reh in dbcontext.ReceivedEntry on re.RENO equals reh.REID
                                   where po.postatusid == 3 && re.receivedqty - (re.acceptedqty + re.rejectedqty + re.holdqty) > 0
                                   && re.RENO == reno && reh.isregistered == 1
                                   group po by new
                                   {
                                       po.Orderid,
                                       ss.suppliername,
                                       po.Podate,
                                       re.RENO,
                                       re.acceptedqty,
                                       re.receivedqty,
                                       re.rejectedqty,
                                       re.holdqty,
                                       re.rtblid,
                                       re.itemid,
                                       ii.itemname
                                   } into grouped
                                   select new
                                   {
                                       grouped.Key.Orderid,
                                       grouped.Key.suppliername,
                                       grouped.Key.Podate,
                                       grouped.Key.RENO,
                                       grouped.Key.acceptedqty,
                                       grouped.Key.receivedqty,
                                       grouped.Key.holdqty,
                                       grouped.Key.rejectedqty,
                                       grouped.Key.itemname,
                                       grouped.Key.itemid,
                                       grouped.Key.rtblid,
                                       pending = (grouped.Key.receivedqty - (grouped.Key.acceptedqty + grouped.Key.holdqty)),

                                   }).ToListAsync();

            if (prdetails == null || !prdetails.Any()) // Handle empty list
            {
                return NotFound();
            }

            return Ok(prdetails);
        }




        [HttpGet("GetPOIssuependingjobnos")]
        public async Task<IActionResult> GetPOIssuependingjobnos()
        {
            // Define valid job type IDs dynamically
            var validJobTypeIds = new List<int> { 1, 2, 5, 6, 7 };

            // Fetch the details from the database
            var prdetails = await (from inv in dbcontext.Inventory
                                   join jj in dbcontext.Job on inv.jobid equals jj.Jobid
                                   where validJobTypeIds.Contains(jj.jobtypeid) // Updated filtering logic
                                   group inv by new
                                   {
                                       inv.jobid,
                                       jj.jobdescription,
                                       JobTypeName = jj.JobType.JobtypeName
                                   } into grouped
                                   select new
                                   {
                                       JobId = grouped.Key.jobid,
                                       JobDescription = grouped.Key.jobdescription,
                                       JobTypeName = grouped.Key.JobTypeName
                                   }).ToListAsync();

            // If no data is found, return a JSON object with an appropriate message
            if (prdetails == null || !prdetails.Any())
            {
                return Ok(new
                {
                    Success = false,
                    Message = "No pending job numbers found.",
                    Data = new List<object>() // Empty data list
                });
            }
            return Ok(prdetails);

            // Return the results if data exists
            //return Ok(new
            //{
            //    Success = true,
            //    Message = "Pending job numbers retrieved successfully.",
            //    Data = prdetails
            //});
        }











        [HttpGet("GetStockjobissuepending")]
        public async Task<IActionResult> GetStockjobissuepending()
        {
            var poitemsissuedbyjobid = await (
            from rh in dbcontext.Inventoryreservation
            join jj in dbcontext.Job on rh.tojobid equals jj.Jobid
            where rh.reservedqty > rh.issuecreatedqty
            group rh by new
            {
                rh.tojobid,
                jj.jobdescription,
                JobTypeName = jj.JobType.JobtypeName
            } into grouped
            select new
            {
                JobId = grouped.Key.tojobid,
                JobDescription = grouped.Key.jobdescription,
                JobTypeName = grouped.Key.JobTypeName
            }).ToListAsync();
            return Ok(poitemsissuedbyjobid);
        }

























        [HttpPost("savereceivedentrydetails")]
        public async Task<IActionResult> savereceivedentrydetails(Addorupdatereceivedentryheaderanddetails dto)
        {
            using (var transaction = await dbcontext.Database.BeginTransactionAsync()) // Start a transaction
            {
                try
                {
                    var unregisteredreceivedentry = await dbcontext.ReceivedEntry
                        .Where(e => e.isregistered == 0 && e.REID != dto.REID)
                        .ToListAsync();

                    if (unregisteredreceivedentry.Any())
                    {
                        return Ok(new { message = "unreg" });
                    }

                    // Find existing received entry
                    var existingEntry = await dbcontext.ReceivedEntry
                        .FirstOrDefaultAsync(e => e.REID == dto.REID);

                    if (existingEntry != null)
                    {
                        // Update existing entry
                        existingEntry.Remarks = dto.Remarks;
                        existingEntry.pono = dto.pono;
                        existingEntry.location = dto.location;
                        existingEntry.REDate = dto.REDate;
                        dbcontext.ReceivedEntry.Update(existingEntry);
                    }
                    else
                    {
                        // Create a new received entry
                        existingEntry = new ReceivedEntry
                        {
                            Remarks = dto.Remarks,
                            REID = dto.REID,
                            pono = dto.pono,
                            location = dto.location,
                            REDate = dto.REDate
                        };

                        await dbcontext.ReceivedEntry.AddAsync(existingEntry);
                    }

                    await dbcontext.SaveChangesAsync(); // Save received entry

                    // Insert or update details
                    foreach (var item in dto.receivedentrydetails)
                    {
                        var detail = new ReceivedEntryDetails
                        {
                            itemid = item.itemid,
                            potblid = item.potblid,
                            receivedqty = item.receivedqty,
                            RENO = dto.REID
                        };

                        await dbcontext.ReceivedEntryDetails.AddAsync(detail);
                    }

                    await dbcontext.SaveChangesAsync(); // Save received entry details

                    await transaction.CommitAsync(); // Commit transaction if everything succeeds

                    return Ok(new { Message = "Received Entry and details saved successfully." });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(); // Rollback transaction on failure

                    return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
                }


            }
        }









        [HttpGet("GetSubCategorydetailsbycategoryid")]
        public async Task<IActionResult> GetSubCategorydetailsbycategoryid(int categoryid)
        {
            if (categoryid <= 0)
            {
                return BadRequest("Invalid Category");
            }
            var subcategorydetails = await dbcontext.SubCategory
       .Where(x => x.categoryid == categoryid)
       .ToListAsync();

            if (subcategorydetails == null)
            {
                return NotFound("Subcategory not found");
            }
            return Ok(subcategorydetails);

        }



        public class POSummary
        {
            public string budgetheadername { get; set; }
            public decimal Totalamt { get; set; }

            public int budgetheaderid { get; set; }

        }


        public class InvoicereceiptPending
        {
            public int invoiceno { get; set; }
            public int jobid { get; set; }
            public decimal invoicevalueinbasecurrency { get; set; }
            public decimal invoicereceipts { get; set; }

            public string customername { get; set; }



        }


        public class Invoicepending
        {
            public int jobid { get; set; }
            public string customername { get; set; }
            public decimal ordervaluebasecurrency { get; set; }
            public decimal totalinvoiced { get; set; }
            public int customerid { get; set; }
            public decimal balancetobeinvoiced { get; set; }
            public string jobdescription { get; set; }
            public string projectname { get; set; }

            public string jobtypename { get; set; }



        }




















        public class BudgetSummary
        {
            public string BudgetHeadName { get; set; }
            public int BudgetHeaderId { get; set; }
            public int JobId { get; set; }
            public decimal Amount { get; set; }
            public decimal fixedamount { get; set; }
            public decimal poamount { get; set; }
            public decimal issuedamount { get; set; }
            public decimal returnedamount { get; set; }
            public int bomrevno { get; set; }
            public decimal fixedbudgetamountadditional { get; set; }
            public decimal overallfixedbudget { get; set; }

        }

        //[HttpGet("GetBudgetSummary")]

        //public List<BudgetSummary> GetBudgetSummary(int jobId)
        //{
        //    List<BudgetSummary> budgetSummaries = new List<BudgetSummary>();

        //    using (SqlConnection conn = new SqlConnection(_connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("sp_GetBudgetSummary", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@jobid", jobId);

        //            conn.Open();
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    budgetSummaries.Add(new BudgetSummary
        //                    {
        //                        BudgetHeadName = reader["budgetheadername"].ToString(),
        //                        BudgetHeaderId = Convert.ToInt32(reader["BudgetHeaderId"]),
        //                        JobId = Convert.ToInt32(reader["jobid"]),
        //                        Amount = Convert.ToDecimal(reader["Amount"])
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    return budgetSummaries;
        //    return budgetSummaries;
        //}



        //[HttpGet("GetBudgetSummary")]
        //public async Task<ActionResult<List<BudgetSummary>>> GetBudgetSummaryAsync(int jobId)
        //{
        //    var budgetSummaries = new List<BudgetSummary>();

        //    using (SqlConnection conn = new SqlConnection(_connectionString))
        //    {
        //        await conn.OpenAsync();
        //        using (SqlCommand cmd = new SqlCommand("sp_GetBudgetSummary", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@jobid", jobId);

        //            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
        //            {
        //                while (await reader.ReadAsync())
        //                {
        //                    budgetSummaries.Add(new BudgetSummary
        //                    {
        //                        BudgetHeadName = reader["budgetheadername"].ToString(),
        //                        BudgetHeaderId = reader.GetInt32(reader.GetOrdinal("BudgetHeaderId")),
        //                        JobId = reader.GetInt32(reader.GetOrdinal("jobid")),
        //                        Amount = reader.GetDecimal(reader.GetOrdinal("Amount"))
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    if (budgetSummaries.Count == 0)
        //    {
        //        return NotFound("No data found for the provided jobId.");
        //    }

        //    return Ok(budgetSummaries);
        //}


        public class POHeader
        {
            public int OrderId { get; set; }
        }





        [HttpGet("GetPODetailsByPrId/{prid}")]
        public async Task<ActionResult<List<POHeader>>> GetPODetailsByPrId(int prid)
        {
            var poHeaders = new List<POHeader>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("SP_GetPOdetailsbyprid", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prid", prid);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            poHeaders.Add(new POHeader
                            {
                                // Assuming 'orderid' is the column name returned by your SP
                                OrderId = reader.GetInt32(reader.GetOrdinal("orderid"))
                            });
                        }
                    }
                }
            }

            if (poHeaders.Count == 0)
            {
                return NotFound("No PO details found for the provided PR ID.");
            }

            return Ok(poHeaders);
        }































        [HttpGet("GetBudgetSummaryAsync")]
        public async Task<ActionResult<List<BudgetSummary>>> GetBudgetSummaryAsync(int jobId)
        {
            var budgetSummaries = new List<BudgetSummary>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_GetBudgetSummaryrv7", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@jobid", jobId);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                budgetSummaries.Add(new BudgetSummary
                                {
                                    BudgetHeadName = reader["budgetheadername"].ToString(),
                                    BudgetHeaderId = reader.GetInt32(reader.GetOrdinal("budgetheaderid")),

                                    Amount = reader.IsDBNull(reader.GetOrdinal("Amount"))
                                     ? 0
                                     : Convert.ToDecimal(reader["Amount"]),
                                    fixedamount = reader.IsDBNull(reader.GetOrdinal("fixedamount"))
                                     ? 0
                                     : Convert.ToDecimal(reader["fixedamount"]),

                                    poamount = reader.IsDBNull(reader.GetOrdinal("poamount"))
                                     ? 0
                                     : Convert.ToDecimal(reader["poamount"]),
                                    issuedamount = reader.IsDBNull(reader.GetOrdinal("issuedamt"))
                                     ? 0
                                     : Convert.ToDecimal(reader["issuedamt"]),

                                    returnedamount = reader.IsDBNull(reader.GetOrdinal("returnedamt"))
                                     ? 0
                                     : Convert.ToDecimal(reader["returnedamt"]),


                                    fixedbudgetamountadditional = reader.IsDBNull(reader.GetOrdinal("fixedbudgetamountadditional"))
                                     ? 0
                                     : Convert.ToDecimal(reader["fixedbudgetamountadditional"]),


                                    overallfixedbudget = reader.IsDBNull(reader.GetOrdinal("overallfixedbudget"))
                                     ? 0
                                     : Convert.ToDecimal(reader["overallfixedbudget"]),






                                });
                            }
                        }
                    }
                }

                if (budgetSummaries.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(budgetSummaries);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching budget summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the budget summary.");
            }
        }
















        [HttpGet("GetBomBudgetrevisiondetails")]
        public async Task<ActionResult<List<BudgetSummary>>> GetBomBudgetrevisiondetails(int jobid, int budgetheaderid)
        {
            var budgetSummaries = new List<BudgetSummary>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_GetBomBudgetrevisiondetails", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@jobid", jobid);
                        cmd.Parameters.AddWithValue("@budgetheaderid", budgetheaderid);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                budgetSummaries.Add(new BudgetSummary
                                {
                                    BudgetHeadName = reader["budgetheadername"].ToString(),
                                    BudgetHeaderId = reader.GetInt32(reader.GetOrdinal("budgetheaderid")),

                                    Amount = reader.IsDBNull(reader.GetOrdinal("Amount"))
                                     ? 0
                                     : Convert.ToDecimal(reader["Amount"]),



                                    bomrevno = reader.GetInt32(reader.GetOrdinal("bomrevno")),


                                });
                            }
                        }
                    }
                }

                if (budgetSummaries.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(budgetSummaries);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching budget summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the budget summary.");
            }
        }

























        public class MainJobValue
        {
            public decimal MainOrderValueBase { get; set; }
        }
        [HttpGet("GetMainJobValue")]
        public ActionResult<MainJobValue> GetMainJobValue(int jobId)
        {
            MainJobValue mainJobValue = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetMainjobvalue", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@jobid", jobId);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mainJobValue = new MainJobValue
                            {
                                MainOrderValueBase = reader.IsDBNull(reader.GetOrdinal("mainordervaluebase"))
                                                      ? 0
                                                      : Convert.ToDecimal(reader.GetDecimal(reader.GetOrdinal("mainordervaluebase")))
                            };
                        }
                    }
                }
            }

            if (mainJobValue == null)
            {
                return NotFound("No data found for the provided jobId.");
            }

            return Ok(mainJobValue);
        }







        [HttpGet("GetMaxInvoiceno")]
        public async Task<int?> GetMaxInvoiceno()

        {
            // Get the maximum PR ID from the PurchaseRequest table
            int maxinvoiceno = (await dbcontext.Invoice.MaxAsync(pr => (int?)pr.invoiceno) ?? 1000) + 1;

            return maxinvoiceno;
        }







        //[HttpPost("addorupdateinvoicedetails")]
        //public async Task<IActionResult> addorupdateinvoicedetails(AddorupdateInvoicedetails dto)
        //{
        //    using (var transaction = await dbcontext.Database.BeginTransactionAsync()) // Start a transaction
        //    {
        //        try
        //        {


        //            // Find existing received entry
        //            var existingEntry = await dbcontext.Invoice
        //                .FirstOrDefaultAsync(e => e.invoiceno == dto.invoiceno);

        //            if (existingEntry != null)
        //            {
        //                // Update existing entry
        //                existingEntry.invoiceno = dto.invoiceno;
        //                existingEntry.DueDate = dto.DueDate;
        //                existingEntry.remarks = dto.remarks;
        //                existingEntry.LPOno = dto.lpono;
        //                existingEntry.LPODate = dto.lpodate;
        //                existingEntry.jobid = dto.jobid;
        //                existingEntry.customerid = dto.customerid;
        //                existingEntry.InvoiceAddress = dto.invoiceaddress;
        //                existingEntry.InvoiceDate = dto.invoicedate;
        //                existingEntry.invcurrencyid = dto.currencyid;
        //                existingEntry.customercontactid = dto.customercontactid;
        //                dbcontext.Invoice.Update(existingEntry);
        //            }
        //            else
        //            {
        //                // Create a new received entry
        //                existingEntry = new Invoice
        //                {
        //                    invoiceno = dto.invoiceno,
        //                    DueDate = dto.DueDate,
        //                    remarks = dto.remarks,
        //                    LPOno = dto.lpono,
        //                    LPODate = dto.lpodate,
        //                    jobid = dto.jobid,
        //                    customerid = dto.customerid,
        //                    InvoiceAddress = dto.invoiceaddress,
        //                    invcurrencyid = dto.currencyid,
        //                    customercontactid =dto.customercontactid
        //                };

        //                await dbcontext.Invoice.AddAsync(existingEntry);
        //            }

        //            await dbcontext.SaveChangesAsync(); // Save received entry

        //            foreach (var item in dto.invoicedetails)
        //            {
        //                if (item.invidno > 0)
        //                {
        //                    // Update existing detail if rtblid exists
        //                    var existingDetail = await dbcontext.Invoicedetails
        //                        .FirstOrDefaultAsync(d => d.invidno == item.invidno);

        //                    if (existingDetail != null)
        //                    {
        //                        existingDetail.unitprice = item.unitprice;
        //                        existingDetail.vatpercent = item.vatpercent;
        //                        existingDetail.qty = item.qty;
        //                        existingDetail.uom = item.uom;
        //                        existingDetail.amount = item.amount;
        //                        existingDetail.description = item.description;
        //                        existingDetail.taxamount = item.taxamount;
        //                        existingDetail.invoiceno = dto.invoiceno;
        //                        existingDetail.counter = item.counter;

        //                        dbcontext.Invoicedetails.Update(existingDetail);
        //                    }
        //                }
        //                else
        //                {
        //                    // Insert new detail if rtblid doesn't exist
        //                    var newDetail = new Invoicedetails
        //                    {
        //                        unitprice = item.unitprice,
        //                        vatpercent = item.vatpercent,
        //                        qty = item.qty,
        //                        uom = item.uom,
        //                        amount = item.amount,
        //                        description = item.description,
        //                        taxamount = item.taxamount,
        //                        invoiceno = dto.invoiceno,
        //                        counter = item.counter
        //                    };

        //                    await dbcontext.Invoicedetails.AddAsync(newDetail);
        //                }
        //            }
        //            await dbcontext.SaveChangesAsync(); // Save received entry details
        //            await transaction.CommitAsync(); // Commit transaction if everything succeeds
        //            return Ok(new { Message = "Invoice Entry and details saved successfully.", invoiceno = existingEntry.invoiceno });
        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync(); // Rollback transaction on failure

        //            return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
        //        }


        //    }
        //}













        [HttpPost("addorupdateinvoicedetails")]
        public async Task<IActionResult> addorupdateinvoicedetails(AddorupdateInvoicedetails dto)
        {
            // Validate if invoiceno is provided in the DTO
            if (dto.invoiceno <= 0)
            {
                return BadRequest(new { Message = "Invoice number (invoiceno) is required." });
            }

            using (var transaction = await dbcontext.Database.BeginTransactionAsync()) // Start a transaction
            {
                try
                {
                    Invoice existingEntry;

                    // --- 1. HANDLE INVOICE HEADER (INSERT or UPDATE) ---

                    var header = await dbcontext.Invoice
                        .FirstOrDefaultAsync(e => e.invoiceno == dto.invoiceno);

                    if (header != null)
                    {
                        // Update existing header
                        header.DueDate = dto.DueDate;
                        header.remarks = dto.remarks;
                        header.LPOno = dto.lpono;
                        header.LPODate = dto.lpodate;
                        header.jobid = dto.jobid;
                        header.customerid = dto.customerid;
                        header.InvoiceAddress = dto.invoiceaddress;
                        header.InvoiceDate = dto.invoicedate;
                        header.invcurrencyid = dto.currencyid;
                        header.customercontactid = dto.customercontactid;
                        dbcontext.Invoice.Update(header);
                        existingEntry = header;
                    }
                    else
                    {
                        // Create a new header
                        header = new Invoice
                        {
                            invoiceno = dto.invoiceno, // Assuming the invoiceno is generated/provided for new invoices
                            InvoiceDate = dto.invoicedate,
                            DueDate = dto.DueDate,
                            remarks = dto.remarks,
                            LPOno = dto.lpono,
                            LPODate = dto.lpodate,
                            jobid = dto.jobid,
                            customerid = dto.customerid,
                            InvoiceAddress = dto.invoiceaddress,
                            invcurrencyid = dto.currencyid,
                            customercontactid = dto.customercontactid
                        };

                        await dbcontext.Invoice.AddAsync(header);
                        existingEntry = header;
                    }

                    // Save changes to ensure the header exists before saving details
                    // This is essential if you are relying on auto-increment IDs for foreign keys, 
                    // but since you use invoiceno as a key, a single SaveChanges at the end is fine.
                    // However, saving here ensures the header is established if it was new.
                    await dbcontext.SaveChangesAsync();

                    // --- 2. HANDLE INVOICE DETAILS (DELETE ALL AND INSERT NEW SET) ---

                    // A. Delete all existing invoice details for this invoice number
                    var existingDetails = await dbcontext.Invoicedetails
                        .Where(d => d.invoiceno == dto.invoiceno)
                        .ToListAsync();

                    if (existingDetails.Any())
                    {
                        dbcontext.Invoicedetails.RemoveRange(existingDetails);
                    }

                    // B. Add all new (or updated) details from the DTO
                    foreach (var item in dto.invoicedetails)
                    {
                        // Create a new Invoicedetails object for insertion
                        var newDetail = new Invoicedetails
                        {
                            unitprice = item.unitprice,
                            vatpercent = item.vatpercent,
                            qty = item.qty,
                            uom = item.uom,
                            amount = item.amount,
                            description = item.description,
                            taxamount = item.taxamount,
                            invoiceno = existingEntry.invoiceno, // Use the final invoiceno
                            counter = item.counter
                            // Note: invidno is left out for a new insert to let the DB generate it
                        };
                        await dbcontext.Invoicedetails.AddAsync(newDetail);
                    }

                    await dbcontext.SaveChangesAsync(); // Save all detail changes (deletes and inserts)
                    await transaction.CommitAsync(); // Commit transaction if everything succeeds

                    return Ok(new { Message = "Invoice and details saved successfully.", invoiceno = existingEntry.invoiceno });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(); // Rollback transaction on failure
                    return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
                }
            }
        }





























        [HttpPost("addorupdatemiscost")]
        public async Task<IActionResult> addorupdatemiscost([FromBody] Addorupdatemiscostdetails dto) // Add [FromBody]
        {
            using (var transaction = await dbcontext.Database.BeginTransactionAsync()) // Start a transaction
            {
                try
                {
                    if (dto == null || dto.misdetails == null)
                    {
                        return BadRequest(new { Message = "Invalid input data." });
                    }

                    foreach (var item in dto.misdetails)
                    {
                        if (item.misid > 0)
                        {
                            // Update existing detail if misid exists
                            var existingDetail = await dbcontext.Miscost
                                .FirstOrDefaultAsync(d => d.misid == item.misid);

                            if (existingDetail != null)
                            {
                                existingDetail.description = item.description;
                                existingDetail.misamount = item.misamount;
                                // You don't need dbcontext.Miscost.Update(existingDetail); if you fetched it
                                // and EF Core is tracking it. Changes will be detected on SaveChanges.
                                // However, explicitly calling Update is harmless and can be clearer sometimes.
                                // If existingDetail was detached, you would need Update.
                                // For simplicity and safety, leaving it if you prefer explicit calls.
                                dbcontext.Miscost.Update(existingDetail); // Explicitly mark as modified
                            }
                            else
                            {
                                // Handle case where misid > 0 but no record found.
                                // Depending on your business logic, you might:
                                // 1. Log a warning
                                // 2. Return a specific error for that item
                                // 3. Decide to add it as a new item (less common for "update" logic)
                                // For now, let's assume valid misids always exist for updates.
                                // Or, if you want to add it if not found, uncomment below:
                                // var newmiscost = new Miscost
                                // {
                                //     description = item.description,
                                //     jobid = item.jobid,
                                //     misamount = item.misamount,
                                // };
                                // await dbcontext.Miscost.AddAsync(newmiscost);
                                return NotFound(new { Message = $"Miscost with ID {item.misid} not found for update." });
                            }
                        }
                        else // misid is 0 or less, indicating a new item
                        {
                            var newmiscost = new Miscost
                            {
                                description = item.description,
                                jobid = item.jobid,
                                misamount = item.misamount,

                                counter = item.counter,
                                createdbyuser = item.createdbyuser,
                                createddate = DateTime.UtcNow.Date
                                // misid will be generated by the database if it's an identity column
                            };
                            await dbcontext.Miscost.AddAsync(newmiscost); // Add the new item
                        }
                    }

                    await dbcontext.SaveChangesAsync(); // Save all changes (updates and additions)
                    await transaction.CommitAsync(); // Commit transaction if everything succeeds

                    return StatusCode(200, new { Message = "Miscost entries processed successfully." }); // Changed to 200 OK as it's an update/add
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(); // Rollback transaction on failure

                    // Log the exception details for debugging
                    // Consider using a proper logging framework like Serilog or NLog
                    Console.Error.WriteLine($"Error in addorupdatemiscost: {ex.Message}");
                    Console.Error.WriteLine($"Stack Trace: {ex.StackTrace}");

                    return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
                }
            }
        }

        [HttpGet("GetInvoicedetailsbyInvoiceno")]
        public async Task<IActionResult> GetInvoicedetailsbyInvoiceno(int invoiceno)
        {

            try
            {

                var invoiceheader = await dbcontext.Invoice
              .Where(po => po.invoiceno == invoiceno)
              .FirstOrDefaultAsync();
                if (invoiceheader == null)
                {
                    return NotFound();
                }
                return Ok(invoiceheader);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }





        [HttpGet("GetDeliverydetailsbydeliveryid")]
        public async Task<IActionResult> GetDeliverydetailsbydeliveryid(int deliveryno)
        {

            try
            {

                var deliveryheader = await dbcontext.DeliveryNote
              .Where(po => po.deliveryno == deliveryno)
              .FirstOrDefaultAsync();
                if (deliveryheader == null)
                {
                    return NotFound();
                }
                return Ok(deliveryheader);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }











        [HttpGet("GetAllInvoicelinedetailsbyinvoiceid")]
        public async Task<IActionResult> GetAllInvoicelinedetailsbyinvoiceid(int invoiceno)
        {

            try
            {

                var invoicedetails = await dbcontext.Invoicedetails
              .Where(po => po.invoiceno == invoiceno)
                  .OrderBy(po => po.counter)
              .ToListAsync();
                if (invoicedetails == null)
                {
                    return NotFound();
                }
                return Ok(invoicedetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            };
        }
























        [HttpDelete("deleteinvoicedetails")]
        public async Task<IActionResult> deleteinvoicedetails(int invidno)
        {
            try
            {
                // Find the invoice detail by rtblid
                var invoiceDetail = await dbcontext.Invoicedetails.FirstOrDefaultAsync(d => d.invidno == invidno);

                if (invoiceDetail == null)
                {
                    return NotFound(new { Message = "Invoice detail not found." });
                }

                // Remove the detail from the database
                dbcontext.Invoicedetails.Remove(invoiceDetail);
                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Invoice detail deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting invoice detail.", Error = ex.Message });
            }
        }



        [HttpDelete("deletemisdetails")]
        public async Task<IActionResult> deletemisdetails(int misid)
        {
            try
            {
                // Find the invoice detail by rtblid
                var misdetails = await dbcontext.Miscost.FirstOrDefaultAsync(d => d.misid == misid);

                if (misdetails == null)
                {
                    return NotFound(new { Message = "Mis detail not found." });
                }

                // Remove the detail from the database
                dbcontext.Miscost.Remove(misdetails);
                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Invoice detail deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting invoice detail.", Error = ex.Message });
            }
        }




        [HttpDelete("deletedeliveryDetails")]
        public async Task<IActionResult> deletedeliveryDetails(int did)
        {
            try
            {
                // Find the invoice detail by rtblid
                var deliverydetails = await dbcontext.deliverydetails.FirstOrDefaultAsync(d => d.did == did);

                if (deliverydetails == null)
                {
                    return NotFound(new { Message = "Delivery detail not found." });
                }

                // Remove the detail from the database
                dbcontext.deliverydetails.Remove(deliverydetails);
                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Delivery detail deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting invoice detail.", Error = ex.Message });
            }
        }




























        [HttpPost("updateInvoiceCounters")]
        public async Task<IActionResult> UpdateInvoiceCounters([FromBody] List<InvoiceDetailUpdateDto> updatedCounters)
        {
            foreach (var item in updatedCounters)
            {
                var invoiceDetail = await dbcontext.Invoicedetails
                                                  .FirstOrDefaultAsync(d => d.invidno == item.Invidno);
                if (invoiceDetail != null)
                {
                    invoiceDetail.counter = item.Counter;
                }
            }

            await dbcontext.SaveChangesAsync();
            return Ok();
        }






        [HttpPost("updatemisCounters")]
        public async Task<IActionResult> updatemisCounters([FromBody] List<misDetailUpdateDto> updatedCounters)
        {
            foreach (var item in updatedCounters)
            {
                var misdetails = await dbcontext.Miscost
                                                  .FirstOrDefaultAsync(d => d.misid == item.misid);
                if (misdetails != null)
                {
                    misdetails.counter = item.Counter;
                }
            }

            await dbcontext.SaveChangesAsync();
            return Ok();
        }











        [HttpPost("updatedeliveryCounters")]
        public async Task<IActionResult> updatedeliveryCounters([FromBody] List<DeliverydetailUpdateDto> updatedCounters)
        {
            foreach (var item in updatedCounters)
            {
                var deliverydetail = await dbcontext.deliverydetails
                                                  .FirstOrDefaultAsync(d => d.did == item.did);
                if (deliverydetail != null)
                {
                    deliverydetail.counter = item.Counter;
                }
            }

            await dbcontext.SaveChangesAsync();
            return Ok();
        }































        // DTO to handle incoming data
        public class InvoiceDetailUpdateDto
        {
            public int Invidno { get; set; }
            public int Counter { get; set; }
        }

        public class misDetailUpdateDto
        {
            public int misid { get; set; }
            public int Counter { get; set; }
        }


        public class DeliverydetailUpdateDto
        {
            public int did { get; set; }
            public int Counter { get; set; }
        }













        [HttpGet("GetInvoicePdf")]
        public IActionResult GetInvoicePdf(int id)
        {
            var invoice = dbcontext.Invoice
      .Include(i => i.Customer)  // Correct syntax
      .FirstOrDefault(i => i.invoiceno == id);

            if (invoice == null)
            {
                return NotFound();
            }


            var details = dbcontext.Invoicedetails
    .Where(i => i.invoiceno == id)
    .ToList();
            using (MemoryStream ms = new MemoryStream())
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4);
                PdfWriter.GetInstance(document, ms);
                document.Open();

                // Header Section
                PdfPTable headerTable = new PdfPTable(2);
                headerTable.WidthPercentage = 100;
                float[] columnWidths = { 0.5f, 0.5f };  // Equal width for both cells
                headerTable.SetWidths(columnWidths);

                // Left Side (Logo)
                string logoPath = "wwwroot/images/Logo.bmp";
                if (System.IO.File.Exists(logoPath))
                {
                    Image logo = Image.GetInstance(logoPath);
                    logo.ScaleToFit(100f, 100f);
                    logo.Alignment = Element.ALIGN_LEFT;
                    PdfPCell leftCell = new PdfPCell(logo)
                    {
                        Border = PdfPCell.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    headerTable.AddCell(leftCell);
                }
                else
                {
                    PdfPCell emptyCell = new PdfPCell()
                    {
                        Border = PdfPCell.NO_BORDER
                    };
                    headerTable.AddCell(emptyCell);
                }

                // Right Side (Invoice Details)
                PdfPCell rightCell = new PdfPCell()
                {
                    Border = PdfPCell.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                Paragraph invoiceNo = new Paragraph("Invoice No: " + invoice.invoiceno, FontFactory.GetFont(FontFactory.HELVETICA, 10));
                invoiceNo.Alignment = Element.ALIGN_RIGHT;

                Paragraph date = new Paragraph("Date: 2025-03-18", FontFactory.GetFont(FontFactory.HELVETICA, 10));
                date.Alignment = Element.ALIGN_RIGHT;

                Paragraph customerId = new Paragraph("Customer ID: 67890", FontFactory.GetFont(FontFactory.HELVETICA, 10));
                customerId.Alignment = Element.ALIGN_RIGHT;

                // Add paragraphs to the right cell
                rightCell.AddElement(invoiceNo);
                rightCell.AddElement(date);
                rightCell.AddElement(customerId);

                // Add the right cell to the header table
                headerTable.AddCell(rightCell);

                // Add header table to document
                document.Add(headerTable);










                PdfPTable headerTable1 = new PdfPTable(2);
                headerTable1.WidthPercentage = 100;
                float[] columnWidths1 = { 1f, 0.5f };  // Equal width for both cells
                headerTable1.SetWidths(columnWidths1);
                PdfPCell leftcell = new PdfPCell()
                {
                    Border = PdfPCell.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                Paragraph invoiceNo1 = new Paragraph("ANNEXTURE TO INVOICE", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
                invoiceNo.Alignment = Element.ALIGN_LEFT;

                Paragraph date1 = new Paragraph("To " + invoice.Customer.Customername, FontFactory.GetFont(FontFactory.HELVETICA, 10));
                date.Alignment = Element.ALIGN_LEFT;

                Paragraph customerId1 = new Paragraph(invoice.Customer.address, FontFactory.GetFont(FontFactory.HELVETICA, 10));
                customerId.Alignment = Element.ALIGN_LEFT;

                // Add paragraphs to the right cell
                leftcell.AddElement(invoiceNo1);
                leftcell.AddElement(date1);
                leftcell.AddElement(customerId1);

                // Add the1 right cell to the header table
                headerTable1.AddCell(leftcell);



                PdfPTable borderedTable = new PdfPTable(2);
                borderedTable.WidthPercentage = 100;
                borderedTable.SetWidths(new float[] { 0.5f, 0.5f });  // Equal width for both columns

                // Add 4 rows of key-value pairs with borders
                borderedTable.AddCell(new PdfPCell(new Phrase("Invoice No:")) { HorizontalAlignment = Element.ALIGN_LEFT });
                borderedTable.AddCell(new PdfPCell(new Phrase(invoice.invoiceno)) { HorizontalAlignment = Element.ALIGN_RIGHT });

                borderedTable.AddCell(new PdfPCell(new Phrase("Date:")) { HorizontalAlignment = Element.ALIGN_LEFT });
                borderedTable.AddCell(new PdfPCell(new Phrase($"{invoice.InvoiceDate:dd-MM-yyyy}")) { HorizontalAlignment = Element.ALIGN_RIGHT });


                borderedTable.AddCell(new PdfPCell(new Phrase("Our Ref:")) { HorizontalAlignment = Element.ALIGN_LEFT });
                borderedTable.AddCell(new PdfPCell(new Phrase($"{invoice.jobid}")) { HorizontalAlignment = Element.ALIGN_RIGHT });

                borderedTable.AddCell(new PdfPCell(new Phrase("Customer LPO No:")) { HorizontalAlignment = Element.ALIGN_LEFT });
                borderedTable.AddCell(new PdfPCell(new Phrase($"{invoice.LPOno}")) { HorizontalAlignment = Element.ALIGN_RIGHT });

                borderedTable.AddCell(new PdfPCell(new Phrase("Customer LPO Date:")) { HorizontalAlignment = Element.ALIGN_LEFT });
                borderedTable.AddCell(new PdfPCell(new Phrase($"{invoice.LPODate:dd-MM-yyyy}")) { HorizontalAlignment = Element.ALIGN_RIGHT });

                // Wrap borderedTable in a cell to add to headerTable1 (Right side)
                PdfPCell borderedTableCell = new PdfPCell(borderedTable)
                {
                    Border = PdfPCell.NO_BORDER,  // No border for the wrapping cell
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                headerTable1.AddCell(borderedTableCell);












                // Add header table to document
                document.Add(headerTable1);

























                document.Add(new Paragraph(" "));

                // Items Table
                PdfPTable table = new PdfPTable(7);
                float[] widths = new float[] { 1f, 3f, 1f, 1f, 1.5f, 1.5f, 1.5f };
                table.SetWidths(widths);
                table.WidthPercentage = 100;
                table.AddCell("Sr No");
                table.AddCell("Description");
                table.AddCell("UOM");
                table.AddCell("QTY");
                table.AddCell("Unit Price");
                table.AddCell("Amount");
                table.AddCell("Vat %");

                int srNo = 1;
                foreach (var detail in details)
                {
                    table.AddCell(srNo.ToString());
                    table.AddCell(detail.description);
                    table.AddCell(detail.uom);
                    table.AddCell(detail.qty);
                    table.AddCell(detail.unitprice);
                    table.AddCell(detail.amount);
                    table.AddCell(detail.vatpercent);
                    srNo++;
                }
                document.Add(table);

                // Footer Notes
                document.Add(new Paragraph("CUSTOM INVOICE NO: ACE/2025/0125"));
                document.Add(new Paragraph($"INVOICE DATED: {invoice.InvoiceDate:dd-MM-yyyy}"));
                document.Add(new Paragraph("DELIVERY NOTE: 4468"));
                document.Close();

                return File(ms.ToArray(), "application/pdf", $"Invoice_{invoice.invoiceno}.pdf");
            }




























        }






        public class InvoiceRegistrationRequest
        {
            public int jobId { get; set; }
            public decimal invoiceValue { get; set; }
            public int invoiceCurrencyId { get; set; }
            public int invoiceId { get; set; }
            public decimal invoiceValueWithVat { get; set; }
            public string registeredBy { get; set; }


        }



        [HttpPost("RegisterInvoice")]
        public IActionResult RegisterInvoice([FromBody] InvoiceRegistrationRequest request)
        {
            using (var transaction = dbcontext.Database.BeginTransaction())
            {
                try
                {
                    var job = dbcontext.Job
                        .Include(j => j.Currency)
                        .FirstOrDefault(j => j.Jobid == request.jobId);

                    if (job == null)
                    {
                        throw new Exception("Job not found");
                    }

                    var invoice = dbcontext.Invoice
                        .FirstOrDefault(j => j.invoiceno == request.invoiceId);

                    if (invoice == null)
                    {
                        throw new Exception("Invoice not found");
                    }

                    // Check currency
                    if (job.Currency.currencyid != request.invoiceCurrencyId)
                    {
                        throw new Exception("Invoice currency must match the job currency.");
                    }

                    // Calculate total invoiced value in base currency
                    decimal totalInvoiced = job.totalinvoiceinbasecurrency;
                    decimal newTotal = totalInvoiced + request.invoiceValue * (decimal)job.exchangerate;
                    decimal orderValueBaseCurrency = Convert.ToDecimal(job.ordervaluebasecurrency) + Convert.ToDecimal(job.ordervaluebasecurrency) * 5 / 100;
                    if (newTotal > orderValueBaseCurrency)
                    {
                        throw new Exception("Total invoice value exceeds job order value.");
                    }

                    // Ensure registeredBy is not empty
                    if (string.IsNullOrWhiteSpace(request.registeredBy))
                    {
                        throw new Exception("RegisteredBy cannot be empty.");
                    }

                    // Proceed with invoice registration
                    var invoiceregdetails = new InvoiceReg
                    {
                        invoiceno = request.invoiceId,
                        Invoicevalueinbasecurrency = request.invoiceValueWithVat * (decimal)job.exchangerate,
                        customerid = invoice.customerid,
                        currencyid = invoice.invcurrencyid,
                        jobid = invoice.jobid,
                        Invoicevalue = request.invoiceValueWithVat,
                        Invoiceregisteredby = request.registeredBy
                    };

                    dbcontext.InvoiceReg.Add(invoiceregdetails);

                    // Update job total invoice value
                    job.totalinvoiceinbasecurrency = newTotal;
                    invoice.isregistered = 1;

                    // Save all changes only if everything is valid
                    dbcontext.SaveChanges();
                    transaction.Commit();

                    return Ok("Invoice registered successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest(ex.Message);
                }
            }
        }








        [HttpGet("GetstockIssuecostdetailsbyjobid")]
        public async Task<IActionResult> GetstockIssuecostdetailsbyjobid(int jobid)
        {
            if (jobid <= 0)
            {
                return BadRequest("Invalid jobid");
            }

            var result = await (from d in dbcontext.IssuedetailsfromStock
                                join h in dbcontext.IssueNoteheader on d.issuenoteref equals h.issueref
                                join im in dbcontext.Product on d.itemid equals im.productcode
                                join bh in dbcontext.BudgettHeader on im.itembudgetheaderid equals bh.budgetheaderid
                                join cc in dbcontext.Currency on d.issuecurrencyid equals cc.currencyid
                                where h.issuetype == "stock" && h.jobid == jobid

                                && h.isregistered == 1
                                group new { d, cc } by new { h.jobid, im.itembudgetheaderid, bh.budgetheadername } into g
                                select new
                                {
                                    JobId = g.Key.jobid,
                                    BudgetHeaderId = g.Key.itembudgetheaderid,
                                    BudgetHeaderName = g.Key.budgetheadername,
                                    TotalCost = g.Sum(x => (decimal)x.d.issueqty * x.d.issueprice * (decimal)x.cc.exchangerate)
                                })
                     .OrderBy(x => x.JobId)
                     .ThenBy(x => x.BudgetHeaderId)
                     .ToListAsync();
            if (!result.Any())
            {
                return NotFound("Invoice registration details not found");
            }

            return Ok(result);
        }















        [HttpGet("GetStockissuenotelinedetails")]
        public async Task<IActionResult> GetStockissuenotelinedetails(int jobid, int budgetheaderid)
        {
            if (jobid <= 0)
            {
                return BadRequest("Invalid jobid");
            }

            var issuedetails = await (from aa in dbcontext.IssueNoteheader
                                      join bb in dbcontext.IssuedetailsfromStock on aa.issueref equals bb.issuenoteref
                                      join ii in dbcontext.Product on bb.itemid equals ii.productcode
                                      join cc in dbcontext.Currency on bb.issuecurrencyid equals cc.currencyid
                                      where aa.jobid == jobid && ii.itembudgetheaderid == budgetheaderid

                                      && aa.isregistered == 1

                                      select new
                                      {
                                          issueref = aa.issueref,
                                          itemname = ii.itemname,
                                          isueqty = bb.issueqty,
                                          price = bb.issueprice,

                                          totalissuecost = (decimal)bb.issueqty * (decimal)bb.issueprice * Convert.ToDecimal(cc.exchangerate)

                                      })
                                           .ToListAsync();

            if (!issuedetails.Any())
            {
                return NotFound("Issue   details not found");
            }

            return Ok(issuedetails);
        }






        [HttpPost("SaveEstimations")]
        public async Task<IActionResult> SaveEstimations([FromBody] List<FixedBudgetdto> estimations)
        {
            if (estimations == null || estimations.Count == 0)
            {
                return BadRequest("No estimations provided.");
            }
            // 🔹 Get the latest revision number and increment it
            int latestRevision = await dbcontext.FixedBudget.MaxAsync(fb => (int?)fb.revision) ?? 0;
            int newRevision = latestRevision + 1;

            // 🔹 Convert DTOs to Entities
            var newEstimations = estimations.Select(estimation => new FixedBudget
            {
                budgetId = estimation.budgetId,
                fixedamount = estimation.fixedamount,
                revision = newRevision,

                jobid = estimation.jobid
            }).ToList();

            // 🔹 Save all new records in a single database operation
            await dbcontext.FixedBudget.AddRangeAsync(newEstimations);
            await dbcontext.SaveChangesAsync();

            return Ok(new { message = "Estimations saved successfully", revision = newRevision });
        }















        [HttpGet("GetLastRevisionEstimations")]
        public async Task<IActionResult> GetLastRevisionEstimations()
        {
            int? latestRevision = await dbcontext.FixedBudget.MaxAsync(fb => (int?)fb.revision);
            if (latestRevision == null) return Ok(new List<FixedBudget>());

            var estimations = await dbcontext.FixedBudget
                .Where(fb => fb.revision == latestRevision)
                .Select(fb => new { budgetId = fb.budgetId, fixedamount = fb.fixedamount })
                .ToListAsync();

            return Ok(estimations);
        }


        [HttpGet("GetLastRevisionEstimationsbyjobid")]
        public async Task<IActionResult> GetLastRevisionEstimationsbyjobid([FromQuery] int jobno)
        {
            if (jobno <= 0)
                return BadRequest("Valid jobno is required.");

            int? latestRevision = await dbcontext.FixedBudget
                .Where(fb => fb.jobid == jobno)
                .MaxAsync(fb => (int?)fb.revision);

            if (latestRevision == null)
                return Ok(new List<object>());

            var estimations = await dbcontext.FixedBudget
                .Where(fb => fb.jobid == jobno && fb.revision == latestRevision)
                .Select(fb => new
                {
                    budgetId = fb.budgetId,
                    fixedamount = fb.fixedamount
                })
                .ToListAsync();

            return Ok(estimations);
        }
















        [HttpPost("addOrUpdateestimationdetails")]
        public async Task<IActionResult> addOrUpdateestimationdetails(Addorupdateestimationcollectiondetails dto)
        {
            try
            {
                // Find existing received entry



                // Insert or update details
                foreach (var item in dto.estimationdetails)
                {
                    var detail = new estimation
                    {


                        applicationid = item.applicationid,
                        // Associate with the received entry
                        jobid = item.jobid,
                        currencyid = item.currencyid,
                        uomid = item.uomid,
                        quantity = item.qty,
                        price = item.unitprice,
                        revision = item.revision,
                        itemid = item.itemid,

                    };

                    await dbcontext.estimation.AddAsync(detail);
                }

                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Received entry and details saved successfully." });
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                // Log.Error(ex, "An error occurred while processing the received entry details.");

                // Return a generic error message to the client
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }

















        [HttpGet("GetEstimationDetailedView")]
        public async Task<IActionResult> GetEstimationDetailedView(int jobid)
        {
            if (jobid <= 0)
            {
                return BadRequest("Invalid jobid");
            }

            var estimationdetails = await (from aa in dbcontext.estimation
                                           join cc in dbcontext.Currency on aa.currencyid equals cc.currencyid
                                           join pp in dbcontext.Product on aa.itemid equals pp.productcode
                                           join bh in dbcontext.BudgettHeader on pp.itembudgetheaderid equals bh.budgetheaderid
                                           join app in dbcontext.ProductionStages on aa.applicationid equals app.prostageid

                                           where aa.jobid == jobid


                                           select new
                                           {
                                               estimationid = aa.estimationid,
                                               budgetheadername = bh.budgetheadername,
                                               itemname = pp.itemname,
                                               application = app.productionstagename,
                                               unitprice = aa.price,
                                               qty = aa.quantity,
                                               revision = aa.revision,
                                               totalpriceinbasecurrency = aa.quantity * aa.price * Convert.ToDecimal(cc.exchangerate),
                                               isconvertedtobom = aa.isconvertedtobom


                                           })
                                           .ToListAsync();

            if (!estimationdetails.Any())
            {
                return NotFound("Estimation   details not found");
            }

            return Ok(estimationdetails);
        }













        [HttpGet("GetMaxmino")]
        public async Task<int?> GetMaxmino()

        {
            // Get the maximum PR ID from the PurchaseRequest table
            int maxmino = (await dbcontext.Materialinspection.MaxAsync(pr => (int?)pr.mid) ?? 1000) + 1;
            return maxmino;
        }











        [HttpGet("GetPOdetailsfromreno")]

        public async Task<IActionResult> GetPOdetailsfromreno(int reno)
        {
            if (reno <= 0)
            {
                return BadRequest("Invalid reno");
            }

            var podetails = await (from aa in dbcontext.PO
                                   join re in dbcontext.ReceivedEntry on aa.Orderid equals re.pono

                                   where re.REID == reno
                                   select new
                                   {
                                       jobid = aa.jobid,
                                       pono = aa.Orderid,





                                   })
                                           .FirstOrDefaultAsync();

            if (podetails == null)
            {
                return NotFound();
            }

            return Ok(podetails);
        }








        //    [HttpPost("AddorupdateMI")]
        //    public async Task<IActionResult> AddorupdateMI(AddorUpdateMIHeaderandDetails dto)
        //    {
        //        using (var transaction = await dbcontext.Database.BeginTransactionAsync()) // Start a transaction
        //        {
        //            try
        //            {
        //                var unregisteredmi = await dbcontext.Materialinspection
        //                    .Where(e => e.isregistered == 0 && e.mid != dto.mid)
        //                    .ToListAsync();

        //                if (unregisteredmi.Any())
        //                {
        //                    return Ok(new { message = "unreg" });
        //                }

        //                // Find existing received entry
        //                var exitingmi = await dbcontext.Materialinspection
        //                    .FirstOrDefaultAsync(e => e.mid == dto.mid);

        //                if (exitingmi != null)
        //                {
        //                    // Update existing entry
        //                    exitingmi.pono = dto.pono;
        //                    exitingmi.mid = dto.mid;
        //                    exitingmi.midate = dto.midate;
        //                    exitingmi.reid = dto.reid;
        //                    exitingmi.remarks = dto.remarks;
        //                    exitingmi.colorcoding = dto.colorcoding;
        //                    exitingmi.correlation = dto.correlation;
        //                    exitingmi.phycondn = dto.phycondn;
        //                    exitingmi.heattags = dto.heattags;
        //                    exitingmi.tcverify = dto.tcverify;
        //                    exitingmi.siteidentification = dto.siteidentification;
        //                    exitingmi.tcverify = dto.tcverify;


        //                    exitingmi.materialsent = dto.materialsent;  
        //                    dbcontext.Materialinspection.Update(exitingmi);
        //                }
        //                else
        //                {
        //                    // Create a new received entry
        //                    exitingmi = new Materialinspection
        //                    {
        //                        pono = dto.pono,
        //                        mid = dto.mid,
        //                        midate = dto.midate,
        //                        reid = dto.reid,
        //                        remarks = dto.remarks,
        //                        colorcoding = dto.colorcoding,
        //                        correlation = dto.correlation,
        //                        phycondn = dto.phycondn,
        //                        heattags = dto.heattags,
        //                        tcverify = dto.tcverify,
        //                        siteidentification = dto.siteidentification,
        //                        materialsent = dto.materialsent,
        //                        qtyverified = dto.qtyverified,

        //                    };
        //                        dbcontext.Materialinspection.Update(exitingmi);


        //                    await dbcontext.Materialinspection.AddAsync(exitingmi);
        //                }

        //                await dbcontext.SaveChangesAsync(); // Save received entry

        //                // Insert or update details
        //                foreach (var item in dto.midetails)
        //                {
        //                    var detail = new MIdetails
        //                    {
        //                       mid =item.mid,
        //                       itemid =item.itemid,
        //                        acceptedqty = item.acceptedqty,
        //                        rejectedqty = item.rejectedqty,
        //                        holdqty =item.holdqty

        //};

        //                    await dbcontext.MIdetails.AddAsync(detail);
        //                }

        //                await dbcontext.SaveChangesAsync(); // Save received entry details

        //                await transaction.CommitAsync(); // Commit transaction if everything succeeds

        //                return Ok(new { Message = "MI Details  saved successfully." });
        //            }
        //            catch (Exception ex)
        //            {
        //                await transaction.RollbackAsync(); // Rollback transaction on failure

        //                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
        //            }


        //        }
        //    }


        [HttpPost("AddorupdateMI")]
        public async Task<IActionResult> AddorupdateMI(AddorUpdateMIHeaderandDetails dto)
        {
            using (var transaction = await dbcontext.Database.BeginTransactionAsync())
            {
                try
                {
                    // Check if there are any unregistered MI entries (other than the one being saved)
                    var unregisteredmi = await dbcontext.Materialinspection
                        .Where(e => e.isregistered == 0 && e.mid != dto.mid)
                        .ToListAsync();

                    if (unregisteredmi.Any())
                    {
                        return Ok(new { message = "unreg" });
                    }

                    // Check if this MI already exists
                    var exitingmi = await dbcontext.Materialinspection
                        .FirstOrDefaultAsync(e => e.mid == dto.mid);

                    if (exitingmi != null)
                    {
                        // Update existing MI entry
                        exitingmi.pono = dto.pono;
                        exitingmi.mid = dto.mid;
                        exitingmi.midate = dto.midate;
                        exitingmi.reid = dto.reid;
                        exitingmi.remarks = dto.remarks;
                        exitingmi.colorcoding = dto.colorcoding;
                        exitingmi.correlation = dto.correlation;
                        exitingmi.phycondn = dto.phycondn;
                        exitingmi.heattags = dto.heattags;
                        exitingmi.tcverify = dto.tcverify;
                        exitingmi.siteidentification = dto.siteidentification;
                        exitingmi.materialsent = dto.materialsent;
                        exitingmi.qtyverified = dto.qtyverified;

                        dbcontext.Materialinspection.Update(exitingmi);
                    }
                    else
                    {
                        // Create new MI entry
                        exitingmi = new Materialinspection
                        {
                            pono = dto.pono,
                            mid = dto.mid,
                            midate = dto.midate,
                            reid = dto.reid,
                            remarks = dto.remarks,
                            colorcoding = dto.colorcoding,
                            correlation = dto.correlation,
                            phycondn = dto.phycondn,
                            heattags = dto.heattags,
                            tcverify = dto.tcverify,
                            siteidentification = dto.siteidentification,
                            materialsent = dto.materialsent,
                            qtyverified = dto.qtyverified,
                        };

                        await dbcontext.Materialinspection.AddAsync(exitingmi);
                    }

                    await dbcontext.SaveChangesAsync();

                    // Process MI Details (Update if exists, else insert)
                    foreach (var item in dto.midetails)
                    {
                        var existingDetail = await dbcontext.MIdetails
                            .FirstOrDefaultAsync(x => x.mid == item.mid && x.itemid == item.itemid);

                        if (existingDetail != null)
                        {
                            // Update existing record
                            existingDetail.acceptedqty = item.acceptedqty;
                            existingDetail.rejectedqty = item.rejectedqty;
                            existingDetail.holdqty = item.holdqty;

                            dbcontext.MIdetails.Update(existingDetail);
                        }
                        else
                        {
                            // Add new record
                            var detail = new MIdetails
                            {
                                mid = item.mid,
                                itemid = item.itemid,
                                acceptedqty = item.acceptedqty,
                                rejectedqty = item.rejectedqty,
                                holdqty = item.holdqty,
                                rtblid = item.rtblid
                            };

                            await dbcontext.MIdetails.AddAsync(detail);
                        }
                    }

                    await dbcontext.SaveChangesAsync(); // Save details
                    await transaction.CommitAsync(); // Commit transaction

                    return Ok(new { Message = "MI Details saved successfully." });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(); // Rollback on failure

                    return StatusCode(500, new
                    {
                        Message = "An error occurred while processing your request.",
                        Error = ex.Message
                    });
                }
            }
        }








        //[HttpGet("GetMIdetailsbymino")]
        //public async Task<IActionResult> GetMIdetailsbymino([FromQuery] int mino)
        //{
        //    var miheaderdetails = await dbcontext.Materialinspection
        //        .Where(p => p.mid == mino) // Assuming PONO is a property in your Purchasedetails model
        //        .ToListAsync();
        //    return Ok(miheaderdetails);
        //}



        [HttpGet("GetMIdetailsbymino")]
        public async Task<IActionResult> GetMIdetailsbymino([FromQuery] int mino)

        {
            var miHeaderDetails = await (from mi in dbcontext.Materialinspection
                                         join po in dbcontext.PO on mi.pono equals po.Orderid
                                         where mi.mid == mino
                                         select new
                                         {
                                             mi.mid,
                                             mi.pono,
                                             mi.midate,
                                             mi.reid,
                                             mi.remarks,
                                             mi.colorcoding,
                                             mi.correlation,
                                             mi.phycondn,
                                             mi.heattags,
                                             mi.tcverify,
                                             mi.siteidentification,
                                             mi.materialsent,
                                             mi.qtyverified,
                                             jobid = po.jobid,
                                             mi.isregistered
                                         }).ToListAsync();

            return Ok(miHeaderDetails);
        }













        [HttpGet("GetMILineDetailsbymiD")]
        public async Task<IActionResult> GetMILineDetailsbymiD(int mino)
        {
            var midetails = await dbcontext.MIdetails
     .Where(p => p.mid == mino)
     .Include(p => p.Product) // Assuming 'Product' is the navigation property in 'Purchasedetail'
     .ToListAsync();
            return Ok(midetails);
        }



        //public async Task<IActionResult> GetAllApprovedpendingmaterilinspectionbasedonren2o(int reno)
        //{
        //    var prdetails = await (from po in dbcontext.PO
        //                           join ss in dbcontext.Supplier on po.supplierid equals ss.supplierid
        //                           join pp in dbcontext.Purchasedetails on po.Orderid equals pp.orderid
        //                           join re in dbcontext.ReceivedEntryDetails on pp.potblid equals re.potblid
        //                           join ii in dbcontext.Product on re.itemid equals ii.itemid
        //                           where po.postatusid == 3 && re.receivedqty > (re.acceptedqty + re.rejectedqty)
        //                           && re.RENO == reno
        //                           group po by new { po.Orderid, ss.suppliername, po.Podate, re.RENO, re.acceptedqty, re.receivedqty, re.rejectedqty, re.holdqty, re.itemid, ii.itemname } into grouped
        //                           select new
        //                           {
        //                               grouped.Key.Orderid,
        //                               grouped.Key.suppliername,
        //                               grouped.Key.Podate,
        //                               grouped.Key.RENO,
        //                               grouped.Key.acceptedqty,
        //                               grouped.Key.receivedqty,
        //                               grouped.Key.holdqty,
        //                               grouped.Key.rejectedqty,
        //                               grouped.Key.itemname,
        //                               grouped.Key.itemid,
        //                               pending = (grouped.Key.receivedqty - (grouped.Key.acceptedqty + grouped.Key.holdqty)),

        //                           }).ToListAsync();

        //    if (prdetails == null || !prdetails.Any()) // Handle empty list
        //    {
        //        return NotFound();
        //    }

        //    return Ok(prdetails);
        //}

        [HttpGet("GetpendinglineitemstobeaddedtoMI")]
        public async Task<IActionResult> GetpendinglineitemstobeaddedtoMI([FromQuery] int mino, int reno)
        {

            //            var midetails = await (from mi in dbcontext.Materialinspection

            //                                   join mid in dbcontext.MIdetails on mi.mid equals mid.mid

            //where mi.mid ==mino

            //                                   select new
            //                                   {

            //                                      mid.itemid


            //                                   }).ToListAsync();

            var midetailsItemIds = await (
      from mi in dbcontext.Materialinspection
      join mid in dbcontext.MIdetails on mi.mid equals mid.mid
      where mi.mid == mino
      select mid.itemid
  ).ToListAsync();



            var prdetails = await (from po in dbcontext.PO
                                   join ss in dbcontext.Supplier on po.supplierid equals ss.supplierid
                                   join pp in dbcontext.Purchasedetails on po.Orderid equals pp.orderid
                                   join re in dbcontext.ReceivedEntryDetails on pp.potblid equals re.potblid
                                   join ii in dbcontext.Product on re.itemid equals ii.productcode
                                   join rh in dbcontext.ReceivedEntry on re.RENO equals rh.REID
                                   where po.postatusid == 3 && re.receivedqty - (re.acceptedqty + re.holdqty + re.rejectedqty) > 0 && rh.isregistered == 1
                                   && re.RENO == reno && !midetailsItemIds.Contains(re.itemid)
                                   group po by new { po.Orderid, ss.suppliername, po.Podate, re.RENO, re.acceptedqty, re.receivedqty, re.rejectedqty, re.holdqty, re.itemid, ii.itemname, re.rtblid } into grouped
                                   select new
                                   {
                                       grouped.Key.Orderid,
                                       grouped.Key.suppliername,
                                       grouped.Key.Podate,
                                       grouped.Key.RENO,
                                       grouped.Key.acceptedqty,
                                       grouped.Key.receivedqty,
                                       grouped.Key.holdqty,
                                       grouped.Key.rejectedqty,
                                       grouped.Key.itemname,
                                       grouped.Key.itemid,
                                       grouped.Key.rtblid,
                                       pending = (grouped.Key.receivedqty - (grouped.Key.acceptedqty + grouped.Key.holdqty + grouped.Key.rejectedqty)),

                                   }).ToListAsync();

            if (prdetails == null || !prdetails.Any()) // Handle empty list
            {
                return Ok(new { message = "nodatafound" });
            }

            return Ok(prdetails);




















        }



        [HttpDelete("deletemidetails")]
        public async Task<bool> deletemidetails(int mitblid)
        {
            var entry = await dbcontext.MIdetails.FindAsync(mitblid);
            if (entry == null)
            {
                return false;
            }

            dbcontext.MIdetails.Remove(entry);
            await dbcontext.SaveChangesAsync();
            return true;
        }






        [HttpPost("RegisterMI")]
        public async Task<IActionResult> RegisterMI(int mid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_RegisterMI_UpdateQuantities", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@mid", mid);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                return Ok(new { message = "MI Registered successfully and quantities updated." });
            }
            catch (Exception ex)
            {
                // Log the error (replace with proper logging)
                Console.WriteLine($"Error in RegisterMI: {ex.Message}");
                return StatusCode(500, new { message = "An error occurred during MI registration.", error = ex.Message });
            }
        }












        [HttpGet("GetPurchasesummarycostingsheet")]
        public async Task<ActionResult<List<POSummary>>> GetPurchasesummarycostingsheet(int jobid)
        {
            var posummary = new List<POSummary>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_GetPurchasesummarycostingpage", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@jobid", jobid);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                posummary.Add(new POSummary
                                {
                                    budgetheadername = reader["budgetheadername"].ToString(),

                                    Totalamt = reader.IsDBNull(reader.GetOrdinal("Totalamt"))
                                     ? 0
                                     : Convert.ToDecimal(reader["Totalamt"]),
                                    budgetheaderid = reader.GetInt32(reader.GetOrdinal("budgetheaderid")),

                                });
                            }
                        }
                    }
                }

                if (posummary.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(posummary);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching PO summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the PO summary.");
            }
        }


        public class Deliveryheader
        {
            public int deliveryno { get; set; }

            public DateTime deliverydate { get; set; }

            public string customername { get; set; }
        }

        [HttpGet("GetDeliveryNoteHeaderDetails")]
        public async Task<ActionResult<List<Deliveryheader>>> GetDeliveryNoteHeaderDetails(int jobid)
        {
            var Deliveryheader = new List<Deliveryheader>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_GetDeliveryheaderdetails", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@jobid", jobid);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                Deliveryheader.Add(new Deliveryheader
                                {
                                    customername = reader["buyername"].ToString(),

                                    deliverydate = reader.GetDateTime(reader.GetOrdinal("deliverydate")),
                                    deliveryno = reader.GetInt32(reader.GetOrdinal("deliveryno")),

                                });
                            }
                        }
                    }
                }

                if (Deliveryheader.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(Deliveryheader);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching Delivery header : {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the PO summary.");
            }
        }


        //[HttpGet("Getrpodetaillineitemsjobsummary")]
        //public async Task<IActionResult> Getrpodetaillineitemsjobsummary(int jobid, int budgetheaderid)
        //{
        //    if (jobid <= 0)
        //    {
        //        return BadRequest("Invalid jobid");
        //    }

        //    var issuedetails = await (from aa in dbcontext.PO
        //                              join bb in dbcontext.Purchasedetails on aa.Orderid equals bb.orderid
        //                              join ii in dbcontext.Product on bb.poitemid equals ii.itemid
        //                              join  ss in dbcontext.Supplier on aa.supplierid equals ss.supplierid
        //                              where aa.jobid == jobid && ii.itembudgetheaderid == budgetheaderid



        //                              select new
        //                              {
        //                                  orderid = aa.Orderid,
        //                                  suppliername=ss.suppliername



        //                              })
        //                                   .ToListAsync();

        //    if (!issuedetails.Any())
        //    {
        //        return NotFound("PO   details not found");
        //    }

        //    return Ok(issuedetails);
        //}

        [HttpGet("Getrpodetaillineitemsjobsummary")]
        public async Task<IActionResult> Getrpodetaillineitemsjobsummary(int jobid, int budgetheaderid)
        {
            if (jobid <= 0)
            {
                return BadRequest("Invalid jobid");
            }

            var issuedetails = await (from aa in dbcontext.PO
                                      join bb in dbcontext.Purchasedetails on aa.Orderid equals bb.orderid
                                      join ii in dbcontext.Product on bb.poitemid equals ii.productcode
                                      join ss in dbcontext.Supplier on aa.supplierid equals ss.supplierid
                                      join status in dbcontext.postatus on aa.postatusid equals status.postatusid
                                      where aa.jobid == jobid && ii.itembudgetheaderid == budgetheaderid
                                      select new
                                      {
                                          aa.Orderid,
                                          ss.suppliername,
                                          aa.Podate,

                                          status.postatusname
                                      })
                                      .Distinct() // Ensures distinct combinations
                                      .ToListAsync();

            if (!issuedetails.Any())
            {
                return NotFound("PO details not found");
            }

            return Ok(issuedetails);
        }


        [HttpGet("GetPrnosFromPrpo")]
        public async Task<ActionResult<List<int>>> GetPrnosFromPrpoAsync(int pono)

        {
            var prnos = new List<int>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_GetPrnosfromprpo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pono", pono);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                prnos.Add(reader.GetInt32(reader.GetOrdinal("prid")));
                            }
                        }
                    }
                }

                if (prnos.Count == 0)
                {
                    return NotFound(new { message = "No PR numbers found for the given PO number." });
                }

                return Ok(prnos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching PR numbers: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the PR numbers.");
            }
        }




        [HttpGet("GetGRNnosfrompono")]
        public async Task<ActionResult<List<int>>> GetGRNnosfrompono(int pono)

        {
            var grnnos = new List<int>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_GetGRNSnosofPO", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pono", pono);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                grnnos.Add(reader.GetInt32(reader.GetOrdinal("grnno")));
                            }
                        }
                    }
                }

                if (grnnos.Count == 0)
                {
                    return Ok(new { message = "No GRN numbers found for the given PO number." });
                    // return NotFound(new { message = "No GRN numbers found for the given PO number." });
                }

                return Ok(grnnos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching GRN numbers: {ex.Message}");
                // return StatusCode(500, "An error occurred while fetching the GRN numbers.");
                return Ok(new { message = "An error occurred while fetching the GRN numbers" });
            }
        }



        [HttpGet("Getminosfrompono")]
        public async Task<ActionResult<List<int>>> Getminosfrompono(int pono)

        {
            var grnnos = new List<int>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_GetMInosforpos", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pono", pono);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                grnnos.Add(reader.GetInt32(reader.GetOrdinal("mid")));
                            }
                        }
                    }
                }

                if (grnnos.Count == 0)
                {
                    return NotFound(new { message = "No MI numbers found for the given PO number." });
                }

                return Ok(grnnos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching GRN numbers: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the GRN numbers.");
            }
        }

















        [HttpGet("GetRenosfrompono")]
        public async Task<ActionResult<List<int>>> GetRenosfrompono(int pono)

        {
            var grnnos = new List<int>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_Getreceivedentryforpos", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pono", pono);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                grnnos.Add(reader.GetInt32(reader.GetOrdinal("REID")));
                            }
                        }
                    }
                }

                if (grnnos.Count == 0)
                {
                    return NotFound(new { message = "No RENO numbers found for the given PO number." });
                }

                return Ok(grnnos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching RE numbers: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the RE numbers.");
            }
        }


















        [HttpGet("GetAllProductCategories")]
        public async Task<IActionResult> GetAllProductCategories()
        {

            var categorydetails = await dbcontext.Category

           .ToListAsync();

            if (categorydetails == null)
            {
                return NotFound("Category not found");
            }
            return Ok(categorydetails);

        }


        [HttpGet("GetAllproductsubCategories")]
        public async Task<IActionResult> GetAllproductsubCategories()
        {
            var subcategorydetails = await dbcontext.SubCategory

           .ToListAsync();

            if (subcategorydetails == null)
            {
                return NotFound("Sub Category not found");
            }
            return Ok(subcategorydetails);

        }



        [HttpGet("GetMiscostdetailsbyjobid")]
        public async Task<IActionResult> GetMiscostdetailsbyjobid(int jobid)

        {
            if (jobid <= 0)
            {
                return BadRequest("Invalid jobid");
            }

            var misdetails = await (from aa in dbcontext.Miscost


                                    where aa.jobid == jobid


                                    select new
                                    {
                                        counter = aa.counter,
                                        misid = aa.misid,
                                        misamount = aa.misamount,
                                        jobid = aa.jobid,
                                        description = aa.description,


                                    })
                                           .ToListAsync();

            if (!misdetails.Any())
            {
                return NotFound(new { message = "No data found for the provided jobId." });
            }

            return Ok(misdetails);
        }


        [HttpGet("GetPruExpense/{jobId}")]
        public async Task<IActionResult> GetPruExpense(int jobId)
        {
            var job = await dbcontext.Job.FindAsync(jobId);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(new { pruexpense1 = job.pruexpense1 });
        }

        [HttpGet("GetPruExpense2/{jobId}")]
        public async Task<IActionResult> GetPruExpense2(int jobId)
        {
            var job = await dbcontext.Job.FindAsync(jobId);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(new { pruexpense2 = job.pruexpense2 });
        }






        [HttpPost("UpdatePruExpense")]
        public async Task<IActionResult> UpdatePruExpense([FromBody] ExpenseUpdateModel model)
        {
            // You can check if Expense is less than 0 or 0 if that’s invalid in your case
            if (model == null)
                return BadRequest("Request body is null.");

            var job = await dbcontext.Job.FindAsync(model.JobId);
            if (job == null)
                return NotFound();

            job.pruexpense1 = model.Expense;
            await dbcontext.SaveChangesAsync();

            return Ok(new { message = "Updated successfully" });
        }

        [HttpPost("UpdatePruExpense2")]
        public async Task<IActionResult> UpdatePruExpense2([FromBody] ExpenseUpdateModel model)
        {
            // You can check if Expense is less than 0 or 0 if that’s invalid in your case
            if (model == null)
                return BadRequest("Request body is null.");

            var job = await dbcontext.Job.FindAsync(model.JobId);
            if (job == null)
                return NotFound();

            job.pruexpense2 = model.Expense;
            await dbcontext.SaveChangesAsync();

            return Ok(new { message = "Updated successfully" });
        }

        public class ExpenseUpdateModel
        {
            public int JobId { get; set; }
            public decimal Expense { get; set; } // use nullable decimal if 0 is valid but null must be checked
        }

        public class mrate
        {

            public decimal rate { get; set; } // use nullable decimal if 0 is valid but null must be checked
        }








        [HttpGet("GetStockissuereturndetailsbyjobid")]
        public async Task<IActionResult> GetStockissuereturndetailsbyjobid(int jobid)
        {
            if (jobid <= 0)
            {
                return BadRequest("Invalid jobid");
            }

            var result = await (from d in dbcontext.Issuereturndetails
                                join h in dbcontext.Issuereturn on d.issuereturnref equals h.issuereturnref
                                join im in dbcontext.Product on d.productid equals im.productcode
                                join bh in dbcontext.BudgettHeader on im.itembudgetheaderid equals bh.budgetheaderid
                                join cc in dbcontext.Currency on d.ircurrencyid equals cc.currencyid
                                where h.jobid == jobid

                                && h.isregistered == 1
                                group new { d, cc } by new { h.jobid, im.itembudgetheaderid, bh.budgetheadername } into g
                                select new
                                {
                                    JobId = g.Key.jobid,
                                    BudgetHeaderId = g.Key.itembudgetheaderid,
                                    BudgetHeaderName = g.Key.budgetheadername,
                                    TotalCost = g.Sum(x => (decimal)x.d.quantityreturned * x.d.irunitprice * (decimal)x.cc.exchangerate)
                                })
                     .OrderBy(x => x.JobId)
                     .ThenBy(x => x.BudgetHeaderId)
                     .ToListAsync();
            if (!result.Any())
            {
                return NotFound("Invoice registration details not found");
            }

            return Ok(result);
        }



























        [HttpGet("Getpoissuereturndetailsbyjobid")]
        public async Task<IActionResult> Getpoissuereturndetailsbyjobid(int jobid)
        {
            if (jobid <= 0)
            {
                return BadRequest("Invalid jobid");
            }

            var result = await (from d in dbcontext.POissuereturndetails
                                join h in dbcontext.Issuereturn on d.issuereturnref equals h.issuereturnref
                                join im in dbcontext.Product on d.productcode equals im.productcode
                                join bh in dbcontext.BudgettHeader on im.itembudgetheaderid equals bh.budgetheaderid

                                where h.jobid == jobid

                                && h.isregistered == 1
                                group new { d } by new { h.jobid, im.itembudgetheaderid, bh.budgetheadername } into g
                                select new
                                {
                                    JobId = g.Key.jobid,
                                    BudgetHeaderId = g.Key.itembudgetheaderid,
                                    BudgetHeaderName = g.Key.budgetheadername,
                                    TotalCost = g.Sum(x => (decimal)x.d.returnqty * x.d.issuereturnunitprice)
                                })
                     .OrderBy(x => x.JobId)
                     .ThenBy(x => x.BudgetHeaderId)
                     .ToListAsync();
            if (!result.Any())
            {
                return NotFound("Invoice registration details not found");
            }

            return Ok(result);
        }

































        [HttpGet("GetAdditionaljobdetailsbymainjobid")]
        public async Task<IActionResult> GetAdditionaljobdetailsbymainjobid(int jobid)
        {
            if (jobid <= 0)
            {
                return BadRequest("Invalid jobid");
            }

            var result = await dbcontext.Job
                .Where(j => j.mainjobid == jobid)
                .Select(j => new
                {
                    JobId = j.Jobid,
                    // example field — include any other fields you want
                    JobDate = j.jobdate,
                    ordervalueinbasecurrency = j.ordervaluebasecurrency,
                    // Add more fields as needed
                })
                .OrderBy(j => j.JobId)
                .ToListAsync();

            if (!result.Any())
            {
                return NotFound(new { message = "No data found for the provided jobId." });
            }

            return Ok(result);
        }






        //[HttpGet("GetInvoicereceiptpendingreport")]
        //public async Task<ActionResult<List<InvoicereceiptPending>>> GetInvoicereceiptpendingreport()
        //{
        //    var InvoicereceiptPending = new List<InvoicereceiptPending>();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(_connectionString))
        //        {
        //            await conn.OpenAsync();
        //            using (SqlCommand cmd = new SqlCommand("SP_GetInvoiceReceiptPending", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
        //                {
        //                    while (await reader.ReadAsync())
        //                    {
        //                        InvoicereceiptPending.Add(new InvoicereceiptPending
        //                        {
        //                            jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
        //                            invoiceno = reader.GetInt32(reader.GetOrdinal("invoiceno")),
        //                            customername = reader["customername"].ToString(),
        //                            invoicevalueinbasecurrency = reader.IsDBNull(reader.GetOrdinal("invoicevalueinbasecurrency"))
        //                             ? 0
        //                             : Convert.ToDecimal(reader["invoicevalueinbasecurrency"]),
        //                            invoicereceipts = reader.IsDBNull(reader.GetOrdinal("invoicereceipts"))
        //                             ? 0
        //                             : Convert.ToDecimal(reader["invoicereceipts"]),

        //                        });
        //                    }
        //                }
        //            }
        //        }

        //        if (InvoicereceiptPending.Count == 0)
        //        {
        //            // Return a valid JSON response with 404 status and a message
        //            return NotFound(new { message = "No data found for the provided jobId." });
        //        }

        //        return Ok(InvoicereceiptPending);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the error (implement proper logging in a real app)
        //        Console.WriteLine($"Error fetching budget summary: {ex.Message}");
        //        return StatusCode(500, "An error occurred while fetching the budget summary.");
        //    }
        //}









        public class Paymentpending
        {

            public string customername { get; set; }

            public int totalinvoicecount { get; set; }
            public decimal totalbalance { get; set; }
            public int totalpending { get; set; }
            public int period { get; set; }
            public int customerid { get; set; }
        }










        [HttpGet("GetPaymentpending")]
        public async Task<ActionResult<List<Paymentpending>>> GetPaymentpending()
        {
            var paymentpending = new List<Paymentpending>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_Getcounttotalregisteredinvoicepercustomer", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                paymentpending.Add(new Paymentpending
                                {
                                    customername = reader["customername"].ToString(),
                                    customerid = reader.GetInt32(reader.GetOrdinal("customerid")),
                                    totalinvoicecount = reader.GetInt32(reader.GetOrdinal("totalinvoicecount")),
                                    totalpending = reader.GetInt32(reader.GetOrdinal("totalpending")),
                                    period = reader.GetInt32(reader.GetOrdinal("period")),

                                    totalbalance = reader.IsDBNull(reader.GetOrdinal("totalbalance"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalbalance"]),



                                });
                            }
                        }
                    }
                }

                if (paymentpending.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(paymentpending);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching budget summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the payment pending.");
            }
        }












        public class invoicereceiptpendingdetails
        {


            public int invoiceno { get; set; }

            public int jobid { get; set; }

            public DateTime InvoiceDate { get; set; }

            public DateTime DueDate { get; set; }

            public decimal Invoicevalueinbasecurrency { get; set; }

            public decimal Invoicereceipts { get; set; }
            public decimal totalpending { get; set; }

        }










        [HttpGet("GetInvoiceReceiptPendingdetailsbycustomerid")]
        public async Task<ActionResult<List<invoicereceiptpendingdetails>>> GetInvoiceReceiptPendingdetailsbycustomerid(int customerid)
        {
            var InvoicereceiptPending = new List<invoicereceiptpendingdetails>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_GetInvoiceReceiptPendingbycustomerid", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customerid", customerid);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                InvoicereceiptPending.Add(new invoicereceiptpendingdetails
                                {
                                    jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                    invoiceno = reader.GetInt32(reader.GetOrdinal("invoiceno")),

                                    InvoiceDate = reader.GetDateTime(reader.GetOrdinal("InvoiceDate")),
                                    DueDate = reader.GetDateTime(reader.GetOrdinal("DueDate")),
                                    Invoicevalueinbasecurrency = reader.IsDBNull(reader.GetOrdinal("Invoicevalueinbasecurrency"))
                                     ? 0
                                     : Convert.ToDecimal(reader["Invoicevalueinbasecurrency"]),


                                    Invoicereceipts = reader.IsDBNull(reader.GetOrdinal("invoicereceipts"))
                                     ? 0
                                     : Convert.ToDecimal(reader["invoicereceipts"]),

                                    totalpending = reader.IsDBNull(reader.GetOrdinal("totalpending"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalpending"]),

                                });
                            }
                        }
                    }
                }

                if (InvoicereceiptPending.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(InvoicereceiptPending);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching budget summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the budget summary.");
            }
        }


























        [HttpGet("GetInvoicependingreport")]
        public async Task<ActionResult<List<Invoicepending>>> GetInvoicependingreport()
        {
            var invoicependig = new List<Invoicepending>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_GetInvoicependingreport", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                invoicependig.Add(new Invoicepending
                                {
                                    jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                    customerid = reader.GetInt32(reader.GetOrdinal("customerid")),
                                    customername = reader["customername"].ToString(),

                                    jobdescription = reader["jobdescription"].ToString(),
                                    jobtypename = reader["jobtypename"].ToString(),
                                    projectname = reader["projectname"].ToString(),
                                    totalinvoiced = reader.IsDBNull(reader.GetOrdinal("totalinvoiced"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalinvoiced"]),
                                    ordervaluebasecurrency = reader.IsDBNull(reader.GetOrdinal("ordervaluebasecurrency"))
                                     ? 0
                                     : Convert.ToDecimal(reader["ordervaluebasecurrency"]),


                                    balancetobeinvoiced = reader.IsDBNull(reader.GetOrdinal("balancetobeinvoiced"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balancetobeinvoiced"]),






                                });
                            }
                        }
                    }
                }

                if (invoicependig.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(invoicependig);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching budget summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the budget summary.");
            }
        }





        [HttpGet("getJobOngoingReport")]
        public async Task<ActionResult<List<Invoicepending>>> getJobOngoingReport()
        {
            var invoicependig = new List<Invoicepending>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_getJobOngoingReport", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                invoicependig.Add(new Invoicepending
                                {
                                    jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                    customerid = reader.GetInt32(reader.GetOrdinal("customerid")),
                                    customername = reader["customername"].ToString(),

                                    jobdescription = reader["jobdescription"].ToString(),
                                    jobtypename = reader["jobtypename"].ToString(),
                                    projectname = reader["projectname"].ToString(),
                                    totalinvoiced = reader.IsDBNull(reader.GetOrdinal("totalinvoiced"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalinvoiced"]),
                                    ordervaluebasecurrency = reader.IsDBNull(reader.GetOrdinal("ordervaluebasecurrency"))
                                     ? 0
                                     : Convert.ToDecimal(reader["ordervaluebasecurrency"]),


                                    balancetobeinvoiced = reader.IsDBNull(reader.GetOrdinal("balancetobeinvoiced"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balancetobeinvoiced"]),






                                });
                            }
                        }
                    }
                }

                if (invoicependig.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(invoicependig);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching budget summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the budget summary.");
            }
        }










        public class jobongoingwithreceipt
        {
            public int jobid { get; set; }
            public int customerid { get; set; }
            public int jobtypeid { get; set; }
            public string customername { get; set; }
            public decimal ordervaluebasecurrencywithvat { get; set; }
            public decimal ordervaluebasecurrencywithoutvat { get; set; }
            public decimal totalinvoiced { get; set; }
            public decimal totalreceivedwithvat { get; set; }
            public decimal totalreceivedwithoutvat { get; set; }
            public decimal balancetobeinvoiced { get; set; }
            public decimal balancereceivablewithoutvat { get; set; }
            public decimal balancereceivablewithvat { get; set; }
            public decimal totalreceipts { get; set; }
            public string projectname { get; set; }

        }





        [HttpGet("getJobOngoingReportwithreceipt")]
        public async Task<ActionResult<List<Invoicepending>>> getJobOngoingReportwithreceipt()
        {
            var jobongoingwithreceipt = new List<jobongoingwithreceipt>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_getJobOngoingWithReceipts", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                jobongoingwithreceipt.Add(new jobongoingwithreceipt
                                {
                                    jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                    jobtypeid = reader.GetInt32(reader.GetOrdinal("jobtypeid")),
                                    customerid = reader.GetInt32(reader.GetOrdinal("customerid")),
                                    customername = reader["customername"].ToString(),

                                    ordervaluebasecurrencywithoutvat = reader.IsDBNull(reader.GetOrdinal("ordervalue_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["ordervalue_withoutvat"]),

                                    ordervaluebasecurrencywithvat = reader.IsDBNull(reader.GetOrdinal("ordervalue_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["ordervalue_withvat"]),

                                    totalreceivedwithoutvat = reader.IsDBNull(reader.GetOrdinal("totalreceived_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalreceived_withoutvat"]),
                                    totalreceivedwithvat = reader.IsDBNull(reader.GetOrdinal("totalreceived_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalreceived_withvat"]),


                                    totalinvoiced = reader.IsDBNull(reader.GetOrdinal("totalinvoiced"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalinvoiced"]),
                                    projectname = reader["projectname"].ToString(),
                                    balancetobeinvoiced = reader.IsDBNull(reader.GetOrdinal("balancetobeinvoiced"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balancetobeinvoiced"]),

                                    balancereceivablewithoutvat = reader.IsDBNull(reader.GetOrdinal("balance_receivable_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balance_receivable_withoutvat"]),
                                    balancereceivablewithvat = reader.IsDBNull(reader.GetOrdinal("balance_receivable_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balance_receivable_withvat"]),


                                });
                            }
                        }
                    }
                }

                if (jobongoingwithreceipt.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(jobongoingwithreceipt);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching budget summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the budget summary.");
            }
        }















        [HttpGet("jobInvoicependingWithReceipts")]
        public async Task<ActionResult<List<Invoicepending>>> jobInvoicependingWithReceipts()
        {
            var jobongoingwithreceipt = new List<jobongoingwithreceipt>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_jobInvoicependingWithReceipts", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                jobongoingwithreceipt.Add(new jobongoingwithreceipt
                                {
                                    jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                    customerid = reader.GetInt32(reader.GetOrdinal("customerid")),
                                    jobtypeid = reader.GetInt32(reader.GetOrdinal("jobtypeid")),
                                    customername = reader["customername"].ToString(),

                                    ordervaluebasecurrencywithoutvat = reader.IsDBNull(reader.GetOrdinal("ordervalue_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["ordervalue_withoutvat"]),

                                    ordervaluebasecurrencywithvat = reader.IsDBNull(reader.GetOrdinal("ordervalue_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["ordervalue_withvat"]),

                                    totalreceivedwithoutvat = reader.IsDBNull(reader.GetOrdinal("totalreceived_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalreceived_withoutvat"]),
                                    totalreceivedwithvat = reader.IsDBNull(reader.GetOrdinal("totalreceived_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalreceived_withvat"]),


                                    totalinvoiced = reader.IsDBNull(reader.GetOrdinal("totalinvoiced"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalinvoiced"]),
                                    projectname = reader["projectname"].ToString(),
                                    balancetobeinvoiced = reader.IsDBNull(reader.GetOrdinal("balancetobeinvoiced"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balancetobeinvoiced"]),

                                    balancereceivablewithoutvat = reader.IsDBNull(reader.GetOrdinal("balance_receivable_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balance_receivable_withoutvat"]),
                                    balancereceivablewithvat = reader.IsDBNull(reader.GetOrdinal("balance_receivable_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balance_receivable_withvat"]),


                                });
                            }
                        }
                    }
                }

                if (jobongoingwithreceipt.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(jobongoingwithreceipt);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching budget summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the budget summary.");
            }
        }


























        [HttpGet("GetjobreceiptPendingrv1")]
        public async Task<ActionResult<List<Invoicepending>>> GetjobreceiptPendingrv1()
        {
            var jobongoingwithreceipt = new List<jobongoingwithreceipt>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_jobwithreceiptpending", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                jobongoingwithreceipt.Add(new jobongoingwithreceipt
                                {
                                    jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                    customerid = reader.GetInt32(reader.GetOrdinal("customerid")),
                                    jobtypeid = reader.GetInt32(reader.GetOrdinal("jobtypeid")),
                                    customername = reader["customername"].ToString(),

                                    ordervaluebasecurrencywithoutvat = reader.IsDBNull(reader.GetOrdinal("ordervalue_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["ordervalue_withoutvat"]),

                                    ordervaluebasecurrencywithvat = reader.IsDBNull(reader.GetOrdinal("ordervalue_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["ordervalue_withvat"]),

                                    totalreceivedwithoutvat = reader.IsDBNull(reader.GetOrdinal("totalreceived_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalreceived_withoutvat"]),
                                    totalreceivedwithvat = reader.IsDBNull(reader.GetOrdinal("totalreceived_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalreceived_withvat"]),


                                    totalinvoiced = reader.IsDBNull(reader.GetOrdinal("totalinvoiced"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalinvoiced"]),
                                    projectname = reader["projectname"].ToString(),
                                    balancetobeinvoiced = reader.IsDBNull(reader.GetOrdinal("balancetobeinvoiced"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balancetobeinvoiced"]),

                                    balancereceivablewithoutvat = reader.IsDBNull(reader.GetOrdinal("balance_receivable_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balance_receivable_withoutvat"]),
                                    balancereceivablewithvat = reader.IsDBNull(reader.GetOrdinal("balance_receivable_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balance_receivable_withvat"]),


                                });
                            }
                        }
                    }
                }

                if (jobongoingwithreceipt.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(jobongoingwithreceipt);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching budget summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the budget summary.");
            }
        }




























        [HttpGet("GetJoballjoboverview")]
        public async Task<ActionResult<List<Invoicepending>>> GetJoballjoboverview()
        {
            var jobongoingwithreceipt = new List<jobongoingwithreceipt>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_GetJobDetailsAllrv2", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                jobongoingwithreceipt.Add(new jobongoingwithreceipt
                                {
                                    jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                    customerid = reader.GetInt32(reader.GetOrdinal("customerid")),
                                    jobtypeid = reader.GetInt32(reader.GetOrdinal("jobtypeid")),
                                    customername = reader["customername"].ToString(),

                                    ordervaluebasecurrencywithoutvat = reader.IsDBNull(reader.GetOrdinal("ordervalue_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["ordervalue_withoutvat"]),

                                    ordervaluebasecurrencywithvat = reader.IsDBNull(reader.GetOrdinal("ordervalue_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["ordervalue_withvat"]),

                                    totalreceivedwithoutvat = reader.IsDBNull(reader.GetOrdinal("totalreceived_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalreceived_withoutvat"]),
                                    totalreceivedwithvat = reader.IsDBNull(reader.GetOrdinal("totalreceived_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalreceived_withvat"]),


                                    totalinvoiced = reader.IsDBNull(reader.GetOrdinal("totalinvoiced"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalinvoiced"]),
                                    projectname = reader["projectname"].ToString(),
                                    balancetobeinvoiced = reader.IsDBNull(reader.GetOrdinal("balancetobeinvoiced"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balancetobeinvoiced"]),

                                    balancereceivablewithoutvat = reader.IsDBNull(reader.GetOrdinal("balance_receivable_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balance_receivable_withoutvat"]),
                                    balancereceivablewithvat = reader.IsDBNull(reader.GetOrdinal("balance_receivable_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balance_receivable_withvat"]),


                                });
                            }
                        }
                    }
                }

                if (jobongoingwithreceipt.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(jobongoingwithreceipt);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching budget summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the budget summary.");
            }
        }






























        //[HttpPost("Addorupdatereceiptvoucher")]
        //public async Task<IActionResult> Addorupdatereceiptvoucher([FromBody] AddorupdateReceiptVoucher dto)
        //{
        //    try
        //    {
        //        Check if this is an update or create operation
        //        var existingEntry = await dbcontext.ReceiptVoucher
        //            .FirstOrDefaultAsync(e => e.receiptid == dto.receiptid);

        //        if (existingEntry != null)
        //        {
        //            Update existing ReceiptVoucher
        //            existingEntry.cheque = dto.cheque;
        //            existingEntry.chequedate = dto.chequedate;
        //            existingEntry.createdbyid = dto.createdbyid;
        //            existingEntry.rvreamrks = dto.rvreamrks;
        //            existingEntry.rvexchangerate = dto.rvexchangerate;
        //            existingEntry.bankname = dto.bankname;
        //            existingEntry.rvcurrencyid = dto.rvcurrencyid;
        //            existingEntry.rvamountaed = dto.rvamountaed;
        //            existingEntry.rvamount = dto.rvamount;
        //            existingEntry.customerid = dto.customerid;
        //            existingEntry.receiptdate = dto.receiptdate;
        //            existingEntry.rvamountwords = dto.rvamountwords;
        //            dbcontext.ReceiptVoucher.Update(existingEntry);
        //        }
        //        else
        //        {
        //            Add new ReceiptVoucher
        //            var newEntry = new ReceiptVoucher
        //            {
        //                receiptid = dto.receiptid,
        //                cheque = dto.cheque,
        //                chequedate = dto.chequedate,
        //                createdbyid = dto.createdbyid,
        //                rvreamrks = dto.rvreamrks,
        //                rvexchangerate = dto.rvexchangerate,
        //                bankname = dto.bankname,
        //                rvcurrencyid = dto.rvcurrencyid,
        //                rvamountaed = dto.rvamountaed,
        //                rvamount = dto.rvamount,
        //                customerid = dto.customerid,
        //                receiptdate = dto.receiptdate,
        //                rvamountwords = dto.rvamountwords
        //            };

        //            await dbcontext.ReceiptVoucher.AddAsync(newEntry);
        //        }

        //        await dbcontext.SaveChangesAsync();

        //        return Ok(new { Message = "Receipt voucher saved successfully." });

        //        return Ok(new
        //        {
        //            Message = "Receipt voucher saved successfully.",
        //            Return the ID of the record just processed
        //            receiptid = finalReceiptId
        //        }); ;



        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new
        //        {
        //            Message = "An error occurred while processing your request.",
        //            Error = ex.Message
        //        });
        //    }
        //}





        [HttpPost("Addorupdatereceiptvoucher")]
        public async Task<IActionResult> Addorupdatereceiptvoucher([FromBody] AddorupdateReceiptVoucher dto)
        {
            try
            {
                // Check if this is an update or create operation
                var existingEntry = await dbcontext.ReceiptVoucher
                    .FirstOrDefaultAsync(e => e.receiptid == dto.receiptid);

                // *** CORRECTION 1: Initialize finalReceiptId here. ***
                // It is set to dto.receiptid, which should hold the ID for both update and new records.
                int finalReceiptId = dto.receiptid;

                if (existingEntry != null)
                {
                    // Update existing ReceiptVoucher
                    existingEntry.cheque = dto.cheque;
                    existingEntry.chequedate = dto.chequedate;
                    existingEntry.createdbyid = dto.createdbyid;
                    existingEntry.rvreamrks = dto.rvreamrks;
                    existingEntry.rvexchangerate = dto.rvexchangerate;
                    existingEntry.bankname = dto.bankname;
                    existingEntry.rvcurrencyid = dto.rvcurrencyid;
                    existingEntry.rvamountaed = dto.rvamountaed;
                    existingEntry.rvamount = dto.rvamount;
                    existingEntry.customerid = dto.customerid;
                    existingEntry.receiptdate = dto.receiptdate;
                    existingEntry.rvamountwords = dto.rvamountwords;
                    // dbcontext.ReceiptVoucher.Update(existingEntry); // Not strictly needed here if tracked, but harmless
                }
                else
                {
                    // Add new ReceiptVoucher
                    var newEntry = new ReceiptVoucher
                    {
                        receiptid = dto.receiptid,
                        cheque = dto.cheque,
                        chequedate = dto.chequedate,
                        createdbyid = dto.createdbyid,
                        rvreamrks = dto.rvreamrks,
                        rvexchangerate = dto.rvexchangerate,
                        bankname = dto.bankname,
                        rvcurrencyid = dto.rvcurrencyid,
                        rvamountaed = dto.rvamountaed,
                        rvamount = dto.rvamount,
                        customerid = dto.customerid,
                        receiptdate = dto.receiptdate,
                        rvamountwords = dto.rvamountwords
                    };

                    await dbcontext.ReceiptVoucher.AddAsync(newEntry);

                    // If the receiptid was generated by the database after AddAsync, 
                    // you might update finalReceiptId here: 
                    // finalReceiptId = newEntry.receiptid; 
                    // But based on your code, it seems the ID is passed, so the initialization is sufficient.
                }

                await dbcontext.SaveChangesAsync();

                // 2. Return the success message AND the ID for Angular navigation
                return Ok(new
                {
                    Message = "Receipt voucher saved successfully.",
                    receiptid = finalReceiptId // Now correctly defined and accessible
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while processing your request.",
                    Error = ex.Message
                });
            }
        }








        [HttpGet("GetReceiptPendingCutomerList")]
        public async Task<ActionResult<List<BudgetSummary>>> GetReceiptPendingCutomerList(int jobId)
        {
            var budgetSummaries = new List<BudgetSummary>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_GetBudgetSummaryrv2", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@jobid", jobId);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                budgetSummaries.Add(new BudgetSummary
                                {
                                    BudgetHeadName = reader["budgetheadername"].ToString(),
                                    BudgetHeaderId = reader.GetInt32(reader.GetOrdinal("budgetheaderid")),

                                    Amount = reader.IsDBNull(reader.GetOrdinal("Amount"))
                                     ? 0
                                     : Convert.ToDecimal(reader["Amount"]),
                                    fixedamount = reader.IsDBNull(reader.GetOrdinal("fixedamount"))
                                     ? 0
                                     : Convert.ToDecimal(reader["fixedamount"]),

                                });
                            }
                        }
                    }
                }

                if (budgetSummaries.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(budgetSummaries);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching budget summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the budget summary.");
            }
        }














        public class ReceiptPendingCustomer
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
        }



        [HttpGet("getReceiptPendingCustomerList")]
        public async Task<ActionResult<List<ReceiptPendingCustomer>>> GetReceiptPendingCustomerList()
        {
            var customerList = new List<ReceiptPendingCustomer>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_GetReceiptPendingCutomerList", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                customerList.Add(new ReceiptPendingCustomer
                                {
                                    CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                                    CustomerName = reader["customername"].ToString()
                                });
                            }
                        }
                    }
                }

                if (customerList.Count == 0)
                {
                    return NotFound(new { message = "No pending receipts found." });
                }

                return Ok(customerList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching pending customers: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the pending customer list.");
            }
        }

        public class ReceiptRV
        {
            public int receiptid { get; set; }

        }




        [HttpGet("Pendingreceiptvouchernosbycustomerid")]
        public async Task<ActionResult<List<ReceiptRV>>> Pendingreceiptvouchernosbycustomerid(int customerid)
        {
            var rvlist = new List<ReceiptRV>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_Pendingreceiptvouchernosbycustomerid", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customerid", customerid); // Pass the parameter

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                rvlist.Add(new ReceiptRV
                                {
                                    receiptid = reader.GetInt32(reader.GetOrdinal("receiptid")),
                                    // Add other properties here as needed
                                });
                            }
                        }
                    }
                }

                if (rvlist.Count == 0)
                {
                    return NotFound(new { message = "No pending receipts found." });
                }

                return Ok(rvlist);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching pending receipt vouchers: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the pending receipt vouchers.");
            }
        }



        public class Receiptpendingvoucherdetails
        {
            public decimal rvamountaed { get; set; }
            public decimal balance { get; set; }
            public DateTime receiptdate { get; set; }

        }


        [HttpGet("detailedreceiptpendingvoucherbyreceipid")]
        public async Task<ActionResult<List<Receiptpendingvoucherdetails>>> detailedreceiptpendingvoucherbyreceipid(int receiptid)
        {
            var rvlist = new List<Receiptpendingvoucherdetails>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_Pendingreceiptvoucherdetailsbyreceiptid", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@receiptid", receiptid); // Pass the parameter

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                rvlist.Add(new Receiptpendingvoucherdetails
                                {
                                    rvamountaed = reader.IsDBNull(reader.GetOrdinal("rvamountaed"))
                                     ? 0
                                     : Convert.ToDecimal(reader["rvamountaed"]),

                                    balance = reader.IsDBNull(reader.GetOrdinal("balance"))
                                     ? 0
                                     : Convert.ToDecimal(reader["balance"]),

                                    receiptdate = reader.GetDateTime(reader.GetOrdinal("receiptdate"))

                                    // Add other properties here as needed
                                });
                            }
                        }
                    }
                }

                if (rvlist.Count == 0)
                {
                    return NotFound(new { message = "No pending receipts found." });
                }

                return Ok(rvlist);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching pending receipt vouchers: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the pending receipt vouchers.");
            }
        }


        public class ReceiptPendinginvoicedetails
        {
            public int invoiceno { get; set; }
            public int jobid { get; set; }
            public DateTime invoicedate { get; set; }
            public decimal invoicevalue { get; set; }
            public decimal invoicevalueinbasecurrency { get; set; }

            public decimal receiptpending { get; set; }

        }

        [HttpGet("GetReceiptPendingInvoiceDetails")]
        public async Task<ActionResult<List<ReceiptPendinginvoicedetails>>> GetReceiptPendingInvoiceDetails(int customerid)
        {
            var invoicelist = new List<ReceiptPendinginvoicedetails>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_GetReceiptPendingpercustomerid", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customerid", customerid);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                invoicelist.Add(new ReceiptPendinginvoicedetails
                                {
                                    invoiceno = reader.GetInt32(reader.GetOrdinal("invoiceno")),
                                    jobid = reader.GetInt32(reader.GetOrdinal("jobid")),

                                    invoicedate = reader.GetDateTime(reader.GetOrdinal("invoicedate")),

                                    invoicevalue = reader.IsDBNull(reader.GetOrdinal("invoicevalue"))
                                     ? 0
                                     : Convert.ToDecimal(reader["invoicevalue"]),
                                    invoicevalueinbasecurrency = reader.IsDBNull(reader.GetOrdinal("Invoicevalueinbasecurrency"))
                                     ? 0
                                     : Convert.ToDecimal(reader["Invoicevalueinbasecurrency"]),
                                    receiptpending = reader.IsDBNull(reader.GetOrdinal("receiptpending"))
                                     ? 0
                                     : Convert.ToDecimal(reader["receiptpending"]),

                                });
                            }
                        }
                    }
                }

                if (invoicelist.Count == 0)
                {
                    return NotFound(new { message = "No pending receipts found." });
                }

                return Ok(invoicelist);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching pending customers: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the pending customer list.");
            }
        }
































        [HttpPost("addorupdatereceiptregister")]
        public async Task<IActionResult> addorupdatereceiptregister([FromBody] Addorupdatereceiptregisterdto dto)
        {
            using var transaction = await dbcontext.Database.BeginTransactionAsync();

            try
            {
                if (dto.receiptdetails == null || dto.receiptdetails.Count == 0)
                    return BadRequest("No receipt details provided.");

                foreach (var detail in dto.receiptdetails)
                {
                    // Insert into receipt table
                    var receipt = new receipt
                    {
                        receiptid = dto.receiptid,
                        customerid = dto.customerid,
                        invoiceid = detail.invoiceno,
                        amountinbasecurrency = detail.receivedamount,
                        Createdbyid = dto.userid,
                        createdbydate = DateTime.UtcNow
                    };
                    dbcontext.receipt.Add(receipt);

                    // Update invoice table
                    var invoice = await dbcontext.InvoiceReg.FirstOrDefaultAsync(i => i.invoiceno == detail.invoiceno);
                    if (invoice != null)
                    {
                        invoice.Invoicereceipts += detail.receivedamount;
                        dbcontext.InvoiceReg.Update(invoice);
                    }

                    // Update job table
                    var job = await dbcontext.Job.FirstOrDefaultAsync(j => j.Jobid == detail.jobid);
                    if (job != null)
                    {
                        job.totalreceivedinbasecurrency += detail.receivedamount;
                        dbcontext.Job.Update(job);
                    }
                }

                await dbcontext.SaveChangesAsync();
                await transaction.CommitAsync();
                return Ok(new { Message = $"Receipt Registered Successfully" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, $"Transaction failed: {ex.Message}");
            }
        }


        [HttpGet("ListReceiptRegister")]
        public async Task<IActionResult> ListReceiptRegister()
        {
            var result = from re in dbcontext.receipt
                         join inv in dbcontext.InvoiceReg on re.invoiceid equals inv.invoiceno
                         join cc in dbcontext.Customer on re.customerid equals cc.customerid
                         join aa in dbcontext.Users on re.Createdbyid equals aa.Id
                         select new
                         {
                             re.receiptid,
                             cc.Customername,
                             re.invoiceid,
                             inv.jobid,
                             re.amountinbasecurrency,
                             re.createdbydate,
                             aa.UserName
                             // Add other properties as needed
                         };
            var filteredData = await result.ToListAsync();
            return Ok(filteredData);

        }




        public class jobreceiptpending
        {
            public int jobid { get; set; }
            public decimal ordervaluebasecurrency { get; set; }
            public decimal totalreceivedwithvat { get; set; }
            public decimal totalreceivedwithoutvat { get; set; }
            public decimal totalpendingwithoutvat { get; set; }

            public decimal totalpendingwithvat { get; set; }

            public string cutomername { get; set; }

        }

        [HttpGet("GetjobreceiptPending")]
        public async Task<ActionResult<List<jobreceiptpending>>> GetjobreceiptPending()
        {
            var invoicelist = new List<jobreceiptpending>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_GetjobreceiptPending", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                invoicelist.Add(new jobreceiptpending
                                {

                                    jobid = reader.GetInt32(reader.GetOrdinal("jobid")),

                                    ordervaluebasecurrency = reader.IsDBNull(reader.GetOrdinal("ordervaluebasecurrency"))
                                     ? 0
                                     : Convert.ToDecimal(reader["ordervaluebasecurrency"]),

                                    totalreceivedwithvat = reader.IsDBNull(reader.GetOrdinal("totalreceived"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalreceived"]),
                                    totalreceivedwithoutvat = reader.IsDBNull(reader.GetOrdinal("totalreceived_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalreceived_withoutvat"]),
                                    totalpendingwithoutvat = reader.IsDBNull(reader.GetOrdinal("totalpending_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalpending_withoutvat"]),

                                    totalpendingwithvat = reader.IsDBNull(reader.GetOrdinal("totalpending_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalpending_withvat"]),

                                });
                            }
                        }
                    }
                }

                if (invoicelist.Count == 0)
                {
                    return NotFound(new { message = "No pending receipts found." });
                }

                return Ok(invoicelist);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching pending customers: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the pending customer list.");
            }
        }



        public class InvoiceregAll
        {
            public int invoiceno { get; set; }
            public int jobid { get; set; }
            public int customerid { get; set; }
            public decimal invoicevalue_withvat { get; set; }
            public decimal received_withvat { get; set; }
            public decimal received_withoutvat { get; set; }
            public decimal pending_withoutvat { get; set; }
            public string customername { get; set; }
            public decimal pending_withvat { get; set; }
            public DateTime invoicedate { get; set; }
            public decimal invoicevalue_withoutvat { get; set; }

        }


        [HttpGet("GetInvoiceAll")]
        public async Task<ActionResult<List<InvoiceregAll>>> GetInvoiceAll()
        {
            var invoicelist = new List<InvoiceregAll>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_GetInvoiceAll", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                invoicelist.Add(new InvoiceregAll
                                {
                                    invoiceno = reader.GetInt32(reader.GetOrdinal("invoiceno")),
                                    jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                    customername = reader["customername"].ToString(),
                                    customerid = reader.GetInt32(reader.GetOrdinal("customerid")),
                                    invoicedate = reader.GetDateTime(reader.GetOrdinal("invoicedate")),
                                    invoicevalue_withvat = reader.IsDBNull(reader.GetOrdinal("invoicevalue_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["invoicevalue_withvat"]),

                                    invoicevalue_withoutvat = reader.IsDBNull(reader.GetOrdinal("invoicevalue_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["invoicevalue_withoutvat"]),
                                    received_withvat = reader.IsDBNull(reader.GetOrdinal("received_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["received_withvat"]),
                                    received_withoutvat = reader.IsDBNull(reader.GetOrdinal("received_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["received_withoutvat"]),

                                    pending_withoutvat = reader.IsDBNull(reader.GetOrdinal("pending_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["pending_withoutvat"]),

                                    pending_withvat = reader.IsDBNull(reader.GetOrdinal("pending_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["pending_withvat"]),

                                });
                            }
                        }
                    }
                }

                if (invoicelist.Count == 0)
                {
                    return NotFound(new { message = "No pending receipts found." });
                }

                return Ok(invoicelist);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching pending customers: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the pending customer list.");
            }
        }





        [HttpGet("GetInvoiceReceiptPending")]
        public async Task<ActionResult<List<InvoiceregAll>>> GetInvoiceReceiptPending()
        {
            var invoicelist = new List<InvoiceregAll>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_GetInvoiceReceiptPending", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                invoicelist.Add(new InvoiceregAll
                                {
                                    invoiceno = reader.GetInt32(reader.GetOrdinal("invoiceno")),
                                    jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                    customername = reader["customername"].ToString(),
                                    customerid = reader.GetInt32(reader.GetOrdinal("customerid")),
                                    invoicedate = reader.GetDateTime(reader.GetOrdinal("invoicedate")),
                                    invoicevalue_withvat = reader.IsDBNull(reader.GetOrdinal("invoicevalue_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["invoicevalue_withvat"]),

                                    invoicevalue_withoutvat = reader.IsDBNull(reader.GetOrdinal("invoicevalue_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["invoicevalue_withoutvat"]),
                                    received_withvat = reader.IsDBNull(reader.GetOrdinal("received_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["received_withvat"]),
                                    received_withoutvat = reader.IsDBNull(reader.GetOrdinal("received_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["received_withoutvat"]),

                                    pending_withoutvat = reader.IsDBNull(reader.GetOrdinal("pending_withoutvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["pending_withoutvat"]),

                                    pending_withvat = reader.IsDBNull(reader.GetOrdinal("pending_withvat"))
                                     ? 0
                                     : Convert.ToDecimal(reader["pending_withvat"]),

                                });
                            }
                        }
                    }
                }

                if (invoicelist.Count == 0)
                {
                    return NotFound(new { message = "No pending receipts found." });
                }

                return Ok(invoicelist);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching pending customers: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the pending customer list.");
            }
        }








        [HttpGet("Getmaxrevisionestimation")]
        public async Task<IActionResult> Getmaxrevisionestimation(int jobid)
        {
            var maxRevision = await dbcontext.estimation
                .Where(e => e.jobid == jobid)
                .MaxAsync(e => (int?)e.revision) ?? 0;

            var nextRevision = maxRevision + 1;

            return Ok(nextRevision);
        }












        public class listestimation
        {

            public int jobid { get; set; }
            public string customername { get; set; }
            public string projectname { get; set; }
        }
        [HttpGet("GetDistinctjobestimationdetails")]
        public async Task<ActionResult<List<listestimation>>> GetDistinctjobestimationdetails()
        {
            var listestimation = new List<listestimation>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_GetDistinctjobestimationdetails", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                listestimation.Add(new listestimation
                                {
                                    customername = reader["customername"].ToString(),
                                    //                        BudgetHeaderId = Convert.ToInt32(reader["BudgetHeaderId"]),
                                    jobid = Convert.ToInt32(reader["jobid"]),

                                    projectname = reader["projectname"].ToString(),


                                });
                            }
                        }
                    }
                }

                if (listestimation.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(listestimation);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching list estimation: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the list estimation.");
            }

























        }









        [HttpGet("GetPRFiles/{prid}")]
        public IActionResult GetPRFiles(string prid)
        {
            var prfolderpath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "PRFILE", prid);

            if (!Directory.Exists(prfolderpath))
            {
                return NotFound("PR folder not found.");
            }

            var files = Directory.GetFiles(prfolderpath)
                                 .Select(System.IO.Path.GetFileName)
                                 .ToList();

            if (files.Count == 0)
            {
                return NotFound("No files found in this PR folder.");
            }

            return Ok(files);
        }


        private readonly string _PRStoragePath = Path.Combine(Directory.GetCurrentDirectory(), "PRFILE"); // Example path




        [HttpPost("uploadprrv2")]
        public async Task<IActionResult> Uploadprrv2([FromForm] IFormFile file, [FromForm] string prid) // Use [FromForm] for prid as well
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Validate file type (only PDF allowed)
            if (file.ContentType != "application/pdf" ||
                !Path.GetExtension(file.FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Only PDF files are allowed.");
            }

            // Create a directory for the specific PR ID if it doesn't exist
            var prSpecificFolderPath = Path.Combine(_PRStoragePath, prid);
            if (!Directory.Exists(prSpecificFolderPath))
            {
                Directory.CreateDirectory(prSpecificFolderPath);
            }

            // Define the file name to be exactly the PR ID with a .pdf extension
            var fileNameToSave = $"{prid}.pdf";
            var filePath = Path.Combine(prSpecificFolderPath, fileNameToSave);

            try
            {
                // Save the file. FileMode.Create will overwrite if a file with the same name exists.
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new { message = "File uploaded successfully!", filePath });
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error uploading file for PR {prid}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while uploading the file: {ex.Message}");
            }
        }



        [HttpGet("GetPRFilesrv2/{prid}")] // This endpoint will serve the PDF
        public IActionResult GetPRFilesrv2(string prid)
        {
            var prSpecificFolderPath = Path.Combine(_PRStoragePath, prid);

            if (!Directory.Exists(prSpecificFolderPath))
            {
                // If the folder doesn't exist, it implies no file has been uploaded for this PR
                return NotFound("PR folder not found or no file uploaded for this PR.");
            }

            // The file name is expected to be [prid].pdf
            var expectedFileName = $"{prid}.pdf";
            var filePath = Path.Combine(prSpecificFolderPath, expectedFileName);

            if (!System.IO.File.Exists(filePath))
            {
                // If the file itself doesn't exist within the folder
                return NotFound($"File '{expectedFileName}' not found for PR ID '{prid}'.");
            }

            try
            {
                // Create a FileStream to read the file
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                // Return the file stream with the correct content type (MIME type)
                // This is crucial for the browser to open it as a PDF
                return File(fileStream, MediaTypeNames.Application.Pdf, expectedFileName);
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                Console.Error.WriteLine($"Error serving PR file {filePath}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving the PR file: {ex.Message}");
            }
        }

        // ... other controller methods










        [HttpGet("GetAuthorizedPOs")]
        public async Task<IActionResult> GetAuthorizedPOs()
        {
            var authorizedStatuses = new[] { "Verified", "Approved" };

            var authorizedPOs = await dbcontext.PO
                .Include(po => po.postatus) // JOIN with POStatus table
                .Where(po => authorizedStatuses.Contains(po.postatus.postatusname))
                .Select(po => new
                {
                    po.Orderid,
                    po.Podate,
                    po.Supplier.suppliername,
                    statusname = po.postatus.postatusname
                })
                .ToListAsync();

            return Ok(authorizedPOs);
        }





        public class UserIdDto
        {
            public string UserId { get; set; } // Use string if your IDs are GUIDs or strings
                                               // If your User IDs are integers, change the type to 'int' or 'int?'
        }





        [HttpPost("POunauthorzation/{poId}")]
        public async Task<IActionResult> POunauthorzation(int poId, [FromBody] UserIdDto request)
        {
            // 1. Input Validation
            if (request == null || string.IsNullOrEmpty(request.UserId))
            {
                return BadRequest("User ID is required in the request body.");
            }

            // 2. Retrieve the PO record
            var po = await dbcontext.PO.FirstOrDefaultAsync(x => x.Orderid == poId);

            if (po == null)
                return NotFound($"PO with ID {poId} not found.");

            // --- PO UN-AUTHORIZATION / RESET LOGIC ---

            // Retrieve the Job details to get the Jobid for tracking
            // NOTE: This assumes your PO model links to a Job model, or the JobId is directly on the PO model.
            // Assuming 'po' object has a 'Job' navigation property or 'Jobid' field.
            var podetails = await dbcontext.PO.FirstOrDefaultAsync(j => j.Orderid == po.Orderid); // Modify this line based on your actual model relationship

            if (podetails == null)
                return NotFound($"Associated Job not found for PO ID {poId}.");

            // 3. Update PO Status
            po.postatusid = 1; // Set status back to 'Created'
            po.poverifiedbyid = null;
            po.poverifiedDate = null;
            po.PoAuthorizedbyid = null;
            po.poauthorizedDate = null;

            // 4. Create Tracking Entry (Trackpage)
            var currentUtcTime = DateTime.UtcNow;

            var trackingEntry = new Trackpage
            {
                pagename = "PO UNAUTHORIZE",
                docno = poId.ToString(), // Use Job ID for tracking
                createddate = currentUtcTime,
                createdbyuser = request.UserId
            };

            dbcontext.Trackpage.Add(trackingEntry);

            // 5. Save all changes (PO update and Trackpage insert)
            await dbcontext.SaveChangesAsync();

            return Ok(new
            {
                message = $"PO ID {poId} successfully reset to Created by user {request.UserId}.",
                newStatus = po.postatusid
            });
        }

















        //[HttpPost("POunauthorzation/{poId}")]
        //public async Task<IActionResult> POunauthorzation(int poId, [FromBody] UserIdDto authData)
        //{
        //    // Check if the User ID was successfully passed in the body
        //    if (string.IsNullOrEmpty(authData.UserId))
        //    {
        //        return BadRequest("User ID is required for this action.");
        //    }

        //    var po = await dbcontext.PO.FirstOrDefaultAsync(x => x.Orderid == poId);

        //    if (po == null)
        //        return NotFound($"PO with ID {poId} not found.");

        //    // --- Unauthorization Logic ---

        //    // 1. Reset Authorization/Verification Fields
        //    po.postatusid = 1; // Set status to 'Created' or 'Pending' (depending on what 1 means)
        //    po.poverifiedbyid = null;
        //    po.poverifiedDate = null;
        //    po.PoAuthorizedbyid = null;
        //    po.poauthorizedDate = null;

        //    // 2. Log the User who performed the UNauthorization action (Optional but Recommended)
        //    // You might want a separate column like PoUnAuthorizedbyid and PoUnauthorizedDate
        //    // po.PoUnAuthorizedbyid = authData.UserId; // Assuming your model supports string ID
        //    // po.PoUnAuthorizedDate = DateTime.Now; 

        //    await dbcontext.SaveChangesAsync();

        //    // Changed message to reflect the action (which is UNauthorization/reset to created)
        //    return Ok(new
        //    {
        //        message = $"PO ID {poId} successfully reset to Created by user {authData.UserId}.",
        //        newStatus = po.postatusid
        //    });
        //}








        [HttpGet("ListReceivedEntry")]
        public async Task<IActionResult> ListReceivedEntry()
        {


            var listreceivedentry = from re in dbcontext.ReceivedEntry
                                    join po in dbcontext.PO on re.pono equals po.Orderid
                                    join ss in dbcontext.Supplier on po.supplierid equals ss.supplierid

                                    select new
                                    {
                                        re.REID,
                                        po.Orderid,
                                        re.REDate,
                                        ss.suppliername,
                                        re.isregistered,

                                        // Add other properties as needed
                                    };

            var filteredData = await listreceivedentry.ToListAsync();

            return Ok(filteredData);
        }






        [HttpGet("Getrelinedetailbyreno")]
        public async Task<IActionResult> Getrelinedetailbyreno(int reno)
        {
            if (reno <= 0)
            {
                return BadRequest("Invalid reno");
            }

            var issuedetails = await (from aa in dbcontext.ReceivedEntryDetails
                                      join bb in dbcontext.ReceivedEntry on aa.RENO equals bb.REID
                                      join ii in dbcontext.Product on aa.itemid equals ii.productcode

                                      where aa.RENO == reno
                                      select new
                                      {
                                          aa.RENO,
                                          ii.productcode,
                                          ii.itemname,
                                          aa.receivedqty


                                      })
                                      .Distinct() // Ensures distinct combinations
                                      .ToListAsync();

            if (!issuedetails.Any())
            {
                return NotFound("PO details not found");
            }

            return Ok(issuedetails);
        }








        [HttpGet("ListMI")]
        public async Task<IActionResult> ListMI()
        {


            var listmi = from re in dbcontext.Materialinspection
                         join po in dbcontext.PO on re.pono equals po.Orderid
                         join ss in dbcontext.Supplier on po.supplierid equals ss.supplierid

                         select new
                         {
                             re.mid,
                             po.Orderid,
                             re.midate,
                             ss.suppliername,
                             re.isregistered,

                             // Add other properties as needed
                         };

            var filteredData = await listmi.ToListAsync();

            return Ok(filteredData);
        }











        [HttpGet("Getmilinedetailbyreno")]
        public async Task<IActionResult> Getmilinedetailbyreno(int mid)
        {
            if (mid <= 0)
            {
                return BadRequest("Invalid MI No");
            }

            var midetails = await (from aa in dbcontext.MIdetails
                                   join bb in dbcontext.Materialinspection on aa.mid equals bb.mid
                                   join ii in dbcontext.Product on aa.itemid equals ii.productcode

                                   where aa.mid == mid
                                   select new
                                   {
                                       aa.mid,
                                       ii.productcode,
                                       ii.itemname,
                                       aa.acceptedqty,
                                       aa.rejectedqty,
                                       aa.holdqty,
                                   })
                                      .Distinct() // Ensures distinct combinations
                                      .ToListAsync();

            if (!midetails.Any())
            {
                return NotFound("MI details not found");
            }

            return Ok(midetails);
        }









        [HttpGet("GetPendingItemsByIssueNo")]
        public async Task<IActionResult> GetPendingItemsByIssueNo([FromQuery] int jobid, [FromQuery] int issueno)
        {
            // Get all issued item IDs for the given issue number
            var issuedItemIds = await dbcontext.Issuenotedetails
                .Where(id => id.issuenoteref == issueno)
                .Select(id => id.itemid)
                .ToListAsync();

            // Get all inventory items for the job, excluding the issued ones
            var pendingItems = await (
                from rh in dbcontext.Inventory
                join red in dbcontext.Product on rh.productid equals red.productcode
                where rh.jobid == jobid && !issuedItemIds.Contains(red.productcode)
                group rh by red.productcode into grouped
                select new
                {
                    ItemId = grouped.Key,
                    ItemName = grouped.Select(g => g.Product.itemname).FirstOrDefault(),
                    TotalQty = (double)grouped.Sum(x => x.quantity)
                }
            ).ToListAsync();

            return Ok(pendingItems);
        }

        [HttpGet("Getjobnosbyjobtypeid")]
        public async Task<IActionResult> GetJobNosByJobTypeId([FromQuery] int jobTypeId)
        {
            var jobNos = await dbcontext.Job
                .Where(j => j.jobtypeid == jobTypeId)
                .Select(j => new
                {
                    j.Jobid,
                    jobname = j.Jobid + "  " + j.projectname + "  " + j.lpono + "  " + j.jobdescription

                })
                .ToListAsync();

            return Ok(jobNos);
        }









        [HttpGet("GetPoissuelinedetails")]
        public async Task<IActionResult> GetPoissuelinedetails(int issueref)
        {
            if (issueref <= 0)
            {
                return BadRequest("Invalid Issueref");
            }

            var issuedetails = await (from aa in dbcontext.IssueNoteheader
                                      join bb in dbcontext.Issuenotedetails on aa.issueref equals bb.issuenoteref
                                      join ii in dbcontext.Product on bb.itemid equals ii.productcode

                                      where aa.issueref == issueref
                                      select new
                                      {
                                          aa.issueref,
                                          ii.productcode,
                                          ii.itemname,
                                          bb.issueqty


                                      })
                                      .Distinct() // Ensures distinct combinations
                                      .ToListAsync();

            if (!issuedetails.Any())
            {
                return NotFound("Issue  details not found");
            }

            return Ok(issuedetails);
        }










        [HttpGet("Getissuereturnlinedetailsjobsummary")]
        public async Task<IActionResult> Getissuereturnlinedetailsjobsummary(int jobid, int budgetheaderid)
        {
            if (jobid <= 0)
            {
                return BadRequest("Invalid jobid");
            }

            var issuereturndetails = await (from aa in dbcontext.Issuereturn
                                            join bb in dbcontext.Issuereturndetails on aa.issuereturnref equals bb.issuereturnref
                                            join ii in dbcontext.Product on bb.productid equals ii.productcode

                                            where aa.jobid == jobid && ii.itembudgetheaderid == budgetheaderid && aa.isregistered == 1
                                            select new
                                            {
                                                aa.issuereturnref,
                                                bb.quantityreturned,
                                                ii.itemname,
                                                bb.irtblid,

                                                ii.productcode
                                            })
                                      .Distinct() // Ensures distinct combinations
                                      .ToListAsync();

            if (!issuereturndetails.Any())
            {
                return NotFound("PO details not found");
            }

            return Ok(issuereturndetails);
        }

        [HttpPost("UploadManhourExcel")]
        public async Task<IActionResult> UploadManhourExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;

            using var package = new ExcelPackage(stream);
            var worksheet = package.Workbook.Worksheets[0];
            var rowCount = worksheet.Dimension.Rows;

            var updatedManhours = new List<manhour>();

            for (int row = 2; row <= rowCount; row++)
            {
                try
                {
                    var jobidText = worksheet.Cells[row, 1].Text;
                    var empidText = worksheet.Cells[row, 2].Text;
                    var jobdateText = worksheet.Cells[row, 3].Text;

                    if (string.IsNullOrWhiteSpace(jobidText) || string.IsNullOrWhiteSpace(empidText) || string.IsNullOrWhiteSpace(jobdateText))
                        continue;

                    if (!int.TryParse(jobidText, out int jobid) || !int.TryParse(empidText, out int empid) || !DateTime.TryParse(jobdateText, out DateTime jobdate))
                        continue;

                    // Check the job's stage
                    var job = await dbcontext.Job
                        .Include(j => j.JobStage)
                        .FirstOrDefaultAsync(j => j.Jobid == jobid);

                    if (job == null || job.JobStage.jobstagename.Equals("Freezed", StringComparison.OrdinalIgnoreCase) || job.JobStage.jobstagename.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                    {
                        // Skip jobs that are Freezed or Completed
                        continue;
                    }

                    var nhText = worksheet.Cells[row, 4].Text;
                    var otText = worksheet.Cells[row, 5].Text;
                    var site = worksheet.Cells[row, 6].Text?.Trim().ToUpper() ?? "N";
                    var type = worksheet.Cells[row, 7].Text?.Trim().ToUpper() ?? "M";

                    if (!decimal.TryParse(nhText, out decimal nh) || !decimal.TryParse(otText, out decimal ot))
                        continue;

                    // Retrieve the applicable manhour rate
                    var rateEntry = await dbcontext.manhourrate
                        .FirstOrDefaultAsync();

                    decimal rate = rateEntry?.manhourrate ?? 0;

                    var existingRecord = await dbcontext.manhour
                        .FirstOrDefaultAsync(m => m.jobid == jobid && m.empid == empid && m.jobdate == jobdate  &&  m.type == type && m.site == site);

                    if (existingRecord != null)
                    {
                        // Update existing record
                        existingRecord.nh = nh;
                        existingRecord.ot = ot;
                        existingRecord.site = site;
                        existingRecord.type = type;
                        existingRecord.createddate = DateTime.Now;
                        existingRecord.mrate = rate;

                        updatedManhours.Add(existingRecord);
                    }
                    else
                    {
                        // Insert new record
                        var mh = new manhour
                        {
                            jobid = jobid,
                            empid = empid,
                            jobdate = jobdate,
                            nh = nh,
                            ot = ot,
                            site = site,
                            type = type,
                            createddate = DateTime.Now,
                            mrate = rate
                        };
                        dbcontext.manhour.Add(mh);
                        updatedManhours.Add(mh);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle accordingly
                    continue;
                }
            }

            await dbcontext.SaveChangesAsync();

            // Return only the newly inserted or updated records
            return Ok(updatedManhours);
        }




        [HttpPost("updatemanhourrate")]
        public async Task<IActionResult> updatemanhourrate([FromBody] mrate model)
        {
            if (model == null)
                return BadRequest("Request body is null.");

            // Execute a raw SQL command to update the manhourrate
            await dbcontext.Database.ExecuteSqlRawAsync(
                "UPDATE manhourrate SET manhourrate = {0}", model.rate);

            return Ok(new { message = "Updated successfully" });
        }











        [HttpGet("Getmanhourrate")]
        public async Task<IActionResult> Getmanhourrate()
        {
            

            var rate = await dbcontext.manhourrate
               
                .Select(j => j.manhourrate) // <-- Use the actual property name here
                                          // Get the first (and presumably only) rate
                .FirstOrDefaultAsync();

            // Return the rate value directly (e.g., 25.5)
            return Ok(rate);
        }







        public class ManhourCostSummary
        {
            public decimal TotalHrs { get; set; }
            public decimal TotalHrRate { get; set; }
            public decimal TotalHrsMechanical { get; set; } // New property for mechanical hours
            public decimal TotalHrRateMechanical { get; set; }
            public decimal TotalHrsElectrical { get; internal set; }
            public decimal TotalHrRateElectrical { get; internal set; }
            public decimal TotalHrssite { get; internal set; }
            public decimal TotalHrRatesite { get; internal set; }
            public decimal TotalHrsNonsite { get; internal set; }
            public decimal TotalHrRateNonsite { get; internal set; }
        }

        [HttpGet("GetTotalManhourCost")]
        public async Task<ActionResult<ManhourCostSummary>> GetTotalManhourCost(int jobId)
        {
            var summary = new ManhourCostSummary();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_Gettotalmanhourcost", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@jobid", jobId);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            // Read the first result set (Total Manhours and Cost)
                            if (await reader.ReadAsync())
                            {
                                summary.TotalHrs = reader.IsDBNull(reader.GetOrdinal("totalhrs")) ? 0 : reader.GetDecimal(reader.GetOrdinal("totalhrs"));
                                summary.TotalHrRate = reader.IsDBNull(reader.GetOrdinal("totalhrrate")) ? 0 : reader.GetDecimal(reader.GetOrdinal("totalhrrate"));
                            }

                            // Move to the second result set (Mechanical Manhours and Cost)
                            if (await reader.NextResultAsync())
                            {
                                if (await reader.ReadAsync())
                                {
                                    summary.TotalHrsMechanical = reader.IsDBNull(reader.GetOrdinal("totalhrsmechanical")) ? 0 : reader.GetDecimal(reader.GetOrdinal("totalhrsmechanical"));
                                    summary.TotalHrRateMechanical = reader.IsDBNull(reader.GetOrdinal("totalhrratemechanical")) ? 0 : reader.GetDecimal(reader.GetOrdinal("totalhrratemechanical"));
                                }
                            }

                            // Move to the third result set (Electrical Manhours and Cost)
                            // This part specifically reads the data from the SQL query you selected.
                            if (await reader.NextResultAsync())
                            {
                                if (await reader.ReadAsync())
                                {
                                    summary.TotalHrsElectrical = reader.IsDBNull(reader.GetOrdinal("totalhrselectrical")) ? 0 : reader.GetDecimal(reader.GetOrdinal("totalhrselectrical"));
                                    summary.TotalHrRateElectrical = reader.IsDBNull(reader.GetOrdinal("totalhrrateelectrical")) ? 0 : reader.GetDecimal(reader.GetOrdinal("totalhrrateelectrical"));
                                }
                            }



                            if (await reader.NextResultAsync())
                            {
                                if (await reader.ReadAsync())
                                {
                                    summary.TotalHrssite = reader.IsDBNull(reader.GetOrdinal("totalhrssite")) ? 0 : reader.GetDecimal(reader.GetOrdinal("totalhrssite"));
                                    summary.TotalHrRatesite = reader.IsDBNull(reader.GetOrdinal("totalhrratesite")) ? 0 : reader.GetDecimal(reader.GetOrdinal("totalhrratesite"));
                                }
                            }



                            if (await reader.NextResultAsync())
                            {
                                if (await reader.ReadAsync())
                                {
                                    summary.TotalHrsNonsite = reader.IsDBNull(reader.GetOrdinal("totalhrsnonsite")) ? 0 : reader.GetDecimal(reader.GetOrdinal("totalhrsnonsite"));
                                    summary.TotalHrRateNonsite = reader.IsDBNull(reader.GetOrdinal("totalhrratenonsite")) ? 0 : reader.GetDecimal(reader.GetOrdinal("totalhrratenonsite"));
                                }
                            }










                        }
                    }
                }

                return Ok(summary);
            }
            catch (Exception ex)
            {
                // Log the exception (implement proper logging in a real application)
                Console.WriteLine($"Error fetching manhour cost summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the manhour cost summary.");
            }
        }





        public class Itemdetails
        {
            public decimal totalqty { get; set; }

        }

        [HttpGet("Getstockstorecountdetailsbyitemid")]
        public async Task<ActionResult<Itemdetails>> Getstockstorecountdetailsbyitemid(int productcode)
        {
            var itemdetails = new Itemdetails();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_Getstockstorecountdetailsbyitemid", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@productcode", productcode);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            if (await reader.ReadAsync())
                            {
                                itemdetails.totalqty = reader.IsDBNull(reader.GetOrdinal("itemqty")) ? 0 : reader.GetDecimal(reader.GetOrdinal("itemqty"));

                            }
                        }
                    }
                }

                return Ok(itemdetails);
            }
            catch (Exception ex)
            {
                // Log the exception (implement proper logging in a real application)
                Console.WriteLine($"Error fetching manhour cost summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the manhour cost summary.");
            }
        }





        [HttpPost("DeductConsumablesInventory")]
        public IActionResult DeductConsumablesInventory([FromBody] DeductInventoryRequest request)
        {
            using (var transaction = dbcontext.Database.BeginTransaction())
            {
                try
                {
                    var batches = new List<Batch>();
                    var remainingQuantity = request.RequestedQuantity;

                    var inventoryItems = (from inv in dbcontext.Inventory
                                          join jj in dbcontext.Job on inv.jobid equals jj.Jobid
                                          join jy in dbcontext.JobType on jj.jobtypeid equals jy.jobtypeid
                                          where jy.JobtypeName == "Miscellaneous" && inv.productid == request.ItemId
                                          orderby inv.Entrydate
                                          select inv).ToList();



                    foreach (var item in inventoryItems)
                    {
                        batches.Add(new Batch(item.batchid, item.quantity, item.invid, item.invcurrencyid, item.uomid, item.invprice));
                    }

                    foreach (var batch in batches)
                    {
                        if (remainingQuantity <= 0) break;

                        var quantityToDeduct = Math.Min(remainingQuantity, batch.Quantity);
                        DeductFromBatchconsumables(request.ItemId, batch.BatchID, quantityToDeduct, request.Jobid, request.issueref, batch.Invid, batch.Currencyid, batch.Uomid, batch.Price);
                        remainingQuantity -= quantityToDeduct;
                    }

                    var issuenoteheader = dbcontext.IssueNoteheader
                        .FirstOrDefault(i => i.issueref == request.issueref);

                    if (issuenoteheader != null)
                    {
                        issuenoteheader.isregistered = 1;
                    }

                    dbcontext.SaveChanges();
                    transaction.Commit();


                    return Ok(new { Message = "Issue Note Registered" });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }

        private void DeductFromBatchconsumables(int itemId, int batchId, decimal quantity, int jobid, int issueref, int invid, int Currencyid, int Uomid, decimal Price)
        {
            var inventoryItem = dbcontext.Inventory
                .FirstOrDefault(i => i.productid == itemId && i.batchid == batchId);

            if (inventoryItem != null)
            {
                inventoryItem.quantity -= quantity;

                var issuetrack = new Issuetracking
                {
                    productid = itemId,
                    jobid = jobid, // Assuming jobid is part of the entry details
                    issuenoteno = issueref,
                    issueqty = quantity,
                    issuedate = DateTime.UtcNow.Date,
                    invid = invid,
                    issuecurrencyid = Currencyid,
                    issueunitprice = Price,
                    issueuomid = Uomid


                    // Assign the retrieved invid here
                };



                dbcontext.Issuetracking.Add(issuetrack);
                if (inventoryItem.quantity <= 0)
                {
                    dbcontext.Inventory.Remove(inventoryItem);
                }














































            }


















        }


























        public class freezedbomdetails
        {
            public int bomid { get; set; }
            public int itemid { get; set; }
            public decimal bomqty { get; set; }
            public int bomuomid { get; set; }
            public decimal price { get; set; }
            public int currencyid { get; set; }
            public int prodstageid { get; set; }

            public DateTime RequiredDate { get; set; }

            public int bomstatus { get; set; }
            public string itemname { get; set; }

            public string uomname { get; set; }

            public decimal prcreatedqty { get; set; }
            public string currency { get; set; }























        }














        [HttpGet("GetFreezedbomdetailfroprcreation/{jobId}")]
        public async Task<ActionResult<List<freezedbomdetails>>> GetFreezedbomdetailfroprcreation(int jobId)
        {
            var freezedbomdetails = new List<freezedbomdetails>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_GetFreezedBombyjobidprnotcreated", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@jobid", jobId);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                freezedbomdetails.Add(new freezedbomdetails
                                {
                                    bomuomid = reader.GetInt32(reader.GetOrdinal("bomuomid")),
                                    bomid = reader.GetInt32(reader.GetOrdinal("bomid")),
                                    itemid = reader.GetInt32(reader.GetOrdinal("itemid")),
                                    bomqty = Convert.ToDecimal(reader["bomqty"]),
                                    price = Convert.ToDecimal(reader["price"]),
                                    prodstageid = reader.GetInt32(reader.GetOrdinal("prodstageid")),
                                    RequiredDate = reader.GetDateTime(reader.GetOrdinal("RequiredDate")),
                                    bomstatus = reader.GetInt32(reader.GetOrdinal("bomstatus")),
                                    itemname = reader.GetString(reader.GetOrdinal("itemname")),
                                    uomname = reader.GetString(reader.GetOrdinal("uomname")),
                                    currency = reader["currency"].ToString(),
                                    prcreatedqty = Convert.ToDecimal(reader["prcreatedqty"]),
                                    // Make sure currencyid is also read if it's in your SP result and model
                                    currencyid = reader.GetInt32(reader.GetOrdinal("currencyid"))
                                });
                            }
                        }
                    }
                }

                // --- CRITICAL CHANGE HERE ---
                // If no data is found, return an empty list of the expected type (200 OK with empty array)
                // instead of an anonymous object with a message.
                return Ok(freezedbomdetails);
            }
            catch (Exception ex)
            {
                // Log the error for server-side debugging
                // _logger.LogError(ex, "Error fetching Freezed BOM details for jobId {jobId}", jobId);

                // Return a 500 Internal Server Error with a more generic message for the client
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }















        [HttpPut("UpdateBom")]
        public async Task<IActionResult> UpdateBom([FromBody] updatebomdto updatedBom)
        {
            if (updatedBom == null || updatedBom.bomid <= 0)
            {
                return BadRequest("Invalid BOM data.");
            }

            try
            {
                var existingBom = await dbcontext.Bom.FirstOrDefaultAsync(b => b.bomid == updatedBom.bomid);

                if (existingBom == null)
                {
                    return NotFound("No BOM found with the given ID.");
                }


                existingBom.bomqty = updatedBom.bomqty;
                existingBom.bomuomid = updatedBom.bomuomid;
                existingBom.price = updatedBom.price;

                existingBom.prodstageid = updatedBom.prodstageid;
                existingBom.RequiredDate = updatedBom.requiredDate;

                existingBom.currencyid = updatedBom.currencyid;

                await dbcontext.SaveChangesAsync();
                return Ok(new { message = "BOM updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }







        [HttpPut("updatepurchasedetails")]
        public async Task<IActionResult> updatepurchasedetails([FromBody] updatepurchasedetails updatepo)
        {
            if (updatepo == null || updatepo.forderid <= 0)
            {
                return BadRequest("Invalid PO data.");
            }

            try
            {
                var existingpolinedetails = await dbcontext.Purchasedetails.FirstOrDefaultAsync(b => b.potblid == updatepo.fpotblid);

                if (existingpolinedetails == null)
                {
                    return NotFound("No PO line found with the given ID.");
                }
                existingpolinedetails.make = updatepo.fmake;
                existingpolinedetails.pounitprice = updatepo.funitprice;


                await dbcontext.SaveChangesAsync();
                return Ok(new { message = "PO Details updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



























        public class LastPurchaseInfo
        {
            public int poitemid { get; set; }
            public decimal pounitprice { get; set; }
            public decimal poexchangerate { get; set; }
            public decimal convertedprice { get; set; }
        }

        [HttpGet("GetLastPurchasePrice")]
        public ActionResult<LastPurchaseInfo> GetLastPurchasePrice(int itemcode)
        {
            LastPurchaseInfo purchaseInfo = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetLastPurchasePriceWithExchangeRate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemcode", itemcode);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            purchaseInfo = new LastPurchaseInfo
                            {
                                poitemid = reader.GetInt32(reader.GetOrdinal("poitemid")),
                                pounitprice = Convert.ToDecimal(reader["pounitprice"]),
                                poexchangerate = Convert.ToDecimal(reader["poexchangerate"]),
                                convertedprice = Convert.ToDecimal(reader["convertedprice"])
                            };
                        }
                    }
                }
            }

            if (purchaseInfo == null)
            {
                return NotFound("No purchase history found for the provided item code.");
            }

            return Ok(purchaseInfo);
        }






        [HttpGet("getallponos")]
        public async Task<ActionResult<IEnumerable<int>>> getallponos()
        {
            // Use Entity Framework Core to query the database.
            // .Select(po => po.orderid) is used to select only the orderid property,
            // which is more efficient than fetching the entire POHeader object.
            var poNumbers = await dbcontext.PO
                                          .Select(po => po.Orderid)
                                          .ToListAsync();

            // Return the list of PO numbers
            return Ok(poNumbers);
        }








        [HttpGet("getexchangeratebycurrencyid/{currencyid}")]
        public async Task<IActionResult> getexchangeratebycurrencyid(int currencyid)
        {
            var product = await dbcontext.Currency
                                         .Where(p => p.currencyid == currencyid)
                                         .Select(p => new
                                         {
                                             p.exchangerate
                                         })
                                         .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product.exchangerate);
        }




        [HttpPost("AddDesignation")]
        public async Task<IActionResult> AddDesignation([FromBody] Designation designation)
        {


            bool exists = await dbcontext.designation
                .AnyAsync(d => d.designationname.ToLower() == designation.designationname.ToLower());

            if (exists)
            {
                return Conflict(new
                {
                    message = "A designation with the same name already exists."
                });
            }

            dbcontext.designation.Add(designation);
            await dbcontext.SaveChangesAsync();
            return Ok(designation);
        }









        [HttpPost("Addcompany")]
        public async Task<IActionResult> Addcompany([FromBody] Company company)
        {
            bool exists = await dbcontext.Company
                 .AnyAsync(d => d.companyname.ToLower() == company.companyname.ToLower());
            if (exists)
            {
                return Conflict(new
                {
                    message = "A company with the same name already exists."
                });
            }
            dbcontext.Company.Add(company);
            await dbcontext.SaveChangesAsync();
            return Ok(company);
        }
        [HttpGet("Listdesignation")]
        public async Task<IActionResult> Listdesignation()
        {
            var listdesignation = await dbcontext.designation.ToListAsync();
            return Ok(listdesignation);
        }


















        [HttpGet("listcompany")]
        public async Task<IActionResult> listcompany()
        {
            var listcompany = await dbcontext.Company.ToListAsync();
            return Ok(listcompany);
        }

        [HttpGet("GetDesignationById/{id}")]
        public async Task<IActionResult> GetDesignationById(int id)
        {
            var designation = await dbcontext.designation.FindAsync(id);

            if (designation == null)
            {
                return NotFound();
            }

            return Ok(designation);
        }


        [HttpPost("AddOrUpdateEmployee")]
        public async Task<IActionResult> AddOrUpdateEmployee([FromBody] Addemployee employee)
        {
            var existingEmployee = await dbcontext.Employeemaster
                .FirstOrDefaultAsync(e => e.empid == employee.empid);

            if (existingEmployee != null)
            {
                existingEmployee.empname = employee.empname;
                existingEmployee.companyid = employee.companyid;
                existingEmployee.designationid = employee.designationid;
                existingEmployee.empstatus = employee.empstatus;
                dbcontext.Employeemaster.Update(existingEmployee);
            }
            else
            {
                var newEmployee = new Employeemaster
                {
                    empid = employee.empid,
                    empname = employee.empname,
                    companyid = employee.companyid,
                    designationid = employee.designationid,
                    empstatus = employee.empstatus
                };

                dbcontext.Employeemaster.Add(newEmployee);
            }

            await dbcontext.SaveChangesAsync();
            return Ok(new { Message = "Employee Created Successfully" });
        }

        [HttpGet("listemployee")]
        public async Task<IActionResult> ListEmployee()
        {
            var list = await (from emp in dbcontext.Employeemaster
                              join comp in dbcontext.Company on emp.companyid equals comp.companyid
                              join desig in dbcontext.designation on emp.designationid equals desig.designationid
                              select new
                              {
                                  emp.empid,
                                  emp.empname,
                                  emp.empstatus,
                                  companyname = comp.companyname,
                                  designationname = desig.designationname
                              }).ToListAsync();

            return Ok(list);
        }



        [HttpGet("listsupplier")]
        public async Task<IActionResult> listsupplier()
        {
            var list = await (from sup in dbcontext.Supplier

                              select new
                              {
                                  sup.supplierid,
                                  sup.supplieraddress,
                                  sup.suppliertrnno,
                                  sup.fax,
                                  sup.emailaddress,
                                  sup.phoneno,
                                  sup.suppliername,
                                  sup.supplierpoboxno

                              }).ToListAsync();

            return Ok(list);
        }


        public class listinvoice
        {
            public int invoiceno { get; set; }
            public int jobid { get; set; }
            public string customername { get; set; }
            public decimal totalamountwithtax { get; set; }

            public DateTime? invoicedate { get; set; }

        }

        [HttpGet("ListInvoice")]
        public async Task<ActionResult<List<listinvoice>>> ListInvoice()
        {
            var listinvoices = new List<listinvoice>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_GetListInvoice", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                listinvoices.Add(new listinvoice
                                {
                                    customername = reader["customername"].ToString(),
                                    invoiceno = reader.GetInt32(reader.GetOrdinal("invoiceno")),
                                    jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                    totalamountwithtax = reader.IsDBNull(reader.GetOrdinal("totalamountwithtax"))
                                     ? 0
                                     : Convert.ToDecimal(reader["totalamountwithtax"]),

                                    invoicedate = reader.IsDBNull(reader.GetOrdinal("invoicedate"))
        ? (DateTime?)null
        : reader.GetDateTime(reader.GetOrdinal("invoicedate"))







                                });
                            }
                        }
                    }
                }

                if (listinvoices.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(listinvoices);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching budget summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the budget summary.");
            }
        }













        [HttpPost("AddOrUpdateSupplier")]
        public async Task<IActionResult> AddOrUpdateSupplier([FromBody] Supplier supplier)
        {
            if (string.IsNullOrWhiteSpace(supplier.suppliername))
                return BadRequest("Supplier name is required.");

            var existingSupplier = await dbcontext.Supplier
                .FirstOrDefaultAsync(s => s.suppliername.ToLower() == supplier.suppliername.ToLower());

            if (existingSupplier != null)
            {
                // Update fields
                existingSupplier.supplieraddress = supplier.supplieraddress;
                existingSupplier.suppliertrnno = supplier.suppliertrnno;
                existingSupplier.supplierpoboxno = supplier.supplierpoboxno;
                existingSupplier.webaddress = supplier.webaddress;
                existingSupplier.emailaddress = supplier.emailaddress;
                existingSupplier.phoneno = supplier.phoneno;
                existingSupplier.fax = supplier.fax;
                existingSupplier.remarks = supplier.remarks;
                existingSupplier.createddate = DateTime.Now;

                dbcontext.Supplier.Update(existingSupplier);
                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Supplier Updated Successfully" });
            }
            else
            {
                supplier.createddate = DateTime.Now;
                dbcontext.Supplier.Add(supplier);
                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Supplier created Successfully" });
            }
        }

        [HttpGet("getSupplierbysupplierid/{supplierid}")]
        public async Task<IActionResult> getSupplierbysupplierid(int supplierid)
        {
            var supplierdetails = await dbcontext.Supplier.FindAsync(supplierid);

            if (supplierdetails == null)
            {
                return NotFound();
            }

            return Ok(supplierdetails);
        }


        [HttpGet("GetCustomercontactbycustomerid/{customerid}")]
        public async Task<IActionResult> GetCustomercontactbycustomerid(int customerid)
        {
            var contactdetails = await dbcontext.customercontact
                .Where(c => c.customerid == customerid)
                .ToListAsync();

            if (contactdetails == null || !contactdetails.Any())
            {
                return NotFound();
            }

            return Ok(contactdetails);
        }



        [HttpGet("GetSupplierContactbySupplierid/{supplierid}")]
        public async Task<IActionResult> GetSupplierContactbySupplierid(int supplierid)
        {
            var supplierdetails = await dbcontext.SupplierContact
                .Where(c => c.supplierid == supplierid)
                .ToListAsync();

            if (supplierdetails == null || !supplierdetails.Any())
            {
                return NotFound();
            }

            return Ok(supplierdetails);
        }




        [HttpGet("GetAllcustomercontact")]
        public async Task<IActionResult> GetAllcustomercontact()
        {
            var contactdetails = await dbcontext.customercontact

                .ToListAsync();

            if (contactdetails == null || !contactdetails.Any())
            {
                return NotFound();
            }

            return Ok(contactdetails);
        }























        [HttpGet("Getcustomeraddressbycustomerid/{customerid}")]
        public async Task<IActionResult> Getcustomeraddressbycustomerid(int customerid)
        {
            var customer = await dbcontext.Customer
                .Where(c => c.customerid == customerid)
                .Select(c => new
                {
                    FullContactDetails = c.address + " _ " + c.phone + " _ " + c.country.countryname
                })
                .FirstOrDefaultAsync();

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }


























        public class budgetsubreviondetails
        {
            public string categoryname { get; set; }
            public string subcategoryname { get; set; }
            public decimal amount { get; set; }
            public int bomrevno { get; set; }

        }


        [HttpGet("GetBomBudgetrevisionsubdetails")]
        public async Task<ActionResult<List<budgetsubreviondetails>>> GetBomBudgetrevisionsubdetails(int jobid, int budgetheaderid, int revno)
        {
            var budgetSummaries = new List<budgetsubreviondetails>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_GetBomBudgetsubrevisiondetails", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@jobid", jobid);
                        cmd.Parameters.AddWithValue("@budgetheaderid", budgetheaderid);
                        cmd.Parameters.AddWithValue("@revno", revno);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await reader.ReadAsync())
                            {
                                budgetSummaries.Add(new budgetsubreviondetails
                                {
                                    categoryname = reader["categoryname"].ToString(),
                                    subcategoryname = reader["subcategoryname"].ToString(),
                                    bomrevno = reader.GetInt32(reader.GetOrdinal("bomrevno")),
                                    amount = reader.IsDBNull(reader.GetOrdinal("Amount"))
                                     ? 0
                                     : Convert.ToDecimal(reader["Amount"]),






                                });
                            }
                        }
                    }
                }

                if (budgetSummaries.Count == 0)
                {
                    // Return a valid JSON response with 404 status and a message
                    return NotFound(new { message = "No data found for the provided jobId." });
                }

                return Ok(budgetSummaries);
            }
            catch (Exception ex)
            {
                // Log the error (implement proper logging in a real app)
                Console.WriteLine($"Error fetching budget summary: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the budget summary.");
            }
        }












        [HttpGet("GetInvoicePdfrv2/{id}")]
        public async Task<IActionResult> GetInvoicePdfrv2(int id)
        {
            // Fetch the invoice with all related data in a single query
            var invoice = await dbcontext.Invoice
                .Include(i => i.Customer)
                .Include(i => i.Job)
                .Include(i => i.Currency)
                .Include(i => i.customercontact)
                .Include(i => i.Invoicedetails)
                .FirstOrDefaultAsync(i => i.invoiceno == id);

            if (invoice == null)
            {
                return NotFound($"Invoice with number {id} not found.");
            }

            // Fetch company info from the database
            var companyInfo = await dbcontext.CompanyInfo.FirstOrDefaultAsync();
            if (companyInfo == null)
            {
                // You might want to seed this data or handle its absence differently
                return StatusCode(500, "Company information not found in the database. Please ensure it's seeded.");
            }

            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new iTextSharp.text.Document(PageSize.A4, 36, 36, 36, 36); // Left, Right, Top, Bottom margins
                PdfWriter.GetInstance(document, ms);
                document.Open();

                // Define fonts
                Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                Font smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24);

                // --- Top Header: Company Name & Logo ---
                PdfPTable topHeaderTable = new PdfPTable(2);
                topHeaderTable.WidthPercentage = 100;
                topHeaderTable.SetWidths(new float[] { 0.5f, 0.5f });

                // Left Side (Logo)
                string logoPath = "wwwroot/images/Logo.bmp";
                if (System.IO.File.Exists(logoPath))
                {
                    try
                    {
                        Image logo = Image.GetInstance(logoPath);
                        logo.ScaleToFit(100f, 100f);
                        logo.Alignment = Element.ALIGN_LEFT;
                        PdfPCell leftCell = new PdfPCell(logo)
                        {
                            Border = PdfPCell.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        topHeaderTable.AddCell(leftCell);
                    }
                    catch (Exception ex)
                    {
                        // Handle image loading error gracefully, e.g., log it and add an empty cell
                        PdfPCell emptyCell = new PdfPCell() { Border = PdfPCell.NO_BORDER };
                        topHeaderTable.AddCell(emptyCell);
                    }
                }
                else
                {
                    PdfPCell emptyCell = new PdfPCell() { Border = PdfPCell.NO_BORDER };
                    topHeaderTable.AddCell(emptyCell);
                }

                // Right Side (Company Name & Address) - Now dynamically from CompanyInfo
                PdfPCell companyInfoCell = new PdfPCell()
                {
                    Border = PdfPCell.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_TOP
                };
                companyInfoCell.AddElement(new Paragraph(companyInfo.CompanyName.Split(' ')[0], headerFont) { Alignment = Element.ALIGN_RIGHT });
                companyInfoCell.AddElement(new Paragraph(companyInfo.Companypobox, smallFont) { Alignment = Element.ALIGN_RIGHT });
                companyInfoCell.AddElement(new Paragraph(companyInfo.CompanyAddressLine2, smallFont) { Alignment = Element.ALIGN_RIGHT });
                // companyInfoCell.AddElement(new Paragraph(companyInfo.Companycountry, smallFont) { Alignment = Element.ALIGN_RIGHT });
                companyInfoCell.AddElement(new Paragraph("Tel: " + companyInfo.CompanyPhone, smallFont) { Alignment = Element.ALIGN_RIGHT });
                companyInfoCell.AddElement(new Paragraph("Fax: " + companyInfo.CompanyFax, smallFont) { Alignment = Element.ALIGN_RIGHT });
                companyInfoCell.AddElement(new Paragraph("Email: " + companyInfo.CompanyEmail, smallFont) { Alignment = Element.ALIGN_RIGHT });
                companyInfoCell.AddElement(new Paragraph("Website: " + companyInfo.CompanyWebsite, smallFont) { Alignment = Element.ALIGN_RIGHT });
                companyInfoCell.AddElement(new Paragraph("TRN: " + companyInfo.CompanyTRN, smallFont) { Alignment = Element.ALIGN_RIGHT });
                topHeaderTable.AddCell(companyInfoCell);

                document.Add(topHeaderTable);
                document.Add(new Paragraph("\n")); // Space

                // --- Invoice Title ---
                document.Add(new Paragraph("Annexure to Invoice", titleFont) { Alignment = Element.ALIGN_CENTER });
                document.Add(new Paragraph("\n")); // Space

                // --- TO Section: Customer Details & Invoice Info Table ---
                PdfPTable mainContentTable = new PdfPTable(2);
                mainContentTable.WidthPercentage = 100;
                mainContentTable.SetWidths(new float[] { 1f, 0.8f }); // Left (Customer) wider than Right (Invoice Details)

                // Left Cell: Customer Details
                PdfPCell customerDetailsCell = new PdfPCell()
                {
                    Border = PdfPCell.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    VerticalAlignment = Element.ALIGN_TOP
                };
                customerDetailsCell.AddElement(new Paragraph("TO", boldFont));
                customerDetailsCell.AddElement(new Paragraph(invoice.Customer?.Customername ?? "N/A", boldFont));
                customerDetailsCell.AddElement(new Paragraph(invoice.InvoiceAddress ?? invoice.Customer?.address ?? "N/A", normalFont));
                // Assuming "Mauritius" comes from customer.Address or a specific field
                customerDetailsCell.AddElement(new Paragraph("Mauritius", normalFont)); // Placeholder
                customerDetailsCell.AddElement(new Paragraph($"TRN: {invoice.Customer?.Trnno ?? ""}", normalFont));
                customerDetailsCell.AddElement(new Paragraph($"Attn: {invoice.customercontact.name ?? "N/A"}", normalFont));
                mainContentTable.AddCell(customerDetailsCell);

                // Right Cell: Invoice Header Details Table (bordered)
                PdfPTable invoiceHeaderDetailsTable = new PdfPTable(2);
                invoiceHeaderDetailsTable.WidthPercentage = 100;
                invoiceHeaderDetailsTable.SetWidths(new float[] { 0.5f, 0.5f }); // Label, Value
                invoiceHeaderDetailsTable.DefaultCell.Border = Rectangle.BOX;
                invoiceHeaderDetailsTable.DefaultCell.BorderWidth = 0.5f; // Add borders to cells

                invoiceHeaderDetailsTable.AddCell(CreateDataCell("Inv. No.", Element.ALIGN_LEFT, boldFont));
                invoiceHeaderDetailsTable.AddCell(CreateDataCell(invoice.invoiceno.ToString(), Element.ALIGN_LEFT, normalFont));

                invoiceHeaderDetailsTable.AddCell(CreateDataCell("Date", Element.ALIGN_LEFT, boldFont));
                invoiceHeaderDetailsTable.AddCell(CreateDataCell(invoice.InvoiceDate.ToShortDateString(), Element.ALIGN_LEFT, normalFont));

                invoiceHeaderDetailsTable.AddCell(CreateDataCell("Our Ref", Element.ALIGN_LEFT, boldFont));
                invoiceHeaderDetailsTable.AddCell(CreateDataCell(invoice.Job.Jobid.ToString(), Element.ALIGN_LEFT, normalFont));

                invoiceHeaderDetailsTable.AddCell(CreateDataCell("Your PO No", Element.ALIGN_LEFT, boldFont));
                invoiceHeaderDetailsTable.AddCell(CreateDataCell(invoice.LPOno ?? "N/A", Element.ALIGN_LEFT, normalFont));

                invoiceHeaderDetailsTable.AddCell(CreateDataCell("Date Of PO", Element.ALIGN_LEFT, boldFont));
                invoiceHeaderDetailsTable.AddCell(CreateDataCell(invoice.LPODate.ToShortDateString() ?? "N/A", Element.ALIGN_LEFT, normalFont));

                invoiceHeaderDetailsTable.AddCell(CreateDataCell("Currency", Element.ALIGN_LEFT, boldFont));
                invoiceHeaderDetailsTable.AddCell(CreateDataCell(invoice.Currency?.currencyname ?? "N/A", Element.ALIGN_LEFT, normalFont));

                invoiceHeaderDetailsTable.AddCell(CreateDataCell("Due Date", Element.ALIGN_LEFT, boldFont));
                invoiceHeaderDetailsTable.AddCell(CreateDataCell(invoice.DueDate.ToShortDateString(), Element.ALIGN_LEFT, normalFont));

                PdfPCell invoiceHeaderDetailsCell = new PdfPCell(invoiceHeaderDetailsTable)
                {
                    Border = PdfPCell.NO_BORDER, // No border for the wrapping cell
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_TOP
                };
                mainContentTable.AddCell(invoiceHeaderDetailsCell);

                document.Add(mainContentTable);
                document.Add(new Paragraph("\n")); // Space

                // --- Line Items Table ---
                PdfPTable itemsTable = new PdfPTable(9); // Added Taxable Amt and Tax Amt
                itemsTable.WidthPercentage = 100;
                float[] widths = new float[] { 0.5f, 3f, 0.8f, 0.8f, 1.2f, 1.2f, 0.8f, 1.2f, 1f };
                itemsTable.SetWidths(widths);
                itemsTable.DefaultCell.Border = Rectangle.BOX;
                itemsTable.DefaultCell.BorderWidth = 0.5f; // Add borders to cells

                // Table Headers
                itemsTable.AddCell(CreateHeaderCell("Sr No", Element.ALIGN_CENTER));
                itemsTable.AddCell(CreateHeaderCell("Description", Element.ALIGN_LEFT));
                itemsTable.AddCell(CreateHeaderCell("UOM", Element.ALIGN_CENTER));
                itemsTable.AddCell(CreateHeaderCell("QTY", Element.ALIGN_RIGHT));
                itemsTable.AddCell(CreateHeaderCell("Unit Price", Element.ALIGN_RIGHT));
                itemsTable.AddCell(CreateHeaderCell("Amount", Element.ALIGN_RIGHT)); // Amount before VAT
                itemsTable.AddCell(CreateHeaderCell("Vat%", Element.ALIGN_RIGHT));
                itemsTable.AddCell(CreateHeaderCell("Taxable Amt", Element.ALIGN_RIGHT));
                itemsTable.AddCell(CreateHeaderCell("Tax Amt", Element.ALIGN_RIGHT));

                decimal totalVATAmount = 0;
                decimal overallTotalAmount = 0; // Total including VAT
                decimal overallTaxableAmount = 0; // Total before VAT

                int itemCounter = 1;
                foreach (var detail in invoice.Invoicedetails.OrderBy(d => d.invidno))
                {
                    // Parse the string properties to decimal before performing calculations
                    decimal parsedUnitPrice = decimal.Parse(detail.unitprice);
                    decimal parsedQty = decimal.Parse(detail.qty);
                    decimal parsedVatPercent = decimal.Parse(detail.vatpercent);

                    decimal lineAmountBeforeTax = parsedUnitPrice * parsedQty;
                    decimal lineTaxAmount = (lineAmountBeforeTax * parsedVatPercent) / 100;
                    decimal lineTotalWithTax = lineAmountBeforeTax + lineTaxAmount;

                    itemsTable.AddCell(CreateDataCell(itemCounter.ToString("D2"), Element.ALIGN_CENTER, smallFont));
                    itemsTable.AddCell(CreateDataCell(detail.description, Element.ALIGN_LEFT, smallFont));
                    itemsTable.AddCell(CreateDataCell(detail.uom, Element.ALIGN_CENTER, smallFont));
                    itemsTable.AddCell(CreateDataCell(parsedQty.ToString("F2"), Element.ALIGN_RIGHT, smallFont)); // Use parsedQty
                    itemsTable.AddCell(CreateDataCell(parsedUnitPrice.ToString("F2"), Element.ALIGN_RIGHT, smallFont)); // Use parsedUnitPrice
                    itemsTable.AddCell(CreateDataCell(lineAmountBeforeTax.ToString("F2"), Element.ALIGN_RIGHT, smallFont));
                    itemsTable.AddCell(CreateDataCell(parsedVatPercent.ToString("F0"), Element.ALIGN_RIGHT, smallFont)); // Use parsedVatPercent
                    itemsTable.AddCell(CreateDataCell(lineAmountBeforeTax.ToString("F2"), Element.ALIGN_RIGHT, smallFont));
                    itemsTable.AddCell(CreateDataCell(lineTaxAmount.ToString("F2"), Element.ALIGN_RIGHT, smallFont));

                    totalVATAmount += lineTaxAmount;
                    overallTotalAmount += lineTotalWithTax;
                    overallTaxableAmount += lineAmountBeforeTax;
                    itemCounter++;
                }

                document.Add(itemsTable);
                // --- Totals Section (VAT and TOTAL) ---
                // IMPORTANT: Using a 4-column table for accurate alignment as per images
                // --- Totals Section (VAT and TOTAL) ---
                // Using a 4-column table for accurate alignment with main invoice columns
                // --- Totals Section (VAT and TOTAL) ---
                // IMPORTANT CHANGE: Now using a 5-column table to align precisely with your invoice's numerical columns.
                PdfPTable totalsTable = new PdfPTable(5);
                totalsTable.WidthPercentage = 100;
                // Column widths re-calculated for precise alignment with the main invoice table's columns:
                // Column 1 (6.3f): Combined label column (aligns with Sr No, Description, UOM, QTY, Unit Price)
                // Column 2 (1.2f): Aligns with 'Amount' column
                // Column 3 (0.8f): Aligns with 'Vat%' column (this will be empty for totals)
                // Column 4 (1.2f): Aligns with 'Taxable Amt' column
                // Column 5 (1f): Aligns with 'Tax Amt' column
                totalsTable.SetWidths(new float[] { 6.3f, 1.2f, 0.8f, 1.2f, 1f });
                // By default, cells will have all borders. We will explicitly set borders for each cell below.

                // VAT row - Custom border and alignment as per correct_one.docx and 5666.png
                // Cell 1: "VAT" label (left-aligned)
                PdfPCell vatLabelCell = CreateDataCell("VAT", Element.ALIGN_LEFT, boldFont);
                // Ensure all borders are present for this cell
                vatLabelCell.Border = Rectangle.ALIGN_JUSTIFIED_ALL;
                totalsTable.AddCell(vatLabelCell);

                // Cell 2: VAT Amount (e.g., 325.00)
                // This aligns exactly under the "Amount" column.
                PdfPCell vatAmountCell = CreateDataCell(totalVATAmount.ToString("F2"), Element.ALIGN_RIGHT, boldFont);
                // Set borders: Only top, bottom, and left borders should be visible for this cell.
                // This will make the vertical line between 'Amount' and 'Vat%' columns disappear for this row.
                vatAmountCell.Border = Rectangle.ALIGN_TOP | Rectangle.ALIGN_BOTTOM | Rectangle.ALIGN_LEFT;
                totalsTable.AddCell(vatAmountCell);

                // Cell 3: Empty for 'Vat%' in VAT row
                // As per the image, this cell should be empty and have no internal vertical borders.
                PdfPCell vatEmptyVatPercCell = CreateDataCell("", Element.ALIGN_RIGHT, boldFont);
                vatEmptyVatPercCell.Border = Rectangle.ALIGN_TOP | Rectangle.ALIGN_BOTTOM; // Only top and bottom borders
                totalsTable.AddCell(vatEmptyVatPercCell);

                // Cell 4: Empty for 'Taxable Amt' in VAT row
                // Again, no internal vertical borders.
                PdfPCell vatEmptyTaxableAmtCell = CreateDataCell("", Element.ALIGN_RIGHT, boldFont);
                vatEmptyTaxableAmtCell.Border = Rectangle.ALIGN_TOP | Rectangle.ALIGN_BOTTOM;
                totalsTable.AddCell(vatEmptyTaxableAmtCell);

                // Cell 5: Empty for 'Tax Amt' in VAT row
                // No internal vertical border, but the outer right border of the table should be present.
                PdfPCell vatEmptyTaxAmtCell = CreateDataCell("", Element.ALIGN_RIGHT, boldFont);
                vatEmptyTaxAmtCell.Border = Rectangle.ALIGN_TOP | Rectangle.ALIGN_BOTTOM | Rectangle.ALIGN_RIGHT;
                totalsTable.AddCell(vatEmptyTaxAmtCell);


                // TOTAL row - All borders visible as per images
                // Cell 1: "TOTAL" label (left-aligned)
                totalsTable.AddCell(CreateDataCell("TOTAL", Element.ALIGN_LEFT, headerFont));

                // Cell 2: Amount column total (e.g., 6825.00)
                // This aligns exactly under the "Amount" column. All borders.
                totalsTable.AddCell(CreateDataCell(overallTotalAmount.ToString("F2"), Element.ALIGN_RIGHT, headerFont));

                // Cell 3: Empty for 'Vat%' column in TOTAL row
                // This column should be empty for the TOTAL row as well. All borders.
                totalsTable.AddCell(CreateDataCell("", Element.ALIGN_RIGHT, headerFont));

                // Cell 4: Taxable Amt column total (e.g., 6500.00)
                // This aligns under the "Taxable Amt" column. Corrected to use 'overallTaxableAmount'. All borders.
                totalsTable.AddCell(CreateDataCell(overallTaxableAmount.ToString("F2"), Element.ALIGN_RIGHT, headerFont));

                // Cell 5: Tax Amt column total (e.g., 325.00)
                // This aligns under the "Tax Amt" column. All borders.
                totalsTable.AddCell(CreateDataCell(totalVATAmount.ToString("F2"), Element.ALIGN_RIGHT, headerFont));

                document.Add(totalsTable);
                document.Add(new Paragraph("\n"));
































                // --- Remarks / Payment Terms / Order Value ---
                if (!string.IsNullOrWhiteSpace(invoice.remarks))
                {
                    document.Add(new Paragraph(invoice.remarks, normalFont));
                }
                //document.Add(new Paragraph($"ORDER VALUE: {invoice.Currency?.currencyname ?? "USD"} {overallTotalAmount:F2}", boldFont));
                //document.Add(new Paragraph("PAYMENT TERMS: 30% ADVANCE", boldFont));
                //document.Add(new Paragraph("70% BALANCE BEFORE DELIVERY", boldFont));
                //document.Add(new Paragraph("\n"));

                // --- Amount in Words ---
                string amountInWords = NumberToWords(overallTotalAmount) + " Only";
                document.Add(new Paragraph("Amount Chargeable Including VAT (in words)", boldFont));
                document.Add(new Paragraph($"{amountInWords} ({overallTotalAmount:F2})", normalFont));
                document.Add(new Paragraph("\n"));

                // --- Bank Details Section ---
                // This section will be added below the totals.

                // Add the general clarification text
                // --- Bank Details Section ---
                // This section will be added below the totals.

                // Add the general clarification text
                // --- Bank Details Section ---
                // This section will be added below the totals.

                // Add the general clarification text
                document.Add(new Paragraph("Any clarifications shall be informed on 00971 56 610 3421 with in 7 days from the date of invoice.", normalFont));
                document.Add(new Paragraph("\n")); // Add a line break for spacing

                // Main heading for the section
                // Assuming 'boldFont' is suitable for "For Ace Cranes & Engineering Fz-LLC"
                Paragraph aceCranesHeader = new Paragraph("For Ace Cranes & Engineering Fz-LLC", boldFont);
                document.Add(aceCranesHeader);

                document.Add(new Paragraph("\n")); // Add a line break for spacing

                // Create a table for "PN: Payment can be done..." and "Bank Details" heading
                // This header table itself should NOT have borders.
                PdfPTable bankDetailsHeaderTable = new PdfPTable(2);
                bankDetailsHeaderTable.WidthPercentage = 100;
                bankDetailsHeaderTable.SetWidths(new float[] { 0.5f, 0.5f });
                bankDetailsHeaderTable.DefaultCell.Border = Rectangle.NO_BORDER;

                // Cell for "PN: Payment can be done..."
                PdfPCell paymentMethodsCell = new PdfPCell(new Phrase("PN: Payment can be done in any one of our below Account", boldFont));
                paymentMethodsCell.Border = Rectangle.NO_BORDER;
                paymentMethodsCell.HorizontalAlignment = Element.ALIGN_LEFT;
                bankDetailsHeaderTable.AddCell(paymentMethodsCell);

                // Cell for "Bank Details :"
                PdfPCell bankDetailsTitleCell = new PdfPCell(new Phrase("Bank Details :", boldFont));
                bankDetailsTitleCell.Border = Rectangle.NO_BORDER;
                bankDetailsTitleCell.HorizontalAlignment = Element.ALIGN_LEFT;
                bankDetailsHeaderTable.AddCell(bankDetailsTitleCell);

                document.Add(bankDetailsHeaderTable);

                // Create the main table for bank accounts
                // This table will contain the two bank detail columns.
                PdfPTable bankAccountsTable = new PdfPTable(2);
                bankAccountsTable.WidthPercentage = 100;
                bankAccountsTable.SetWidths(new float[] { 0.5f, 0.5f });
                bankAccountsTable.DefaultCell.Border = Rectangle.NO_BORDER;
                // IMPORTANT: We apply borders directly to the cells to create the outer frame.
                // By default, DefaultCell.Border is Rectangle.ALL, which is what we want for the entire outline,
                // but we'll manually specify individual cell borders to ensure the middle line is there.

                // --- Left Bank Details (Mashreq Bank Psc) ---
                PdfPCell mashreqBankCell = new PdfPCell();
                // This cell needs a TOP, BOTTOM, LEFT, and RIGHT border to create its part of the outer frame
                // AND the vertical separator in the middle.
                mashreqBankCell.Border = Rectangle.ALIGN_JUSTIFIED_ALL;
                mashreqBankCell.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;

                // Add some padding inside the cell

                mashreqBankCell.AddElement(new Phrase("Benificiary : Ace Cranes and Engineering FZ llc", normalFont));
                mashreqBankCell.AddElement(new Phrase("Mashreq Bank Psc", boldFont));
                mashreqBankCell.AddElement(new Phrase("Branch 12, King Abdul Aziz Branch Sharjah, UAE", normalFont));
                mashreqBankCell.AddElement(new Phrase("AED :AE 41 0330 0000 1900 0028 744", normalFont));
                mashreqBankCell.AddElement(new Phrase("USD :AE 29 0330 0000 1900 0036 332", normalFont));
                mashreqBankCell.AddElement(new Phrase("SWIFT:BOMLAEAD", normalFont));
                bankAccountsTable.AddCell(mashreqBankCell);

                // --- Right Bank Details (NBAD) ---
                PdfPCell nbadBankCell = new PdfPCell();
                // This cell needs a TOP, BOTTOM, and RIGHT border to complete the outer frame.
                // The LEFT border is provided by the RIGHT border of the MashreqBankCell.
                nbadBankCell.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                nbadBankCell.Padding = 5; // Add some padding inside the cell

                nbadBankCell.AddElement(new Phrase("Benificiary : Ace Cranes and Engineering FZ llc", normalFont));
                nbadBankCell.AddElement(new Phrase("NBAD", boldFont));
                nbadBankCell.AddElement(new Phrase("Ras Al Riffa Branch , Ras Al Khaimah,UAE", normalFont));
                nbadBankCell.AddElement(new Phrase("AED :AE 89 0350 0000 0620 6483 580", normalFont));
                nbadBankCell.AddElement(new Phrase("USD : AE 50 0350 0000 0620 6483 603", normalFont));
                nbadBankCell.AddElement(new Phrase("SWIFT:NBADAEAARAK", normalFont));
                bankAccountsTable.AddCell(nbadBankCell);

                document.Add(bankAccountsTable);

                document.Add(new Paragraph("\n")); // Add a line break after the bank details

                // Add the format number at the bottom right
                Paragraph formatNo = new Paragraph("Format No: ACE-ACC-F-03, REV.00", normalFont);
                formatNo.Alignment = Element.ALIGN_RIGHT;
                document.Add(formatNo);

                document.Close();
                return File(ms.ToArray(), "application/pdf", $"Invoice_{invoice.invoiceno}.pdf");
            }
        }

        // --- Helper Methods ---
        private PdfPCell CreateHeaderCell(string content, int alignment)
        {
            PdfPCell cell = new PdfPCell(new Phrase(content, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9)));
            cell.HorizontalAlignment = alignment;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = new BaseColor(240, 240, 240);
            cell.BorderWidth = 0.5f;
            cell.Padding = 5;
            return cell;
        }

        private PdfPCell CreateDataCell(string content, int alignment, Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(content, font));
            cell.HorizontalAlignment = alignment;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BorderWidth = 0.5f;
            cell.Padding = 5;
            return cell;
        }

        private string GetBankAccountString(string currency, string accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber)) return "N/A";
            if (accountNumber.StartsWith("AE") && accountNumber.Length >= 23)
            {
                return $"{currency}: {accountNumber.Substring(0, 2)} {accountNumber.Substring(2, 4)} {accountNumber.Substring(6, 4)} {accountNumber.Substring(10, 4)} {accountNumber.Substring(14, 4)} {accountNumber.Substring(18, 5)}";
            }
            return $"{currency}: {accountNumber}";
        }

        [HttpGet("listjobamendment")]
        public async Task<IActionResult> listjobamendment()

        {
            try
            {

                var jobamend = await dbcontext.jobamend
             .Include(dn => dn.Job)

             .Include(us => us.Amendedby)
              .ToListAsync();
                if (jobamend == null)
                {
                    return NotFound();
                }
                return Ok(jobamend);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }


















        private string NumberToWords(decimal number)
        {
            if (number == 0)
                return "Zero";

            string s = number.ToString("F2");
            string[] parts = s.Split('.');
            long integerPart = long.Parse(parts[0]);
            int decimalPart = parts.Length > 1 ? int.Parse(parts[1]) : 0;

            string words = "";
            if (integerPart > 0)
            {
                words += ConvertNumberToWords(integerPart);
            }

            if (decimalPart > 0)
            {
                if (integerPart > 0)
                    words += " and ";
                words += ConvertNumberToWords(decimalPart) + "/100";
            }
            return words.Trim();
        }

        private string ConvertNumberToWords(long number)
        {
            if (number == 0) return "";
            if (number < 0) return "Minus " + ConvertNumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += ConvertNumberToWords(number / 1000000000) + " Billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += ConvertNumberToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += ConvertNumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += ConvertNumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += " ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }
            return words.Trim();
        }






        [HttpGet("GetHoldMIDetails")]
        public async Task<IActionResult> GetHoldMIDetails()
        {
            var holdlist = await (from mh in dbcontext.Materialinspection
                                  join md in dbcontext.MIdetails on mh.mid equals md.mid
                                  join pr in dbcontext.Product on md.itemid equals pr.productcode
                                  where md.holdqty > 0
                                  select new
                                  {
                                      md.mitblid,
                                      mh.mid,
                                      mh.midate,
                                      pr.itemname,
                                      pr.productcode,
                                      md.acceptedqty,
                                      md.rejectedqty,
                                      md.holdqty,
                                      mh.pono
                                  }).ToListAsync();
            return Ok(holdlist);

        }































     public class UpdateMiDetailsDtorejected
        {
            public int MiTblId { get; set; }
            public int Mino { get; set; } // Added mino
            public int newacceptedqty { get; set; }
            public int newHoldQty { get; set; }
            public int rejectedQty { get; set; } // This is the new, remaining hold quantity
            public int originalrejectedqty { get; set; }
            public int itemcode { get; set; }
            // This is the initial total hold quantity for the item
        }






        public class UpdateMiDetailsDto
        {
            public int MiTblId { get; set; }
            public int Mino { get; set; } // Added mino
            public int NewAcceptedQty { get; set; }
            public int NewRejectedQty { get; set; }
            public int HoldQty { get; set; } // This is the new, remaining hold quantity
            public int OriginalHoldQty { get; set; } // This is the initial total hold quantity for the item
        }


        [HttpPost("UpdateHoldMi")] // Route matching Angular service: /api/Mi/po/updateholdmi
        public async Task<IActionResult> UpdateHoldMi([FromBody] UpdateMiDetailsDto updateDto)
        {
            // Basic validation: Check if the DTO is null or invalid
            if (updateDto == null)
            {
                return BadRequest("Invalid update data provided.");
            }

            // Start a database transaction to ensure atomicity of updates
            using var transaction = await dbcontext.Database.BeginTransactionAsync();
            try
            {
                // 3. Logic to update the MIdetails:
                // Find the existing MI item in the database using its primary key (miTblId).
                // Ensure 'MIdetails' is the correct DbSet name in your DbContext.
                var miItemToUpdate = await dbcontext.MIdetails
                                                     .FirstOrDefaultAsync(m => m.mitblid == updateDto.MiTblId);
                var miheader = await dbcontext.Materialinspection
                                                  .FirstOrDefaultAsync(m => m.mid == updateDto.Mino);

                if (miItemToUpdate == null)
                {
                    // If the MI item is not found, rollback transaction and return 404.
                    await transaction.RollbackAsync();
                    return NotFound($"MI item with ID {updateDto.MiTblId} not found.");
                }

                if (miheader == null)
                {
                    // If the MI item is not found, rollback transaction and return 404.
                    await transaction.RollbackAsync();
                    return NotFound($"MI item with ID {miheader} not found.");
                }

                // Store the pono from MIdetails before updating, as it's needed for PurchaseDetails lookup
                var purchaseOrderNo = miheader.pono;

                // Apply the requested quantity update logic to MIdetails:
                miItemToUpdate.rejectedqty += updateDto.NewRejectedQty;
                miItemToUpdate.acceptedqty += updateDto.NewAcceptedQty;
                // The logic is: current DB HoldQty - original total hold from this MI + new remaining hold for this MI.
                miItemToUpdate.holdqty = updateDto.HoldQty;

                // Ensure quantities do not go below zero (optional, based on your business rules)
                //miItemToUpdate.rejectedqty = Math.Max(0, miItemToUpdate.rejectedqty);
                //miItemToUpdate.acceptedqty = Math.Max(0, miItemToUpdate.acceptedqty);
                //miItemToUpdate.holdqty = Math.Max(0, miItemToUpdate.holdqty);

                // Mark the MIdetails entity as modified
                dbcontext.Entry(miItemToUpdate).State = EntityState.Modified;

                // 4. Logic to update the PurchaseDetails:
                // Find the corresponding PurchaseDetails item using the pono.
                // Ensure 'PurchaseDetails' is the correct DbSet name in your DbContext.
                var purchaseDetailsToUpdate = await dbcontext.Purchasedetails
                                                              .FirstOrDefaultAsync(p => p.orderid == purchaseOrderNo);

                if (purchaseDetailsToUpdate == null)
                {
                    // If PurchaseDetails is not found, rollback transaction and return 404.
                    await transaction.RollbackAsync();
                    return NotFound($"Purchase Details for PO No. {purchaseOrderNo} not found.");
                }

                // Apply quantity updates to PurchaseDetails:
                // Assuming 'rejectedqty' in PurchaseDetails corresponds to total rejected for that PO
                purchaseDetailsToUpdate.insprejectedqty += updateDto.NewRejectedQty;
                // Assuming 'inspectedqty' in PurchaseDetails corresponds to total accepted for that PO
                purchaseDetailsToUpdate.inspacceptedqty += updateDto.NewAcceptedQty;
                // The logic for hold in PurchaseDetails:
                // current DB HoldQty - original total hold from this specific MI + new remaining hold for this specific MI.
                purchaseDetailsToUpdate.inspholdqty = purchaseDetailsToUpdate.inspholdqty - updateDto.OriginalHoldQty + updateDto.HoldQty;

                // Ensure quantities do not go below zero (optional)
                //purchaseDetailsToUpdate.insprejectedqty = Math.Max(0, purchaseDetailsToUpdate.insprejectedqty);
                //purchaseDetailsToUpdate.inspacceptedqty = Math.Max(0, purchaseDetailsToUpdate.inspacceptedqty);
                //purchaseDetailsToUpdate.inspholdqty = Math.Max(0, purchaseDetailsToUpdate.inspholdqty);

                // Mark the PurchaseDetails entity as modified
                dbcontext.Entry(purchaseDetailsToUpdate).State = EntityState.Modified;

                // Save all changes within the transaction
                await dbcontext.SaveChangesAsync();

                // Commit the transaction if all operations are successful
                await transaction.CommitAsync();

                // Return a 200 OK response with a success message.
                return Ok(new { message = "MI item and Purchase Details updated successfully." });
            }
            catch (DbUpdateConcurrencyException)
            {
                // Rollback transaction on concurrency conflict
                await transaction.RollbackAsync();
                if (!MiItemExists(updateDto.MiTblId)) // Check if MI item still exists after conflict
                {
                    return NotFound($"MI item with ID {updateDto.MiTblId} not found after concurrency check.");
                }
                else
                {
                    throw; // Re-throw if it's a genuine concurrency issue
                }
            }
            catch (Exception ex)
            {
                // Rollback transaction on any other exception
                await transaction.RollbackAsync();
                // Log the exception (use a proper logger in production)
                Console.WriteLine($"Error updating MI item and Purchase Details: {ex.Message}");
                return StatusCode(500, "An error occurred while updating the MI item and Purchase Details.");
            }
        }

        // Helper method to check if an MI item exists (useful for concurrency handling).
        private bool MiItemExists(int id)
        {
            return dbcontext.MIdetails.Any(e => e.mitblid == id);
        }





        public class AmendJobRequestDto
        {
            public int jobid { get; set; }
            public string amenduserid { get; set; } // Still good to know who is doing the action
            public decimal amendvalueinbasecurrency { get; set; }
            public decimal newordervalueinbasecurrency { get; set; }
            public int newcurrencyid { get; set; }
            public decimal newordervalue { get; set; }
            public string remarks { get; set; }
            public string password { get; set; } // This is the shared amendment password
            public decimal rate { get; set; }
            public decimal vatpercent { get; set; }

            public decimal ordervaluewithvat { get; set; }


        }




        [HttpPost("amendjob")]
        public async Task<IActionResult> amendjob([FromBody] AmendJobRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var storedJobAmendmentPasswordHash = _configuration["AppSettings:JobAmendmentPasswordHash"];

                if (string.IsNullOrEmpty(storedJobAmendmentPasswordHash))
                {
                    _logger.LogError("Job Amendment Password Hash is not configured in appsettings.json or secure store.");
                    return StatusCode(500, new { Message = "Server configuration error: Job amendment password not set." });
                }

                bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(request.password, storedJobAmendmentPasswordHash);

                if (!isPasswordCorrect)
                {
                    _logger.LogWarning("Job amendment attempt for job {JobId} failed due to incorrect amendment password.", request.jobid);
                    return Unauthorized(new { Message = "Incorrect amendment password provided." });
                }

                // Fetch the job. Include the associated Job, and potentially the user if needed for auditing the amendment itself
                // Make sure your DbContext has a DbSet<Job> named 'Job'
                var job = await dbcontext.Job.FirstOrDefaultAsync(j => j.Jobid == request.jobid);

                if (job == null)
                {
                    return NotFound(new { Message = $"Job with ID {request.jobid} not found." });
                }

                // Store the old base currency value before updating
                var oldOrderValueInBaseCurrency = job.ordervaluebasecurrency;

                // Update the Job entity
                job.ordervaluebasecurrency = request.newordervalueinbasecurrency;
                job.currencyid = request.newcurrencyid;
                job.ordervalue = request.newordervalue;

                job.exchangerate = request.rate;
                job.ordervaluewithvat = request.ordervaluewithvat;
                job.vatpercent = request.vatpercent;
                // Assuming you want to add remarks to the Job entity as well:
                // job.remarks = request.remarks; // Uncomment if your Job entity has a 'remarks' property

                // Calculate the amendment value (difference)
                decimal calculatedAmendValue = request.newordervalueinbasecurrency - oldOrderValueInBaseCurrency;

                // --- NEW LOGIC: Insert into jobamendment table ---
                var jobAmendmentRecord = new jobamend
                {
                    jobid = job.Jobid, // Link to the job being amended
                    amenddate = DateTime.UtcNow, // Record the current UTC time of amendment
                    amendvalueinbasecurrency = calculatedAmendValue, // The calculated difference
                    amenduserid = request.amenduserid,
                    remarks = request.remarks

                    // The user who performed the amendment
                    // Note: 'Job' and 'Amendedby' navigation properties will be handled by EF Core
                    // if you retrieve related entities before saving, or if FKs are configured correctly.
                    // For simplicity, directly setting the FK properties is often sufficient here.
                };

                await dbcontext.jobamend.AddAsync(jobAmendmentRecord); // Add the new amendment record
                                                                       // --- END NEW LOGIC ---

                // Log the amendment
                _logger.LogInformation("Job {JobId} amended by user {UserId}. Old Base Value: {OldVal}, New Base Value: {NewVal}. Amendment Value: {AmendVal}",
                    request.jobid, request.amenduserid, oldOrderValueInBaseCurrency, request.newordervalueinbasecurrency, calculatedAmendValue);

                // Save all changes to the database (both Job update and jobamendment insert)
                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Job amended successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while amending job {JobId} for user {UserId}", request.jobid, request.amenduserid);
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }
































        [HttpPost("Calculatetotalconsumableitemprice")]
        public IActionResult Calculatetotalconsumableitemprice([FromBody] DeductInventoryRequest12 request)
        {
            decimal totalprice1 = 0;
            using (var transaction = dbcontext.Database.BeginTransaction())
            {
                try
                {
                    var batches = new List<Batch2>();
                    var remainingQuantity = request.qty;

                    var inventoryItems = (from inv in dbcontext.Inventory
                                          join jj in dbcontext.Job on inv.jobid equals jj.Jobid
                                          join jy in dbcontext.JobType on jj.jobtypeid equals jy.jobtypeid
                                          join ci in dbcontext.Currency on inv.invcurrencyid equals ci.currencyid
                                          where jy.JobtypeName == "Miscellaneous" && inv.productid == request.ItemId
                                          orderby inv.Entrydate // Ensures FIFO ordering
                                          select inv).ToList();

                    foreach (var item in inventoryItems)
                    {
                        // Assuming 'Batch' constructor or properties correctly map these fields
                        // Make sure your 'Inventory' entity has 'quantity', 'invprice', 'reservedqty' (if applicable)
                        // If you have a 'reservedqty' in your Inventory model, you should deduct it here:
                        // var availableQuantity = item.quantity - item.reservedqty; // <--- IMPORTANT if you have reserved quantity
                        // batches.Add(new Batch(item.batchid, availableQuantity, item.invid, item.invcurrencyid, item.uomid, item.invprice));

                        // Based on your previous context, let's assume 'item.quantity' directly means available for calculation
                        // If 'reservedqty' is a field in your Inventory model, adjust this line:
                        batches.Add(new Batch2(item.batchid, item.quantity, item.invid, item.invcurrencyid, item.uomid, item.invprice, (decimal)(item.Currency?.exchangerate ?? 1)));
                    }

                    foreach (var batch in batches)
                    {
                        if (remainingQuantity <= 0) break;

                        // Adjust batch.Quantity if you have reservedqty in your 'Batch' or 'Inventory' model
                        // For example, if Batch also has a ReservedQuantity property:
                        // var currentBatchAvailableQuantity = batch.Quantity - batch.ReservedQuantity;

                        // For now, assuming batch.Quantity is the available quantity in that batch
                        var quantityToDeductFromBatch = Math.Min(remainingQuantity, batch.Quantity);

                        totalprice1 += (quantityToDeductFromBatch * batch.Price * batch.excrate); // Accumulate total price

                        remainingQuantity -= quantityToDeductFromBatch; // Reduce remaining quantity needed
                    }

                    // transaction.Commit(); // You're not modifying data here, so commit is not strictly needed for this calculation endpoint.
                    // If you were to deduct inventory in this same endpoint, you'd commit here.

                    // --- IMPORTANT CHANGE HERE ---
                    // Return the calculated totalprice1 in an anonymous object
                    return Ok(new { TotalPrice = totalprice1 });
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Rollback if an error occurs
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }






        [HttpPost("CalculatetotalPOitemprice")]
        public IActionResult CalculatetotalPOitemprice([FromBody] DeductInventoryRequestPO request)
        {
            decimal totalprice1 = 0;
            using (var transaction = dbcontext.Database.BeginTransaction())
            {
                try

                {
                    var batches = new List<Batch2>();
                    var remainingQuantity = request.qty;
                    var inventoryItems = (from inv in dbcontext.Inventory
                                          .Include(i => i.Currency)
                                          join jj in dbcontext.Job on inv.jobid equals jj.Jobid
                                          join jy in dbcontext.JobType on jj.jobtypeid equals jy.jobtypeid
                                          join ci in dbcontext.Currency on inv.invcurrencyid equals ci.currencyid
                                          where jj.Jobid == request.jobid && inv.productid == request.ItemId
                                          orderby inv.Entrydate // Ensures FIFO ordering
                                          select inv).ToList();

                    foreach (var item in inventoryItems)
                    {
                        // Assuming 'Batch' constructor or properties correctly map these fields
                        // Make sure your 'Inventory' entity has 'quantity', 'invprice', 'reservedqty' (if applicable)
                        // If you have a 'reservedqty' in your Inventory model, you should deduct it here:
                        // var availableQuantity = item.quantity - item.reservedqty; // <--- IMPORTANT if you have reserved quantity
                        // batches.Add(new Batch(item.batchid, availableQuantity, item.invid, item.invcurrencyid, item.uomid, item.invprice));

                        // Based on your previous context, let's assume 'item.quantity' directly means available for calculation
                        // If 'reservedqty' is a field in your Inventory model, adjust this line:
                        batches.Add(new Batch2(item.batchid, item.quantity, item.invid, item.invcurrencyid, item.uomid, item.invprice, (decimal)(item.Currency?.exchangerate ?? 1)));
                    }

                    foreach (var batch in batches)
                    {
                        if (remainingQuantity <= 0) break;

                        // Adjust batch.Quantity if you have reservedqty in your 'Batch' or 'Inventory' model
                        // For example, if Batch also has a ReservedQuantity property:
                        // var currentBatchAvailableQuantity = batch.Quantity - batch.ReservedQuantity;

                        // For now, assuming batch.Quantity is the available quantity in that batch
                        var quantityToDeductFromBatch = Math.Min(remainingQuantity, batch.Quantity);

                        totalprice1 += (quantityToDeductFromBatch * batch.Price * batch.excrate); // Accumulate total price

                        remainingQuantity -= quantityToDeductFromBatch; // Reduce remaining quantity needed
                    }

                    // transaction.Commit(); // You're not modifying data here, so commit is not strictly needed for this calculation endpoint.
                    // If you were to deduct inventory in this same endpoint, you'd commit here.

                    // --- IMPORTANT CHANGE HERE ---
                    // Return the calculated totalprice1 in an anonymous object
                    return Ok(new { TotalPrice = totalprice1 });
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Rollback if an error occurs
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }

            }
        }




        [HttpPost("Calculatetotalissuereturnprice")]
        public IActionResult Calculatetotalissuereturnprice([FromBody] DeductInventoryRequestPO request)
        {
            decimal totalprice1 = 0;
            using (var transaction = dbcontext.Database.BeginTransaction())
            {
                try

                {
                    var batches = new List<Batch3>();
                    var remainingQuantity = request.qty;
                    var inventoryItems = (from inv in dbcontext.Issuetracking
                                          .Include(i => i.currency)
                                          join jj in dbcontext.Job on inv.jobid equals jj.Jobid

                                          join ci in dbcontext.Currency on inv.issuecurrencyid equals ci.currencyid
                                          where jj.Jobid == request.jobid && inv.productid == request.ItemId
                                          orderby inv.issuedate // Ensures FIFO ordering
                                          select inv).ToList();

                    foreach (var item in inventoryItems)
                    {
                        // Assuming 'Batch' constructor or properties correctly map these fields
                        // Make sure your 'Inventory' entity has 'quantity', 'invprice', 'reservedqty' (if applicable)
                        // If you have a 'reservedqty' in your Inventory model, you should deduct it here:
                        // var availableQuantity = item.quantity - item.reservedqty; // <--- IMPORTANT if you have reserved quantity
                        // batches.Add(new Batch(item.batchid, availableQuantity, item.invid, item.invcurrencyid, item.uomid, item.invprice));

                        // Based on your previous context, let's assume 'item.quantity' directly means available for calculation
                        // If 'reservedqty' is a field in your Inventory model, adjust this line:
                        batches.Add(new Batch3(0, item.issueqty, item.invid, item.issuecurrencyid, item.issueuomid, item.issueunitprice, (decimal)(item.currency?.exchangerate ?? 1)));
                    }

                    foreach (var batch in batches)
                    {
                        if (remainingQuantity <= 0) break;

                        // Adjust batch.Quantity if you have reservedqty in your 'Batch' or 'Inventory' model
                        // For example, if Batch also has a ReservedQuantity property:
                        // var currentBatchAvailableQuantity = batch.Quantity - batch.ReservedQuantity;

                        // For now, assuming batch.Quantity is the available quantity in that batch
                        var quantityToDeductFromBatch = Math.Min(remainingQuantity, batch.Quantity);

                        totalprice1 += (quantityToDeductFromBatch * batch.Price * batch.excrate); // Accumulate total price

                        remainingQuantity -= quantityToDeductFromBatch; // Reduce remaining quantity needed
                    }

                    // transaction.Commit(); // You're not modifying data here, so commit is not strictly needed for this calculation endpoint.
                    // If you were to deduct inventory in this same endpoint, you'd commit here.

                    // --- IMPORTANT CHANGE HERE ---
                    // Return the calculated totalprice1 in an anonymous object
                    return Ok(new { TotalPrice = totalprice1 });
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Rollback if an error occurs
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }

            }
        }













        [HttpGet("GetListConsumableIssuenoteheader")]
        public async Task<IActionResult> GetListConsumableIssuenoteheader()

        {
            try
            {

                var issueheader = await dbcontext.IssueNoteheader
              .Where(po => po.issuetype == "Consumables")
              .ToListAsync();
                if (issueheader == null)
                {
                    return NotFound();
                }
                return Ok(issueheader);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }






        [HttpGet("GetListstockIssuenoteheader")]
        public async Task<IActionResult> GetListstockIssuenoteheader()

        {
            try
            {

                var issueheader = await dbcontext.IssueNoteheader
              .Where(po => po.issuetype == "Stock")
              .ToListAsync();
                if (issueheader == null)
                {
                    return NotFound();
                }
                return Ok(issueheader);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }






        [HttpPost("addorupdatedeliverydetails")]
        public async Task<IActionResult> addorupdatedeliverydetails(Addorupdatedeliverydetails dto)
        {
            using (var transaction = await dbcontext.Database.BeginTransactionAsync()) // Start a transaction
            {
                try
                {


                    // Find existing received entry
                    var existingEntry = await dbcontext.DeliveryNote
                        .FirstOrDefaultAsync(e => e.deliveryno == dto.deliveryno);

                    if (existingEntry != null)
                    {
                        // Update existing entry
                        existingEntry.deliveryno = dto.deliveryno;
                        existingEntry.deliverydate = dto.deliverydate;
                        existingEntry.buyerid = dto.buyerid;
                        existingEntry.buyerdeliveryaddress = dto.buyerdeliveryaddress;
                        existingEntry.buyertrnno = dto.buyertrnno;
                        existingEntry.buyeriec = dto.buyeriec;
                        existingEntry.buyercontactid = dto.buyercontactid;
                        existingEntry.jobid = dto.jobid;
                        existingEntry.buyerlpono = dto.buyerlpono;
                        existingEntry.buyerlpodate = dto.buyerlpodate;
                        existingEntry.consigneename = dto.consigneename;
                        existingEntry.consigneeaddress = dto.consigneeaddress;
                        existingEntry.consigneelpono = dto.consigneelpono;
                        existingEntry.consigneelpodate = dto.consigneelpodate;
                        existingEntry.consigneetrnno = dto.consigneetrnno;
                        existingEntry.consigneeiec = dto.consigneeiec;
                        existingEntry.vehicleno = dto.vehicleno;
                        existingEntry.receivedby = dto.receivedby;
                        existingEntry.deliveredby = dto.deliveredby;
                        dbcontext.DeliveryNote.Update(existingEntry);
                    }
                    else
                    {
                        // Create a new received entry
                        existingEntry = new DeliveryNote
                        {
                            deliveryno = dto.deliveryno,
                            deliverydate = dto.deliverydate,
                            buyerid = dto.buyerid,
                            buyerdeliveryaddress = dto.buyerdeliveryaddress,
                            buyertrnno = dto.buyertrnno,
                            buyeriec = dto.buyeriec,
                            buyercontactid = dto.buyercontactid,
                            jobid = dto.jobid,
                            buyerlpono = dto.buyerlpono,
                            buyerlpodate = dto.buyerlpodate,

                            consigneename = dto.consigneename,
                            consigneeaddress = dto.consigneeaddress,
                            consigneelpono = dto.consigneelpono,
                            consigneelpodate = dto.consigneelpodate,

                            consigneetrnno = dto.consigneetrnno,
                            consigneeiec = dto.consigneeiec,
                            vehicleno = dto.vehicleno,

                            receivedby = dto.receivedby,
                            deliveredby = dto.deliveredby,

                        };

                        await dbcontext.DeliveryNote.AddAsync(existingEntry);
                    }

                    await dbcontext.SaveChangesAsync(); // Save received entry

                    foreach (var item in dto.deliverydetails)
                    {
                        if (item.did > 0)
                        {
                            // Update existing detail if rtblid exists
                            var existingDetail = await dbcontext.deliverydetails
                                .FirstOrDefaultAsync(d => d.did == item.did);

                            if (existingDetail != null)
                            {
                                existingDetail.deliveryid = item.deliveryid;
                                existingDetail.uom = item.uom;
                                existingDetail.qty = item.qty;

                                existingDetail.remarks = item.remarks;
                                existingDetail.description = item.description;
                                existingDetail.counter = item.counter;
                                existingDetail.srno = item.srno;

                                dbcontext.deliverydetails.Update(existingDetail);
                            }
                        }
                        else
                        {
                            // Insert new detail if rtblid doesn't exist
                            var newDetail = new deliverydetails
                            {
                                deliveryid = item.deliveryid,
                                uom = item.uom,
                                qty = item.qty,
                                description = item.description,
                                remarks = item.remarks,
                                counter = item.counter,
                                srno = item.srno

                            };

                            await dbcontext.deliverydetails.AddAsync(newDetail);
                        }
                    }
                    await dbcontext.SaveChangesAsync(); // Save received entry details
                    await transaction.CommitAsync(); // Commit transaction if everything succeeds
                    return Ok(new { Message = "Invoice Entry and details saved successfully.", invoiceno = existingEntry.deliveryno });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(); // Rollback transaction on failure

                    return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
                }


            }
        }






        [HttpGet("GetAllDeliverydetailsbydeliveryno")]
        public async Task<IActionResult> GetAllDeliverydetailsbydeliveryno(int deliveryno)
        {

            try
            {

                var deliverydetails = await dbcontext.deliverydetails
              .Where(po => po.deliveryid == deliveryno)
                  .OrderBy(po => po.counter)
              .ToListAsync();
                if (deliverydetails == null)
                {
                    return NotFound();
                }
                return Ok(deliverydetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            };
        }






        [HttpGet("GetStandardUomNameFromProductId")]
        public async Task<ActionResult<string>> GetStandardUomNameFromProductId(int productcode)
        {
            // 1. Find the Product by productid
            // 2. Eagerly load the related Uom entity using Include()
            // 3. Select the uomname from the loaded Uom entity

            var uomName = await dbcontext.Product
                .Where(p => p.productcode == productcode) // Assuming 'ProductId' is the property name in your Product entity
                .Select(p => p.UOM.uomname) // Assuming 'StandardUom' is the navigation property to Uom and 'UomName' is the property in Uom entity
                .FirstOrDefaultAsync();

            if (uomName == null)
            {
                return NotFound($"No standard UOM found for Product ID: {productcode}");
            }

            return Ok(uomName);
        }






        [HttpPost("addpreferreduom")]
        public async Task<IActionResult> addpreferreduom(AddPreferreduomdto request)
        {
            try
            {
                // Check if a job with the same Jobid already exists
                var existinguom = await dbcontext.Preferreduomperproducts
     .FirstOrDefaultAsync(j => j.itemcode == request.productcode && j.prefuomid == request.prefuomid);

                if (existinguom != null)
                {

                }
                else
                {
                    // If the job does not exist, create a new one
                    var preferreduomdetails = new Preferreduomperproducts
                    {
                        itemcode = request.productcode,
                        prefuomid = request.prefuomid,
                        multiplyfactor = request.multiplyingfactor


                    };

                    await dbcontext.Preferreduomperproducts.AddAsync(preferreduomdetails);
                }

                // Save changes
                await dbcontext.SaveChangesAsync();

                // Prepare the response DTO
                return Ok(new { Message = "Preferred UOM  details saved successfully." });
            }
            catch (Exception ex)
            {
                // Log the exception (consider using ILogger for better logging)
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }








        [HttpGet("listpreferreduom")]
        public async Task<IActionResult> ListPreferredUom() // Renamed method for PascalCase convention
        {
            try
            {
                // Using LINQ Join syntax to explicitly join Preferreduomperproducts with Product
                var listPreferredUom = await (from preferredUomProduct in dbcontext.Preferreduomperproducts
                                              join product in dbcontext.Product
                                              on preferredUomProduct.itemcode equals product.productcode // <-- **IMPORTANT: Adjust these property names**
                                              join standuom in dbcontext.UOM
                                              on product.standarduomid equals standuom.uomid                                                           // preferredUomProduct.ProductId should be the FK in Preferreduomperproduct
                                              join prefuom in dbcontext.UOM
                                          on preferredUomProduct.prefuomid equals prefuom.uomid                                                                                                                       // product.ProductId should be the PK in Product
                                              select new
                                              {
                                                  pid = preferredUomProduct.pid,
                                                  productcode = product.productcode,
                                                  itemname = product.itemname,
                                                  multiplyingfactor = preferredUomProduct.multiplyfactor,
                                                  standarduom = standuom.uomname,
                                                  preferreduom = prefuom.uomname


                                              })
                                              .ToListAsync();

                if (listPreferredUom == null || !listPreferredUom.Any()) // Check if the list is empty
                {
                    return NotFound("No preferred UOM products found.");
                }

                return Ok(listPreferredUom);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes (e.g., using ILogger)
                Console.WriteLine($"Error in ListPreferredUom: {ex.Message}");
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }
        public class uomlist
        {
            public int uomid { get; set; }
            public string uomname { get; set; }
        }

        [HttpGet("getPreferreduombyproductid/{productid}")]

        public async Task<ActionResult<List<uomlist>>> getPreferreduombyproductid(int productid)
        {
            var ulist = new List<uomlist>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sP_GetPreferreduombyuomid", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // No parameters are needed for this stored procedure
                    cmd.Parameters.AddWithValue("@productcode", productid);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ulist.Add(new uomlist
                            {
                                uomid = reader.GetInt32(reader.GetOrdinal("uomid")),
                                uomname = reader["uomname"].ToString(),

                            });
                        }
                    }
                }
            }

            if (ulist.Count == 0)
            {
                return NotFound("No pending PR items found.");
            }

            return Ok(ulist);
        }










        public class Pendinggrn
        {
            public int productcode { get; set; }
            public decimal poquantity { get; set; }
            public int productuomid { get; set; }
            public int pouomid { get; set; }

            public string itemname { get; set; }
            public string purchaseuomname { get; set; }
            public string productuomname { get; set; }
            public decimal inspacceptedqty { get; set; }

            public decimal grncreatedqty { get; set; }


            public int orderid { get; set; }

            public decimal multiplyfactor { get; set; }
            public decimal pounitprice { get; set; }
            public string location { get; set; }

        }



        [HttpGet("GetPendingPurchasedetailsbyponosrv1")]
        public async Task<ActionResult<List<Pendinggrn>>> GetPendingPurchasedetailsbyponosrv1(int pono)
        {
            var budgetSummaries = new List<Pendinggrn>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("GetPendingPurchasedetailsbyponos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pono", pono);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            budgetSummaries.Add(new Pendinggrn
                            {

                                productcode = reader.GetInt32(reader.GetOrdinal("productcode")),
                                poquantity = reader.GetDecimal(reader.GetOrdinal("poquantity")),
                                productuomid = reader.GetInt32(reader.GetOrdinal("productuomid")),
                                pouomid = reader.GetInt32(reader.GetOrdinal("pouomid")),
                                itemname = reader.GetString(reader.GetOrdinal("itemname")),
                                purchaseuomname = reader["purchaseuomname"].ToString(),
                                productuomname = reader["productuomname"].ToString(),
                                grncreatedqty = reader.GetDecimal(reader.GetOrdinal("grncreatedqty")),
                                inspacceptedqty = reader.GetDecimal(reader.GetOrdinal("inspacceptedqty")),
                                orderid = reader.GetInt32(reader.GetOrdinal("orderid")),
                                multiplyfactor = reader.GetDecimal(reader.GetOrdinal("multiplyfactor")),
                                pounitprice = reader.GetDecimal(reader.GetOrdinal("pounitprice")),



                            });
                        }
                    }
                }
            }

            if (budgetSummaries.Count == 0)
            {
                return NotFound("No data found for the provided jobId.");
            }

            return Ok(budgetSummaries);
        }




        [HttpGet("GetPendingPurchasedetailsbyponoeditgrn")]
        public async Task<ActionResult<List<Pendinggrn>>> GetPendingPurchasedetailsbyponoeditgrn(int grnno, int orderid)
        {
            var budgetSummaries = new List<Pendinggrn>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("GetPendingPurchasedetailsbyponosineditgrn", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pono", orderid);
                    cmd.Parameters.AddWithValue("@grnno", grnno);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            budgetSummaries.Add(new Pendinggrn
                            {
                                productcode = reader.GetInt32(reader.GetOrdinal("productcode")),
                                poquantity = reader.GetDecimal(reader.GetOrdinal("poquantity")),
                                productuomid = reader.GetInt32(reader.GetOrdinal("productuomid")),
                                pouomid = reader.GetInt32(reader.GetOrdinal("pouomid")),
                                itemname = reader.GetString(reader.GetOrdinal("itemname")),
                                purchaseuomname = reader["purchaseuomname"].ToString(),
                                productuomname = reader["productuomname"].ToString(),
                                grncreatedqty = reader.GetDecimal(reader.GetOrdinal("grncreatedqty")),
                                inspacceptedqty = reader.GetDecimal(reader.GetOrdinal("inspacceptedqty")),
                                orderid = reader.GetInt32(reader.GetOrdinal("orderid")),
                                multiplyfactor = reader.GetDecimal(reader.GetOrdinal("multiplyfactor")),
                                pounitprice = reader.GetDecimal(reader.GetOrdinal("pounitprice")),



                            });
                        }
                    }
                }
            }

            if (budgetSummaries.Count == 0)
            {
                return NotFound("No data found for the provided jobId.");
            }

            return Ok(budgetSummaries);
        }





        public class consumablesissuedetails
        {
            public int issuenoteref { get; set; }
            public int issuedetailid { get; set; }
            public decimal issueqty { get; set; }
            public decimal issueunitprice { get; set; }
            public DateTime issuedate { get; set; }
            public int jobid { get; set; }
            public string remarks { get; set; }
            public string issuedto { get; set; }
            public int isregistered { get; set; }
            public string issuetype { get; set; }
            public string itemname { get; set; }

            public int productcode { get; set; }
        }


        [HttpGet("Getconsumableissuenotedetailsreport")]
        public async Task<ActionResult<List<consumablesissuedetails>>> Getconsumableissuenotedetailsreport()
        {
            var consumablesissuedetails = new List<consumablesissuedetails>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("GetConsumableIssueDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            consumablesissuedetails.Add(new consumablesissuedetails
                            {
                                itemname = reader["itemname"].ToString(),
                                issuenoteref = reader.GetInt32(reader.GetOrdinal("issuenoteref")),
                                jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                issueunitprice = reader.GetDecimal(reader.GetOrdinal("issueunitprice")),
                                issueqty = reader.GetDecimal(reader.GetOrdinal("issueqty")),
                                remarks = reader["remarks"].ToString(),
                                issuedate = reader.GetDateTime(reader.GetOrdinal("issuedate")),
                                productcode = reader.GetInt32(reader.GetOrdinal("productcode")),


                            }); ;
                        }
                    }
                }
            }

            if (consumablesissuedetails.Count == 0)
            {
                return NotFound("No data found for the provided jobId.");
            }

            return Ok(consumablesissuedetails);
        }


        [HttpGet("Getpoissuenotedetailsreport")]
        public async Task<ActionResult<List<consumablesissuedetails>>> Getpoissuenotedetailsreport()
        {
            var consumablesissuedetails = new List<consumablesissuedetails>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("GetPOIssueDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            consumablesissuedetails.Add(new consumablesissuedetails
                            {
                                itemname = reader["itemname"].ToString(),
                                issuenoteref = reader.GetInt32(reader.GetOrdinal("issuenoteref")),
                                jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                issueunitprice = reader.GetDecimal(reader.GetOrdinal("issueunitprice")),
                                issueqty = reader.GetDecimal(reader.GetOrdinal("issueqty")),
                                remarks = reader["remarks"].ToString(),
                                issuedate = reader.GetDateTime(reader.GetOrdinal("issuedate")),
                                productcode = reader.GetInt32(reader.GetOrdinal("productcode")),

                            }); ;
                        }
                    }
                }
            }

            if (consumablesissuedetails.Count == 0)
            {
                return NotFound("No data found for the provided jobId.");
            }

            return Ok(consumablesissuedetails);
        }



        public class InventoryAsOfDateItemwise
        {

            public string itemname { get; set; }
            public decimal inventory { get; set; }
            public decimal price { get; set; }
            public string uom { get; set; }
            public string currency { get; set; }
            public decimal rate { get; set; }
            public string budgetheadername { get; set; }
            public string categoryname { get; set; }
            public string subcategoryname { get; set; }
            public int invid { get; set; }

            public int budgetheaderid { get; set; }

        }

        [HttpGet("GetInventoryAsOfDateItemwiserv1")]
        public async Task<ActionResult<List<InventoryAsOfDateItemwise>>> GetInventoryAsOfDateItemwiserv1(DateTime targetDate)
        {
            var InventoryAsOfDateItemwise = new List<InventoryAsOfDateItemwise>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("GetInventoryAsOfDateItemwise", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@targetDate", targetDate);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            InventoryAsOfDateItemwise.Add(new InventoryAsOfDateItemwise
                            {

                                invid = reader.GetOrdinal("invid"),
                                itemname = reader["itemname"].ToString(),
                                uom = reader["uom"].ToString(),
                                currency = reader["currency"].ToString(),
                                budgetheadername = reader["budgetheadername"].ToString(),
                                categoryname = reader["categoryname"].ToString(),
                                subcategoryname = reader["subcategoryname"].ToString(),

                                inventory = reader.GetDecimal(reader.GetOrdinal("inventory")),
                                price = reader.GetDecimal(reader.GetOrdinal("price")),

                                budgetheaderid = reader.GetInt32(reader.GetOrdinal("budgetheaderid")),

                            });
                        }
                    }
                }
            }

            if (InventoryAsOfDateItemwise.Count == 0)
            {
                return NotFound("No data found for the provided jobId.");
            }

            return Ok(InventoryAsOfDateItemwise);
        }











        public class IssuedItems
        {
            public int productcode { get; set; }
            public string itemname { get; set; }
            public decimal totalissuedqty { get; set; }
            public decimal totalretunedqty { get; set; }
            public decimal maxpossiblereturnqty { get; set; }
        }



        [HttpGet("GetIssueItemSummaryByJob")]

        public async Task<ActionResult<List<IssuedItems>>> GetIssueItemSummaryByJob(int jobid)
        {
            var ulist = new List<IssuedItems>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("GetIssueItemSummaryByJob", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // No parameters are needed for this stored procedure
                    cmd.Parameters.AddWithValue("@jobid", jobid);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ulist.Add(new IssuedItems
                            {
                                productcode = reader.GetInt32(reader.GetOrdinal("productcode")),
                                itemname = reader["itemname"].ToString(),
                                totalissuedqty = reader.GetDecimal(reader.GetOrdinal("totalissuedqty")),
                                totalretunedqty = reader.GetDecimal(reader.GetOrdinal("TotalReturnedQty")),
                                maxpossiblereturnqty = reader.GetDecimal(reader.GetOrdinal("maxpossiblereturnqty")),

                            });
                        }
                    }
                }
            }

            if (ulist.Count == 0)
            {
                return NotFound("No pending PR items found.");
            }

            return Ok(ulist);
        }

        public class AddorupdatePOissuereturndetails
        {

            public int issuereturnref { get; set; }

            public int jobid { get; set; }
            public DateTime returndate { get; set; }
            public string Remarks { get; set; }
            public ICollection<AddPOIssuereturndetails> issuereturndetails { get; set; }



        }


        public class AddPOIssuereturndetails
        {

            public int productcode { get; set; }
            public decimal returnqty { get; set; }
            public decimal issuereturnunitprice { get; set; }
            public string? location { get; set; }




        }




        //[HttpPost("AddorupdatePOissuereturn")]
        //    public async Task<IActionResult> AddorupdatePOissuereturn(AddorupdatePOissuereturndetails dto)
        //    {
        //        try
        //        {
        //            var unregisteredIssueNotes = await dbcontext.Issuereturn
        //  .Where(e => e.isregistered == 0 && e.issuereturnref != dto.issuereturnref && e.jobid == dto.jobid)
        //  .ToListAsync();

        //            if (unregisteredIssueNotes.Any())
        //            {
        //                // Return unregistered Issue Notes in the response and stop further processing
        //                return Ok(new { Message = "UnregisteredIssuereturn" });
        //            }


        //            // Find existing received entry
        //            var existingEntry = await dbcontext.Issuereturn
        //                .FirstOrDefaultAsync(e => e.issuereturnref == dto.issuereturnref);

        //            if (existingEntry != null)
        //            {
        //                // Update existing entry
        //                existingEntry.issuereturnref = dto.issuereturnref;
        //                existingEntry.jobid = dto.jobid;
        //                existingEntry.returndate = dto.returndate;
        //                existingEntry.Remarks = dto.Remarks;

        //                dbcontext.Issuereturn.Update(existingEntry);
        //            }
        //            else
        //            {
        //                // Create a new received entry
        //                existingEntry = new Issuereturn
        //                {
        //                    // Assuming REID is generated elsewhere or provided
        //                    issuereturnref = dto.issuereturnref,
        //                    jobid = dto.jobid,
        //                    returndate = dto.returndate,
        //                    Remarks = dto.Remarks,
        //                };

        //                await dbcontext.Issuereturn.AddAsync(existingEntry);
        //            }

        //            await dbcontext.SaveChangesAsync();

        //            // Insert or update details
        //            foreach (var item in dto.issuereturndetails)
        //            {
        //                var detail = new POissuereturndetails
        //                {
        //                    issuereturnunitprice = item.issuereturnunitprice,
        //                    returnqty = item.returnqty,
        //                    productcode = item.productcode,
        //                    issuereturnref = dto.issuereturnref



        //                };

        //                await dbcontext.POissuereturndetails.AddAsync(detail);


        //          }

        //            await dbcontext.SaveChangesAsync();

        //            return Ok(new { Message = "Issue Return note  entry and details saved successfully." });
        //        }
        //        catch (Exception ex)
        //        {
        //            // Log the error for debugging purposes
        //            // Log.Error(ex, "An error occurred while processing the received entry details.");

        //            // Return a generic error message to the client
        //            return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
        //        }





        //    }

        [HttpPost("AddorupdatePOissuereturn")]
        public async Task<IActionResult> AddorupdatePOissuereturn([FromBody] AddorupdatePOissuereturndetails dto)
        {
            // Start a database transaction to ensure all operations are atomic
            // If any step fails, the entire transaction will be rolled back.
            using (var transaction = await dbcontext.Database.BeginTransactionAsync())
            {
                try
                {
                    // 1. Check for unregistered Issue Notes (Header Level Validation)
                    var unregisteredIssueNotes = await dbcontext.Issuereturn
          .Where(e => e.isregistered == 0 && e.issuereturnref != dto.issuereturnref && e.jobid == dto.jobid)
          .ToListAsync();

                    if (unregisteredIssueNotes.Any())
                    {
                        // Return unregistered Issue Notes in the response and stop further processing
                        return Ok(new { Message = "UnregisteredIssuereturn" });
                    }


                    // Find existing received entry
                    var existingEntry = await dbcontext.Issuereturn
                        .FirstOrDefaultAsync(e => e.issuereturnref == dto.issuereturnref);

                    if (existingEntry != null)
                    {
                        // Update existing entry
                        existingEntry.issuereturnref = dto.issuereturnref;
                        existingEntry.jobid = dto.jobid;
                        existingEntry.returndate = dto.returndate;
                        existingEntry.Remarks = dto.Remarks;
                        existingEntry.issuereturntype = "PO";
                        dbcontext.Issuereturn.Update(existingEntry);
                    }
                    else
                    {
                        // Create a new received entry
                        existingEntry = new Issuereturn
                        {
                            // Assuming REID is generated elsewhere or provided
                            issuereturnref = dto.issuereturnref,
                            jobid = dto.jobid,
                            returndate = dto.returndate,
                            Remarks = dto.Remarks,
                            issuereturntype = "PO",

                        };

                        await dbcontext.Issuereturn.AddAsync(existingEntry);
                    }

                    await dbcontext.SaveChangesAsync();

                    // Get the actual issuereturnref (either existing or newly generated)
                    int currentIssuereturnRef = existingEntry.issuereturnref;

                    // 3. Process PO Issue Return Details (Add new details, link to IssueTracking, update IssueTracking)
                    // For existing details, you would typically fetch them and handle updates/deletions.
                    // This example focuses on adding new details and their links.
                    foreach (var itemDto in dto.issuereturndetails)
                    {
                        // Create a new POissuereturndetails entity
                        var detailEntity = new POissuereturndetails
                        {
                            issuereturnref = currentIssuereturnRef, // Link to the current header
                            productcode = itemDto.productcode,
                            returnqty = itemDto.returnqty,
                            issuereturnunitprice = itemDto.issuereturnunitprice,
                            location = itemDto.location
                        };

                        await dbcontext.POissuereturndetails.AddAsync(detailEntity);

                        // Save changes to get the auto-generated issuereturndetailid for the new detail line.
                        // This is important because the linking table needs this ID.
                        await dbcontext.SaveChangesAsync();

                        int newDetailId = detailEntity.issuereturndetailid;
                        decimal remainingReturnQty = itemDto.returnqty;

                        // 4. Distribute return quantity and create links to issuetracking
                        // Find outstanding issued items for this product, ordered by issue date (FIFO)
                        var outstandingIssueItems = await dbcontext.Issuetracking
                            .Where(it => it.productid == itemDto.productcode && it.issueqty > it.totalreturnedqty && it.jobid == dto.jobid)
                            .OrderBy(it => it.issuedate) // Assuming 'issuedate' is the column for chronological order
                            .ToListAsync();

                        foreach (var issueItem in outstandingIssueItems)
                        {
                            if (remainingReturnQty <= 0) break; // No more quantity to apply

                            decimal pendingQtyInThisIssue = issueItem.issueqty - issueItem.totalreturnedqty;
                            decimal qtyToApplyToThisIssue = Math.Min(remainingReturnQty, pendingQtyInThisIssue);

                            if (qtyToApplyToThisIssue > 0)
                            {
                                // Update totalreturnedqty in the original issuetracking record
                                issueItem.totalreturnedqty += qtyToApplyToThisIssue;
                                dbcontext.Issuetracking.Update(issueItem); // Mark entity as modified

                                // Create a link in the POIssueReturnDetailIssueTracking table
                                var linkingEntry = new POIssueReturnDetailIssueTracking
                                {
                                    issuereturndetailid = newDetailId,
                                    issuetrackid = issueItem.issuetrackid
                                    // If your linking table has a quantity column for the link, add it here:
                                    // LinkedQty = qtyToApplyToThisIssue
                                };
                                await dbcontext.POIssueReturnDetailIssueTracking.AddAsync(linkingEntry);

                                remainingReturnQty -= qtyToApplyToThisIssue;
                            }
                        }

                        // Optional: Handle cases where return quantity exceeds total outstanding
                        if (remainingReturnQty > 0)
                        {
                            // You might want to log this or adjust the return quantity to match outstanding
                            Console.WriteLine($"Warning: Return quantity for product {itemDto.productcode} exceeded outstanding issues by {remainingReturnQty}.");
                            // Depending on business rules, you could:
                            // 1. Throw an exception
                            // 2. Adjust detailEntity.returnqty to (itemDto.returnqty - remainingReturnQty)
                            // 3. Allow it, but log a warning.
                        }
                    }

                    // Save all changes made within the loop (updates to IssueTrackings and additions to linking table)
                    await dbcontext.SaveChangesAsync();

                    // Commit the transaction if all operations were successful
                    await transaction.CommitAsync();

                    return Ok(new { Message = "Issue Return note entry and details saved successfully.", IssuereturnRef = currentIssuereturnRef });
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if any error occurs
                    await transaction.RollbackAsync();
                    Console.Error.WriteLine($"Error in AddorupdatePOissuereturn: {ex.Message}");
                    Console.Error.WriteLine($"Stack Trace: {ex.StackTrace}");
                    // In a real application, use a proper logging framework (e.g., Serilog, NLog)
                    // Log.Error(ex, "An error occurred while processing the PO issue return.");

                    return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
                }
            }
        }


        public class listPOissuereturndetails
        {

            public int issuereturnref { get; set; }
            public int productcode { get; set; }
            public string itemname { get; set; }
            public decimal returnqty { get; set; }
            public decimal issuereturnunitprice { get; set; }
            public string location { get; set; }

        }




        [HttpGet("GetPOissuereturndetails")]
        public async Task<ActionResult<List<listPOissuereturndetails>>> GetPOissuereturndetails(int issuereturnref)
        {
            var prPendingList = new List<listPOissuereturndetails>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("SP_GetPOIssuereturndetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@issuereturnrefno", issuereturnref);
                    // No parameters are needed for this stored procedure

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            prPendingList.Add(new listPOissuereturndetails
                            {
                                issuereturnref = reader.GetInt32(reader.GetOrdinal("issuereturnref")),
                                productcode = reader.GetInt32(reader.GetOrdinal("productcode")),
                                itemname = reader["itemname"].ToString(),
                                returnqty = reader.GetDecimal(reader.GetOrdinal("returnqty")),
                                issuereturnunitprice = reader.GetDecimal(reader.GetOrdinal("issuereturnunitprice")),
                                location = reader["location"].ToString()

                            });
                        }
                    }
                }
            }

            if (prPendingList.Count == 0)
            {
                return NotFound("No pending PR items found.");
            }

            return Ok(prPendingList);
        }






        public class POissuereturnheader
        {

            public int issuereturnref { get; set; }
            public DateTime returndate { get; set; }
            public int jobid { get; set; }
            public string remarks { get; set; }

            public int isregistered { get; set; }

        }




        [HttpGet("GetPOissuereturnheader")]
        public async Task<ActionResult<List<POissuereturnheader>>> GetPOissuereturnheader(int issuereturnref)
        {
            var prPendingList = new List<POissuereturnheader>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("SP_GetPOissuereturnheader", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@issuereturnrefno", issuereturnref);
                    // No parameters are needed for this stored procedure

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            prPendingList.Add(new POissuereturnheader
                            {
                                issuereturnref = reader.GetInt32(reader.GetOrdinal("issuereturnref")),
                                jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                remarks = reader["remarks"].ToString(),
                                returndate = reader.GetDateTime(reader.GetOrdinal("returndate")), // Retrieve the DateTime value
                                isregistered = reader.GetInt32(reader.GetOrdinal("isregistered")),

                            });
                        }
                    }
                }
            }

            if (prPendingList.Count == 0)
            {
                return NotFound("No pending PR items found.");
            }

            return Ok(prPendingList);
        }

        public class stockledger
        {

            public DateTime transactiondate { get; set; }
            public string transactiontype { get; set; }
            public int jobid { get; set; }
            public int? referenceno { get; set; }
            public decimal QuantityIn { get; set; }
            public decimal QuantityOut { get; set; }
            public decimal UnitCost { get; set; }
            public decimal TotalValueIn { get; set; }
            public decimal TotalValueOut { get; set; }

            public string? BillOfEntryNo { get; set; }

            public DateTime? BillOfEntryDate { get; set; }

            public decimal RunningBalance { get; set; }

            public int productcode { get; set; }


        }
        public class ItemNameDto
        {
            public string ItemName { get; set; }
        }

        [HttpGet("GetItemnamefromItemcode/{productcode}")] // Matches your Angular URL: /api/Inventory/GetItemnamefromItemcode/123
        public async Task<ActionResult<List<ItemNameDto>>> GetItemnamefromItemcode(int productcode)
        {
            if (productcode <= 0)
            {
                return BadRequest("Invalid product code.");
            }

            try
            {
                // Use Entity Framework Core to query the Item/Product table
                // This will execute a SELECT statement like:
                // SELECT ItemName FROM Items WHERE ProductId = @productcode
                var itemName = await dbcontext.Product
                                             .Where(i => i.productcode == productcode)
                                             .Select(i => new ItemNameDto { ItemName = i.itemname })
                                             .FirstOrDefaultAsync(); // Get the first matching item, or null if not found

                if (itemName == null)
                {
                    return NotFound($"Item name not found for product code: {productcode}");
                }

                // Since your Angular service expects an array (Observable<any[]>),
                // we wrap the single DTO in a List. If your Angular service expects
                // a single object, you can return `Ok(itemName)`.
                return Ok(new List<ItemNameDto> { itemName });
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error fetching item name from item code: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



















        [HttpGet("GetStockLedgerByProductID/{productcode}")]
        public async Task<ActionResult<List<stockledger>>> GetStockLedgerByProductID(int productcode)
        {
            var stockLedgerEntries = new List<stockledger>(); // Renamed 'poHeaders' to be more descriptive

            try // Added try-catch for database operations
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("GetStockLedgerByProductID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProductID", productcode);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                stockLedgerEntries.Add(new stockledger
                                {
                                    // Safe retrieval for each column

                                    // Non-nullable DateTime
                                    transactiondate = reader.GetDateTime(reader.GetOrdinal("TransactionDate")),

                                    // String (handle DBNull for strings, convert to null or empty string)
                                    transactiontype = reader.IsDBNull(reader.GetOrdinal("TransactionType")) ? null : reader.GetString(reader.GetOrdinal("TransactionType")),
                                    referenceno = reader.IsDBNull(reader.GetOrdinal("ReferenceNo")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ReferenceNo")),

                                    // Non-nullable int (or use GetOrdinal and check IsDBNull if it can be nullable)
                                    jobid = reader.GetInt32(reader.GetOrdinal("jobid")), // Use LocationID as aliased in SP
                                    productcode = reader.GetInt32(reader.GetOrdinal("ProductID")),

                                    // Nullable DateTime: Use GetOrdinal and IsDBNull check
                                    BillOfEntryDate = reader.IsDBNull(reader.GetOrdinal("BillOfEntryDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("BillOfEntryDate")),

                                    // String (handle DBNull)
                                    BillOfEntryNo = reader.IsDBNull(reader.GetOrdinal("BillOfEntryNo")) ? null : reader.GetString(reader.GetOrdinal("BillOfEntryNo")),

                                    // Non-nullable decimals
                                    QuantityIn = reader.GetDecimal(reader.GetOrdinal("QuantityIn")),
                                    QuantityOut = reader.GetDecimal(reader.GetOrdinal("QuantityOut")),
                                    UnitCost = reader.GetDecimal(reader.GetOrdinal("UnitCost")),
                                    TotalValueIn = reader.GetDecimal(reader.GetOrdinal("TotalValueIn")),
                                    TotalValueOut = reader.GetDecimal(reader.GetOrdinal("TotalValueOut")),
                                    RunningBalance = reader.GetDecimal(reader.GetOrdinal("RunningBalance"))
                                });
                            }
                        }
                    }
                }

                if (stockLedgerEntries.Count == 0)
                {
                    return NotFound($"No stock ledger entries found for product ID: {productcode}");
                }

                return Ok(stockLedgerEntries);
            }
            catch (SqlException ex)
            {
                // Log specific SQL exceptions (e.g., connection issues, SP errors)
                Console.WriteLine($"SQL Error: {ex.Message} (Error Code: {ex.Number})");
                return StatusCode(500, $"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Catch any other general exceptions
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        [HttpGet("GetPOByIdWithDetails/{orderId}")] // Reverted to original route name for simplicity
        public async Task<ActionResult<PO>> GetPOByIdWithDetails(int orderId)
        {
            try
            {
                // Using .Include() is the standard and most efficient way to eager load related data in Entity Framework Core.
                // It handles the underlying JOIN operation and object materialization automatically.
                var purchaseOrder = await dbcontext.PO
                                                   .Include(po => po.PurchaseDetails) // Eager load the PurchaseDetails
                                                   .FirstOrDefaultAsync(po => po.Orderid == orderId); // Filter by OrderId

                if (purchaseOrder == null)
                {
                    return NotFound($"Purchase Order with OrderId {orderId} not found.");
                }

                return Ok(purchaseOrder);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        [HttpGet("GetPOByIdWithDetailsrv1/{orderId}")]
        public async Task<ActionResult<PO>> GetPOByIdWithDetailsrv1(int orderId)
        {
            try
            {
                // Using a LINQ Join and GroupBy to reconstruct the PO object with its details.
                // This approach explicitly joins POs with Purchasedetails.
                // It's generally less efficient and more complex than .Include() for simple eager loading
                // because it requires manually projecting all PO properties and then collecting
                // the grouped details into the navigation property.
                var purchaseOrder = await (from po in dbcontext.PO
                                           join pd in dbcontext.Purchasedetails on po.Orderid equals pd.orderid into poDetails
                                           where po.Orderid == orderId
                                           select new PO
                                           {
                                               Orderid = po.Orderid,
                                               Podate = po.Podate,
                                               jobid = po.jobid,
                                               createddate = po.createddate,
                                               updateddate = po.updateddate,
                                               pocurrencyid = po.pocurrencyid,
                                               poexchangerate = po.poexchangerate,
                                               createdbyid = po.createdbyid,
                                               modifiedbyid = po.modifiedbyid,
                                               poverifiedbyid = po.poverifiedbyid,
                                               PoAuthorizedbyid = po.PoAuthorizedbyid,
                                               poauthorizedDate = po.poauthorizedDate,
                                               poverifiedDate = po.poverifiedDate,
                                               supplierid = po.supplierid,
                                               supplieraddress = po.supplieraddress,
                                               suppliercontactid = po.suppliercontactid,
                                               Qtnref = po.Qtnref,
                                               Qtndate = po.Qtndate,
                                               suppliertrnno = po.suppliertrnno,
                                               podeliverytermsid = po.podeliverytermsid,
                                               deliverydate = po.deliverydate,
                                               popaymenttermsid = po.popaymenttermsid,
                                               PaymenttermsDaysid = po.PaymenttermsDaysid,
                                               POPaymentterms2id = po.POPaymentterms2id,
                                               Mtcrequired = po.Mtcrequired,
                                               coorequired = po.coorequired,
                                               predispatchinspection = po.predispatchinspection,
                                               warranty = po.warranty,
                                               chineseorgin = po.chineseorgin,
                                               mtcpriortodispatch = po.mtcpriortodispatch,
                                               extendedwarraty3years = po.extendedwarraty3years,
                                               qtnattached = po.qtnattached,
                                               qtnshippingdocs = po.qtnshippingdocs,
                                               approveddrawings = po.approveddrawings,
                                               Others = po.Others,
                                               Remarks = po.Remarks,
                                               postatusid = po.postatusid,
                                               discount = po.discount,
                                               paymenterm1description = po.paymenterm1description,
                                               otherpaymentremarks = po.otherpaymentremarks,
                                               budgetheaderid = po.budgetheaderid,
                                               PurchaseDetails = poDetails.ToList() // Populate the navigation property
                                           }).FirstOrDefaultAsync();

                if (purchaseOrder == null)
                {
                    return NotFound($"Purchase Order with OrderId {orderId} not found.");
                }

                return Ok(purchaseOrder);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


































        public class JobSummaryDto
        {
            public int jobid { get; set; } // Renamed to JobId for clarity in DTO
            public string jobname { get; set; } = string.Empty;
        }


        [HttpGet("GetFilteredJobs")]
        public async Task<ActionResult<IEnumerable<JobSummaryDto>>> GetFilteredJobs(
             [FromQuery] int? customerId,
             [FromQuery] int? jobstageid,
             [FromQuery] int? jobtypeid,
             [FromQuery] string? jobname) // Added jobname parameter
        {
            // Start with all jobs from the database context
            IQueryable<Job> query = dbcontext.Job; // Use IQueryable for deferred execution

            // Apply filters conditionally
            if (customerId.HasValue)
            {
                query = query.Where(j => j.customerid == customerId.Value);
            }

            if (jobstageid.HasValue)
            {
                query = query.Where(j => j.jobstageid == jobstageid.Value);
            }

            if (jobtypeid.HasValue)
            {
                query = query.Where(j => j.jobtypeid == jobtypeid.Value);
            }

            // Apply jobname filter if provided.
            // This searches for the 'jobname' query parameter within the combined job details.
            if (!string.IsNullOrWhiteSpace(jobname))
            {
                string searchLower = jobname.ToLower(); // Convert search term to lowercase once for efficiency
                query = query.Where(j =>
                    j.Jobid.ToString().ToLower().Contains(searchLower) || // Search in JobId (converted to string)
                    j.projectname.ToLower().Contains(searchLower) ||   // Search in ProjectName
                    j.lpono.ToLower().Contains(searchLower) ||         // Search in LpoNo
                    j.jobdescription.ToLower().Contains(searchLower)    // Search in JobDescription
                );
            }

            // Apply the projection to select only the required fields and concatenate jobname
            var jobSummaries = await query
                .Select(j => new JobSummaryDto // Project into the DTO
                {
                    jobid = j.Jobid,

                    // Concatenate the jobname string as required
                    jobname = j.Jobid + " " + j.projectname + " " + j.lpono + " " + j.jobdescription
                })
                .ToListAsync(); // Execute the query and materialize to a list

            // Return the filtered and projected list as an OK (200) response
            return Ok(jobSummaries);
        }




        public class OutstandingInvoiceDto
        {
            public int InvoiceRegId { get; set; }
            public int InvoiceNo { get; set; }
            public string CustomerName { get; set; } // Added for clarity
            public string JobId { get; set; }
            public int CurrencyId { get; set; }
            public decimal InvoiceValue { get; set; }
            public decimal Receipts { get; set; }
            public decimal OutstandingAmount { get; set; }
        }








        [HttpGet("GetOutstandingInvoices")]
        public async Task<IActionResult> GetOutstandingInvoices()
        {
            try
            {
                // 1. Query the Invoice Registration table
                var outstandingInvoices = await dbcontext.InvoiceReg
                    // Optional: Include Customer data for the name
                    .Include(ir => ir.Customer)
                    // 2. Filter: InvoiceValueinbasecurrency - Invoicereceipts > 0
                    .Where(ir => (ir.Invoicevalueinbasecurrency - ir.Invoicereceipts) > 0)
                    // 3. Select and project into the DTO
                    .Select(ir => new OutstandingInvoiceDto
                    {

                        InvoiceNo = ir.invoiceno,
                        // Assuming 'Customer' navigation property is available on InvoiceRegistration
                        CustomerName = ir.Customer.Customername,
                        JobId = ir.jobid.ToString(), // Convert int/long to string if necessary
                        CurrencyId = ir.currencyid,
                        InvoiceValue = ir.Invoicevalue,
                        Receipts = ir.Invoicereceipts,
                        OutstandingAmount = ir.Invoicevalueinbasecurrency - ir.Invoicereceipts
                    })
                    .ToListAsync();

                if (outstandingInvoices == null || !outstandingInvoices.Any())
                {
                    return NotFound(new { Message = "No outstanding invoices found." });
                }

                return Ok(outstandingInvoices);
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(500, new { Message = "An error occurred while fetching the outstanding invoice report.", Error = ex.Message });
            }
        }


        public class CustomerOutstandingSummaryDto
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public int TotalInvoices { get; set; }
            public int TotalUnpaidInvoices { get; set; }
            public decimal TotalPendingAmount { get; set; }
            public int AverageAgingDays { get; set; }
        }



        [HttpGet("GetCustomerOutstandingsummary")]
        public async Task<ActionResult<List<CustomerOutstandingSummaryDto>>> GetCustomerOutstandingSummaryReport()
        {
            var outstandinglist = new List<CustomerOutstandingSummaryDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("GetCustomerOutstandingSummaryReport", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // No parameters are needed for this stored procedure

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            outstandinglist.Add(new CustomerOutstandingSummaryDto
                            {
                                TotalInvoices = reader.GetInt32(reader.GetOrdinal("TotalInvoices")),
                                CustomerName = reader["customername"].ToString(),
                                TotalUnpaidInvoices = reader.GetInt32(reader.GetOrdinal("TotalUnpaidInvoices")),
                                TotalPendingAmount = reader.GetDecimal(reader.GetOrdinal("TotalPendingAmount")),
                                AverageAgingDays = reader.GetInt32(reader.GetOrdinal("AverageAgingDays")),
                                CustomerId= reader.GetInt32(reader.GetOrdinal("customerid")),

                            });
                        }
                    }
                }
            }

            if (outstandinglist.Count == 0)
            {
                return NotFound("No pending PR items found.");
            }

            return Ok(outstandinglist);
        }



        public class Customeroutstandingreportdetails
        {
            public int invoiceno { get; set; }
            public string CustomerName { get; set; }
            public DateTime invoicedate { get; set; }
            public DateTime duedate { get; set; }



            public int period { get; set; }

            public decimal invoicevalueinbasecurrency { get; set; }

            public decimal invoicereceipts { get; set; }
        }













        [HttpGet("GetCustomeroutstandingreportdetails")]
        public async Task<ActionResult<List<Customeroutstandingreportdetails>>> GetCustomeroutstandingreportdetails(int customerid)
        {
            // Use the correct DTO name for the list
            var outstandinglist = new List<Customeroutstandingreportdetails>();

            // Assuming _connectionString is accessible within this class
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_Customeroutstandingreportdetails", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parameter is correctly added
                        cmd.Parameters.AddWithValue("@customerid", customerid);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                // Use the correct DTO name for object instantiation
                                outstandinglist.Add(new Customeroutstandingreportdetails
                                {
                                    invoiceno = reader.GetInt32(reader.GetOrdinal("invoiceno")),
                                    CustomerName = reader["customername"].ToString(),
                                    invoicedate = reader.GetDateTime(reader.GetOrdinal("invoicedate")),
                                    duedate = reader.GetDateTime(reader.GetOrdinal("duedate")),

                                    invoicevalueinbasecurrency = reader.GetDecimal(reader.GetOrdinal("invoicevalueinbasecurrency")),


                                    invoicereceipts = reader.GetDecimal(reader.GetOrdinal("invoicereceipts")),
                                    // Map remaining fields here...
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (ex)
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }

            if (outstandinglist.Count == 0)
            {
                // Updated message to reflect the report context
                return NotFound($"No outstanding report details found for Customer ID: {customerid}.");
            }

            return Ok(outstandinglist);
        }





        [HttpPost("Updatesupplier")]
        public async Task<IActionResult> Updatesupplier(updatesupplierdto request)
        {
            if (request.supplierid <= 0)
            {
                return BadRequest(new { message = "Invalid customer ID for update." });
            }

            var supplier = await dbcontext.Supplier.FindAsync(request.supplierid);
            if (supplier == null)
            {
                return NotFound(new { message = "Customer not found." });
            }

            // Update fields
            supplier.supplieraddress = request.supplieraddress;
            supplier.suppliertrnno = request.suppliertrnno;
            supplier.emailaddress = request.emailaddress;
            supplier.fax = request.fax;
            supplier.phoneno = request.phoneno;
            supplier.remarks = request.remarks;
            supplier.supplierpoboxno = request.supplierpoboxno;
            supplier.webaddress = request.webaddress;


            dbcontext.Supplier.Update(supplier);
            await dbcontext.SaveChangesAsync();

            return Ok(new { message = "Supplier updated successfully." });
        }




        [HttpGet("Getreceiptvoucherbyreceiptid")]
        public async Task<IActionResult> Getreceiptvoucherbyreceiptid(int receiptid)
        {
            try
            {
                var receiptvoucher = await dbcontext.ReceiptVoucher
              .Where(po => po.receiptid == receiptid)
              .FirstOrDefaultAsync();
                if (receiptvoucher == null)
                {
                    return NotFound();
                }
                return Ok(receiptvoucher);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }













        [HttpGet("GetrejectedMIDetails")]
        public async Task<IActionResult> GetrejectedMIDetails()
        {
            var holdlist = await (from mh in dbcontext.Materialinspection
                                  join md in dbcontext.MIdetails on mh.mid equals md.mid
                                  join pr in dbcontext.Product on md.itemid equals pr.productcode
                                  where md.rejectedqty > 0
                                  select new
                                  {
                                      md.mitblid,
                                      mh.mid,
                                      mh.midate,
                                      pr.itemname,
                                      pr.productcode,
                                      md.acceptedqty,
                                      md.rejectedqty,
                                      md.holdqty,
                                      mh.pono
                                  }).ToListAsync();
            return Ok(holdlist);

        }


        [HttpGet("GetrejectedMIDetailsbymino")]
        public async Task<IActionResult> GetrejectedMIDetailsbymino(int mino)
        {
            var rejectedlist = await (from mh in dbcontext.Materialinspection
                                      join md in dbcontext.MIdetails on mh.mid equals md.mid
                                      join pr in dbcontext.Product on md.itemid equals pr.productcode
                                      // *** APPLYING THE FILTERING CONDITION HERE ***
                                      where mh.mid == mino && md.rejectedqty > 0
                                      select new
                                      {
                                          md.mitblid,
                                          mh.mid,
                                          mh.midate,
                                          pr.itemname,
                                          pr.productcode,
                                          md.acceptedqty,
                                          md.rejectedqty,
                                          md.holdqty,
                                          mh.pono
                                      }).ToListAsync();

            return Ok(rejectedlist);
        }






















        [HttpPost("UpdaterejectedMi")] // Route matching Angular service: /api/Mi/po/updateholdmi
        public async Task<IActionResult> UpdaterejectedMi([FromBody] UpdateMiDetailsDtorejected updateDto)
        {
            // Basic validation: Check if the DTO is null or invalid
            if (updateDto == null)
            {
                return BadRequest("Invalid update data provided.");
            }

            // Start a database transaction to ensure atomicity of updates
            using var transaction = await dbcontext.Database.BeginTransactionAsync();
            try
            {
                // 3. Logic to update the MIdetails:
                // Find the existing MI item in the database using its primary key (miTblId).
                // Ensure 'MIdetails' is the correct DbSet name in your DbContext.
                var miItemToUpdate = await dbcontext.MIdetails
                                                     .FirstOrDefaultAsync(m => m.mitblid == updateDto.MiTblId);
                var miheader = await dbcontext.Materialinspection
                                                  .FirstOrDefaultAsync(m => m.mid == updateDto.Mino);

                if (miItemToUpdate == null)
                {
                    // If the MI item is not found, rollback transaction and return 404.
                    await transaction.RollbackAsync();
                    return NotFound($"MI item with ID {updateDto.MiTblId} not found.");
                }

                if (miheader == null)
                {
                    // If the MI item is not found, rollback transaction and return 404.
                    await transaction.RollbackAsync();
                    return NotFound($"MI item with ID {miheader} not found.");
                }

                // Store the pono from MIdetails before updating, as it's needed for PurchaseDetails lookup
                var purchaseOrderNo = miheader.pono;

                // Apply the requested quantity update logic to MIdetails:
                miItemToUpdate.holdqty += updateDto.newHoldQty;
                miItemToUpdate.acceptedqty += updateDto.newacceptedqty;
                // The logic is: current DB HoldQty - original total hold from this MI + new remaining hold for this MI.
                miItemToUpdate.rejectedqty = updateDto.rejectedQty;

                // Ensure quantities do not go below zero (optional, based on your business rules)
                //miItemToUpdate.rejectedqty = Math.Max(0, miItemToUpdate.rejectedqty);
                //miItemToUpdate.acceptedqty = Math.Max(0, miItemToUpdate.acceptedqty);
                //miItemToUpdate.holdqty = Math.Max(0, miItemToUpdate.holdqty);

                // Mark the MIdetails entity as modified
                dbcontext.Entry(miItemToUpdate).State = EntityState.Modified;

                // 4. Logic to update the PurchaseDetails:
                // Find the corresponding PurchaseDetails item using the pono.
                // Ensure 'PurchaseDetails' is the correct DbSet name in your DbContext.
                var purchaseDetailsToUpdate = await dbcontext.Purchasedetails
    // Filter by both the Purchase Order ID (orderid) AND the Item Code
    .FirstOrDefaultAsync(p => p.orderid == purchaseOrderNo && p.poitemid == updateDto.itemcode);

                if (purchaseDetailsToUpdate == null)
                {
                    // If PurchaseDetails is not found, rollback transaction and return 404.
                    await transaction.RollbackAsync();
                    return NotFound($"Purchase Details for PO No. {purchaseOrderNo} not found.");
                }

                purchaseDetailsToUpdate.inspholdqty += updateDto.newHoldQty;
                // Assuming 'inspectedqty' in PurchaseDetails corresponds to total accepted for that PO
                purchaseDetailsToUpdate.inspacceptedqty += updateDto.newacceptedqty;
                // The logic for hold in PurchaseDetails:
                // current DB HoldQty - original total hold from this specific MI + new remaining hold for this specific MI.
                purchaseDetailsToUpdate.insprejectedqty =  updateDto.rejectedQty;

              

                // Mark the PurchaseDetails entity as modified
                dbcontext.Entry(purchaseDetailsToUpdate).State = EntityState.Modified;

                // Save all changes within the transaction
                await dbcontext.SaveChangesAsync();

                // Commit the transaction if all operations are successful
                await transaction.CommitAsync();

                // Return a 200 OK response with a success message.
                return Ok(new { message = "MI item and Purchase Details updated successfully." });
            }
            catch (DbUpdateConcurrencyException)
            {
                // Rollback transaction on concurrency conflict
                await transaction.RollbackAsync();
                if (!MiItemExists(updateDto.MiTblId)) // Check if MI item still exists after conflict
                {
                    return NotFound($"MI item with ID {updateDto.MiTblId} not found after concurrency check.");
                }
                else
                {
                    throw; // Re-throw if it's a genuine concurrency issue
                }
            }
            catch (Exception ex)
            {
                // Rollback transaction on any other exception
                await transaction.RollbackAsync();
                // Log the exception (use a proper logger in production)
                Console.WriteLine($"Error updating MI item and Purchase Details: {ex.Message}");
                return StatusCode(500, "An error occurred while updating the MI item and Purchase Details.");
            }
        }




        [HttpGet("Getpoissuereturnlinedetailsjobsummary")]
        public async Task<IActionResult> Getpoissuereturnlinedetailsjobsummary(int jobid, int budgetheaderid)
        {
            if (jobid <= 0)
            {
                return BadRequest("Invalid jobid");
            }

            var issuereturndetails = await (from aa in dbcontext.Issuereturn
                                            join bb in dbcontext.POissuereturndetails on aa.issuereturnref equals bb.issuereturnref
                                            join ii in dbcontext.Product on bb.productcode equals ii.productcode

                                            where aa.jobid == jobid && ii.itembudgetheaderid == budgetheaderid && aa.isregistered == 1
                                            select new
                                            {
                                                aa.issuereturnref,
                                                bb.returnqty,
                                                ii.itemname,
                                                bb.issuereturndetailid,
                                                bb.issuereturnunitprice,

                                                ii.productcode
                                            })
                                      .Distinct() // Ensures distinct combinations
                                      .ToListAsync();

            if (!issuereturndetails.Any())
            {
                return NotFound("PO details not found");
            }

            return Ok(issuereturndetails);
        }











        //[HttpGet("GetPOPrint")]
        //public async Task<IActionResult> GetPOPrint(int orderid) // Renamed from GetPRheader for clarity
        //{
        //    // Check for a valid OrderId before querying the database
        //    if (orderid <= 0)
        //    {
        //        return BadRequest("Invalid Purchase Order ID.");
        //    }

        //    var poHeader = await (from pr1 in dbcontext.PO
        //                              // 1. Apply the filtering condition here using 'where'
        //                          where pr1.Orderid == orderid

        //                          join ps in dbcontext.Purchasedetails on pr1.Orderid equals ps.orderid
        //                          join ss in dbcontext.Supplier on pr1.supplierid equals ss.supplierid
        //                          join pd in dbcontext.PODeliveryTerms on pr1.podeliverytermsid equals pd.deliveryid

        //                          select new
        //                          {
        //                              pr1.Orderid,
        //                              ss.suppliername,
        //                              incoterms = pd.deliveryterms,
        //                              pr1.Podate,
        //                              pr1.supplieraddress,
        //                              pr1.jobid,
        //                              // Note: Including 'ps' here (which is Purchasedetails) will likely flatten
        //                              // the result and return a separate object for every PurchaseDetail line item.
        //                              // If you want the PO Header and a LIST of items, you should structure this differently (see note below).
        //                              ps
        //                          })
        //                          // If you expect multiple PurchaseDetail records per PO, use ToListAsync()
        //                          .ToListAsync();

        //    // 2. Check the result
        //    if (poHeader == null || poHeader.Count == 0)
        //    {
        //        return NotFound($"Purchase Order with ID {orderid} not found.");
        //    }

        //    // 3. Return the filtered list
        //    return Ok(poHeader);
        //}







        // --- Service Interface ---


        //[HttpGet("GetPOPrint")]
        //public async Task<IActionResult> GetPOPrint(int orderid)
        //{
        //    if (orderid <= 0)
        //    {
        //        return BadRequest("Invalid Purchase Order ID.");
        //    }

        //    // --- 1. Fetch and Structure Data (MINIMAL FIELDS) ---
        //    var poData = await (from pr1 in dbcontext.PO
        //                        where pr1.Orderid == orderid

        //                        // You still need to join Supplier to look up the name, or hardcode it
        //                        join ss in dbcontext.Supplier on pr1.supplierid equals ss.supplierid

        //                        select new PoHeaderPrintDto
        //                        {
        //                            Orderid = pr1.Orderid,
        //                            Jobid = pr1.jobid,
        //                            SupplierName = ss.suppliername,
        //                            Podate = pr1.Podate,
        //                            GrandTotal = 819.00M, // Replace with actual column or calculation

        //                            LineItems = pr1.PurchaseDetails // Assuming navigation property
        //                                .Select((ps, index) => new PoItemPrintDto
        //                                {
        //                                    No = index + 1,
        //                                    ItemCode = ps.poitemid.ToString(),
        //                                    Qty = ps.poquantity,
        //                                    UnitPrice = ps.pounitprice,
        //                                    Amount = ps.poquantity * ps.pounitprice // Calculated field
        //                                })
        //                                .ToList()
        //                        })
        //                        .FirstOrDefaultAsync();

        //    if (poData == null)
        //    {
        //        return NotFound($"Purchase Order with ID {orderid} not found.");
        //    }

        //    // --- 2. Generate and Return PDF File ---
        //    try
        //    {
        //        var pdfBytes = await _pdfService.GeneratePurchaseOrderPdf(poData);

        //        return File(
        //            fileContents: pdfBytes,
        //            contentType: "application/pdf",
        //            fileDownloadName: $"PO-{poData.Orderid}.pdf"
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (ex)
        //        return StatusCode(500, "Error generating Purchase Order PDF.");
        //    }
        //}







        //public async Task<IActionResult> PrintPO(int orderid)
        //{
        //    if (orderid <= 0)
        //        return BadRequest("Invalid PO ID.");

        //    // 1️⃣ Fetch PO Data
        //    var poData = await (from pr1 in dbcontext.PO
        //                        where pr1.Orderid == orderid
        //                        join ss in dbcontext.Supplier
        //                            on pr1.supplierid equals ss.supplierid
        //                        select new PoHeaderPrintDto
        //                        {
        //                            Orderid = pr1.Orderid,
        //                            Jobid = pr1.jobid,
        //                            Podate = pr1.Podate,
        //                            SupplierName = ss.suppliername,

        //                            LineItems = pr1.PurchaseDetails
        //                                .Select((pd, index) => new PoItemPrintDto
        //                                {
        //                                    No = index + 1,
        //                                    ItemCode = pd.poitemid.ToString(),
        //                                    Qty = pd.poquantity,
        //                                    UnitPrice = pd.pounitprice,
        //                                    Amount = pd.poquantity * pd.pounitprice
        //                                }).ToList(),

        //                            GrandTotal = pr1.PurchaseDetails
        //                                .Sum(x => x.poquantity * x.pounitprice)
        //                        })
        //                        .FirstOrDefaultAsync();

        //    if (poData == null)
        //        return NotFound($"PO ID {orderid} not found.");

        //    try
        //    {
        //        // 2️⃣ Generate PDF using service
        //        var pdfBytes = await _pdfService.GeneratePurchaseOrderPdf(poData);

        //        // 3️⃣ Return PDF File
        //        return File(
        //            pdfBytes,
        //            "application/pdf",
        //            $"PO-{orderid}.pdf"
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log exception if needed
        //        return StatusCode(500, "Failed to generate PDF.");
        //    }
        //}




        //[HttpGet("PrintPO")]
        //public async Task<IActionResult> PrintPO(int orderid)
        //{
        //    if (orderid <= 0)
        //        return BadRequest("Invalid PO ID.");

        //    // ------------------------
        //    // 1️⃣ Fetch PO Header
        //    // ------------------------
        //    var poHeader = await (from pr1 in dbcontext.PO
        //                          where pr1.Orderid == orderid
        //                          join ss in dbcontext.Supplier
        //                          on pr1.supplierid equals ss.supplierid
        //                          join pdt in dbcontext.PODeliveryTerms 
        //                          on pr1.podeliverytermsid equals pdt.deliveryid
        //                          join cc in dbcontext.Currency 
        //                          on pr1.pocurrencyid equals cc.currencyid 
        //                          join pt1 in dbcontext.POPaymentterms 
        //                          on pr1.popaymenttermsid equals  pt1.paytermsid
        //                          join pdays in dbcontext.PaymenttermsDays
        //                          on pr1.PaymenttermsDaysid equals pdays.paydaysid
        //                          join pt2 in dbcontext.Popaymentterms2 
        //                          on pr1.POPaymentterms2id equals pt2.paytermsid
        //                          select new
        //                          {
        //                              pr1.Orderid,
        //                              pr1.jobid,
        //                              pr1.Podate,
        //                              SupplierName = ss.suppliername,
        //                              incoterms = pdt.deliveryterms,
        //                              poaddrss=pr1.supplieraddress ,
        //                              pocurrency =cc.currencyname,
        //                              podeliverydate= pr1.deliverydate ,
        //                              paymentterms1 = pt1.paymenttermsname,
        //                              paymentdays = pdays.paydaynames,
        //                              paymentterms2 =pt2.paymenttermsname,

        //                              mtcrequired =pr1.Mtcrequired,
        //                              coorequired =pr1.coorequired,
        //                              predispatchinspection =pr1.predispatchinspection
        //                          }).FirstOrDefaultAsync();

        //    if (poHeader == null)
        //        return NotFound($"PO ID {orderid} not found.");

        //    // ------------------------
        //    // 2️⃣ Fetch Line Items separately (client-side)
        //    // ------------------------
        //    var lineItems = await dbcontext.Purchasedetails
        //        .Where(pd => pd.orderid == poHeader.Orderid)
        //        .Select(pd => new PoItemPrintDto
        //        {
        //            ItemCode = pd.poitemid.ToString(),
        //            Qty = pd.poquantity,
        //            UnitPrice = pd.pounitprice,
        //            Amount = pd.poquantity * pd.pounitprice
        //        })
        //        .ToListAsync();

        //    // Add serial numbers
        //    for (int i = 0; i < lineItems.Count; i++)
        //    {
        //        lineItems[i].No = i + 1;
        //    }

        //    // ------------------------
        //    // 3️⃣ Create final DTO
        //    // ------------------------
        //    var poData = new PoHeaderPrintDto
        //    {
        //        Orderid = poHeader.Orderid,
        //        Jobid = poHeader.jobid,
        //        Podate = poHeader.Podate,
        //        SupplierName = poHeader.SupplierName,
        //        incoterms = poHeader.incoterms,
        //        poaddress = poHeader.poaddrss,
        //        pocurrency = poHeader.pocurrency,
        //        deliverydate = poHeader.podeliverydate,
        //        paymentterms1 = poHeader.paymentterms1,
        //        paymentdays = poHeader.paymentdays,
        //        paymentterms2 = poHeader.paymentterms2,
        //        mtcrequired = poHeader.mtcrequired ? "Yes" : "No",
        //        coorequired =poHeader.coorequired ? "Yes" : "No",

        //        predispatchinspection =poHeader.predispatchinspection ? "Yes" : "No",
        //        LineItems = lineItems,
        //        GrandTotal = lineItems.Sum(x => x.Amount)
        //    };

        //    try
        //    {
        //        // ------------------------
        //        // 4️⃣ Generate PDF using service
        //        // ------------------------
        //        var pdfBytes = await _pdfService.GeneratePurchaseOrderPdf(poData);

        //        // ------------------------
        //        // 5️⃣ Return PDF File
        //        // ------------------------
        //        return File(
        //            pdfBytes,
        //            "application/pdf",
        //            $"PO-{orderid}.pdf"
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log exception if needed
        //        return StatusCode(500, $"Failed to generate PDF. {ex.Message}");
        //    }
        //}


        [HttpGet("PrintPO")]
        public async Task<IActionResult> PrintPO(int orderid)
        {
            if (orderid <= 0)
                return BadRequest("Invalid PO ID.");

            // ------------------------
            // 1️⃣ Fetch PO Header (including individual payment terms)
            // ------------------------
            var poHeader = await (from pr1 in dbcontext.PO
                                  where pr1.Orderid == orderid
                                  join ss in dbcontext.Supplier on pr1.supplierid equals ss.supplierid
                                  join pdt in dbcontext.PODeliveryTerms on pr1.podeliverytermsid equals pdt.deliveryid
                                  join cc in dbcontext.Currency on pr1.pocurrencyid equals cc.currencyid
                                  join pt1 in dbcontext.POPaymentterms on pr1.popaymenttermsid equals pt1.paytermsid
                                  join pdays in dbcontext.PaymenttermsDays on pr1.PaymenttermsDaysid equals pdays.paydaysid
                                  join pt2 in dbcontext.Popaymentterms2 on pr1.POPaymentterms2id equals pt2.paytermsid
                                  join pc in dbcontext.SupplierContact on pr1.suppliercontactid equals pc.suppliercontectid
                         


                                  select new
                                  {
                                      pr1.Orderid,
                                      pr1.jobid,
                                      pr1.Podate,
                                      SupplierName = ss.suppliername,
                                      incoterms = pdt.deliveryterms,
                                      poaddrss = pr1.supplieraddress,
                                      pocurrency = cc.currencyname,
                                      podeliverydate = pr1.deliverydate,
                                      paymentterms1 = pt1.paymenttermsname,
                                      paymentdays = pdays.paydaynames,
                                      paymentterms2 = pt2.paymenttermsname,
                                      mtcrequired = pr1.Mtcrequired,
                                      coorequired = pr1.coorequired,
                                      predispatchinspection = pr1.predispatchinspection,
                                      suppliercontactname = pc.suppliercontactname,
                                      suppliercontactemail =pc.email,
                                      suppliertrn =pr1.suppliertrnno,
                                      qtrnref=pr1.Qtnref,
                                      qtndate =pr1.Qtndate,
                                      createdbyusername =pr1.createdby.UserName,
                                      phoneno=pc.phoneno,
                                      fax=ss.fax,
                                      warranty= pr1.warranty,
                                      poremarks =pr1.Remarks,
                                      revno =pr1.revno,
                                      qtnattched =pr1.qtnattached,
                                      qtnshippingdocs =pr1.qtnshippingdocs,

                                      approveddocs=pr1.approveddrawings,
                                      otherdocs =pr1.Others,
                                      authorizedby =pr1.PoAuthorizedby.UserName,
                                      authorizeddate =pr1.poauthorizedDate



                                  }).FirstOrDefaultAsync();

            if (poHeader == null)
                return NotFound($"PO ID {orderid} not found.");

            // ------------------------
            // 2️⃣ Fetch Line Items (with Item Description and UOM - assumed to exist in DB)
            // ------------------------
            var lineItems = await (from pd in dbcontext.Purchasedetails
                                   where pd.orderid == poHeader.Orderid
                                   // ✅ JOIN TO PRODUCT TABLE
                                   join prod in dbcontext.Product // Assuming your DbSet is named 'Product'
                                   on pd.poitemid equals prod.productcode
                                   join uom in dbcontext.UOM 
                                   on pd.pouomid  equals uom.uomid  
                      select  new PoItemPrintDto
                                   {
                                       ItemCode = pd.poitemid.ToString(),
                                       Qty = pd.poquantity,
                                       UnitPrice = pd.pounitprice,
                                       Amount = pd.poquantity * pd.pounitprice,
                                       ItemDescription = prod.itemname, // Assuming this column exists
                                       Uom = uom.uomname // Assuming this column exists
                                   })
                .ToListAsync();

            // Add serial numbers
            for (int i = 0; i < lineItems.Count; i++)
            {
                lineItems[i].No = i + 1;
            }

            var subTotal = lineItems.Sum(x => x.Amount);
            // As per the sample PDF, Tax Amount is 0.00 but 5% VAT is mentioned.
            var taxAmount = 0.00M;
            var discount = 0.00M;
            var grandTotal = subTotal - discount + taxAmount;

            // ------------------------
            // 3️⃣ Create final DTO (Mapping and Hardcoding)
            // ------------------------
            var poData = new PoHeaderPrintDto
            {
                // Mapped from DB
                Orderid = poHeader.Orderid,
                Jobid = poHeader.jobid,
                Podate = poHeader.Podate,
                SupplierName = poHeader.SupplierName,
                poaddress = poHeader.poaddrss,
                pocurrency = poHeader.pocurrency,
                deliverydate = poHeader.podeliverydate,
                incoterms = poHeader.incoterms,
                LineItems = lineItems,

                // Boolean Conversions
                mtcrequired = poHeader.mtcrequired ? "Yes" : "No",
                coorequired = poHeader.coorequired ? "Yes" : "No",
                predispatchinspection = poHeader.predispatchinspection ? "Yes" : "No",

                // Hardcoded / Concatenated (Matching PDF structure/content)
                CompanyName = "ACE CRANES & ENGINEERING FZ-LLC",
                CompanyAddress = "P.O. Box 85652, RAKEZ, Al Hamra, RAK, U.A.E",
                CompanyTelFax = "Tel:+971 (7) 2445002 / Fax:+971 (6) 5269096",
                CompanyEmail = "info@ace-me.com",
                CompanyTrn = "100296598400003",

                PaymentTermsFull = $"{poHeader.paymentterms1}-{poHeader.paymentdays}-{poHeader.paymentterms2}",
                Buyer = poHeader.createdbyusername,
                VendorRef = poHeader.qtrnref,
                QtnDate = poHeader.qtndate.ToString(),

                SupplierContactName = poHeader.suppliercontactname,
                SupplierTelFax = "Tel: " +  poHeader.phoneno?.ToString() + " / Fax:" + poHeader.fax?.ToString(),
                SupplierEmail =poHeader.suppliercontactemail,
                SupplierTrnNo = poHeader.suppliertrn, // From PDF [cite: 7]
                Warranty = poHeader.warranty ? "Yes" : "No",// From PDF [cite: 7]
                SubTotal = subTotal,
                Discount = discount,
                TaxAmount = taxAmount,
                GrandTotal = grandTotal,
                Remarks = poHeader.poremarks,
                Annexures = new List<string> {  poHeader.qtnattched? "Yes" :"No", poHeader.qtnshippingdocs ? "Yes" : "No", poHeader.approveddocs ? "Yes" : "No", poHeader.otherdocs ? "Yes" : "No" },
                 authorizedby =poHeader.authorizedby,
                 authorizeddate =poHeader.authorizeddate
            
            
            
            
            };

            try
            {
                // 4️⃣ Generate PDF using service
                var document = new PurchaseOrderPdfDocument(poData);
                byte[] pdfBytes = document.GeneratePdf();

                // 5️⃣ Return PDF File
                return File(
                    pdfBytes,
                    "application/pdf",
                    $"PO-{orderid}.pdf"
                );
            }
            catch (Exception ex)
            {
                // Log exception if needed
                return StatusCode(500, $"Failed to generate PDF. {ex.Message}");
            }
        }















        [HttpGet("PrintInvoice")]
        public async Task<IActionResult> PrintInvoice(int invoiceno)
        {
            if (invoiceno <= 0)
                return BadRequest("Invalid Invoice No.");

            // ------------------------
            // 1️⃣ Fetch PO Header (including individual payment terms)
            // ------------------------
            var invoiceHeader = await (from pr1 in dbcontext.Invoice
                                  where pr1.invoiceno == invoiceno
                                  select new
                                  {
                                      pr1.invoiceno,
                                      pr1.jobid,
                                      pr1.InvoiceDate,
                                      customername = pr1.Customer.Customername,
                                      contactperson = pr1.customercontact.name,
                                      invoiceaddress = pr1.InvoiceAddress,
                                      invoicecurrency = pr1.Currency.currencyname,
                                      ourref = pr1.jobid,
                                      lpono = pr1.LPOno,
                                      lpodate = pr1.LPODate,
                                      duedate = pr1.DueDate,
                                  
                                      customrtrno =pr1.Customer.Trnno
                                  }).FirstOrDefaultAsync();

            if (invoiceHeader == null)
                return NotFound($"Invoice ID {invoiceno} not found.");

            // ------------------------
            // 2️⃣ Fetch Line Items (with Item Description and UOM - assumed to exist in DB)
            // ------------------------
            var lineItems = await (from pd in dbcontext.Invoicedetails
                                   where pd.invoiceno == invoiceHeader.invoiceno
                                   // ✅ JOIN TO PRODUCT TABLE
                                 
                                   select new Invoiceprintlineitemdto
                                   {
                                       invidno = pd.invidno,
                                       description = pd.description,
                                       uom = pd.uom,
                                       unitprice = pd.unitprice,
                                       vatpercent = pd.vatpercent,
                                       amount =pd.amount,// Assuming this column exists
                                       taxamount = pd.taxamount,

                                       qty =pd.qty
                                      
                                       // Assuming this column exists
                                   })
                .ToListAsync();

            // Add serial numbers
            for (int i = 0; i < lineItems.Count; i++)
            {
                lineItems[i].No = i + 1;
            }
            var subTotal = lineItems.Sum(x =>
            {
                // 1. Check for null or empty string and return 0 if either is found.
                if (string.IsNullOrWhiteSpace(x.amount))
                {
                    return 0m; // 0m is a decimal literal
                }

                // 2. Attempt to safely parse the string to a decimal.
                if (decimal.TryParse(x.amount, out decimal value))
                {
                    return value;
                }

                // 3. Fallback: If parsing fails (e.g., "abc"), return 0 or throw an error based on requirements.
                // Returning 0m is safer for summing a column.
                return 0m;
            });
            // As per the sample PDF, Tax Amount is 0.00 but 5% VAT is mentioned.
            var taxamount = lineItems.Sum(x =>
            {
                // 1. Check for null or empty string and return 0 if either is found.
                if (string.IsNullOrWhiteSpace(x.taxamount))
                {
                    return 0m; // 0m is a decimal literal
                }

                // 2. Attempt to safely parse the string to a decimal.
                if (decimal.TryParse(x.taxamount, out decimal value))
                {
                    return value;
                }

                // 3. Fallback: If parsing fails (e.g., "abc"), return 0 or throw an error based on requirements.
                // Returning 0m is safer for summing a column.
                return 0m;
            });
         
            var grandTotal = subTotal  + taxamount;

            // ------------------------
            // 3️⃣ Create final DTO (Mapping and Hardcoding)
            // ------------------------
            var invoiceData = new invoiceheaderlineitemdto
            {
                // Mapped from DB
                invoiceno = invoiceHeader.invoiceno,
                jobid = invoiceHeader.jobid,
                InvoiceDate = invoiceHeader.InvoiceDate,
                customername = invoiceHeader.customername,
                InvoiceAddress=invoiceHeader.invoiceaddress,
                LPOno=invoiceHeader.lpono,
                LPODate = invoiceHeader.lpodate,
                invoicecurrency = invoiceHeader.invoicecurrency,
           

                // Hardcoded / Concatenated (Matching PDF structure/content)
                CompanyName = "ACE CRANES & ENGINEERING FZ-LLC",
                CompanyAddress = "P.O. Box 85652, RAKEZ, Al Hamra, RAK, U.A.E",
                CompanyTelFax = "Tel:+971 (7) 2445002 / Fax:+971 (6) 5269096",
                CompanyEmail = "info@ace-me.com",
                CompanyTrn = "100296598400003",

                LineItems =lineItems,
                subTotal =subTotal,
                taxamount =taxamount ,
                grandTotal =grandTotal ,
                customertrn=invoiceHeader.customrtrno,
                customercontact =invoiceHeader.contactperson

            };

            try
            {
                // 4️⃣ Generate PDF using service
                var document = new Invoicepdfdocument(invoiceData);
                byte[] pdfBytes = document.GeneratePdf();

                // 5️⃣ Return PDF File
                return File(
                    pdfBytes,
                    "application/pdf",
                    $"PO-{invoiceno}.pdf"
                );
            }
            catch (Exception ex)
            {
                // Log exception if needed
                return StatusCode(500, $"Failed to generate PDF. {ex.Message}");
            }
        }















        [HttpGet("PrintDeliveryNote")]
        public async Task<IActionResult> PrintDeliveryNote(int deliveryno)
        {
            if (deliveryno <= 0)
                return BadRequest("Invalid Delivery ID.");

            // ------------------------
            // 1️⃣ Fetch PO Header (including individual payment terms)
            // ------------------------
            var deliveryheader = await (from dn1 in dbcontext.DeliveryNote
                                  where dn1.deliveryno == deliveryno
                                  join cc in dbcontext.Customer on dn1.buyerid  equals cc.customerid 
                                  join ccc in dbcontext.customercontact on dn1.buyercontactid  equals ccc.customercontactid
                                  select new
                                  {
                                      dn1.deliveryno,
                                      dn1.jobid,
                                      dn1.deliverydate,
                                      dn1.buyerdeliveryaddress,
                                      dn1.buyertrnno,
                                      dn1.buyeriec,
                                     cutsomercontact= ccc.name ,
                                     dn1.buyerlpodate,
                                     dn1.buyerlpono,
                                     dn1.consigneename,
                                    dn1.consigneeaddress,
                                    dn1.consigneelpono,
                                    dn1.consigneelpodate,
                                    dn1.consigneetrnno,
                                    dn1.consigneeiec,
                                    dn1.vehicleno,
                                    dn1.receivedby,
                                    dn1.deliveredby,
                                   buyername= dn1.Customer.Customername ,
                                    buyercontactname =dn1.customercontact.name,
                                    CompanyName = "ACE CRANES & ENGINEERING FZ-LLC",
                                      CompanyAddress = "P.O. Box 85652, RAKEZ, Al Hamra, RAK, U.A.E",
                                      CompanyTelFax = "Tel:+971 (7) 2445002 / Fax:+971 (6) 5269096",
                                      CompanyEmail = "info@ace-me.com",
                                      CompanyTrn = "100296598400003",

                                  }).FirstOrDefaultAsync();

            if (deliveryheader == null)
                return NotFound($"Delivery No  {deliveryno} not found.");

            // ------------------------
            // 2️⃣ Fetch Line Items (with Item Description and UOM - assumed to exist in DB)
            // ------------------------
            //var lineItems = await (from pd in dbcontext.deliverydetails
            //                       where pd.deliveryid == deliveryheader.deliveryno
                               
            //                       select new Deliverynoteitemdto
            //                       {
            //                           srno = pd.srno,
            //                           description = pd.description,
            //                           uom = pd.uom,
            //                           qty = pd.qty,
            //                           remarks = pd.remarks, // Assuming this column exists
                                       
            //                       })
            //    .ToListAsync();



            var lineItems = await dbcontext.deliverydetails
                .Where(pd => pd.deliveryid == deliveryheader.deliveryno)
                // 🚨 ADDED: Order by the 'count' column
                .OrderBy(pd => pd.counter)
                .Select(pd => new Deliverynoteitemdto
                {
                    srno = pd.srno,
                    description = pd.description,
                    uom = pd.uom,
                    qty = pd.qty,
                    remarks = pd.remarks,
                    // counter = pd.counter,
                })
                .ToListAsync();













            // Add serial numbers
            //for (int i = 0; i < lineItems.Count; i++)
            //{
            //    lineItems[i].No = i + 1;
            //}

            //var subTotal = lineItems.Sum(x => x.Amount);
            //// As per the sample PDF, Tax Amount is 0.00 but 5% VAT is mentioned.
            //var taxAmount = 0.00M;
            //var discount = 0.00M;
            //var grandTotal = subTotal - discount + taxAmount;

            // ------------------------
            // 3️⃣ Create final DTO (Mapping and Hardcoding)
            // ------------------------
            var poData = new Deliveryheaderprintdto
            {
                // Mapped from DB
                deliveryno = deliveryheader.deliveryno,
                jobid = deliveryheader.jobid,
                buyerdeliveryaddress = deliveryheader.buyerdeliveryaddress,
                buyername = deliveryheader.buyername,
                buyertrnno = deliveryheader.buyertrnno,
                buyeriec = deliveryheader.buyeriec,
                buyercontactname = deliveryheader.buyercontactname ,
                LineItems = lineItems,
                buyerlpodate=deliveryheader.buyerlpodate,   
                buyerlpono =deliveryheader.buyerlpono,
                 consigneename =deliveryheader.consigneename,
                 consigneeaddress=deliveryheader.consigneeaddress,  
                 consigneelpono = deliveryheader.consigneelpono,    
                 consigneelpodate =deliveryheader.consigneelpodate,
                  consigneeiec=deliveryheader.consigneeiec,
                  consigneetrnno=deliveryheader.consigneetrnno,
                 
                   receivedby =deliveryheader .receivedby,
                   vehicleno= deliveryheader.vehicleno,
                   deliveredby=deliveryheader.deliveredby,
                   deliverydate =deliveryheader.deliverydate,   

                   CompanyAddress =deliveryheader.CompanyAddress ,
                   CompanyEmail =deliveryheader .CompanyEmail,
                   CompanyName=deliveryheader.CompanyName,
                   CompanyTelFax=deliveryheader.CompanyTelFax,
                   CompanyTrn =deliveryheader.CompanyTrn 





            };

            try
            {
                // 4️⃣ Generate PDF using service
                var document = new DeliveryOrderPdfdocument(poData);
                byte[] pdfBytes = document.GeneratePdf();

                // 5️⃣ Return PDF File
                return File(
                    pdfBytes,
                    "application/pdf",
                    $"Deliveryno-{deliveryno}.pdf"
                );
            }
            catch (Exception ex)
            {
                // Log exception if needed
                return StatusCode(500, $"Failed to generate PDF. {ex.Message}");
            }
        }









        public class budgetsummary
        {
            public decimal  budgetcost { get; set; }
            public decimal  actualcost { get; set; }
        }



        [HttpGet("GetfullBudgetcostSummary")]
        public async Task<ActionResult<List<budgetsummary>>> GetfullBudgetcostSummary(int jobid)
        {
            var budgetactual = new List<budgetsummary>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_GetfullBudgetcostSummary", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // --- CORRECTION: Pass the jobid parameter to the stored procedure ---
                    cmd.Parameters.AddWithValue("@jobid", jobid);
                    // --------------------------------------------------------------------

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            budgetactual.Add(new budgetsummary
                            {
                                budgetcost = reader.GetDecimal(reader.GetOrdinal("OverallFixedBudget")),
                                actualcost = reader.GetDecimal(reader.GetOrdinal("TotalJobCost"))
                            });
                        }
                    }
                }
            }
            if (budgetactual.Count == 0)
            {
                // Changed "pending PR items" to a more general message relevant to this procedure
                return NotFound($"No budget summary data found for Job ID: {jobid}.");
            }
            return Ok(budgetactual);
        }



        public class jobsummary
        {

            public int jobid  { get; set; }

            public string customername  { get; set; }
            public string projectname { get; set; }

            public DateTime  jobdate  { get; set; }

            public string  currencyname { get; set; }

            public decimal   ordervalue { get; set; }

            public  decimal ordervaluebasecurrency { get; set; }
            public decimal  totalbomcost { get; set; }

            public decimal fixedamount { get; set; }

            public decimal  fixedbudgetadditional { get; set; }

            public decimal  overallfixedbudget { get; set; }

            public decimal  totalpoamount { get; set; }

            public decimal totalissuedamount { get; set; }

            public decimal totalreturnedamount { get; set; }

            public decimal miscostamount { get; set; }
            public decimal totaljobcost { get; set; }

        }


        [HttpGet("Getlistjobsummary")]
        public async Task<ActionResult<List<jobsummary>>> Getlistjobsummary()
        {
            var budgetactual = new List<jobsummary>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_Getlistjobsummary", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // --- CORRECTION: Pass the jobid parameter to the stored procedure ---
              
                    // --------------------------------------------------------------------

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            budgetactual.Add(new jobsummary
                            {
                                jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                customername = reader["customername"].ToString(),
                                projectname = reader["projectname"].ToString(),
                                currencyname = reader["currencyname"].ToString(),
                                jobdate = reader.GetDateTime(reader.GetOrdinal("jobdate")),
                             
                                ordervalue = reader.GetDecimal(reader.GetOrdinal("ordervalue")),
                                ordervaluebasecurrency = reader.GetDecimal(reader.GetOrdinal("ordervaluebasecurrency")),
                                // totalbomcost = reader.GetDecimal(reader.GetOrdinal("totalbomcost")),// Read the value as an object, then convert it to a decimal.
                                totalbomcost = Convert.ToDecimal(reader.GetValue(reader.GetOrdinal("totalbomcost"))),
                                fixedamount = reader.GetDecimal(reader.GetOrdinal("fixedamount")),
                                fixedbudgetadditional = reader.GetDecimal(reader.GetOrdinal("fixedbudgetadditional")),
                                overallfixedbudget = reader.GetDecimal(reader.GetOrdinal("overallfixedbudget")),
                                totalpoamount = reader.GetDecimal(reader.GetOrdinal("totalpoamount")),
                                totalissuedamount = reader.GetDecimal(reader.GetOrdinal("totalissuedamount")),
                                miscostamount = Convert.ToDecimal(reader.GetValue(reader.GetOrdinal("miscostamount"))),
                                totalreturnedamount = Convert.ToDecimal(reader.GetValue(reader.GetOrdinal("totalreturnedamount"))),

                                totaljobcost = Convert.ToDecimal(reader.GetValue(reader.GetOrdinal("totaljobcost"))),

                            });
                        }
                    }
                }
            }
            if (budgetactual.Count == 0)
            {
                // Changed "pending PR items" to a more general message relevant to this procedure
                return NotFound($"No budget summary data found.");
            }
            return Ok(budgetactual);
        }



     public class Itemwiseporeport
        {

            public int orderid { get; set; }

            public string itemname { get; set; }
            public string uomname { get; set; }

            public DateTime podate { get; set; }
            public decimal  pounitprice { get; set; }

            public decimal poquantity { get; set; }

            public string   suppliername { get; set; }

            public string  currencyname { get; set; }

            public int  jobid { get; set; }

            public int productcode { get; set; }

        }


        [HttpGet("GetItemwiseporeport")]
        public async Task<ActionResult<List<Itemwiseporeport>>> GetItemwiseporeport()
        {
            var itemwiseporeport = new List<Itemwiseporeport>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("SP_itemwiseporeport", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // --- CORRECTION: Pass the jobid parameter to the stored procedure ---

                    // --------------------------------------------------------------------

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            itemwiseporeport.Add(new Itemwiseporeport
                            {
                                orderid = reader.GetInt32(reader.GetOrdinal("orderid")),
                                itemname = reader["itemname"].ToString(),
                            
                                currencyname = reader["currencyname"].ToString(),
                                podate = reader.GetDateTime(reader.GetOrdinal("podate")),
                                pounitprice = reader.GetDecimal(reader.GetOrdinal("pounitprice")),
                                poquantity = reader.GetDecimal(reader.GetOrdinal("poquantity")),
                                uomname = reader["uomname"].ToString(),
                                suppliername = reader["suppliername"].ToString(),
                                jobid = reader.GetInt32(reader.GetOrdinal("jobid")),

                               productcode= reader.GetInt32(reader.GetOrdinal("productcode"))

                            });
                        }
                    }
                }
            }
            if (itemwiseporeport.Count == 0)
            {
                // Changed "pending PR items" to a more general message relevant to this procedure
                return NotFound($"No PO Details  found.");
            }
            return Ok(itemwiseporeport);
        }

        public class jobtobefreezed
        {
            public int jobid { get; set; }

            public string  customername { get; set; }

            public string  projectname { get; set; }

            public string  jobdescription { get; set; }


        }

        [HttpGet("Getjobnostobefreezed")]
        public async Task<ActionResult<List<jobtobefreezed>>> Getjobnostobefreezed()
        {
            var jobstobefreezed = new List<jobtobefreezed>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("SP_GetAllunfreezedjobs", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // --- CORRECTION: Pass the jobid parameter to the stored procedure ---

                    // --------------------------------------------------------------------

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            jobstobefreezed.Add(new jobtobefreezed
                            {
                                jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                customername  = reader["customername"].ToString(),
                                projectname = reader["projectname"].ToString(),
                                jobdescription = reader["jobdescription"].ToString(),
                              

                            });
                        }
                    }
                }
            }
            if (jobstobefreezed.Count == 0)
            {
                // Changed "pending PR items" to a more general message relevant to this procedure
                return NotFound($"No Job Details  found.");
            }
            return Ok(jobstobefreezed);
        }




        [HttpGet("Getjobstobeunfreezed")]
        public async Task<ActionResult<List<jobtobefreezed>>> Getjobstobeunfreezed()
        {
            var jobstobefreezed = new List<jobtobefreezed>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("SP_GetAllfreezedjobs", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // --- CORRECTION: Pass the jobid parameter to the stored procedure ---

                    // --------------------------------------------------------------------

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            jobstobefreezed.Add(new jobtobefreezed
                            {
                                jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                customername = reader["customername"].ToString(),
                                projectname = reader["projectname"].ToString(),
                                jobdescription = reader["jobdescription"].ToString(),


                            });
                        }
                    }
                }
            }
            if (jobstobefreezed.Count == 0)
            {
                // Changed "pending PR items" to a more general message relevant to this procedure
                return NotFound($"No Job Details  found.");
            }
            return Ok(jobstobefreezed);
        }


    }
}




























