using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class grntracking
    {
        [Key]
        public int grntrackid { get; set; }
      
        public int invid { get; set; }
        public Job Job { get; set; }
        public int jobid { get; set; }
        public GRNHeader GRNHeader { get; set; }
        public int grnno { get; set; }
        public DateTime grndate { get; set; }
        public decimal grnqty { get; set; }


        public Product Product { get; set; }
        public int productid { get; set; }


        public decimal  grnunitprice { get; set; }
        public Currency currency { get; set; }
        public int  grncurrencyid { get; set; }
        public UOM UOM { get; set; }
        public int grnuomid { get; set; }







    }
}
