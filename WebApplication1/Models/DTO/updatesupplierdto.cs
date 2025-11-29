using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class updatesupplierdto
    {


        [Key]
        public int supplierid { get; set; }
      
        public string supplieraddress { get; set; }
        public string? suppliertrnno { get; set; }
        public string? supplierpoboxno { get; set; }
        public string? webaddress { get; set; }
        public string? emailaddress { get; set; }
        public string? phoneno { get; set; }
        public string? fax { get; set; }
        public string? remarks { get; set; }
    

    }
}
