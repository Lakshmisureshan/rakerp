using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class FixedBudget
    {
        [Key]

        public int fixedbudgetid { get; set; }

        public BudgettHeader BudgetHeader { get; set; }
        public int budgetId { get; set; }

        public decimal fixedamount { get; set; } = 0;

        public int  revision { get; set; }


        public Job Job { get; set; }
        public int jobid  { get; set; }


    }
}
