namespace WebApplication1.Models.Domain
{
    public class CustomerContactDto
    {

        public int customerid { get; set; }
     
        public string name { get; set; }
        public string? designation { get; set; }
        public string? phone { get; set; }
        public string? mobile { get; set; }
        public string email { get; set; }
    }
}
