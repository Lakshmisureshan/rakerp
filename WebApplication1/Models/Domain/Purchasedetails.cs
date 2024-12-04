using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class Purchasedetails
    {
        [Key]
        public int potblid { get; set; }
        public PO  PO { get; set; }
        public int orderid { get; set; }
        public Product product { get; set; }
        public int poitemid  { get; set; }
        public decimal  poquantity { get; set; }
        public decimal pounitprice { get; set; }
        public string  make { get; set; }
        public ICollection<PRDetails> prdetails { get; set; }
        public ICollection<PRPO> PRPOs { get; set; } = new List<PRPO>();
        public decimal receivedentryqty { get; set; } = 0;
        public decimal inspacceptedqty { get; set; } = 0;
        public decimal grncreatedqty { get; set; } = 0;
        public UOM UOM { get; set; }
        public int pouomid { get; set; }




    }
}
     