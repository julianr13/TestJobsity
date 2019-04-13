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
            if (message.Contains("/stock="))
            {
                string[] codeS = message.Split('=');
                string stock_code = codeS[1];
                GetStock getStock = new GetStock();
                string resBot = getStock.GetBotMessageStock(stock_code);
                Clients.All.broadcastMessage("Stock BOT", resBot);
            }

        }
    }
}