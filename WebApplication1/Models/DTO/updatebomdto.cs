namespace WebApplication1.Models.DTO
{
    public class updatebomdto
    {
        public int bomid { get; set; }
        public int bomqty { get; set; }
        public int bomuomid { get; set; }
        public double  price { get; set; }
        public int prodstageid { get; set; }

        public DateTime requiredDate { get; set; }
        public int  currencyid { get; set; }

    }
}