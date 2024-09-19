using Microsoft.AspNetCore.Identity;
using WebApplication1.Models.Domain;
namespace WebApplication1.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwttoken(ApplicationUser user, List<string> roles);
    }
}
