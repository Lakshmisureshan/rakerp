using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class Inventory
    {
        [Key]
        public int invid { get; set; }
        public Product Product { get; set; }
        public int productid { get; set; }
        public int batchid { get; set; }
        public Job  Job { get; set; }
        public int jobid { get; set; }
        public PO PO { get; set; }
        public int pono { get; set; }
        public decimal  quantity { get; set; }
        public DateTime  Entrydate  { get; set; }
        public UOM UOM { get; set; }
        public int uomid { get; set; }
        public Currency Currency { get; set; }
        public int invcurrencyid { get; set; }
        public decimal  invprice { get; set; }
        public decimal reservedqty { get; set; }

        public string type { get; set; } = "GRN";

    }
}
