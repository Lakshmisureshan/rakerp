using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class AddMIDetails
    {
        public int mid { get; set; }

        public int itemid { get; set; }
        public decimal acceptedqty { get; set; }
        public decimal rejectedqty { get; set; }
        public decimal holdqty { get; set; }
        public int  rtblid { get; set; }
    }
}
