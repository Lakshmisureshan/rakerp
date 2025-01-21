namespace WebApplication1.Models.DTO
{
    public class Addorupdateprdetails
    {
        public int prid { get; set; }
         public DateTime prdate { get; set; }
        public string  remarks { get; set; }
        public ICollection<updateprdetails> prlines { get; set; }
    }
}
