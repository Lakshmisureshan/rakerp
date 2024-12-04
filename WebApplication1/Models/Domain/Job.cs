using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models.Domain
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Jobid { get; set; }
        public Customer Customer { get; set; }
        public int  customerid { get; set; }
        public JobType JobType { get; set; }
        public int jobtypeid { get; set; }
        public DateTime jobdate { get; set; }
        public DateTime lpodate { get; set; }
        public string  lpono { get; set; }
        public ApplicationUser ProjectManager { get; set; }
        public string   projectmanagerid { get; set; }

        public ApplicationUser ProjectEngineer { get; set; }
        public string  projectengineerid { get; set; }

        public int totalnumber { get; set; }

        public ManufacturingBay ManufacturingBay { get; set; }

        public int  manufacturingbayid { get; set; }


        public QualityLevel QualityLevel { get; set; }

        public int qualitylevelid { get; set; }

        public DateTime podeliverydate { get; set; }


        public ProjectCategory ProjectCategory { get; set; }

        public int projectcategoryid { get; set; }




        public IsLDApplicable isldapp { get; set; }

        public int isldapplicable { get; set; }


        public string  ldpercent { get; set; }


        public Currency Currency { get; set; }
        public int currencyid { get; set; }
        public double  exchangerate { get; set; }
        public double ordervalue { get; set; }
        public double ordervaluebasecurrency { get; set; }
        public string projectname  { get; set; }
        public string paymentterms { get; set; }
        public string warrantyterms { get; set; }
        public string deliveryterms { get; set; }
        public int bomjobrevno { get; set; } = 0;
        public int bomjobstatusid { get; set; } = 0;

        public Customer Enduser { get; set; }
        public int enduserid { get; set; }


        public int mainjobid { get; set; } = 0;

        public DateTime expecteddeliverydate { get; set; }

    }
}
