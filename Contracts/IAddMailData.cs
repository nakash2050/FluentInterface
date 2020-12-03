using System;
namespace FluentInterface.Contracts
{
    public interface IAddMailSubject
    {
        public string Subject { get; }

        IAddMailBody WithSubject(string subject);
    }

    public interface IAddMailBody
    {
        public string Body { get; }
        public bool IsHtml { get; }

        IAddAttachments WithBody(string body, bool isHtml = true);
    }

    public interface IAddAttachments
    {
        public string[] Attachments { get; }

        ISend AddAttachments(params string[] attachments);
    }
}
