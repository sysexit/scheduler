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
    public class UserOnboardedEventHandler : INotificationHandler<UserOnboardedEvent>
    {
        public Task Handle(UserOnboardedEvent notification, CancellationToken cancellationToken)
        {
            string path = @"/app/Emails/OnboardingEmail.txt";
            string domain = Environment.GetEnvironmentVariable("DOMAIN");
            string url = string.Format("https://hr.{0}/onboarding/{1}", domain, notification.Token);

            string email = File.ReadAllText(path);
            email = string.Format(email, url);

            var smtpClient = new SmtpClient(Environment.GetEnvironmentVariable("EMAIL_SERVER"))
            {
                Port = int.Parse(Environment.GetEnvironmentVariable("EMAIL_PORT")),
                Credentials = new NetworkCredential(Environment.GetEnvironmentVariable("EMAIL_ACCOUNT"), Environment.GetEnvironmentVariable("EMAIL_PASSWORD")),
                EnableSsl = bool.Parse(Environment.GetEnvironmentVariable("EMAIL_SSL")),
            };

            var subject = Environment.GetEnvironmentVariable("COMPANY") + " Staff Website";

            smtpClient.Send(Environment.GetEnvironmentVariable("EMAIL_FROM"), notification.Email, subject, email);
            return Task.CompletedTask;
        }
    }
}
