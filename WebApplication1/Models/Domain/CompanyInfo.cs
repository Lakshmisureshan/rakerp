using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class CompanyInfo
    {
        [Key]
        public int Id { get; set; } // Primary key, likely always 1 for a single company

        [Required]
        public string CompanyName { get; set; } = "Ace Cranes & Engineering FZ-LLC";
        public string Companypobox { get; set; } = "P.O Box 85652, RAK-UAE";
        public string CompanyAddressLine2 { get; set; } = "RAKEZ, Al Hamra, RAK"; // As seen in header
        public string Companycountry { get; set; } = "UAE";
        public string CompanyPhone { get; set; } = "+971 7 2445002";
        public string CompanyFax { get; set; } = "+971 6 5269062";
        public string CompanyEmail { get; set; } = "info@ace-me.com";
        public string CompanyWebsite { get; set; } = "www.ace-me.com";
        public string CompanyTRN { get; set; } = "100296598400003";
        public string InvoiceFormatNo { get; set; } = "ACE-ACC-F-03, REV.00";
        public string ClarificationContact { get; set; } = "00971 56 610 3421";
        public int ClarificationDays { get; set; } = 7;

        public string Bank1Name { get; set; } = "Mashreq Bank Psc";
        public string Bank1Branch { get; set; } = "Branch 12, King Abdul Aziz Branch Sharjah, UAE";
        public string Bank1AEDAccount { get; set; } = "AE 41 0330 0000 1900 0028 744";
        public string Bank1USDAccount { get; set; } = "AE 29 0330 0000 1900 0036 332";
        public string Bank1SWIFT { get; set; } = "BOMLAEAD";

        public string Bank2Name { get; set; } = "NBAD";
        public string Bank2Branch { get; set; } = "Ras Al Riffa Branch, Ras Al Khaimah, UAE";
        public string Bank2AEDAccount { get; set; } = "AE 89 0350 0000 0620 6483 580";
        public string Bank2USDAccount { get; set; } = "AE 50 0350 0000 0620 6483 603";
        public string Bank2SWIFT { get; set; } = "NBADAEAARAK";
    }
}