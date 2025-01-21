using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Issuereturndetails
    {
       [Key]
        public int irtblid { get; set; }
        public Product Product { get; set; }
        public int  productid { get; set; }
        public decimal quantityreturned { get; set; }
        public Issuereturn Issuereturn { get; set; }
        public int  issuereturnref { get; set; }
        public IssuedetailsfromStock IssuedetailsfromStock { get; set; }
        public int issuedetailtblid { get; set; }
        public decimal  irunitprice { get; set; }

        public Currency Currency { get; set; }
        public int ircurrencyid { get; set; }


        public UOM UOM { get; set; }
        public int iruomid { get; set; }

    }
}
