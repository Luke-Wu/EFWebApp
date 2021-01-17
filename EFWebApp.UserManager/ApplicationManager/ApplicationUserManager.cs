using EFWebApp.Data.Models.Identity;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using EFWebApp.Data.Context;
using Microsoft.Owin;

namespace EFWebApp.UserManager
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, int> userStore) : base(userStore)
        {

        }


        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new CustomUserStore(context.Get<ApplicationDbContext>()));

            manager.UserValidator = new UserValidator<ApplicationUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true

            };

            manager.UserLockoutEnabledByDefault = true;
            manager.MaxFailedAccessAttemptsBeforeLockout = 3;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(30);


            manager.PasswordValidator = new PasswordValidator
            {
                RequireUppercase = false,
                RequireLowercase = false,
                RequireDigit = true,
                RequiredLength = 6,
                RequireNonLetterOrDigit = false

            };

            return manager;

        }


    }
}
