using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class PRstatus
    {
        [Key]
        public int prstatusid { get; set; }
        public string  prstatusname { get; set; }

    }
}
