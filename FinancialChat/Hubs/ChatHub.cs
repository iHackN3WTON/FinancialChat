using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;


namespace FinancialChat.Hubs
{

    public class ChatHub : Hub
    {
        public void Send(string name, string message, string roomName)
        {
            // Call the addNewMessageToPage method to update clients.
            // Clients.All.addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), name, message);

            if (message.Substring(0, 1).Equals("/"))
            {
                if (message.Substring(0, 7).ToLower().Equals("/stock="))
                {
                    var stockBot = new StockBot.StockBot();
                    var command = message.Substring(7).Trim();
                    var stock = stockBot.RequestStock(command);
                    Clients.Caller.addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), "Chat bot", stock);
                }else if (message.Substring(0, 8).ToLower().Equals("/stock ="))
                {
                    var stockBot = new StockBot.StockBot();
                    var command = message.Substring(8).Trim();
                    var stock = stockBot.RequestStock(command);
                    Clients.Caller.addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), "Chat bot", stock);
                }
                else
                {
                    Clients.Caller.addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), "Chat bot", "Unknown command");
                }
            }
            else
            {
                Clients.Group(roomName).addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), name, message);
            }
        }

        public void JoinRoom(string roomName, string name)
        {
            Groups.Add(Context.ConnectionId, roomName);
            Clients.Group(roomName, Context.ConnectionId).addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), "", name + " joined the group");
        }

        public void LeaveRoom(string roomName,string name)
        {
            Clients.Group(roomName, Context.ConnectionId).addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), "", name + " leave the group");
            Groups.Remove(Context.ConnectionId, roomName);
        }
    }
}