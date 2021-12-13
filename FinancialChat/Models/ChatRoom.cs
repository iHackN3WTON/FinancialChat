using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialChat.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please type a chat room name")]
        [StringLength(50)]
        [Display(Name = "Chat Room Name")]
        public string Name { get; set; }
    }
}