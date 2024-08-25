using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class UomMultiplyingFactor
    {
        [Key]
        public int muid { get; set; }
        public Product Product { get; set; }
        public int itemid  { get; set; }
        public UOM FROMUOM { get; set; }
        public int fromuomid  { get; set; }
        public UOM TOUOM { get; set; }
        public int touomid  { get; set; }
        public int conversionfactor  { get; set; }

        public string  description  { get; set; }



    }
}
