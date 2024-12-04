using WebApplication1.Models.Domain;
namespace WebApplication1.Models.DTO
{
    public class AddPODetailsDto
    {
    
        public int orderid { get; set; }
    
        public int poitemid { get; set; }
        public double poquantity { get; set; }
        
         public double pounitprice { get; set; }
        public string make { get; set; }

        public int prtblid { get; set; }
        public int prid { get; set; }
    }
}
