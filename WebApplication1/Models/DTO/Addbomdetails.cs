using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class Addbomdetails
    {


        public int itemid { get; set; }
        public double bomqty { get; set; }


        public int bomuomid { get; set; }
        public double price { get; set; }

        public int prodstageid { get; set; }
        public DateTime requireddate { get; set; }


        public int currencyid { get; set; }

        public int jobid { get; set; }



        public int bomrevno { get; set; }
        public int bomnumber { get; set; }
    }
}
