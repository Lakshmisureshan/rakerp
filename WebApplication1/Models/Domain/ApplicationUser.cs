using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models.Domain
{
   


        public class ApplicationUser : IdentityUser
        {
            // Add your custom fields here
            public string passcode { get; set; }
        }





    
}
