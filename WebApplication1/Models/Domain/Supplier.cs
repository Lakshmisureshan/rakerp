using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class Supplier
    {
        [Key]
        public int supplierid { get; set; }
        public string  suppliername { get; set; }
        public string  supplieraddress { get; set; }
        public string? suppliertrnno { get; set; }
        public string ? supplierpoboxno{ get; set; }
        public string?  webaddress { get; set; }
        public string? emailaddress { get; set; }
        public string? phoneno { get; set; }
        public string? fax { get; set; }
        public string? remarks { get; set; }
        public DateTime createddate { get; set; }

    }
}
