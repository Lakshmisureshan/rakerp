using Org.BouncyCastle.Bcpg.OpenPgp;
using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class invoiceheaderlineitemdto
    {

        public int invoiceno { get; set; }
        public string  customername { get; set; }
     
        public DateTime InvoiceDate { get; set; }
        public string InvoiceAddress { get; set; }
        public string LPOno { get; set; }
        public DateTime LPODate { get; set; }
        public DateTime DueDate { get; set; }
        public Job Job { get; set; }
        public int jobid { get; set; }
        public string? remarks { get; set; }


        public int isregistered { get; set; } = 0;

        public string  customercontact { get; set; }
        public int customercontactid { get; set; }

        public string invoicecurrency { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyTelFax { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyTrn { get; set; }

        public List<Invoiceprintlineitemdto> LineItems { get; set; }
        public decimal subTotal { get; set; }
        public decimal taxamount { get; set; }
        public decimal grandTotal { get; set; }

        public string  customertrn { get; set; }

    }
}
