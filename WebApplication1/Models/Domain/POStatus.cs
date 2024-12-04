using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class POStatus
    {
        [Key]
        public int postatusid { get; set; }
        public string  postatusname { get; set; }
    }
}
