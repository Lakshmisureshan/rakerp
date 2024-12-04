using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class DeliveryTerms
    {
        [Key]
        public int podeliveryid { get; set; }
        public int podeliveryterms { get; set; }
    }
}
