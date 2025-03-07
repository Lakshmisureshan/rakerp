using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class SubCategory
    {
        [Key]
        public int subcategoryid { get; set; }
        public string subcategoryname { get; set; }
        public Category Category { get; set; }
        public int categoryid { get; set; }
    }
}
