namespace WebApplication1.Models.DTO
{
    public class UpdateCustomerDto
    {
        public string customername { get; set; }
        public string ccode { get; set; }
        public string? shortname { get; set; }
        public string? trnno { get; set; }
        public string? iec { get; set; }
        public string email { get; set; }
        public string? pobox { get; set; }
        public string web { get; set; }
        public string? location { get; set; }
        public string? phone { get; set; }
        public int countryid { get; set; }
        public string? remarks { get; set; }
        public string address { get; set; }
        public int  customerid { get; set; }
    }
}
