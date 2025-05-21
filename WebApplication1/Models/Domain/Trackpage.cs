using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class Trackpage
    {
        [Key]
        public int trackid { get; set; }
        public string  pagename { get; set; }
        public string  docno { get; set; }
        public DateTime createddate { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string createdbyuser { get; set; }
    }
}
