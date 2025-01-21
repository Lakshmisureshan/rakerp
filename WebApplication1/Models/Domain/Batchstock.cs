namespace WebApplication1.Models.Domain
{
    public class Batchstock
    {



        public int BatchID { get; set; }
        public decimal Quantity { get; set; }

        public int Invid { get; set; }



        public int Currencyid { get; set; }
        public int Uomid { get; set; }
        public decimal Price { get; set; }
        public int  Jobid { get; set; }

        public Batchstock(int batchID, decimal quantity, int invid, int currencyid, int uomid, decimal price, int jobid )
        {
            BatchID = batchID;
            Quantity = quantity;
            Invid = invid;



            Currencyid = currencyid;
            Uomid = uomid;
            Price = price;
            Jobid = jobid;
        }











    }
}
