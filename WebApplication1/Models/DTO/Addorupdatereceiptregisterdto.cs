namespace WebApplication1.Models.DTO
{
    public class Addorupdatereceiptregisterdto
    {
     
        public int receiptid { get; set; }
        public int customerid { get; set; }
        public string userid { get; set; }
        public ICollection<Receiptregisterdto> receiptdetails { get; set; }



      

















    }
}
