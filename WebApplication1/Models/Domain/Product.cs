using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class Product
    {
        [Key]
        public int itemid { get; set; }
        public string itemcode { get; set; }
        public string itemname { get; set; }
        public string itemdescription { get; set; }
        public float price { get; set; }
        public UOM UOM { get; set; }
        public int standarduomid { get; set; }
        public BudgettHeader BudgettHeader { get; set; }
        public int itembudgetheaderid { get; set; }

    }
}
