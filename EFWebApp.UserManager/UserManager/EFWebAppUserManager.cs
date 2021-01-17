using Baseline.Dates;
using EFWebApp.Data.Models.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.UserManager
{
    public class EFWebAppUserManager : IEFWebAppUserManager
    {
        private readonly IHttpContextWrapper _httpContextWrapper;
        private readonly ISystemTime _systemTime;

        public EFWebAppUserManager(IHttpContextWrapper httpContextWrapper, ISystemTime systemTime)
        {
            _httpContextWrapper = httpContextWrapper;
            _systemTime = systemTime;
        }

        public bool IsAnonymous
        {
            get
            {
                return _httpContextWrapper.GetUserId() == 0;
            }
        }

      

        public async Task<IdentityResult> AccessFailedAsync(int id)
        {
            return await _httpContextWrapper.GetApplicationUserManager().AccessFailedAsync(id);
        }

        public async Task<IdentityResult> AddPasswordAsync(int id, string newPassword)
        {
            return await _httpContextWrapper.GetApplicationUserManager().AddPasswordAsync(id, newPassword);
        }

        public async Task<IdentityResult> ChangePasswordAsync(int id, string currentPassword, string newPassword)
        {
            return await _httpContextWrapper.GetApplicationUserManager().ChangePasswordAsync(id, currentPassword, newPassword);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(int id, string code)
        {
            return await _httpContextWrapper.GetApplicationUserManager().ConfirmEmailAsync(id, code);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser login)
        {
            return await _httpContextWrapper.GetApplicationUserManager().CreateAsync(login);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser login, string password)
        {
            return await _httpContextWrapper.GetApplicationUserManager().CreateAsync(login, password);
        }

        public async Task<ApplicationUser> FindAsync(string usename, string password)
        {
            return await _httpContextWrapper.GetApplicationUserManager().FindAsync(usename, password);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _httpContextWrapper.GetApplicationUserManager().FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> FindByIdAsync(int id)
        {
            return await _httpContextWrapper.GetApplicationUserManager().FindByIdAsync(id);
        }

        public async Task<ApplicationUser> FindByNameAsync(string username)
        {
            return await _httpContextWrapper.GetApplicationUserManager().FindByNameAsync(username);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(int id)
        {
            return await _httpContextWrapper.GetApplicationUserManager().GenerateEmailConfirmationTokenAsync(id);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(int id)
        {
            return await _httpContextWrapper.GetApplicationUserManager().GeneratePasswordResetTokenAsync(id);
        }

        public async Task<IList<string>> GetRolesAsync(int id)
        {
            return await _httpContextWrapper.GetApplicationUserManager().GetRolesAsync(id);
        }

        public int GetUserId()
        {
            return _httpContextWrapper.GetUserId();
        }

        public UserManager<ApplicationUser, int> GetUserManager()
        {
            return _httpContextWrapper.GetApplicationUserManager();
        }

        public bool IsCurrentUserAuthorized(int id)
        {
            return _httpContextWrapper.GetUserId() == id;
        }

        public bool IsCurrentUserAuthorized(string[] ids)
        {
            if (ids.Contains(_httpContextWrapper.GetUserId().ToString()))
            {
                return true;
            }
           
                return false;
        }

        public async Task<bool> IsLockedOutAsync(int id)
        {
            return await _httpContextWrapper.GetApplicationUserManager().IsLockedOutAsync(id);
        }

        public async Task<IdentityResult> LockUserAccountAsync(int id)
        {
            return await _httpContextWrapper.GetApplicationUserManager().SetLockoutEndDateAsync(id, DateTime.MaxValue);
        }

        public async Task<IdentityResult> RemovePasswordAsync(int id)
        {
            return await _httpContextWrapper.GetApplicationUserManager().RemovePasswordAsync(id);
        }

        public async Task<IdentityResult> ResetPasswordAsync(int id, string code, string password)
        {
            return await _httpContextWrapper.GetApplicationUserManager().ResetPasswordAsync(id, code, password);
        }

        public async Task<IdentityResult> ResetPasswordAsync(int id, string password)
        {
             await _httpContextWrapper.GetApplicationUserManager().RemovePasswordAsync(id);
            return await _httpContextWrapper.GetApplicationUserManager().AddPasswordAsync(id, password);
        }

        public async Task<IdentityResult> UnlockUserAccountAsync(int id)
        {
            var result = await _httpContextWrapper.GetApplicationUserManager().SetLockoutEndDateAsync(id, _systemTime.UtcNow().AddMinutes(-1));
            if (result.Succeeded)
            {
                await _httpContextWrapper.GetApplicationUserManager().ResetAccessFailedCountAsync(id);
            }
            return result;
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUser login)
        {
            return await _httpContextWrapper.GetApplicationUserManager().UpdateAsync(login);
        }
    }
}
