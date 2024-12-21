namespace WebApplication1.Models.Domain
{
    public class Batch
    {

      
            public int BatchID { get; set; }
            public decimal Quantity { get; set; }

            public Batch(int batchID, decimal quantity)
            {
                BatchID = batchID;
                Quantity = quantity;
            }
        
    }
}
