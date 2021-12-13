using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace FinancialChat.Models
{
    public class MessageModel
    {
        [JsonProperty("userid")] public int UserId { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("roomid")] public long RoomId { get; set; }
        [JsonProperty("room")] public string Room { get; set; }
        [JsonProperty("message")] public string Message { get; set; }

    }
}