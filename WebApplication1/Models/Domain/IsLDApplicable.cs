using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class IsLDApplicable
    {
        [Key]
        public int ldid { get; set; }
        public string IsLDApplicableName { get; set; }

    }
}
