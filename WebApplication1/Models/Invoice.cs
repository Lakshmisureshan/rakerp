using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Domain;

namespace WebApplication1.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int invoiceno { get; set; }
        public Customer Customer { get; set; }
        public int customerid { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string  InvoiceAddress { get; set; }
        public string LPOno { get; set; }
        public DateTime LPODate { get; set; }
        public DateTime DueDate { get; set;}
        public Job Job { get; set; }
        public int jobid { get; set; }
        public string?  remarks { get; set; }
        public Currency Currency { get; set; }
        public int invcurrencyid { get; set; }

        public int isregistered { get; set; } = 0;















    }
}
