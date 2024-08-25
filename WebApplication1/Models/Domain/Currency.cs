using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Currency
    {
        [Key]
        public int currencyid { get; set; }
        public string  currencyname { get; set; }
        public double exchangerate { get; set; }
    }
}
