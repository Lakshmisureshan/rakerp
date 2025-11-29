using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace WebApplication1.Models.Domain
{
    public class Enquirydetails
    {
        [Key]
        public int enqtblid { get; set; }

        [JsonIgnore]
        public Enquiry Enquiry { get; set; }
        public int Enquiryref { get; set; }
        public string? description { get; set; }
        public DateTime  entrydate { get; set; }
        public ApplicationUser linedetailentryuser { get; set; }
        public string  entryuserid { get; set; }
    }
}
