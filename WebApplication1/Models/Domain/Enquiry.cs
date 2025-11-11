using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class Enquiry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Enquiryref { get; set; }
        public DateTime enquirydate { get; set; }
        public Customer Customer { get; set; }
        public int customerid { get; set; }
        public customercontact customercontact { get; set; }
        public int customercontactid { get; set; }
        public ApplicationUser ProjectManager { get; set; }
        public string projectmanagerid { get; set; }
        public ApplicationUser ProjectEngineer { get; set; }
        public string projectengineerid { get; set; }
        public JobType Enquirytype { get; set; }
        public int enquirytypeid { get; set; }


        public Enquirystatus Enquirystatus { get; set; }
        public int EnquiryStatusId { get; set; } = 1;
        public string ?  remarks  { get; set; }


        public int iscompleted { get; set; } = 0;
        public DateTime?  completiondate { get; set; }


        public int isverified { get; set; } = 0;



        public DateTime? verifiedbydate { get; set; }


        public ApplicationUser? Verifiedby { get;}

       public string ? verifiedbyuserid { get; set;}



        public ApplicationUser? Completedby { get; }


        public string? completedbybyuserid { get; set; }
















    }
}
