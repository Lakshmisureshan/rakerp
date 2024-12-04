using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class PODeliveryTerms
    {
        [Key]
        public int deliveryid { get; set; }
        public string  deliveryterms { get; set; }
    }
}
