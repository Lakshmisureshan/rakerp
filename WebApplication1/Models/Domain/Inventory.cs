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
        public double  quantity { get; set; }
        public DateTime  Entrydate  { get; set; }

        public UOM UOM { get; set; }
        public int uomid { get; set; }



    }
}
