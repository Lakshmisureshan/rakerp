using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class Deliveryheaderprintdto
    {

        public int deliveryno { get; set; }
        public DateTime deliverydate { get; set; }
        public Customer Customer { get; set; }
        public string  buyername { get; set; }
        public string buyerdeliveryaddress { get; set; }
        public string? buyertrnno { get; set; }
        public string? buyeriec { get; set; }
        public customercontact customercontact { get; set; }
        public string  buyercontactname { get; set; }
        public Job Job { get; set; }
        public int jobid { get; set; }
        public string buyerlpono { get; set; }
        public DateTime buyerlpodate { get; set; }
        public string? consigneename { get; set; }
        public string? consigneeaddress { get; set; }
        public string? consigneelpono { get; set; }
        public string? consigneelpodate { get; set; }
        public string? consigneetrnno { get; set; }
        public string? consigneeiec { get; set; }

        public string? vehicleno { get; set; }
        public string? receivedby { get; set; }
        public string? deliveredby { get; set; }

        public List<Deliverynoteitemdto> LineItems { get; set; }


        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyTelFax { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyTrn { get; set; }






    }
}
