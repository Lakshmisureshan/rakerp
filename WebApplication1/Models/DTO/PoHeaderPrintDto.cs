using static WebApplication1.Controllers.POController;

namespace WebApplication1.Models.DTO
{
    public class PoHeaderPrintDto
    {
       public int Orderid { get; set; }
        public int Jobid { get; set; }
        public DateTime Podate { get; set; }
        public string SupplierName { get; set; }
        public string poaddress { get; set; }
        public string pocurrency { get; set; }
        public DateTime?   deliverydate { get; set; }
        public string incoterms { get; set; }

        public string mtcrequired { get; set; } // Yes/No
        public string coorequired { get; set; } // Yes/No
        public string predispatchinspection { get; set; } // Yes/No
        public decimal GrandTotal { get; set; }
        public List<PoItemPrintDto> LineItems { get; set; }

        // NEW FIELDS (for PDF details)
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyTelFax { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyTrn { get; set; }

        public string PaymentTermsFull { get; set; } // Combined payment terms
        public string Buyer { get; set; }
        public string VendorRef { get; set; }
        public string   QtnDate { get; set; }

        public string SupplierContactName { get; set; }
        public string SupplierTelFax { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierTrnNo { get; set; }

        public string Warranty { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal SubTotal { get; set; }
        public string Remarks { get; set; }

        public int revno  { get; set; }
        public List<string> Annexures { get; set; }

        public string   authorizedby { get; set; }

        public DateTime ? authorizeddate  { get; set; }


    }
}
