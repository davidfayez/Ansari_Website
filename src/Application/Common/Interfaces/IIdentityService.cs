using Ansari_Website.Application.Common.Models;
using ERP.DAL.Domains;

namespace Ansari_Website.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
    Task<AspNetUser> AuthenticateUserAsync(string UserName, string Password, bool RememberMe);
    string GetUserRoleId(string id);
    Task<Result> DeleteUserAsync(string userId);
}
