using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Invoicedetails
    {
        [Key]
        public int invidno { get; set; }
        public Invoice  Invoice  { get; set; }
        public int invoiceno { get; set; }
        public string  description  { get; set; }
        public string uom { get; set; }
        public string unitprice  { get; set; }
        public string  qty { get; set; }
        public string amount { get; set; }
        public int  counter { get; set; }
        public string  vatpercent  { get; set; }
        public string  taxamount { get; set; }






    }
}
