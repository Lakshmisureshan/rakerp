using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class AddProductdto
    {
        public int itemid { get; set; }


        public string itemcode { get; set; }

        public string itemname { get; set; }
        public string itemdescription { get; set; }
        public float price { get; set; }

     
        public int standarduomid { get; set; }
    }
}
