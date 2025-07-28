namespace WebApplication1.Models.Domain
{
    public class Batch3
    {


        public int BatchID { get; set; }
        public decimal Quantity { get; set; }

        public int? Invid { get; set; }

        public decimal excrate { get; set; }

        public int Currencyid { get; set; }
        public int Uomid { get; set; }
        public decimal Price { get; set; }

        public Batch3(int batchID, decimal quantity, int? invid, int currencyid, int uomid, decimal price, decimal Exrate)
        {
            BatchID = batchID;
            Quantity = quantity;
            Invid = invid;
            Currencyid = currencyid;
            Uomid = uomid;
            Price = price;

            excrate = Exrate;
        }

    }
}
