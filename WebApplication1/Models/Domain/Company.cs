using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int companyid { get; set; }
        public string  companyname { get; set; }
        public string companycode { get; set; }
        public DateTime ?  createddate { get; set; }
    }
}
