using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class ProductionStages
    {
        [Key]
        public int prostageid { get; set; }

        public string  productionstagename { get; set; }
    }
}
