using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.User.VM;

namespace Ansari_Website.Application.Common.Interfaces;
public interface IUserOTPService
{
    Task<UserOTPVM> Insert(string UserId, int contactType);
    Task<UserOTPVM> GetByUserId(string UsersId);
    Task<bool> SendOTP(string Email, string phone, string OTP, int OTPMethod, string Name);
    Task<UserOTPVM> GetByKey(string CustomerKey);
    Task<string?> ReSendOTP(string Key);
}
