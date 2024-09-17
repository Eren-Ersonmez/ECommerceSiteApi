
namespace ECommerceSiteApi.Application.Services.MailServices;

public interface IMailService
{
    Task SendMailAsync(string to,string subject,string body,bool isBodyHtml=true);
    Task SendMailAsync(string[] to, string subject, string body, bool isBodyHtml = true);
    Task SendPasswordResetMailAsync(string to, string userId, string resetToken);
}
