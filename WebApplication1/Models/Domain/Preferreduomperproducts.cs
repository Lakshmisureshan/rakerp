using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class Preferreduomperproducts
    {
        [Key]
        public int pid { get; set; }
        public UOM Prefuom { get; set; }
        public int prefuomid { get; set; }
        public decimal  multiplyfactor { get; set; }
        public Product Product { get; set; }
        public int itemcode { get; set; }
    }
}
