using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class ManufacturingBay
    {

        [Key]
        public int BayId { get; set; }
        public string BayName { get; set; }
    }
}
