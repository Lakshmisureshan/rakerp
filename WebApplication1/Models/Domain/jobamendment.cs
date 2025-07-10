using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class jobamend
    {
        [Key]
        public int amid { get; set; }
        public Job Job { get; set; }
        public int  jobid { get; set; }
        public DateTime  amenddate { get; set; }
        public decimal  amendvalueinbasecurrency { get; set; }
        public ApplicationUser? Amendedby { get; set; }
        public string? amenduserid { get; set; }
        public string? remarks { get; set; }

    }
}
