using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class DeliveryNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int deliveryno{ get; set; }
        public DateTime deliverydate { get; set; }
        public Customer Customer { get; set; }
        public int buyerid { get; set; }
        public string  buyerdeliveryaddress { get; set; }
        public string? buyertrnno { get; set;}
        public string? buyeriec { get; set; }
        public customercontact customercontact { get; set; }
        public int buyercontactid { get; set; }
        public Job Job { get; set; }
        public int jobid { get; set; }
        public string buyerlpono { get; set; }
        public DateTime buyerlpodate { get; set; }
        public string?  consigneename { get; set; }
        public string? consigneeaddress { get; set; }
        public string? consigneelpono { get; set; }
        public string? consigneelpodate { get; set; }
        public string? consigneetrnno { get; set; }
        public string? consigneeiec { get; set; }

        public string? vehicleno { get; set; }
        public string? receivedby { get; set; }
        public string? deliveredby { get; set; }


    }
}
