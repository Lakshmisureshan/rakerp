using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Issuenotedetails
    {
        [Key]
        public int issuedetailid { get; set; }
        public IssueNoteheader IssueNoteheader { get; set; }
        public int issuenoteref  { get; set; }
        public Product Product { get; set; }
        public int itemid { get; set; }
        public decimal issueqty { get; set; } 



    }
}
