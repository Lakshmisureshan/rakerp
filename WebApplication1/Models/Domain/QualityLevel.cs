using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class QualityLevel
    {

        [Key]
        public int qualitylevelid { get; set; }
        public string qualitylevelname { get; set; }
    }
}
