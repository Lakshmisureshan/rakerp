using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models.DTO
{
    public class AddorupdateReceiptVoucher
    {
        public string? bankname { get; set; }
        public string? cheque { get; set; }
        public DateTime? chequedate { get; set; }

        public string createdbyid { get; set; }

        public int customerid { get; set; }
        public DateTime receiptdate { get; set; }

        public int receiptid { get; set; }
        public decimal rvamount { get; set; }
        public decimal rvamountaed { get; set; }

        public int rvcurrencyid { get; set; }

        public decimal rvexchangerate { get; set; }
        public string rvreamrks { get; set; }
        public string rvamountwords { get; set; }
        




    }
}
