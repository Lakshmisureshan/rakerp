using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class AddIssuenotefromstockdetails
    {

        public int issuenoteref { get; set; }
       
        public int itemid { get; set; }
        public decimal issueqty { get; set; }
      
        public int rid { get; set; }

        public decimal issueprice { get; set; }

        public int uomid { get; set; }

        public int invrcurrencyid { get; set; }
    }
}
