using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class manhour
    {
        [Key]
        public int mid { get; set; }
        public Job  Job  { get; set; }
        public int  jobid { get; set; }

        public Employeemaster employeemaster { get; set; }
        public int empid { get; set; }

        public DateTime   jobdate { get; set; } 

        public decimal  nh { get; set; }
        public decimal  ot  { get; set; }

        public string site { get; set; } = "N";

        public string type { get; set; } = "M";

        public DateTime  createddate { get; set; }

        public decimal mrate { get; set; } = 0;
    

    }
}
