using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using WebApplication1.Data;
//using WebApplication1.Migrations;
using WebApplication1.Models;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static WebApplication1.Controllers.AuthController;
using static WebApplication1.Controllers.POController;
using AddReceivedEntry = WebApplication1.Models.DTO.AddReceivedEntry;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POController : ControllerBase
    {
        private readonly ApplicationDBContext dbcontext;
        private readonly string _connectionString;

        public POController(ApplicationDBContext dbcontext, IConfiguration configuration)
        {
            this.dbcontext = dbcontext;
            _connectionString = configuration.GetConnectionString("CodePlusConnectionStrings");
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
                // Check if the PO already exists
                var existingPO = await dbcontext.PO.FirstOrDefaultAsync(po => po.Orderid == request.Orderid);

                if (existingPO != null)
                {
                    // If the PO exists, update it
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

                    // Save changes to the existing PO
                    await dbcontext.SaveChangesAsync();
                }
                else
                {
                    // If the PO doesn't exist, create a new PO
                    var PO = new PO
                    {
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
                        suppliertrnno = request.suppliertrnno,
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
                    };

                    // Add the new PO to the database
                    await dbcontext.PO.AddAsync(PO);
                    await dbcontext.SaveChangesAsync();
                }

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

                                           po.potblid,
                                           po.orderid,
                                           po.poquantity,
                                           po.make,
                                           po.poitemid,
                                           ii.itemname,
                                           po.pounitprice,


                                           totalamount=po.pounitprice * po.poquantity
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
                                        join ii in dbcontext.Product on po.itemcode equals ii.itemid
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
                                            po.pounitprice


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
                    existingPrDetails.pocreatedqty += (float)prDetail.poquantity;
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
                        prDetail.pocreatedqty = Math.Max(0, prDetail.pocreatedqty - (float)purchaseDetail.poquantity);
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
             .GroupBy(x => new { x.po.Orderid, x.po.Supplier.suppliername, x.po.Currency.currencyname, x.po.Podate, x.po.jobid, x.po.poverifiedbyid, x.po.postatus.postatusname, x.po.postatusid, x.po.PoAuthorizedbyid, x.po.Poverifiedby.UserName, x.po.poverifiedDate })
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
                 TotalAmount = (double)g.Sum(x => (decimal)x.pod.poquantity * (decimal)x.pod.pounitprice * (decimal)x.po.poexchangerate),


             })
             .ToListAsync();
            return Ok(groupedPOData);
        }

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


            var purchasedetails = await dbcontext.Purchasedetails
          .Where(p => p.orderid == pono
                      && p.poquantity > p.receivedentryqty

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
                        pounitprice = item.pounitprice
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
      join red in dbcontext.Product on rh.productid equals red.itemid
      where rh.jobid == jobid
      group rh by red.itemid into grouped
      select new
      {
          ItemId = grouped.Key,
          ItemName = grouped.Select(g => g.Product.itemname).FirstOrDefault(),


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
                        issuetype = "PO"


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
                                      join ii in dbcontext.Product on po.itemid equals ii.itemid


                                      where po.issuenoteref == issueref
                                      select new
                                      {
                                          po.issuedetailid,
                                          po.Product.itemname,
                                          po.issueqty,
                                          po.itemid




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




        [HttpPost("DeductInventory")]
        public IActionResult DeductInventory([FromBody] DeductInventoryRequest request)
        {
            using (var transaction = dbcontext.Database.BeginTransaction())
            {
                try
                {
                    var batches = new List<Batch>();
                    var remainingQuantity = request.RequestedQuantity;

                    var inventoryItems = dbcontext.Inventory
                        .Where(i => i.productid == request.ItemId && i.jobid == request.Jobid)
                        .OrderBy(i => i.Entrydate)
                        .ToList();

                    foreach (var item in inventoryItems)
                    {
                        batches.Add(new Batch(item.batchid, item.quantity, item.invid, item.invcurrencyid, item.uomid, item.invprice));
                    }

                    foreach (var batch in batches)
                    {
                        if (remainingQuantity <= 0) break;

                        var quantityToDeduct = Math.Min(remainingQuantity, batch.Quantity);
                        DeductFromBatch(request.ItemId, batch.BatchID, quantityToDeduct, request.Jobid, request.issueref, batch.Invid, batch.Currencyid, batch.Uomid, batch.Price);
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

        private void DeductFromBatch(int itemId, int batchId, decimal quantity, int jobid, int issueref, int invid, int Currencyid, int Uomid, decimal Price)
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
                                               TotalAmountinbasecurrency = g.Sum(x => (string.IsNullOrEmpty(x.ii.amount) ? 0 : Convert.ToDouble(x.ii.amount)) * x.jj.exchangerate),
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
                                       join ii in dbcontext.Product on red.pritemid equals ii.itemid
                                       join uu in dbcontext.UOM on red.pruomid equals uu.uomid
                                       where rh.prstatusid == 3 && red.prqty > (red.pocreatedqty + (float)red.prstockqty)
                                       select new
                                       {
                                           rh.PRID,  // You may include other fields from PR as required
                                           ii.itemname,  // Product name
                                           ii.productcode,  // Product code
                                           red.prqty,  // Total quantity requested
                                           red.pocreatedqty,  // Quantity already created (PO created qty)
                                           uu.uomname,  // Unit of measure
                                           PendingQty = red.prqty - (red.pocreatedqty + (float)red.prstockqty),  // Pending quantity calculation
                                           rh.jobid,  // Job ID
                                           red.prtblid,  // PR Details table ID
                                           ii.itemid  // Product ID
                                       }).ToListAsync();
            return Ok(prpendinglist);
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
                                      join ii in dbcontext.Product on inv.productid equals ii.itemid
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
                                          join ii in dbcontext.Product on inv.productid equals ii.itemid
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

            public string jobtypename { get; set; }

            public int budgetheaderid { get; set; }

            public string  budgetheadername { get; set; }
       

















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



        [HttpGet("GetInventoryAsOfDate")]
        public async Task<List<InventoryResult>> GetInventoryAsOfDate(DateTime targetDate)
        {
            // Total Received Quantities
            var totalReceived = await (from grn in dbcontext.grntracking
                                       join product in dbcontext.Product on grn.productid equals product.itemid
                                       join currency in dbcontext.Currency on grn.grncurrencyid equals currency.currencyid
                                       join uom in dbcontext.UOM on grn.grnuomid equals uom.uomid
                                       join jj in dbcontext.Job on grn.jobid equals jj.Jobid
                                       join jt in dbcontext.JobType on jj.jobtypeid equals jt.jobtypeid
                                       join bh in dbcontext.BudgettHeader on product.itembudgetheaderid equals bh.budgetheaderid


                                       where grn.grndate <= targetDate
                                       group grn by new
                                       {
                                           grn.invid,
                                           grn.grnunitprice,
                                           grn.grnuomid,
                                           grn.grncurrencyid,
                                           product.itemname,
                                           currency.currencyname,
                                           uom.uomname,
                                           currency.exchangerate,
                                           grn.jobid,


                                           jt.JobtypeName,
                                           bh.budgetheadername,
                                           bh.budgetheaderid

                                       } into g
                                       select new
                                       {
                                           Invid = g.Key.invid,
                                           TotalGrnQty = g.Sum(grn => grn.grnqty),
                                           Price = g.Key.grnunitprice,
                                           Uom = g.Key.uomname,
                                           Currency = g.Key.currencyname,
                                           Itemname = g.Key.itemname,
                                           Rate = g.Key.exchangerate,
                                           jobid = g.Key.jobid,


                                           jobtypename=g.Key.JobtypeName,


                                           budgetheadername =g.Key.budgetheadername,
                                           budgetheaderid =g.Key.budgetheaderid
                                       }).ToListAsync();

            // Total Issued Quantities
            var totalIssued = await (from issue in dbcontext.Issuetracking
                                     join product in dbcontext.Product on issue.productid equals product.itemid
                                     join currency in dbcontext.Currency on issue.issuecurrencyid equals currency.currencyid
                                     join uom in dbcontext.UOM on issue.issueuomid equals uom.uomid

                                     join jj in dbcontext.Job on issue.jobid equals jj.Jobid
                                     join jt in dbcontext.JobType on jj.jobtypeid equals jt.jobtypeid
                                     join bh in dbcontext.BudgettHeader on product.itembudgetheaderid equals bh.budgetheaderid



                                     where issue.issuedate <= targetDate
                                     group issue by new
                                     {
                                         issue.invid,
                                         issue.issueunitprice,
                                         issue.issueuomid,
                                         issue.issuecurrencyid,
                                         product.itemname,
                                         currency.currencyname,
                                         uom.uomname,
                                         currency.exchangerate,
                                         issue.jobid,
                                         jt.JobtypeName,
                                         bh.budgetheadername,
                                         bh.budgetheaderid




                                     } into g
                                     select new
                                     {
                                         Invid = g.Key.invid,
                                         TotalIssueQty = g.Sum(issue => issue.issueqty),
                                         Price = g.Key.issueunitprice,
                                         Uom = g.Key.uomname,
                                         Currency = g.Key.currencyname,
                                         Itemname = g.Key.itemname,
                                         Rate = g.Key.exchangerate,
                                         jobid = g.Key.jobid,
                                         jobtypename = g.Key.JobtypeName,
                                         budgetheadername = g.Key.budgetheadername,
                                         budgetheaderid = g.Key.budgetheaderid


                                     }).ToListAsync();

            // Total Returned Quantities
            var totalReturned = await (from returnTrack in dbcontext.issuereturntracking
                                       join product in dbcontext.Product on returnTrack.productid equals product.itemid
                                       join currency in dbcontext.Currency on returnTrack.issuecurrencyid equals currency.currencyid
                                       join uom in dbcontext.UOM on returnTrack.uomid equals uom.uomid

                                       join jj in dbcontext.Job on returnTrack.jobid equals jj.Jobid
                                       join jt in dbcontext.JobType on jj.jobtypeid equals jt.jobtypeid
                                       join bh in dbcontext.BudgettHeader on product.itembudgetheaderid equals bh.budgetheaderid
                                       where returnTrack.issuereturndate <= targetDate
                                       group returnTrack by new
                                       {
                                           returnTrack.invid,
                                           returnTrack.issuereturnunitprice,
                                           returnTrack.uomid,
                                           returnTrack.issuecurrencyid,
                                           product.itemname,
                                           currency.currencyname,
                                           uom.uomname,
                                           currency.exchangerate,
                                           returnTrack.jobid,
                                           jt.JobtypeName,
                                           bh.budgetheadername,
                                           bh.budgetheaderid
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
                                           budgetheaderid = g.Key.budgetheaderid
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
                    issue.budgetheaderid,
                    issue.budgetheadername



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
                    jobtypename=x.Received.jobtypename  ,
                    budgetheaderid = x.Received.budgetheaderid,
                    budgetheadername = x.Received.budgetheadername,

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
                        budgetheaderid = i.budgetheaderid,
                        budgetheadername =i.budgetheadername,
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

                        budgetheaderid = r.budgetheaderid,
                        budgetheadername =r.budgetheadername,
                    }))
                .OrderBy(result => result.invid)
                .ToList();

            return inventory;
        }

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
        join red in dbcontext.Product on rh.productid equals red.itemid
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
            join red in dbcontext.Product on rh.productid equals red.itemid
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
                                      join ii in dbcontext.Product on po.itemid equals ii.itemid
                                      where po.issuenoteref == issueref
                                      select new
                                      {
                                          po.rid,
                                          po.issuedetailid,
                                          po.Product.itemname,
                                          po.issueqty,
                                          po.itemid
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
                            batches.Add(new Batchstock(item.batchid, item.quantity, item.invid, item.invcurrencyid, item.uomid, item.invprice, item.jobid));
                        }

                        foreach (var batch in batches)
                        {
                            if (remainingQuantity <= 0) break;

                            var quantityToDeduct = Math.Min(remainingQuantity, batch.Quantity);
                            DeductFromBatchrv1(request.ItemId, batch.BatchID, quantityToDeduct, batch.Jobid, request.issueref, batch.Invid, batch.Currencyid, batch.Uomid, batch.Price);
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



        private void DeductFromBatchrv1(int itemId, int batchId, decimal quantity, int jobid, int issueref, int invid, int Currencyid, int Uomid, decimal Price)
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
                                batches.Add(new Batchstock(invItem.batchid, invItem.quantity, invItem.invid, invItem.invcurrencyid, invItem.uomid, invItem.invprice, invItem.jobid));
                            }

                            foreach (var batch in batches)
                            {
                                if (remainingQuantity <= 0) break;

                                var quantityToDeduct = Math.Min(remainingQuantity, batch.Quantity);
                                DeductFromBatchrv2(item.ItemId, batch.BatchID, quantityToDeduct, batch.Jobid, request.IssueRef, batch.Invid, batch.Currencyid, batch.Uomid, batch.Price);
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

        private void DeductFromBatchrv2(int itemId, int batchId, decimal quantity, int jobid, int issueref, int invid, int Currencyid, int Uomid, decimal Price)
        {
            var inventoryItem = dbcontext.Inventory
                .FirstOrDefault(i => i.productid == itemId && i.batchid == batchId && i.jobid == jobid);

            if (inventoryItem != null)
            {
                inventoryItem.quantity -= quantity;

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
                    issueuomid = Uomid
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
                                      join ii in dbcontext.Product on po.itemid equals ii.itemid
                                      join ir in dbcontext.Inventoryreservation on po.rid equals ir.RId
                                      join ih in dbcontext.IssueNoteheader on po.issuenoteref equals ih.issueref
                                      where ih.jobid == jobid && ih.isregistered == 1 && po.issueqty > po.returnedqty
                                      select new
                                      {
                                          ii.itemid,
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





        [HttpGet("GetIssuereturnstocklinedetails")]
        public async Task<IActionResult> GetIssuereturnstocklinedetails(int issuereturnref)
        {
            var issuereturndetails = await (from po in dbcontext.Issuereturndetails
                                            join ii in dbcontext.Product on po.productid equals ii.itemid
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
                            bomdetails.prcreatedqty = (bomdetails.prcreatedqty - existingprdetails.prqty) + (float)item.maxprqty;
                            dbcontext.Bom.Update(bomdetails);
                        }
                        existingprdetails.prqty = (float)item.maxprqty;
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
                                   where po.postatusid == 3 && pp.poquantity > pp.receivedentryqty
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
                                   where po.postatusid == 3   &&  re.receivedqty > (re.acceptedqty+ re.rejectedqty)
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
                                join ii in dbcontext.Product on re.itemid equals  ii.itemid
                                   where po.postatusid == 3 && re.receivedqty > (re.acceptedqty + re.rejectedqty)
                                   && re.RENO  ==reno
                                   group po by new { po.Orderid, ss.suppliername, po.Podate, re.RENO , re.acceptedqty, re.receivedqty, re.rejectedqty, re.holdqty, re.itemid, ii.itemname} into grouped
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
                                       pending = (grouped.Key.receivedqty -(grouped.Key.acceptedqty + grouped.Key.holdqty)),

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

            public int  budgetheaderid { get; set; }

        }


        public class InvoicereceiptPending
        {
            public int invoiceno { get; set; }
            public int  jobid { get; set; }
            public decimal invoicevalueinbasecurrency { get; set; }
            public decimal invoicereceipts { get; set; }
        
         



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


        [HttpGet("GetBudgetSummaryAsync")]
        public async Task<ActionResult<List<BudgetSummary>>> GetBudgetSummaryAsync(int jobId)
        {
            var budgetSummaries = new List<BudgetSummary>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_GetBudgetSummaryrv3", conn))
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
                                    fixedamount= reader.IsDBNull(reader.GetOrdinal("fixedamount"))
                                     ? 0
                                     : Convert.ToDecimal(reader["fixedamount"]),

                                    poamount = reader.IsDBNull(reader.GetOrdinal("poamount"))
                                     ? 0
                                     : Convert.ToDecimal(reader["poamount"]),


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
                                                      : Convert.ToDecimal(reader.GetDouble(reader.GetOrdinal("mainordervaluebase")))
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







        [HttpPost("addorupdateinvoicedetails")]
        public async Task<IActionResult> addorupdateinvoicedetails(AddorupdateInvoicedetails dto)
        {
            using (var transaction = await dbcontext.Database.BeginTransactionAsync()) // Start a transaction
            {
                try
                {


                    // Find existing received entry
                    var existingEntry = await dbcontext.Invoice
                        .FirstOrDefaultAsync(e => e.invoiceno == dto.invoiceno);

                    if (existingEntry != null)
                    {
                        // Update existing entry
                        existingEntry.invoiceno = dto.invoiceno;
                        existingEntry.DueDate = dto.DueDate;
                        existingEntry.remarks = dto.remarks;
                        existingEntry.LPOno = dto.lpono;
                        existingEntry.LPODate = dto.lpodate;
                        existingEntry.jobid = dto.jobid;
                        existingEntry.customerid = dto.customerid;
                        existingEntry.InvoiceAddress = dto.invoiceaddress;
                        existingEntry.InvoiceDate = dto.invoicedate;
                        existingEntry.invcurrencyid = dto.currencyid;
                        dbcontext.Invoice.Update(existingEntry);
                    }
                    else
                    {
                        // Create a new received entry
                        existingEntry = new Invoice
                        {
                            invoiceno = dto.invoiceno,
                            DueDate = dto.DueDate,
                            remarks = dto.remarks,
                            LPOno = dto.lpono,
                            LPODate = dto.lpodate,
                            jobid = dto.jobid,
                            customerid = dto.customerid,
                            InvoiceAddress = dto.invoiceaddress,
                            invcurrencyid = dto.currencyid
                        };

                        await dbcontext.Invoice.AddAsync(existingEntry);
                    }

                    await dbcontext.SaveChangesAsync(); // Save received entry

                    foreach (var item in dto.invoicedetails)
                    {
                        if (item.invidno > 0)
                        {
                            // Update existing detail if rtblid exists
                            var existingDetail = await dbcontext.Invoicedetails
                                .FirstOrDefaultAsync(d => d.invidno == item.invidno);

                            if (existingDetail != null)
                            {
                                existingDetail.unitprice = item.unitprice;
                                existingDetail.vatpercent = item.vatpercent;
                                existingDetail.qty = item.qty;
                                existingDetail.uom = item.uom;
                                existingDetail.amount = item.amount;
                                existingDetail.description = item.description;
                                existingDetail.taxamount = item.taxamount;
                                existingDetail.invoiceno = dto.invoiceno;
                                existingDetail.counter = item.counter;

                                dbcontext.Invoicedetails.Update(existingDetail);
                            }
                        }
                        else
                        {
                            // Insert new detail if rtblid doesn't exist
                            var newDetail = new Invoicedetails
                            {
                                unitprice = item.unitprice,
                                vatpercent = item.vatpercent,
                                qty = item.qty,
                                uom = item.uom,
                                amount = item.amount,
                                description = item.description,
                                taxamount = item.taxamount,
                                invoiceno = dto.invoiceno,
                                counter = item.counter
                            };

                            await dbcontext.Invoicedetails.AddAsync(newDetail);
                        }
                    }
                    await dbcontext.SaveChangesAsync(); // Save received entry details
                    await transaction.CommitAsync(); // Commit transaction if everything succeeds
                    return Ok(new { Message = "Invoice Entry and details saved successfully.", invoiceno = existingEntry.invoiceno });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(); // Rollback transaction on failure

                    return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
                }


            }
        }



        [HttpPost("addorupdatemiscost")]
        public async Task<IActionResult> addorupdatemiscost(Addorupdatemiscostdetails dto)
        {
            using (var transaction = await dbcontext.Database.BeginTransactionAsync()) // Start a transaction
            {
                try
                {




                    foreach (var item in dto.misdetails)
                    {

                        // Insert new detail if rtblid doesn't exist
                        var newmiscost = new Miscost
                        {
                            description = item.description,
                            jobid = item.jobid,
                            misamount = item.misamount,



                        };

                        await dbcontext.Miscost.AddAsync(newmiscost);
                    }
                    await dbcontext.SaveChangesAsync(); // Save received entry details
                    await transaction.CommitAsync(); // Commit transaction if everything succeeds
                    return StatusCode(201, new { Message = "Miscost Entry created successfully." });

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(); // Rollback transaction on failure

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

        // DTO to handle incoming data
        public class InvoiceDetailUpdateDto
        {
            public int Invidno { get; set; }
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
                Paragraph invoiceNo1 = new Paragraph("Annexture to Invoice", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
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
                    decimal orderValueBaseCurrency = Convert.ToDecimal(job.ordervaluebasecurrency)  + Convert.ToDecimal(job.ordervaluebasecurrency) *5/100;
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
                                join im in dbcontext.Product on d.itemid equals im.itemid
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
                                      join ii in dbcontext.Product on bb.itemid equals ii.itemid
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
                
                jobid=estimation.jobid
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


                        applicationid = item.applicationid ,
                        // Associate with the received entry
                        jobid = item.jobid,
                        currencyid = item.currencyid,
                        uomid = item.uomid,
                        quantity=item.qty,
                        price=item.unitprice,
                         revision=item.revision,
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
                                          estimationid=aa.estimationid,
                                          budgetheadername = bh.budgetheadername,
                                          itemname = pp.itemname,
                                          application = app.productionstagename,
                                          unitprice = aa.price,
                                          qty=aa.quantity,
                                          revision = aa.revision,
                                          totalpriceinbasecurrency =aa.quantity *  aa.price* Convert.ToDecimal(cc.exchangerate),
                                          isconvertedtobom =aa.isconvertedtobom


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
                                holdqty = item.holdqty
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
                                         }).  ToListAsync();

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
                                   join ii in dbcontext.Product on re.itemid equals ii.itemid
                                   where po.postatusid == 3 && re.receivedqty > (re.acceptedqty + re.holdqty)
                                   && re.RENO == reno && !midetailsItemIds.Contains(re.itemid)
                                   group po by new { po.Orderid, ss.suppliername, po.Podate, re.RENO, re.acceptedqty, re.receivedqty, re.rejectedqty, re.holdqty, re.itemid, ii.itemname } into grouped
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
                                       pending = (grouped.Key.receivedqty - (grouped.Key.acceptedqty + grouped.Key.holdqty)),

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
                                      join ii in dbcontext.Product on bb.poitemid equals ii.itemid
                                      join ss in dbcontext.Supplier on aa.supplierid equals ss.supplierid
                                      where aa.jobid == jobid && ii.itembudgetheaderid == budgetheaderid
                                      select new
                                      {
                                          aa.Orderid,
                                          ss.suppliername
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























        [HttpGet("GetStockissuereturndetailsbyjobid")]
        public async Task<IActionResult> GetStockissuereturndetailsbyjobid(int jobid)
        {
            if (jobid <= 0)
            {
                return BadRequest("Invalid jobid");
            }

            var result = await (from d in dbcontext.Issuereturndetails
                                join h in dbcontext.Issuereturn on d.issuereturnref equals h.issuereturnref
                                join im in dbcontext.Product on d.productid equals im.itemid
                                join bh in dbcontext.BudgettHeader on im.itembudgetheaderid equals bh.budgetheaderid
                                join cc in dbcontext.Currency on d.ircurrencyid equals cc.currencyid
                                where  h.jobid == jobid

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






        [HttpGet("GetInvoicereceiptpendingreport")]
        public async Task<ActionResult<List<InvoicereceiptPending>>> GetInvoicereceiptpendingreport()
        {
            var InvoicereceiptPending = new List<InvoicereceiptPending>();

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
                                InvoicereceiptPending.Add(new InvoicereceiptPending
                                {
                                    jobid = reader.GetInt32(reader.GetOrdinal("jobid")),
                                    invoiceno = reader.GetInt32(reader.GetOrdinal("invoiceno")),



                                    invoicevalueinbasecurrency = reader.IsDBNull(reader.GetOrdinal("invoicevalueinbasecurrency"))
                                     ? 0
                                     : Convert.ToDecimal(reader["invoicevalueinbasecurrency"]),


                                    invoicereceipts = reader.IsDBNull(reader.GetOrdinal("invoicereceipts"))
                                     ? 0
                                     : Convert.ToDecimal(reader["invoicereceipts"]),



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









        public class Paymentpending
        {

            public string  customername { get; set; }

            public int  totalinvoicecount  { get; set; }
            public decimal totalbalance { get; set; }
            public int totalpending { get; set; }
            public int period { get; set; }
            public int customerid { get; set; }
        }










        [HttpGet("GetPaymentpending")]
        public async Task<ActionResult<List<Paymentpending>>> GetPaymentpending()
        {
            var paymentpending  = new List<Paymentpending>();

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
                                    customerid= reader.GetInt32(reader.GetOrdinal("customerid")),
                                    totalinvoicecount = reader.GetInt32(reader.GetOrdinal("totalinvoicecount")),
                                     totalpending= reader.GetInt32(reader.GetOrdinal("totalpending")),
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

            public DateTime  DueDate { get; set; }

            public decimal  Invoicevalueinbasecurrency { get; set; }

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

                                    InvoiceDate= reader.GetDateTime(reader.GetOrdinal("InvoiceDate")),
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










        [HttpPost("Addorupdatereceiptvoucher")]
        public async Task<IActionResult> Addorupdatereceiptvoucher([FromBody]  AddorupdateReceiptVoucher dto)
        {
            try
            {
                // Check if this is an update or create operation
                var existingEntry = await dbcontext.ReceiptVoucher
                    .FirstOrDefaultAsync(e => e.receiptid == dto.receiptid);

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
                    dbcontext.ReceiptVoucher.Update(existingEntry);
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
                        rvamountwords=dto.rvamountwords
                    };

                    await dbcontext.ReceiptVoucher.AddAsync(newEntry);
                }

                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "Receipt voucher saved successfully." });
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
            public int  invoiceno { get; set; }
            public int  jobid { get; set; }
            public DateTime invoicedate { get; set; }
            public decimal invoicevalue { get; set; }
            public decimal  invoicevalueinbasecurrency { get; set; }

            public decimal receiptpending { get; set; }

        }

        [HttpGet("GetReceiptPendingInvoiceDetails")]
        public async Task<ActionResult<List<ReceiptPendinginvoicedetails>>> GetReceiptPendingInvoiceDetails(int customerid )
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
            public decimal  ordervaluebasecurrency { get; set; }
            public decimal  totalreceivedwithvat { get; set; }
            public decimal totalreceivedwithoutvat { get; set; }
            public decimal totalpendingwithoutvat { get; set; }

            public decimal totalpendingwithvat { get; set; }

            public string  cutomername { get; set; }

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
            public int  jobid { get; set; }
            public decimal invoicevalue_withvat { get; set; }
            public decimal received_withvat { get; set; }
            public decimal received_withoutvat { get; set; }
            public decimal pending_withoutvat { get; set; }
            public string customername { get; set; }
            public decimal pending_withvat { get; set; }
            public DateTime  invoicedate  { get; set; }
            public decimal invoicevalue_withoutvat { get; set; }

        }


        [HttpGet("GetInvoiceRegDetailsWithVATCheck")]
        public async Task<ActionResult<List<InvoiceregAll>>> GetInvoiceRegDetailsWithVATCheck()
        {
            var invoicelist = new List<InvoiceregAll>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_GetInvoiceRegDetailsWithVATCheck", conn))
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
                .Where(e => e.jobid == jobid )
                .MaxAsync(e => (int?)e.revision) ?? 0;

            var nextRevision = maxRevision + 1;

            return Ok(nextRevision);
        }












        public class listestimation
        {
          
            public int jobid { get; set; }
            public string  customername { get; set; }
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













    }
}


























