using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class AddJobDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Jobid { get; set; }

        public int customerid { get; set; }
     
        public int jobtypeid { get; set; }
        public DateTime jobdate { get; set; }
        public DateTime? lpodate { get; set; }
        public string? lpono { get; set; }
  
        public string projectmanagerid { get; set; }
        public int ?  mainjobid { get; set; }
        public string projectengineerid { get; set; }
        public int totalnumber { get; set; }

    
        public int manufacturingbayid { get; set; }



        public int qualitylevelid { get; set; }

        public DateTime ?  podeliverydate { get; set; }


        public int enduserid { get; set; }

        public int projectcategoryid { get; set; }




      
        public int isldapplicable { get; set; }


        public string ldpercent { get; set; }


  

        public int currencyid { get; set; }


        public decimal exchangerate { get; set; }
        public decimal ordervalue { get; set; }


        public decimal ordervaluebasecurrency { get; set; }

        public string projectname { get; set; }
        public string paymentterms { get; set; }
        public string warrantyterms { get; set; }
        public string deliveryterms { get; set; }
        public string jobdescription { get; set; }

    }
}
