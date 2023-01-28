using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.User.VM;
using Ansari_Website.Domain.Entities.Identity;
using Ansari_Website.Domain.Enums;
using Ansari_Website.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Website.Services;

public class UserOTPService : IUserOTPService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMsgService _messageService;

    public UserOTPService(IMsgService messageService, ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _messageService = messageService;
    }

    public async Task<UserOTPVM> GetByUserId(string UserId)
    {
        var data = await _context.UserOTPs.OrderByDescending(x => x.Id).FirstOrDefaultAsync(x => x.UserId == UserId);
        return _mapper.Map<UserOTPVM>(data);
    }

    public async Task<UserOTPVM> GetByKey(string Key)
    {
        var data = await _context.UserOTPs.FirstOrDefaultAsync(x => x.Key == Key);
        return _mapper.Map<UserOTPVM>(data);
    }


    public async Task<UserOTPVM> Insert(string UserId, int contactType)
    {
        // expire previce otp for customer 
        var lastOTP = await _context.UserOTPs.OrderByDescending(x => x.Id).FirstOrDefaultAsync(x => x.UserId == UserId && x.ContactType == contactType);
        if (lastOTP != null)
            lastOTP.IsActive = false;

        UserOTP userOTP = new UserOTP
        {
            UserId = UserId,
            OTP = Helper.GenerateOTP(),
            //OTP=1234,
            Key = Helper.GenerateOTP(6).ToString(),
            ContactType = contactType,
        };

        await _context.UserOTPs.AddAsync(userOTP);
        return await _context.SaveChangesAsync() > 0 ? _mapper.Map<UserOTPVM>(userOTP) : null;
    }
    public async Task<bool> ExpireOTP(int id)
    {
        var lastOTP = await _context.UserOTPs.LastOrDefaultAsync(x => x.Id == id);
        if (lastOTP != null)
            lastOTP.IsActive = false;
        return await _context.SaveChangesAsync() > 0 ? true : false;
    }

    public async Task<bool> SendOTP(string Email, string? phone, string OTP, int OTPMethod, string Name)
    {
        try
        {

            string message = "Recruting OneTime Password :" + OTP + "  أدخل هذا الكود بنفسك ولا تفصح عنه لأي شخص";
            if (OTPMethod == (int)EOTPMethods.Email && !string.IsNullOrEmpty(Email))
                await _messageService.SendOTPEmail(Email, OTP, Name/*new MailRequestDto { ToEmail = Email, Subject = "Recruting Verification Code", Body = message }*/);

            if (OTPMethod == (int)EOTPMethods.SMS && !string.IsNullOrEmpty(phone))
            {
                // check if the number is for egypt
                if (phone.Substring(0, 3).Equals("201"))
                    await _messageService.SendSMSEGAsync(phone, message);
                else
                    await _messageService.SendSMSAsync(phone, message);
            }

            if (OTPMethod == (int)EOTPMethods.WhatsApp && !string.IsNullOrEmpty(phone))
                await _messageService.SendWhatsAppAsync(phone, message);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public async Task<string?> ReSendOTP(string Key)
    {
        try
        {
            var UserOTP = await _context.UserOTPs.Where(x => x.Key == Key).Include(x => x.User).FirstOrDefaultAsync();
            if (UserOTP != null)
            {
                var createUserOTP = await Insert(UserOTP.UserId, UserOTP.ContactType);
                if (createUserOTP != null)
                {
                    var send = SendOTP(UserOTP.User.Email, null, createUserOTP.OTP.ToString(), (int)EOTPMethods.Email, UserOTP.User.FullName);
                    return createUserOTP.Key;
                }
            }
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }

    }

}
