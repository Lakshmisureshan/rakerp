using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Issuetracking
    {
        [Key]
        public int issuetrackid { get; set; }
      
        public int? invid { get; set; }
        public Job Job { get; set; }
        public int jobid { get; set; }
        public IssueNoteheader IssueNoteheader { get; set; }
        public int issuenoteno { get; set; }
        public DateTime issuedate { get; set; }
        public decimal issueqty { get; set; }


        public Product Product { get; set; }
        public int productid { get; set; }



        public decimal issueunitprice { get; set; }
        public Currency currency { get; set; }
        public int issuecurrencyid { get; set; }
        public UOM UOM { get; set; }
        public int issueuomid { get; set; }













    }
}
