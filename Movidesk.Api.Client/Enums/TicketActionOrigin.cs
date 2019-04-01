using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Enums
{
    public enum TicketActionOrigin
    {
        FirstAction = 0,
        WebByClient = 1,
        WebByAgent = 2,
        EmailReceive = 3,
        Trigger = 4,
        ChatOnline = 5,
        ChatOffline = 6,
        EmailSentBySystem = 7,
        ContactForm = 8,
        WebApi = 9
    }
}
