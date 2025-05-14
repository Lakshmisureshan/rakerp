using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace WebApplication1.Models.Domain
{
    public class PO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Orderid { get; set; }
        public DateTime Podate { get; set; }
        public Job Job { get; set; }
        public int jobid { get; set; }
        public DateTime ? createddate { get; set; }
        public DateTime? updateddate { get; set;}
        public Currency  Currency { get; set; }
        public int pocurrencyid { get; set; }
        public double  poexchangerate  { get; set; }
        public ApplicationUser createdby { get; set; }
        public string   createdbyid  { get; set; }
        public ApplicationUser? modifiedby { get; set; }
        public string? modifiedbyid { get; set; }
        public ApplicationUser? Poverifiedby { get; set; }
        public string? poverifiedbyid { get; set; }
        public ApplicationUser? PoAuthorizedby{ get; set; }
        public string? PoAuthorizedbyid { get; set; }
        public DateTime? poauthorizedDate { get; set; }
        public DateTime? poverifiedDate { get; set; }
        public Supplier Supplier { get; set; }
        public int  supplierid { get; set; }
        public string  supplieraddress { get; set; }
        public SupplierContact SupplierContact { get; set; }
        public int  suppliercontactid  { get; set; }
        public string? Qtnref { get; set; }
        public DateTime? Qtndate { get; set; }
        public string? suppliertrnno { get; set; }
        public PODeliveryTerms PODeliveryTerms { get; set; }
        public int podeliverytermsid { get; set; }
        public DateTime? deliverydate { get; set; }
        public POPaymentterms POPaymentterms { get; set; }
        public int popaymenttermsid { get; set; }
        public PaymenttermsDays PaymenttermsDays { get; set; }
        public int PaymenttermsDaysid { get; set; }
        public Popaymentterms2 POPaymentterms2  { get; set; }
        public int POPaymentterms2id { get; set; }
        public Boolean  Mtcrequired { get; set; }
        public Boolean coorequired { get; set; }
        public Boolean  predispatchinspection { get; set; }
        public Boolean  warranty { get; set; }
        public Boolean chineseorgin { get; set; }
        public Boolean mtcpriortodispatch { get; set; }
        public Boolean extendedwarraty3years { get; set; }
        public Boolean qtnattached { get; set; }
        public Boolean qtnshippingdocs { get; set; }
        public Boolean approveddrawings { get; set; }
        public Boolean Others { get; set; }
        public string?  Remarks  { get; set; }
        public POStatus postatus { get; set; }
        public int postatusid { get; set; } = 1;


        public decimal discount { get; set; }

        public string?  paymenterm1description { get; set; }
       
    }
}
