using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models.Domain
{
    public class IssueNoteheader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int issueref { get; set; }
        public DateTime issuedate  { get; set; }
        public Job job { get; set; }
        public int  jobid  { get; set; }
        public string?  Remarks { get; set; }
        public string? issuedto { get; set; }
        public int isregistered { get; set; } = 0;

    }
}
