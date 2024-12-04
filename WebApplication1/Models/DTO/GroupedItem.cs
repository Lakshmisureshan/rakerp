namespace WebApplication1.Models.DTO
{
    public class GroupedItem
    {
        public int orderid { get; set; }
        public int PoItemId { get; set; }
            public double TotalQuantity { get; set; }
            public double UnitPrice { get; set; }
            public string Make { get; set; }

        public int prtblid { get; set; }

    }
}
