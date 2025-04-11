using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class Product
    {
        [Key]
        public int itemid { get; set; }
        public int  productcode { get; set; }
        public string itemcode { get; set; }
        public string itemname { get; set; }
        public string itembname { get; set; }
        public string itemdescription { get; set; }
        public float price { get; set; }
        public UOM UOM { get; set; }
        public int standarduomid { get; set; }
        public BudgettHeader BudgettHeader { get; set; }
        public int itembudgetheaderid { get; set; }

        public Category Category { get; set; }
        public int categoryid { get; set; }


        public SubCategory SubCategory { get; set; }
        public int subcategoryid { get; set; }
        public decimal reorderqty { get; set; }
        public decimal reorderlevel  { get; set; }

    }
}
