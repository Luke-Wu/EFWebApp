using EFWebApp.Data.Models.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.UserManager
{
    public interface IEFWebAppUserManager
    {
        UserManager<ApplicationUser, int> GetUserManager();

        Task<ApplicationUser> FindAsync(string email, string password);
        Task<ApplicationUser> FindByIdAsync(int id);
        Task<ApplicationUser> FindByNameAsync(string username);
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<IdentityResult> CreateAsync(ApplicationUser login);
        Task<IdentityResult> CreateAsync(ApplicationUser login, string password);
        Task<IdentityResult> AddPasswordAsync(int id, string newPassword);
        Task<IdentityResult> RemovePasswordAsync(int id);      
        Task<IdentityResult> UpdateAsync(ApplicationUser login);
        Task<IdentityResult> ConfirmEmailAsync(int id, string code);
        Task<IdentityResult> ChangePasswordAsync(int id, string currentPassword, string newPassword);
        Task<IdentityResult> ResetPasswordAsync(int id, string code, string password);
        Task<IdentityResult> UnlockUserAccountAsync(int id);
        Task<IdentityResult> LockUserAccountAsync(int id);
        Task<string> GeneratePasswordResetTokenAsync(int id);
        Task<string> GenerateEmailConfirmationTokenAsync(int id);
        Task<IdentityResult> ResetPasswordAsync(int id, string password);
        Task<IdentityResult> AccessFailedAsync(int id);
        Task<bool> IsLockedOutAsync(int id);
        int GetUserId();
        bool IsAnonymous { get; }
        bool IsCurrentUserAuthorized(int id);
        bool IsCurrentUserAuthorized(string[] ids);
        //string[] GetAuthorizedUsers(Person person);
        //string[] GetAuthorizedUsers(List<Person> people);
        //bool IsValidSubscription(Person profile);

        Task<IList<string>> GetRolesAsync(int id);


    }
}
