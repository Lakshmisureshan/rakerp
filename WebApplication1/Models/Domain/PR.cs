using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Domain
{
    public class PR
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PRID { get; set; }
        public DateTime Prdate { get; set; }
        public Job  Job { get; set; }
        public int jobid { get; set; }

        public string  remarks  { get; set; }
    }
}
