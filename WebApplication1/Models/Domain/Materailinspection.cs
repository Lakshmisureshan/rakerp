using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Materialinspection
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mid { get; set; }
        public DateTime  midate { get; set; }
        public PO  PO { get; set; }
        public int  pono { get; set; }
        public ReceivedEntry receivedEntry { get; set; }
        public int reid { get; set; }
        public int isregistered { get; set; } = 0;
        public string? remarks { get; set; }
        public Boolean  qtyverified{ get; set; }

        public Boolean phycondn { get; set; }

        public Boolean heattags { get; set; }

        public Boolean colorcoding { get; set;}

        public Boolean siteidentification { get; set; }

        public Boolean correlation { get; set; }

        public Boolean tcverify { get; set; }

        public Boolean materialsent { get; set; }

    }
}
