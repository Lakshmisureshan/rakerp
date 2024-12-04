using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class ReceivedEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int REID { get; set; }
        public PO  PO { get; set; }
        public int  pono  { get; set; }
        public string?  Remarks  { get; set; }
        public string? location { get; set; }

        public DateTime  REDate   { get; set; }

        public int isregistered { get; set; } = 0;
    }
}
