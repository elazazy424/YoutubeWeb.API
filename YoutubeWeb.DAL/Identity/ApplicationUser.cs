using Microsoft.AspNetCore.Identity;

namespace YoutubeWeb.DAL.Identity
{
    public class ApplicationUser  : IdentityUser
    {
        public string DisplayName{ get; set; }
    }
}
