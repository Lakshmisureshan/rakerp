using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Bom
    {
        [Key]
        public int bomid { get; set; }
        public Product Product { get; set; }
        public int itemid { get; set; }
        public double  bomqty { get; set; }
    
        public UOM UOM { get; set; }
        public int bomuomid { get; set; }
        public double   price { get; set; }
        public ProductionStages Productionstages { get; set; }
        public int prodstageid { get; set; }
        public DateTime RequiredDate { get; set; }

        public Currency currency { get; set; }
        public int currencyid { get; set; }
    }
}
