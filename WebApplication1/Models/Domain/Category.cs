using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Domain
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int categoryid { get; set; }
        public string  categoryname { get; set; }
        public BudgettHeader BudgettHeader { get; set; }
        public int  budgetheaderid { get; set; }
    }
}
