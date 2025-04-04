using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class estimation
    {
        [Key]
        public int estimationid { get; set; }
        public Product Product { get; set; }
        public int   itemid  { get; set; }
        public ProductionStages ProductionStages { get; set; }
        public int applicationid { get; set; }

        public UOM UOM  { get; set; }
        public int  uomid  { get; set; }

        public Currency  Currency  { get; set; }
        public int currencyid  { get; set; }


        public decimal  quantity { get; set; }
        public decimal price { get; set; }
        public Job Job { get; set; }
        public int  jobid { get; set; }

        public int isconvertedtobom { get; set; } = 0;


    }
}
