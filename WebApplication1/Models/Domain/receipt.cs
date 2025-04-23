using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class receipt
    {
        [Key]
        public int rtblid { get; set; }
        public ReceiptVoucher receiptvoucher { get; set; }
        public int  receiptid { get; set; }
        public Invoice Invoice { get; set; }
        public int invoiceid { get; set; }
        public Customer Customer { get; set; }
        public int customerid { get; set; }
        public decimal  amountinbasecurrency { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public string   Createdbyid { get; set; }
        public DateTime  createdbydate  { get; set; }

        

    }
}
