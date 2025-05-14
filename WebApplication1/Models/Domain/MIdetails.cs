using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class MIdetails
    {
        [Key]
        public int mitblid { get; set; }
        public Materialinspection Materialinspection { get; set; }
        public int mid { get; set; }
        public Product Product { get; set; }
        public int itemid { get; set; }
        public ReceivedEntryDetails receivedEntryDetails { get; set; }
        public int rtblid { get; set; }



        public decimal acceptedqty { get; set; }
        public decimal rejectedqty { get; set; }
        public decimal holdqty { get; set; }

    }
}
