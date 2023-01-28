using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.Common.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Web;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;
using MailKit.Security;
using ContentType = MimeKit.ContentType;

namespace Website.Services;

public class MsgService : IMsgService
{
    private readonly MailSettingsDto _mailSettings;
    private readonly IAppSettingService _appSettingService;
    private readonly IApplicationDbContext _context;
    public MsgService(IOptions<MailSettingsDto> mailSettings, IApplicationDbContext context, IAppSettingService appSettingService)
    {
        _mailSettings = mailSettings.Value;
        _context = context;
        _appSettingService = appSettingService;
    }

    public async Task SendEmailAsync(MailRequestDto mailRequest)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        email.Subject = mailRequest.Subject;
        var builder = new BodyBuilder();
        if (mailRequest.Attachments != null)
        {
            byte[] fileBytes;
            foreach (var file in mailRequest.Attachments)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }
                    builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                }
            }
        }
        builder.HtmlBody = mailRequest.Body;
        email.Body = builder.ToMessageBody();
        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
    }

    public async Task SendEmail(MailRequestDto mail)
    {
        var client = new SendGridClient(_appSettingService.GetAppSettingValue("SendGrid", "APIKey").Result);
        var from = new EmailAddress(_appSettingService.GetAppSettingValue("SendGrid", "SenderEmail").Result);
        var subject = mail.Subject;
        var to = new EmailAddress(mail.ToEmail);
        var plainTextContent = "and easy to do anywhere";
        var htmlContent = mail.Body;
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //msg.AddAttachments((IEnumerable<SendGrid.Helpers.Mail.Attachment>)mail.Attachments);
        if (mail.Attachments != null)
        {
            msg.AddAttachments((IEnumerable<SendGrid.Helpers.Mail.Attachment>)mail.Attachments);
        }
        var response = await client.SendEmailAsync(msg);
    }

    public async Task SendOTPEmail(string ToEmail, string code, string Name)
    {
        var client = new SendGridClient(_appSettingService.GetAppSettingValue("SendGrid", "APIKey").Result);
        var from = new EmailAddress(_appSettingService.GetAppSettingValue("SendGrid", "SenderEmail").Result);
        var subject = "Imploy OneTime Password";
        var to = new EmailAddress(ToEmail);
        var plainTextContent = "Imploy OneTime Password";
        string htmlCode = "";
        using (WebClient x = new WebClient())
        {
            //var url = "https://localhost:44326/Account/EmailTemplate?code=" + code + "&&name=" + Name;
            var url = _appSettingService.GetAppSettingValue("AppSettings", "AdminUrl").Result + "/Account/EmailTemplate?code=" + code + "&&name=" + Name;
            htmlCode = x.DownloadString(url.ToString());
        }


        var htmlContent = htmlCode;
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);
    }

    public async Task<bool> SendSMSEGAsync(string phone, string message)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_appSettingService.GetAppSettingValue("SMSSettings", "EGclientBaseAddress").Result);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            var builder = new UriBuilder(client.BaseAddress);
            builder.Port = int.Parse(_appSettingService.GetAppSettingValue("SMSSettings", "EGclientport").Result);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["UserName"] = _appSettingService.GetAppSettingValue("SMSSettings", "EGclientUserName").Result;
            query["Password"] = _appSettingService.GetAppSettingValue("SMSSettings", "EGclientPassword").Result;
            query["language"] = _appSettingService.GetAppSettingValue("SMSSettings", "EGclientlanguage").Result;
            query["sender"] = _appSettingService.GetAppSettingValue("SMSSettings", "EGclientsender").Result;
            query["Mobile"] = phone;
            query["message"] = message;
            builder.Query = query.ToString();
            string url = builder.ToString();
            response = await client.PostAsync(url, null);
            return response.IsSuccessStatusCode;
        }
    }

    public async Task<bool> SendSMSAsync(string phone, string message)
    {

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_appSettingService.GetAppSettingValue("SMSSettings", "SARclientBaseAddress").Result);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            var builder = new UriBuilder(client.BaseAddress);
            builder.Port = int.Parse(_appSettingService.GetAppSettingValue("SMSSettings", "SARclientport").Result);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["username"] = _appSettingService.GetAppSettingValue("SMSSettings", "SARclientUserName").Result;
            query["password"] = _appSettingService.GetAppSettingValue("SMSSettings", "SARclientPassword").Result;
            query["numbers"] = phone;
            query["sender"] = _appSettingService.GetAppSettingValue("SMSSettings", "SARclientsender").Result;
            query["message"] = message;
            builder.Query = query.ToString();
            string url = builder.ToString();
            response = await client.PostAsync(url, null);

            return response.IsSuccessStatusCode;


        }
    }
    public async Task<bool> SendWhatsAppAsync(string phone, string message)
    {

        //https://hiwhats.com/API/send?mobile=966549361945&password=123654789&instanceid=19448&message=test&numbers=966549361945&json=1&type=1
        //https://hiwhats.com/API/send?mobile=966549361945&password=c8b285fd1&instanceid=19476&message=test2&numbers=966549361945&json=1&type=1
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_appSettingService.GetAppSettingValue("WhatsAppSettings", "BaseAddress").Result);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            var builder = new UriBuilder(client.BaseAddress);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["mobile"] = _appSettingService.GetAppSettingValue("WhatsAppSettings", "mobile").Result;
            query["password"] = _appSettingService.GetAppSettingValue("WhatsAppSettings", "password").Result;
            query["instanceid"] = _appSettingService.GetAppSettingValue("WhatsAppSettings", "instanceid").Result;
            query["message"] = message;
            query["numbers"] = phone;
            query["json"] = _appSettingService.GetAppSettingValue("WhatsAppSettings", "json").Result;
            query["type"] = _appSettingService.GetAppSettingValue("WhatsAppSettings", "type").Result;
            builder.Query = query.ToString();
            string url = builder.ToString();
            response = await client.GetAsync(url);

            return response.IsSuccessStatusCode;
        }
    }
}
