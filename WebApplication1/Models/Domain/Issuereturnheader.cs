using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Issuereturn
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int issuereturnref { get; set; }
        public DateTime returndate { get; set; }
        public Job job { get; set; }
        public int jobid { get; set; }
        public string? Remarks { get; set; }
        public int isregistered { get; set; } = 0;

    }
}
