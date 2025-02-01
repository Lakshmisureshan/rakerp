using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class issuereturntracking
    {

        [Key]
        public int issuereturntrackid { get; set; }
        public int invid { get; set; }
        public Job Job { get; set; }
        public int jobid { get; set; }
        public Issuereturn Issuereturn { get; set; }
        public int issuereturnno { get; set; }
        public DateTime issuereturndate { get; set; }
        public decimal issuereturnqty { get; set; }
        public Product Product { get; set; }
        public int productid { get; set; }
        public decimal issuereturnunitprice { get; set; }
        public Currency currency { get; set; }
        public int issuecurrencyid { get; set; }
        public UOM UOM { get; set; }
        public int uomid { get; set; }
    }
}
