namespace WebApplication1.Models.DTO
{
    public class PoItemPrintDto
    {
        public int No { get; set; }
        public string ItemCode { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }

        // NEW FIELDS
        public string ItemDescription { get; set; }
        public string Uom { get; set; }
    }
}
