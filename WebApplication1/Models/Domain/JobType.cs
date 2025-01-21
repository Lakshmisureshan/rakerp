using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Domain
{
    public class JobType
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int jobtypeid { get; set; }
        public string   JobtypeName { get; set; }
        public string startingseries { get; set; }  
    }
}
