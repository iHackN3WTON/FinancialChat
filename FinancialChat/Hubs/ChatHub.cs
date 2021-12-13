using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using FinancialChat.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity;


namespace FinancialChat.Hubs
{

    public class ChatHub : Hub
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public void Send(MessageModel messageModel, string roomId)
        {
            messageModel.Message = messageModel.Message.Trim();
            if (messageModel.Message.Substring(0, 1).Equals("/"))
            {
                if (messageModel.Message.Substring(0, 7).ToLower().Equals("/stock="))
                {
                    var stockBot = new StockBot.StockBot();
                    var command = messageModel.Message.Substring(7).Trim();
                    var stock = stockBot.RequestStock(command);
                    Clients.Caller.addNewMessageToPage(String.Format("{0:yyyy/MM/dd} {0:HH:mm:ss}", DateTime.Now), "Chat bot", stock);
                }else if (messageModel.Message.Substring(0, 8).ToLower().Equals("/stock ="))
                {
                    var stockBot = new StockBot.StockBot();
                    var command = messageModel.Message.Substring(8).Trim();
                    var stock = stockBot.RequestStock(command);
                    Clients.Caller.addNewMessageToPage(String.Format("{0:yyyy/MM/dd} {0:HH:mm:ss}", DateTime.Now), "Chat bot", stock);
                }
                else
                {
                    Clients.Caller.addNewMessageToPage(String.Format("{0:yyyy/MM/dd} {0:HH:mm:ss}", DateTime.Now), "Chat bot", "Unknown command");
                }
            }
            else
            {
                Clients.Group(roomId).addNewMessageToPage(String.Format("{0:yyyy/MM/dd} {0:HH:mm:ss}", DateTime.Now), messageModel.UserName, messageModel.Message);
                var post = new Post()
                {
                    DateTime = DateTime.Now,
                    RoomId = int.Parse(messageModel.RoomId),
                    RoomName = messageModel.RoomName,
                    UserId = messageModel.UserId,
                    UserName = messageModel.UserName,
                    Message = messageModel.Message
                };
                _context.Posts.Add(post);
                _context.SaveChanges();
            }
        }

        public void JoinRoom(string roomId, string name)
        {
            Groups.Add(Context.ConnectionId, roomId);
            Clients.Group(roomId, Context.ConnectionId).addNewMessageToPage(String.Format("{0:yyyy/MM/dd} {0:HH:mm:ss}", DateTime.Now), "", name + " joined the group");
        }

        public void LeaveRoom(string roomId,string name)
        {
            Clients.Group(roomId, Context.ConnectionId).addNewMessageToPage(String.Format("{0:yyyy/MM/dd} {0:HH:mm:ss}", DateTime.Now), "", name + " leave the group");
            Groups.Remove(Context.ConnectionId, roomId);
        }
    }
}