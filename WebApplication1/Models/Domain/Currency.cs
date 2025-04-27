using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Domain
{
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int currencyid { get; set; }
        public string  currencyname { get; set; }
        public double exchangerate { get; set; }
    }
}
