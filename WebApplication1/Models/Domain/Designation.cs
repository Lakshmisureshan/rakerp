using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class Designation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int designationid { get; set; }
        public string designationname { get; set; }
    }
}
