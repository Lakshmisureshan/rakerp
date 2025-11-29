using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class deliverydetails
    {
        [Key]
        public int did  { get; set; }
        public DeliveryNote DeliveryNote { get; set; }
        public int deliveryid { get; set; }
        public string ? srno { get; set; }
        public string?  description { get; set; }
        public string? uom { get; set; }
        public string?   qty { get; set; }
        public int  counter { get; set; }
        public string?  remarks  { get; set; }
    }
}
