using MailKit.Net.Smtp;
using MimeKit;
using System;

namespace CryptoPriceBot.Notifications
{
    public class SmtpEmailNotificationService : INotificationService
    {
        // Make sure to change this to either your outlook email or gmail that you want to use.
        // You can also create a completely new email address to be extra safe
        private const string FromAddress = "fakemail@outlook.com";

        private const string FromName = "Bobby";

        private readonly string _toAddress;

        public SmtpEmailNotificationService(string toAddress)
        {
            _toAddress = toAddress;
        }

        public bool Notify(string message)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.To.Add(new MailboxAddress(FromName, _toAddress));
                mimeMessage.Subject = message;
                mimeMessage.Body = new TextPart { Text = message };
                mimeMessage.From.Add(new MailboxAddress(FromName, FromAddress));

                using var client = new SmtpClient();
                // Change the address to 'smtp.gmail.com' if you want to use gmail instead.
                client.Connect("SMTP.office365.com", 587, options: MailKit.Security.SecureSocketOptions.StartTls);

                // Authenticate with outlook/gmail, change the password!
                client.Authenticate(FromAddress, "changeme");
                client.Send(mimeMessage);
                client.Disconnect(true);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}