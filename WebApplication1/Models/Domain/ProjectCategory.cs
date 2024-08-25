using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class ProjectCategory
    {
        [Key]
        public int projectcategoryid { get; set; }
        public string  projectcategoryname { get; set; }
    }
}
