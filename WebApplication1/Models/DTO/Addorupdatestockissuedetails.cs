namespace WebApplication1.Models.DTO
{
    public class Addorupdatestockissuedetails
    {

        public int issueref { get; set; }
        public string issuedto { get; set; }
        public int jobid { get; set; }
        public DateTime issuedate { get; set; }
        public string Remarks { get; set; }
        public ICollection<AddIssuenotefromstockdetails> issuedetails { get; set; }
    }
}
