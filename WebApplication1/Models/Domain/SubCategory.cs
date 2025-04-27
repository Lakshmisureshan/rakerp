using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Domain
{
    public class SubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int subcategoryid { get; set; }
        public string subcategoryname { get; set; }
        public Category Category { get; set; }
        public int categoryid { get; set; }
    }
}
