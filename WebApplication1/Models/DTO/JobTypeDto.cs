using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class JobTypeDto
    {
        public int jobtypeid { get; set; }
       

        [Required]
        public string JobtypeName { get; set; }

    }
}
