using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class GRNDetails
    {
        [Key]
        public int grntblid { get; set; }
        public GRNHeader GRNHeader { get; set; }
        public int grnno { get; set; }
        public Product Product { get; set; }
        public int  itemcode { get; set; }
        public decimal  grnqty { get; set; }
        public UOM POUOM { get; set; }
        public int  pouomid { get; set; }
        public UOM Inventoryuom { get; set; }
        public int inventoryuomid { get; set; }
        public double  multiplyingfactor  { get; set; }
    }
}
