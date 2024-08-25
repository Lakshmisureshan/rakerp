using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class UOM
    {
        [Key]
        public int uomid { get; set; }
        [Required]
        public string uomname { get; set; }
    }
}
