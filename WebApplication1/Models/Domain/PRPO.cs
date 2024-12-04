using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class PRPO
    {

        [Key]
        public int prpotblid { get; set; }
        public int prdetailsprtblid { get; set; }
        public PRDetails Prdetails { get; set; }
       public int Purchasedetailspotblid { get; set; }
       public Purchasedetails Purchasedetails { get; set; }
        
    }
}
