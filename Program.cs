using System;

namespace FluentInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            MailBuilder
                .CreateEmail()
                .UsingSmtpServer("smtp.google.com")
                .AddTo("email1@gmail.com", "email2@gmail.com")
                .AddCc("email3@gmail.com", "email4@gmail.com")
                .AddBcc(new string[] { })
                .WithSubject("This is a subject")
                .WithBody("This is the body")
                .AddAttachments(new string[] { "Attachment1", "Attachment2" })
                .Send();

            Console.ReadLine();
        }
    }
}
