using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinancialChat.Models;
using FinancialChat.ViewModels;

namespace FinancialChat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: ChatRooms
        public ActionResult Index()
        {
            var chatRooms = _context.ChatRooms.ToList();
            return View(chatRooms);
        }

        // GET: NewRoom
        public ActionResult New()
        {
            var chatRoom = new ChatRoomViewModel()
            {
                Id = 0
            };
            return View(chatRoom);
        }

        // POST: Save Room
        public ActionResult Save(ChatRoom chatRoom)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ChatRoomViewModel(chatRoom);
                return View("New", viewModel);
            }

            if (chatRoom.Id == 0)
            {
                var chatRoomInDb = _context.ChatRooms.Any(s => s.Name == chatRoom.Name);
                if (!chatRoomInDb)
                    _context.ChatRooms.Add(chatRoom);
            }
            else
            {
                var chatRoomInDb = _context.ChatRooms.Single(s => s.Id == chatRoom.Id);

                chatRoomInDb.Name = chatRoom.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            var chatRoomToDelete = _context.ChatRooms.Single(s => s.Id == id);
            _context.ChatRooms.Remove(chatRoomToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Chat(int chatRoomId = 0, string chatRoomName = "")
        {
            if (chatRoomId == 0)
                return RedirectToAction("Index", "Home");
            var chatRoom = new ChatRoomViewModel()
            {
                Id = chatRoomId,
                Name = chatRoomName
            };
            return View(chatRoom);
        }
    }
}