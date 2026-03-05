using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace ECommerce_PL.Utilis
{
    public class EmailSetting : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
 //587
            var client = new SmtpClient("smtp.gmail.com",587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("Email@gmail.com", "pqrt pouh fchh zppr")
            };

            return client.SendMailAsync(
                new MailMessage(from: "Email@gmail.com",
                                to: email,
                                subject, htmlMessage)

                { IsBodyHtml=true}    );
   
    }
    }
}
