using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;

namespace Chatroom
{
    [HubName("symbolsChat")]
    public class Chat : Hub
    {
        public void send(string user, string message)
        {
            Clients.All.broadcastMessage(user, message);

        }
    }
}