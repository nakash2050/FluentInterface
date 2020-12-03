using System;
namespace FluentInterface.Contracts
{
    public interface IAddServer
    {
        public string SmtpServer { get; }

        IAddRecipientTo UsingSmtpServer(string server);
    }
}
