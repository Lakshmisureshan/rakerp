using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Domain;

namespace WebApplication1.Models
{
    public class AddGrnDetails
    {
        [Key]
     
        


        public int itemid { get; set; }
        public int inuomid { get; set; }
        public int pouomid { get; set; }

        public double  mf { get; set; }

        public decimal grnqty { get; set; }
        public int uomid { get; set; }
    }
}
