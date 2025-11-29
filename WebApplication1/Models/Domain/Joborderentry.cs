using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Joborderentry
    {
        [Key]
        public int jobentryidno  { get; set; }
        public Enquiry  Enquiry  { get; set; }
        public int  Enquiryref { get; set; }
        public Customer Customer { get; set; }
        public int customerid { get; set; }
        public string  projectname  { get; set; }
        public Customer Enduser { get; set; }
        public int enduserid  { get; set; }
        public string  jobdescription { get; set; }
        public decimal  ordervalue  { get; set; }
        public Currency  ordervaluecurrency  { get; set; }
        public int   ordervaluecurrencyid  { get; set; }
        public decimal enduservlaue { get; set; }
        public Currency enduservaluecurrency { get; set; }
        public int enduservaluecurrencyid  { get; set; }
        public string  warrantyterms  { get; set; }
        public string  paymentterms   { get; set; }
        public string ?  notes  { get; set; }








    }
}
