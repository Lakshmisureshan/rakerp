using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class AddReceivedEntryDetails
    {
        [Key]
        public int rtblid { get; set; }

        public int potblid { get; set; }
        public int RENO { get; set; }
        public int itemid { get; set; }
        public decimal receivedqty { get; set; }
    }
}
