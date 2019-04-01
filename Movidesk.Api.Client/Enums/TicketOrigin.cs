using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Enums
{
    public enum TicketOrigin
    {
        WebByClient = 1,
        WebByAgent = 2,
        EmailReceive = 3,
        Trigger = 4,
        Chat = 5,
        EmailSentBySystem = 7,
        ContactForm = 8,
        WebApi = 9
    }
}
