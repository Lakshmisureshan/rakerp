namespace WebApplication1.Models.Domain
{
    public class Batchrev1
    {
        public int BatchID { get; set; }
        public decimal Quantity { get; set; }
        public int Invid { get; set; }
        public int Currencyid { get; set; }
        public int Uomid { get; set; }
        public decimal Price { get; set; }

        public string billofentryno { get; set; }
        public DateTime? billofentrydate { get; set; } // CHANGED TO DateTime?

        public Batchrev1(int batchID, decimal quantity, int invid, int currencyid, int uomid, decimal price, string billofentryno, DateTime? billofentrydate) // CHANGED PARAMETER TO DateTime?
        {
            BatchID = batchID;
            Quantity = quantity;
            Invid = invid;
            Currencyid = currencyid;
            Uomid = uomid;
            Price = price;

            this.billofentryno = billofentryno;   // FIX: Use 'this.' for properties
            this.billofentrydate = billofentrydate; // FIX: Use 'this.' for properties
        }
    }
}