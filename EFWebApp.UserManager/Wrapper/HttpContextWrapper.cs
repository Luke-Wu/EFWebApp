using EFWebApp.Data.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;


namespace EFWebApp.UserManager
{
    public class HttpContextWrapper : IHttpContextWrapper
    {
        private readonly HttpContext _httpContext;
        public HttpContextWrapper()
        {
            _httpContext = HttpContext.Current;
        }


        public UserManager<ApplicationUser, int> GetApplicationUserManager()
        {
           
            return _httpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        public int GetUserId()
        {
            if (_httpContext == null)
            {
                return 1;
            }
            return _httpContext.User.Identity.GetUserId<int>();
        }
    }
}
