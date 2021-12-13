using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FinancialChat.Models;

namespace FinancialChat.ViewModels
{
    public class ChatRoomViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please type a chat room name")]
        [StringLength(50)]
        [Display(Name = "Chat Room Name")]
        public string Name { get; set; }

        public ChatRoomViewModel()
        {
            Id = 0;
        }

        public ChatRoomViewModel(ChatRoom chatRoom)
        {
            Id = chatRoom.Id;
            Name = chatRoom.Name;
        }
    }
}