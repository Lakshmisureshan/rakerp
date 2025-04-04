namespace WebApplication1.Models.DTO
{
    public class AddorupdateInvoicedetails
    {
        public int invoiceno { get; set; }
  
        public int jobid { get; set; }
        public string remarks { get; set; }
        public DateTime invoicedate { get; set; }
        public int customerid { get; set; }
        public string lpono { get; set; }
        public DateTime lpodate { get; set; }
        public string invoiceaddress { get; set; }
         public DateTime DueDate { get; set; }
        public int currencyid { get; set; }
        public ICollection<AddInvoicedetails> invoicedetails { get; set; }



    }
    }

