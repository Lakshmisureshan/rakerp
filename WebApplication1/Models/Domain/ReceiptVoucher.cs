using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class ReceiptVoucher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int receiptid  { get; set; }
        public Customer Customer { get; set; }
        public int customerid { get; set; }
        public Currency Currency { get; set; }
        public int rvcurrencyid { get; set; }
        public decimal  rvexchangerate  { get; set; }

        public decimal rvamount { get; set; }
        public decimal rvamountaed { get; set; }
        public string  rvamountwords  { get; set; }
        public string? cheque { get; set; }
        public DateTime?  chequedate  { get; set; }
        public string bankname  { get; set; }

        public DateTime  receiptdate  { get; set; }
        public string rvreamrks   { get; set; }
        public int isregistered { get; set; } = 0;

        public ApplicationUser createdby { get; set; }
        public string createdbyid { get; set; }





















    }
}
