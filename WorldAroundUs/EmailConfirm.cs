namespace WorldAroundUs
{
    using System.Threading.Tasks;
    using MailKit.Net.Smtp;
    using MimeKit;

    namespace BlueLife
    {
        public class EmailConfirm
        {
            public EmailConfirm()
            {
            }

            public async Task SendEmailDefault(string email, string subject, string message)
            {
                MimeMessage emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("Электронная энциклопедия", "fanfanconfim@fanfan.com"));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587);

                    await client.AuthenticateAsync("fanfanconfim@gmail.com", "stbnkqraincqwfet");
                    await client.SendAsync(emailMessage);

                    await client.DisconnectAsync(true);
                }
            }
        }
    }
}