using System;
using System.Collections;

namespace FluentInterface.Contracts
{
    public interface IAddRecipientTo
    {
        string[] RecipientsTo { get; }

        IAddRecipientCc AddTo(params string[] recipients);
    }

    public interface IAddRecipientCc
    {
        string[] RecipientsCc { get; }

        IAddRecipientBcc AddCc(params string[] recipients);
    }

    public interface IAddRecipientBcc
    {
        string[] RecipientsBcc { get; }

        IAddMailSubject AddBcc(params string[] recipients);
    }
}
