using static WebApplication1.Models.Domain.Batch1;
namespace WebApplication1.Models.Domain
{
    public class Batch1
    {
        public decimal Quantity { get; set; }
        public int Invid { get; set; }
        public int Fromjobid { get; set; }
        public int ToJobid { get; set; }
        public int Uomid { get; set; }
        public decimal Invunitprice { get; set; }

        public int Invcurrencyid { get; set; }
        public Batch1( decimal quantity, int invid , int fromjobid, int tojobid, int uomid, decimal  invunitprice, int invcurrencyid)
            {
         
            Quantity = quantity;
            Invid = invid;
            Fromjobid = fromjobid;
            ToJobid = tojobid;
            Uomid = uomid;
            Invunitprice = invunitprice;
            Invcurrencyid = invcurrencyid;

            }
    }
}
