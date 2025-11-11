using WebApplication1.Models.Domain;
namespace WebApplication1.Models.DTO
{
    public class Addenquiry
    {
       public int Enquiryref { get; set; }
        public DateTime enquirydate { get; set; }
         public int customerid { get; set; }
         public int customercontactid { get; set; }
         public string projectmanagerid { get; set; }
         public string projectengineerid { get; set; }
         public int enquirytypeid { get; set; }
         public string? remarks { get; set; }


        public string  userid { get; set; }
    }
}
