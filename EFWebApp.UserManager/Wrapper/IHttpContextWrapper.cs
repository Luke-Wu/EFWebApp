using EFWebApp.Data.Models.Identity;
using Microsoft.AspNet.Identity;

namespace EFWebApp.UserManager
{
    public interface IHttpContextWrapper
    {
        int GetUserId();

        UserManager<ApplicationUser, int> GetApplicationUserManager();
    }
}
