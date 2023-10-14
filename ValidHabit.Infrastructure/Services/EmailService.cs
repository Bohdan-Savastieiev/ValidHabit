using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using ValidHabit.Application.DTOs;
using ValidHabit.Application.Interfaces;
using ValidHabit.Infrastructure.ServiceConfigurations;
using ValidHabit.Application.Utilities;

namespace ValidHabit.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettingsOptions)
        {
            _emailSettings = emailSettingsOptions.Value;
        }

        public async Task<Result> SendEmailAsync(EmailDto emailDto)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailDto.From));
            email.To.Add(MailboxAddress.Parse(emailDto.To));
            email.Subject = emailDto.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailDto.Body };

            using var smtp = new SmtpClient();
            try
            {
                await smtp.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_emailSettings.Email, _emailSettings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return Result.Success();
            }
            catch (SmtpProtocolException)
            {
                return Result.Failure("Failed to send the email due to a server error.");
            }
            catch (AuthenticationException)
            {
                return Result.Failure("Failed to authenticate with the email server.");
            }
            catch (Exception)
            {
                return Result.Failure("Something went wrong.");
            }
        }
    }
}