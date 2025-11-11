using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models.Domain
{
    public class Enquirystatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int enqstatusid { get; set; }
        public string  enqstatusname { get; set; }
    }
}
