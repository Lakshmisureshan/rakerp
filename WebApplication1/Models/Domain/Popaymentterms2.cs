using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Popaymentterms2
    {
        [Key]
        public int paytermsid { get; set; }

        public string paymenttermsname { get; set; }
    }
}
