using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class PRwithUsernameDto
    {
        public PR PR { get; set; }
        public string VerifiedByUsername { get; set; }
    }
}
