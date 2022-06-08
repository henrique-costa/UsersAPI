using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace UsersAPI.Model
{
    public class MailMessage
    {
        public List<MailboxAddress> Recipient { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public MailMessage(IEnumerable<string> recipient, string subject, int userId, string activationCode)
        {
            Recipient = new List<MailboxAddress>();
            Recipient.AddRange(recipient.Select(d => new MailboxAddress(string.Empty, d)));
            Subject = subject;
            Content = $"http://localhost:6000/ativa?UserId={userId}&ActivationCode={activationCode}";
        }
    }
}
