using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class Deliverynoteitemdto
    {

        public int did { get; set; }
 
        public int deliveryid { get; set; }
        public string? srno { get; set; }
        public string? description { get; set; }
        public string? uom { get; set; }
        public string? qty { get; set; }
        public int counter { get; set; }
        public string? remarks { get; set; }


    }
}
