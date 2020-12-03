using System;
using System.Linq;
using System.Text;
using FluentInterface.Contracts;

namespace FluentInterface
{
    public class MailBuilder : IAddServer, IAddRecipientTo, IAddRecipientCc, IAddRecipientBcc, IAddMailSubject, IAddMailBody, IAddAttachments, ISend
    {
        private string _smtpServer;
        private string[] _recipientsTo;
        private string[] _recipientsCc;
        private string[] _recipientsBcc;
        private string _subject;
        private string _body;
        private bool _isHtml;
        private string[] _attachments;


        public string SmtpServer => _smtpServer;
        public string[] RecipientsTo => _recipientsTo;
        public string[] RecipientsCc => _recipientsCc;
        public string[] RecipientsBcc => _recipientsBcc;
        public string Subject => _subject;
        public string Body => _body;
        public bool IsHtml => _isHtml;

        public string[] Attachments => _attachments;

        private MailBuilder()
        {
        }

        public static IAddServer CreateEmail()
        {
            return new MailBuilder();
        }

        public IAddRecipientTo UsingSmtpServer(string server)
        {
            _smtpServer = server;
            return this;
        }


        public IAddRecipientCc AddTo(params string[] recipients)
        {
            _recipientsTo = recipients;
            return this;
        }

        public IAddRecipientBcc AddCc(params string[] recipients)
        {
            _recipientsCc = recipients;
            return this;
        }

        public IAddMailSubject AddBcc(params string[] recipients)
        {
            _recipientsBcc = recipients;
            return this;
        }

        public IAddMailBody WithSubject(string subject)
        {
            _subject = subject;
            return this;
        }

        public IAddAttachments WithBody(string body, bool isHtml = true)
        {
            _body = body;
            _isHtml = isHtml;
            return this;
        }

        public ISend AddAttachments(params string[] attachments)
        {
            _attachments = attachments;
            return this;
        }

        public void Send()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"SMTP Server: {SmtpServer}");
            stringBuilder.AppendLine($"To: {string.Join(", ", RecipientsTo)}");
            stringBuilder.AppendLine($"Cc: {string.Join(", ", RecipientsCc)}");
            stringBuilder.AppendLine($"Bcc: {string.Join(", ", RecipientsBcc)}");
            stringBuilder.AppendLine($"Subject: {Subject}");
            stringBuilder.AppendLine($"Body: {Body}");
            stringBuilder.AppendLine($"Is HTML: {IsHtml}");
            stringBuilder.AppendLine($"Attachments: {string.Join(", ", Attachments)}");

            Console.WriteLine(stringBuilder.ToString());
            Console.WriteLine("Sending Email");
        }
    }
}
