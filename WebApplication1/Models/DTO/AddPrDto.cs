using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class AddPrDto
    {

        public int PRID { get; set; }
        public DateTime Prdate { get; set; }
    
        public int jobid { get; set; }

        public string remarks { get; set; }

        public string prcreatedbyid { get; set; }
    }
}
