using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class Supplier
    {
        [Key]
        public int supplierid { get; set; }
        public string  suppliername { get; set; }
        public string supplieraddress { get; set; }
        public string suppliertrnno { get; set; }
    }
}
