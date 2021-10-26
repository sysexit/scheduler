using Auth.Infrastructure.Events;
using MediatR;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Infrastructure.EventHandler
{
    public class ForgotPasswordEventHandler : INotificationHandler<ForgotPasswordEvent>
    {
        public Task Handle(ForgotPasswordEvent notification, CancellationToken cancellationToken)
        {
            string path = @"/app/Emails/ForgotPasswordEmail.txt";
            string domain = Environment.GetEnvironmentVariable("DOMAIN");
            string url = string.Format("https://staff.{0}/resetpassword?email={1}&token={2}", domain, notification.Email, notification.Token);

            string email = File.ReadAllText(path);
            email = string.Format(email, url);

            var smtpClient = new SmtpClient(Environment.GetEnvironmentVariable("EMAIL_SERVER"))
            {
                Port = int.Parse(Environment.GetEnvironmentVariable("EMAIL_PORT")),
                Credentials = new NetworkCredential(Environment.GetEnvironmentVariable("EMAIL_ACCOUNT"), Environment.GetEnvironmentVariable("EMAIL_PASSWORD")),
                EnableSsl = bool.Parse(Environment.GetEnvironmentVariable("EMAIL_SSL")),
            };

            var subject = Environment.GetEnvironmentVariable("COMPANY") + " Password Reset";

            smtpClient.Send(Environment.GetEnvironmentVariable("EMAIL_FROM"), notification.Email, subject, email);
            return Task.CompletedTask;
        }
    }
}
