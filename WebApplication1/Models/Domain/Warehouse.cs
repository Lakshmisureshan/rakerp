using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Warehouse
    {
        [Key]
        public int wId { get; set; }
        public string  warehousename { get; set; }
    }
}
