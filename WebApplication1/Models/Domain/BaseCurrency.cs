using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class BaseCurrency
    {

        [Key]
        public int basecurrencyid { get; set; }
        public string  basecurrency { get; set; }
    }
}
