namespace WebApplication1.Models.DTO
{
    public class PODto
    {
        public int Orderid { get; set; }
        public DateTime Podate { get; set; }
        public int jobid { get; set; }
        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }
        public string createdbyid { get; set; }

        public string? modifiedbyid { get; set; }
        public string? poverifiedbyid { get; set; }

        public string? poauthorizedbyid { get; set; }
        public DateTime? poauthorizedDate { get; set; }
        public DateTime? poverifiedDate { get; set; }

        public string? suppliername { get; set; }

        public double TotalAmount { get; set; }

        public int pocurrencyid { get; set; }
        public string  postatusname { get; set; }
        public int postatusid { get; set; } 

        public string poverifiedusername { get; set; }
        public string currencyname { get; set; }

    }
}
