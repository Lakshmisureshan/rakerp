using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class setmanhourrate
    {

        [Key]
        public int rateid { get; set; }
        public decimal manhourrate { get; set; }
    }
}
