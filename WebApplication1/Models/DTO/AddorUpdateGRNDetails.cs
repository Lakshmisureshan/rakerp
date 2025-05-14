using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class AddorUpdateGRNDetails
    {
        public int grnno { get; set; }
        public DateTime grndate { get; set; }
   
        public int pono { get; set; }

        public int currencyid { get; set; }
        public string ? billofentryno { get; set; }
        public DateTime?  billofentrydate { get; set; }
        public string  dono { get; set; }

        public string? remarks { get; set; }

        public ICollection<AddGrnDetails> grndetails { get; set; }
    }
}
