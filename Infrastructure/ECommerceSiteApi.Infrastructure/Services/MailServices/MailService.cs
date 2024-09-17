using ECommerceSiteApi.Application.Services.MailServices;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSiteApi.Infrastructure.Services.MailServices
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] to, string subject, string body, bool isBodyHtml = true)
        {
            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.Credentials = new NetworkCredential(_configuration["Mail:UserName"], _configuration["Mail:Password"]);
                smtpClient.EnableSsl = true;

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration["Mail:UserName"], "AlışverişSepeti", Encoding.UTF8),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isBodyHtml
                };

                foreach (var recipient in to)
                {
                    mailMessage.To.Add(recipient);
                }

                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
            }
        }

        public async Task SendPasswordResetMailAsync(string to,string userId, string resetToken)
        {

            // HTML içeriği oluşturulurken linklerin doğru biçimde yerleştirildiğinden emin olun
            StringBuilder mail = new StringBuilder();
            mail.AppendLine("Merhaba,<br><br>");
            mail.AppendLine("Eğer yeni şifre talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz.<br>");
            mail.AppendLine($"<a target=\"_blank\" href=\"{_configuration["AngularClientUrl"]}/updatePassword/{userId}/{resetToken}\">");
            mail.AppendLine("<strong>Yeni şifre talebi için tıklayınız...</strong></a><br><br>");
            mail.AppendLine("<span style=\"font-size:12px;\">NOT : Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen bu maili ciddiye almayınız.</span><br><br>");
            mail.AppendLine("Saygılarımızla...<br><br><br>TeknoXPress");

            await SendMailAsync(to, "Şifre Yenileme Talebi", mail.ToString());
        }
    }
}
