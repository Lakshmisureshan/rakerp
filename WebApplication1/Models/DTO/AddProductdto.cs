using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class AddProductdto
    {
        public int itemid { get; set; }

        public int productcode { get; set; }
        public string itemcode { get; set; }

        public string itemname { get; set; }
        public string itemdescription { get; set; }
        public float price { get; set; }

     
        public int standarduomid { get; set; }
        public int itembudgetheaderid { get; set; }

        public int categoryid { get; set; }
        public int subcategoryid { get; set; }

        public string itembname { get; set; }
        public decimal reorderqty { get; set; }
        public decimal reorderlevel { get; set; }












    }
}
