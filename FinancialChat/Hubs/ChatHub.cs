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
        //public void Send(string name, string message, string room)
        //{
        //    message = message.Trim();
        //    var roomId = int.Parse(room);
        //    if (message.Substring(0, 1).Equals("/"))
        //    {
        //        if (message.Substring(0, 7).ToLower().Equals("/stock="))
        //        {
        //            var stockBot = new StockBot.StockBot();
        //            var command = message.Substring(7).Trim();
        //            var stock = stockBot.RequestStock(command);
        //            Clients.Caller.addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), "Chat bot", stock);
        //        }else if (message.Substring(0, 8).ToLower().Equals("/stock ="))
        //        {
        //            var stockBot = new StockBot.StockBot();
        //            var command = message.Substring(8).Trim();
        //            var stock = stockBot.RequestStock(command);
        //            Clients.Caller.addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), "Chat bot", stock);
        //        }
        //        else
        //        {
        //            Clients.Caller.addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), "Chat bot", "Unknown command");
        //        }
        //    }
        //    else
        //    {
        //        Clients.Group(room).addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), name, message);
        //        var post = new Post()
        //        {
        //            DateTime = DateTime.Now,
        //            RoomId = int.Parse(room),
        //            RoomName = _context.ChatRooms.Any(r => r.Id == roomId) ? _context.ChatRooms.Single(r => r.Id == roomId).Name : "",
        //            UserId = User.Identity.GetUserId();
        //        };
        //    }
        //}
        public void Send(MessageModel messageModel)
        {
            messageModel.Message = messageModel.Message.Trim();
            if (messageModel.Message.Substring(0, 1).Equals("/"))
            {
                if (messageModel.Message.Substring(0, 7).ToLower().Equals("/stock="))
                {
                    var stockBot = new StockBot.StockBot();
                    var command = messageModel.Message.Substring(7).Trim();
                    var stock = stockBot.RequestStock(command);
                    Clients.Caller.addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), "Chat bot", stock);
                }else if (messageModel.Message.Substring(0, 8).ToLower().Equals("/stock ="))
                {
                    var stockBot = new StockBot.StockBot();
                    var command = messageModel.Message.Substring(8).Trim();
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
                Clients.Group(messageModel.RoomId.ToString()).addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), messageModel.UserName, messageModel.Message);
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
            Clients.Group(roomId, Context.ConnectionId).addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), "", name + " joined the group");
        }

        public void LeaveRoom(string roomName,string name)
        {
            Clients.Group(roomName, Context.ConnectionId).addNewMessageToPage(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), "", name + " leave the group");
            Groups.Remove(Context.ConnectionId, roomName);
        }
    }
}