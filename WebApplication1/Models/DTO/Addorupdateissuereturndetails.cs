namespace WebApplication1.Models.DTO
{
    public class Addorupdateissuereturndetails
    {

        public int issuereturnref { get; set; }
      
        public int jobid { get; set; }
        public DateTime returndate { get; set; }
        public string Remarks { get; set; }
        public ICollection<AddIssuereturndetails> issuereturndetails { get; set; }



    }
}
