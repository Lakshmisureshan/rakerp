using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class Country
    {
        [Key]
        public  int  countryid  { get; set; }
        public string  countryname { get; set; }
    }
}
