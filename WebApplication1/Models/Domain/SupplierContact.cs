using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class SupplierContact
    {
        [Key]
        public int suppliercontectid { get; set; }
        public Supplier Supplier { get; set; }
        public int supplierid { get; set; }
        public string  suppliercontactname { get; set; }
    }
}
