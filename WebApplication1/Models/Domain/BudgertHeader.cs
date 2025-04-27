using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Domain
{
    public class BudgettHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int budgetheaderid { get; set; }
        public string  budgetheadername{ get; set; }
    }
}
