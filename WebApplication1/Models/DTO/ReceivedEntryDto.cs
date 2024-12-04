using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class ReceivedEntryDto
    {
        public int REID { get; set; }
      
        public int pono { get; set; }
        public string? Remarks { get; set; }
        public string? location { get; set; }

        public DateTime REDate { get; set; }
    }
}
