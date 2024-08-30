using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class BudgettHeader
    {
        [Key]
        public int budgetheaderid { get; set; }
        public string  budgetheadername{ get; set; }
    }
}
