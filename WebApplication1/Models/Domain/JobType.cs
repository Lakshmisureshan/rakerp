using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class JobType
    {

        [Key]
        public int jobtypeid { get; set; }
        public string   JobtypeName { get; set; }
    }
}
