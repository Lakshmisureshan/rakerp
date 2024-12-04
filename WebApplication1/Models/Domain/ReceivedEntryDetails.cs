using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class ReceivedEntryDetails
    {
        [Key]
        public int rtblid { get; set; }
        public ReceivedEntry ReceivedEntry { get; set; }
        public int RENO { get; set; }
         public decimal receivedqty { get; set; }

        public Product Product { get; set; }
        public int itemid  { get; set; }

        public Purchasedetails Purchasedetails { get; set; }

        public int potblid  { get; set; }

    }
}
