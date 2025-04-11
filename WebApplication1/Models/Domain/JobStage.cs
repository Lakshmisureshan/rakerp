using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class JobStage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int jobstageid { get; set; }

        public string jobstagename { get; set; }
    }
}
