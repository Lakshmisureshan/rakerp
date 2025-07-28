using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class Addorupdatemiscost
    {
        public int misid { get; set; }
        public string description { get; set; }

        public decimal misamount { get; set; }
      
        public int jobid { get; set; }
        public int counter { get; set; }

        public string   createdbyuser { get; set; }


    }
}
