using Microsoft.AspNetCore.Identity;
using YoutubeWeb.DAL.Identity;

namespace YoutubeWeb.BLL.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(ApplicationUser user, UserManager<ApplicationUser> userManager);
    }
}
