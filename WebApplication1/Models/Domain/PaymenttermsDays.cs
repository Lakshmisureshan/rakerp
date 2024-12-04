using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class PaymenttermsDays
    {

        [Key]
        public int paydaysid { get; set; }

        public string  paydaynames { get; set; }
    }
}
