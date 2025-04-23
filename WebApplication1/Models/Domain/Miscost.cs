using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Miscost
    {
        [Key]
        public int misid { get; set; }

        public string  description { get; set; }

        public decimal  misamount { get; set; }
        public Job Job { get; set; }
        public int jobid { get; set; }
    }
}
