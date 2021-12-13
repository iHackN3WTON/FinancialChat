using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace FinancialChat.Models
{
    public class MessageModel
    {
        [JsonProperty("userid")] public string UserId { get; set; }
        [JsonProperty("username")] public string UserName { get; set; }
        [JsonProperty("roomid")] public string RoomId { get; set; }
        [JsonProperty("roomname")] public string RoomName { get; set; }
        [JsonProperty("message")] public string Message { get; set; }

    }
}