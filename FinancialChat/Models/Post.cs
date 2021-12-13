using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialChat.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
    }
}