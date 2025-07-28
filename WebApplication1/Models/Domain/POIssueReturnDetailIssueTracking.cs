namespace WebApplication1.Models.Domain
{
    public class POIssueReturnDetailIssueTracking
    {

        // Composite Primary Key (or a single primary key if you prefer)
        // If you want a simple primary key:
        public int POIssueReturnDetailIssueTrackingID { get; set; }

        // Foreign Keys
        public int issuereturndetailid { get; set; }
        public int issuetrackid { get; set; }

        // Navigation properties to the related entities
        public POissuereturndetails POIssueReturnDetail { get; set; }
        public Issuetracking IssueTracking { get; set; }

        // You can add other properties here if needed for the link itself
        // public DateTime LinkDate { get; set; }
    }
}
