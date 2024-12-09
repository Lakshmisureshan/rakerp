using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class AddPrdetails
    {
        [Key]
        public int prtblid { get; set; }
    
        public int prid { get; set; }

  
        public int pritemid { get; set; }

      
        public int bomid { get; set; }


        public float prqty { get; set; }
        public int  pruomid { get; set; }

    }
}
