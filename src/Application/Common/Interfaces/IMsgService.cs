using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.Common.Models;

namespace Ansari_Website.Application.Common.Interfaces;
public interface IMsgService
{
    Task SendEmailAsync(MailRequestDto mailRequest);

    Task SendEmail(MailRequestDto mail);
    Task<bool> SendSMSEGAsync(string phone, string message);
    Task<bool> SendSMSAsync(string phone, string message);
    Task<bool> SendWhatsAppAsync(string phone, string message);
    Task SendOTPEmail(string ToEmail, string code, string Name);

}
