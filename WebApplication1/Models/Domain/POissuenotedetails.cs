using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class POissuenotedetails
    {

        [Key]
        public int issuereturndetailid { get; set; }
        public Issuereturn Issuereturn { get; set; }
        public int issuereturnref { get; set; }
        public Product Product { get; set; }
        public int productcode { get; set; }
        public decimal returnqty { get; set; }

        public decimal issuereturnunitprice { get; set; } = 0;


    }
}