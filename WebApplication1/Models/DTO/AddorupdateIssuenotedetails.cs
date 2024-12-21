using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class AddorupdateIssuenotedetails
    {

        public int issueref { get; set; }
        public string issuedto { get; set; }
        public int jobid  { get; set; }
        public DateTime issuedate { get; set; }
        public string  Remarks { get; set; }
        public ICollection<Addissuenotedetails> issuedetails { get; set; }
    }
}
