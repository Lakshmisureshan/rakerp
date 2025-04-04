using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class InvoiceReg
    {
        [Key]
        public int invoiceregid { get; set; }
        public Invoice Invoice { get; set; }
        public int  invoiceno { get; set; }
        public Customer Customer { get; set; }
        public int customerid  { get; set; }

        public Job Job { get; set; }
        public int jobid { get; set; }



        public Currency Currency { get; set; }
        public int currencyid { get; set; }

        public decimal  Invoicevalue { get; set; }

        public decimal Invoicevalueinbasecurrency { get; set; }
        public decimal Invoicereceipts { get; set; }

        public ApplicationUser applicationUser { get; set; }
        public string Invoiceregisteredby { get; set; }

    }
}
