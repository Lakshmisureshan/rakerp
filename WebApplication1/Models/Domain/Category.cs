using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Category
    {
        [Key]
        public int categoryid { get; set; }
        public string  categoryname { get; set; }
        public BudgettHeader BudgettHeader { get; set; }
        public int  budgetheaderid { get; set; }
    }
}
