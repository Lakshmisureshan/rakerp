using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class POPaymentterms
    {
        [Key]
        public int paytermsid { get; set; }

        public string  paymenttermsname { get; set; }

    }
}
