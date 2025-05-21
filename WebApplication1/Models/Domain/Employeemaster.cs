using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Employeemaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int empid { get; set; }

        public string  empname { get; set; }
        public int empstatus { get; set; }

        public Company Company { get; set; }
        public int  companyid { get; set; }

        public Designation Designation { get; set; }
        public int designationid { get; set; }

        public int issupplier { get; set; } = 0;



    }
}
