using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Migrations;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;
using static WebApplication1.Controllers.AuthController;
using AddReceivedEntry = WebApplication1.Models.DTO.AddReceivedEntry;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POController : ControllerBase
    {
        private readonly ApplicationDBContext dbcontext;

        public POController(ApplicationDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
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



        [HttpPost("AddPOHeader")]
        public async Task<IActionResult> AddpoHeader(AddPO request)
        {
            DateTime currentDate = DateTime.Now;
            try
            {
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
                    Others = request.Others,
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

                await dbcontext.PO.AddAsync(PO);
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
                // e.g., logger.LogError(ex, "An error occurred while adding PR header");

                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }


        [HttpGet("GetPrpendinglistwhereponotcreated")]

        public async Task<IActionResult> GetPrpendinglistwhereponotcreated(int jobid)
        {
            var result = from prHeader in dbcontext.PR
                         join prDetail in dbcontext.PRDetails on prHeader.PRID equals prDetail.prid
                         where prDetail.pocreatedqty < prDetail.prqty && prHeader.prstatusid == 3 && prHeader.jobid == jobid
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
      .Include(po => po.Supplier) // Include the Supplier related entity
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

                                       join ii in dbcontext.Product on po.poitemid equals ii.itemid

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
            var grnlinedetails  = await (from po in dbcontext.GRNDetails
                                       join ii in dbcontext.Product on po.itemcode equals ii.itemid
                                         join pou in dbcontext.UOM on po.pouomid equals pou.uomid
                                         join invuom  in dbcontext.UOM on po.inventoryuomid equals invuom.uomid

                                         where po.grnno == grnno
                                         select new
                                       {
                                           po.grntblid,
                                           po.Product.itemname,
                                           po.grnqty,

                                         pouomname=  pou.uomname  ,
                                         invuomname =invuom.uomname,
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




        [HttpDelete("Deletepoline/{potblid}")]
        public async Task<IActionResult> DeletePoline(int potblid)
        {
            // Check if the POLine item exists
            var purchaseDetail = await dbcontext.Purchasedetails.FindAsync(potblid);
            if (purchaseDetail == null)
            {
                return NotFound(new { Message = $"The POLine item with id {potblid} does not exist." });
            }

            // Remove the item
            dbcontext.Purchasedetails.Remove(purchaseDetail);

            // Save changes to the database
            await dbcontext.SaveChangesAsync();

            return NoContent(); // 204 No Content response
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
        public async Task<IActionResult> GetReceivedEntryLineDetailsbyReceivedID( int reno)
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
                .Where(p => p.PO.postatusid==3) // Filter only authorized PurchaseOrders
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
            try
            {


                var unregisteredGRNs = await dbcontext.GRNHeader
                    .Where(e => e.isregistered ==0  && e.grnno != dto.grnno)
                    .ToListAsync();

                if (unregisteredGRNs.Any())
                {
                    // Return an error response if any unregistered GRNs are found
                    return BadRequest(new { Message = "Cannot save GRN because there are unregistered GRNs with the same GRN number." });
                }















                // Find existing received entry
                var existingEntry = await dbcontext.GRNHeader
                    .FirstOrDefaultAsync(e => e.grnno == dto.grnno);

                if (existingEntry != null)
                {
                    // Update existing entry
                    existingEntry.pono = dto.pono;
                    existingEntry.grnno = dto.grnno;
                    existingEntry.grndate = dto.grndate;
                    existingEntry.currencyid = dto.currencyid;
                    dbcontext.GRNHeader.Update(existingEntry);
                }
                else
                {
                    // Create a new received entry
                    existingEntry = new GRNHeader
                    {
                        // Assuming REID is generated elsewhere or provided
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
                        // Associate with the received entry
                        itemcode = item.itemid,
                        grnqty = item.grnqty,

                        pouomid = item.pouomid,
                        inventoryuomid=item.inuomid,
                        multiplyingfactor=item.mf,
                        pounitprice=item.pounitprice

                    };

                    await dbcontext.GRNDetails.AddAsync(detail);
                }

                await dbcontext.SaveChangesAsync();

                return Ok(new { Message = "GRN entry and details saved successfully." });
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                // Log.Error(ex, "An error occurred while processing the received entry details.");

                // Return a generic error message to the client
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }





        [HttpGet("GetGRNHeaderDetailsbygrnno")]
        public async Task<IActionResult> GetGRNHeaderDetailsbygrnno(int grnno)
       {
            try
            {

                var grnheader  = await dbcontext.GRNHeader
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
      

        TotalQty = (double)grouped.Sum(x => x.quantity )
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
                    issuedto = dto.issuedto
                  

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
                        DeductFromBatch(request.ItemId, batch.BatchID, quantityToDeduct, request.Jobid, request.issueref,batch.Invid, batch.Currencyid, batch.Uomid, batch.Price );
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

        private void DeductFromBatch(int itemId, int batchId, decimal quantity, int jobid, int issueref, int invid, int Currencyid, int Uomid, decimal Price  )
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
                    invid = invid  ,
                    issuecurrencyid=Currencyid,
                    issueunitprice=Price,
                    issueuomid=Uomid


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
                                        join pr in dbcontext.PR on po.prid equals pr. PRID 
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
                                      && inv.quantity -inv.reservedqty > 0
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
                        batches.Add(new Batch1( item.quantity-item.reservedqty,  item.invid, item.jobid, request.jobid, item.uomid, item.invprice, item.invcurrencyid));
                    }
                    foreach (var batch in batches)
                    {
                        if (prqty <= 0) break;
                        var quantityToreserve = Math.Min(prqty, batch.Quantity);
                        reserve(request.itemid, quantityToreserve, batch.Invid, request.prtblid, request.jobid,batch.Fromjobid ,batch. Uomid, batch.Invunitprice, batch.Invcurrencyid);
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

        private void reserve(int itemId,  decimal quantity, int invid, int prtblid, int tojob, int fromjob, int uomid, decimal unitprice, int invcurrencyid)
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
                    issuecreatedqty = 0 ,
                    reservationtime= DateTime.Now ,
                    prtblid=prtblid ,
                    invrcurrencyid=invcurrencyid
                    
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
            public int ? Invid { get; set; }
            public decimal Inventory { get; set; }
            public decimal Price { get; set; }
            public string  Uom { get; set; }
            public string  Currency { get; set; }
        }







        [HttpGet("GetInventoryAsOfDate")]
        public async Task<List<InventoryResult>> GetInventoryAsOfDate(DateTime targetDate)
        {
            var totalReceived = await (from grn in dbcontext.grntracking
                                       join product in dbcontext.Product on grn.productid equals product.itemid
                                       join currency in dbcontext.Currency on grn.grncurrencyid equals currency.currencyid
                                       join uom in dbcontext.UOM on grn.grnuomid equals uom.uomid
                                       where  grn.grndate <= targetDate
                                       group grn by new { grn.invid, grn.grnunitprice, grn.grnuomid, grn.grncurrencyid, product.itemname, currency.currencyname, uom.uomname } into g
                                       select new
                                       {
                                           Invid = g.Key.invid,
                                           TotalGrnQty = g.Sum(grn => grn.grnqty),
                                           Price = g.Key.grnunitprice,
                                           Uom = g.Key.uomname,
                                           Currency = g.Key.currencyname,
                                           Itemname = g.Key.itemname
                                       }).ToListAsync();

            var totalIssued = await (from issue in dbcontext.Issuetracking
                                     join product in dbcontext.Product on issue.productid equals product.itemid
                                     join currency in dbcontext.Currency on issue.issuecurrencyid equals currency.currencyid
                                     join uom in dbcontext.UOM on issue.issueuomid equals uom.uomid
                                     where  issue.issuedate <= targetDate
                                     group issue by new { issue.invid, issue.issueunitprice, issue.issueuomid, issue.issuecurrencyid, product.itemname, currency.currencyname, uom.uomname } into g
                                     select new
                                     {
                                         Invid = g.Key.invid,
                                         TotalissueQty = g.Sum(grn => grn.issueqty),
                                         Price = g.Key.issueunitprice,
                                         Uom = g.Key.uomname,
                                         Currency = g.Key.currencyname,
                                         Itemname = g.Key.itemname
                                     }).ToListAsync();

            var inventory = totalReceived
                .GroupJoin(totalIssued,
                    r => r.Invid,
                    i => i.Invid,
                    (r, i) => new { Received = r, Issued = i.DefaultIfEmpty() })
                .SelectMany(
                    x => x.Issued.Select(i => new InventoryResult
                    {
                        Invid = x.Received.Invid,
                        Inventory = x.Received.TotalGrnQty - (i?.TotalissueQty ?? 0),
                        Price = x.Received.Price,
                        Uom = x.Received.Uom,
                        Currency = x.Received.Currency
                    }))
                .Union(totalIssued
                    .Where(i => !totalReceived.Any(r => r.Invid == i.Invid))
                    .Select(i => new InventoryResult
                    {
                        Invid= i.Invid,
                        Inventory = 0 - i.TotalissueQty,
                        Price = i.Price,
                        Uom = i.Uom,
                        Currency = i.Currency
                    }))
                .OrderBy(result => result.Invid)
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
            fromjob=rh.fromjobid,
            tojob=rh.tojobid
        }
    ).ToListAsync();

            return Ok(stockitemsissuedbyjobid);
        }







        [HttpGet("GetPendingPurchasedetailsbypono")]
        public async Task<IActionResult> GetPendingPurchasedetailsbypono(int pono)
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
          rid=rh.RId,
          ItemId = rh.productid,
          ItemName = red.itemname,
          maxqantity=rh.reservedqty - rh.issuecreatedqty,
          unitprice=rh.invunitprice,
          fromjob=rh.fromjobid,
          tojob=rh.tojobid,
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
                        rid=item.rid,
                        issueprice=item.issueprice,
                        
                        issuecurrencyid=item.invrcurrencyid,

                        issueuomid=item.uomid,

                    };

                    await dbcontext.IssuedetailsfromStock.AddAsync(detail);




                    var inventoryReservation = await dbcontext.Inventoryreservation
    .FirstOrDefaultAsync(ir => ir.RId == item.rid);

                    if (inventoryReservation != null)
                    {
                        inventoryReservation.issuecreatedqty +=item.issueqty;

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
                                      where ih.jobid == jobid && ih.isregistered ==1 && po.issueqty > po.returnedqty
                                      select new
                                      {ii.itemid,
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
                    irunitprice=item.irunitprice,
                    issuereturnref=dto.issuereturnref,
                    productid=item.itemid,
                    quantityreturned=item.issueqty,
                    issuedetailtblid=item.issuedetailtblid, 

                    iruomid=item.issueuomid,
                    ircurrencyid=item.issuecurrencyid

                    
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
                            bomdetails.prcreatedqty = (bomdetails.prcreatedqty- existingprdetails.prqty) + (float)item.maxprqty;
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





        [HttpPost("UploadFile")]
        public IActionResult UploadFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var filePath = Path.Combine("prUploads", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Ok(new { Message = "File uploaded successfully", FileName = file.FileName });
        }









        [HttpGet("GetJobDetailsbyjobid")]
        public async Task<IActionResult> GetJobDetailsbyjobid(int jobid)
        {
            try
            {
                var issueheader = await dbcontext.Job
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




























    }



        }

