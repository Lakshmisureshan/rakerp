using WebApplication1.Models.Domain;
namespace WebApplication1.Models.DTO
{
    public class AddPO
    {
        public int Orderid { get; set; }
        public DateTime Podate { get; set; }
             public int jobid { get; set; }
      
                public int pocurrencyid { get; set; }
        public double poexchangerate { get; set; }
  
        public string createdbyid { get; set; }
   
     
        public int supplierid { get; set; }
        public string supplieraddress { get; set; }
        public string? Qtnref { get; set; }
        public DateTime? Qtndate { get; set; }
        public string? suppliertrnno { get; set; }
     
        public int podeliverytermsid { get; set; }
        public DateTime? deliverydate { get; set; }

        public int popaymenttermsid { get; set; }

        public int PaymenttermsDaysid { get; set; }
        public int suppliercontactid { get; set; }
        public int POPaymentterms2id { get; set; }
        public Boolean Mtcrequired { get; set; }
        public Boolean coorequired { get; set; }
        public Boolean predispatchinspection { get; set; }
        public Boolean warranty { get; set; }
        public Boolean chineseorgin { get; set; }
        public Boolean mtcpriortodispatch { get; set; }
        public Boolean extendedwarraty3years { get; set; }
        public Boolean qtnattached { get; set; }
        public Boolean qtnshippingdocs { get; set; }
        public Boolean approveddrawings { get; set; }
        public Boolean others { get; set; }
        public string Remarks { get; set; }
        


    }
}
