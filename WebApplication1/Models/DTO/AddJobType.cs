using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class AddJobType
    {
        [Required]
        public string JobtypeName { get; set; }
    }
}
