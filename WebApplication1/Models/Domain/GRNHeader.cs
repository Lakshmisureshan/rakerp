using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class GRNHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int grnno { get; set; }
        public DateTime  grndate  { get; set; }
        public PO   PO { get; set; }
        public int pono { get; set; }
        public int isregistered { get; set; } = 0;
        public Currency Currency { get; set; }
        public int currencyid { get; set; }
        
    }
}
