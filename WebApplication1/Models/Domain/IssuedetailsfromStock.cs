using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class IssuedetailsfromStock
    {
        [Key]
        public int issuedetailid { get; set; }
        public IssueNoteheader IssueNoteheader { get; set; }
        public int issuenoteref { get; set; }
        public Product Product { get; set; }
        public int itemid { get; set; }
        public decimal issueqty { get; set; }
        public Inventoryreservation Inventoryreservation { get; set; }
        public int  rid { get; set; }
        public decimal  issueprice { get; set; }
        public decimal returnedqty { get; set; }



        public UOM UOM { get; set; }
        public int issueuomid { get; set; }

        public Currency Currency { get; set; }
        public int issuecurrencyid { get; set; }






    }
}
