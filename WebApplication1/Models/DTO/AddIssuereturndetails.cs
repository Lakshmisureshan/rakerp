namespace WebApplication1.Models.DTO
{
    public class AddIssuereturndetails
    {

        public   int  itemid { get; set; }
        public decimal  issueqty { get; set; }
        public int issuedetailtblid { get; set; }

        public decimal  irunitprice { get; set; }
    

            public int issuecurrencyid { get; set; }

        public int issueuomid { get; set; }

    }
}
