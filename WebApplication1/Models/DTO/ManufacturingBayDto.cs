using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class ManufacturingBayDto
    {


        [Key]
        public int BayId { get; set; }
        public string BayName { get; set; }
    }
}
