using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class PRDetails
    {
        [Key]
        public int prtblid { get; set; }
        public PR PR { get; set; }
        public int prid { get; set; }

        public Product Product { get; set; }
        public int pritemid { get; set; }

        public Bom Bom { get; set; }
        public int bomid { get; set; }


        public float prqty { get; set; }


    }
}
