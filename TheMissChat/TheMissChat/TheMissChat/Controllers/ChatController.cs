using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheMissChat.Data;
using TheMissChat.Models;

namespace TheMissChat.Controllers
{
    public class ChatController : Controller
    {
        private readonly AppDbContext _context;

        public ChatController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Rooms");
        }

        public IActionResult Rooms()
        {
            var username = HttpContext.Session.GetString("Username");
            if (username == null)
                return RedirectToAction("Login", "Account");

            var rooms = _context.ChatRooms.ToList();
            return View(rooms);
        }

        public IActionResult CreateRoom()
        {
            var username = HttpContext.Session.GetString("Username");
            if (username == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public IActionResult CreateRoom(string name)
        {
            var username = HttpContext.Session.GetString("Username");
            if (username == null)
                return RedirectToAction("Login", "Account");

            if (string.IsNullOrWhiteSpace(name))
            {
                ViewBag.Error = "Room name is required";
                return View();
            }

            var room = new ChatRoom { Name = name };
            _context.ChatRooms.Add(room);
            _context.SaveChanges();

            return RedirectToAction("Rooms");
        }

        // -----------------------------
        // ROOM: GET + POST в един метод
        // -----------------------------
        [HttpGet, HttpPost]
        public IActionResult Room(int id, string? text)
        {
            var username = HttpContext.Session.GetString("Username");
            if (username == null)
                return RedirectToAction("Login", "Account");

            var room = _context.ChatRooms.FirstOrDefault(r => r.Id == id);
            if (room == null) return NotFound();

            // Ако има текст → записваме съобщение
            if (!string.IsNullOrWhiteSpace(text))
            {
                var msg = new Message
                {
                    User = username,
                    Text = text,
                    SentAt = DateTime.Now,
                    ChatRoomId = id
                };

                _context.Messages.Add(msg);
                _context.SaveChanges();
            }

            // Зареждаме всички съобщения
            var messages = _context.Messages
                .Where(m => m.ChatRoomId == id)
                .OrderBy(m => m.SentAt)
                .ToList();

            ViewBag.RoomName = room.Name;
            ViewBag.RoomId = room.Id;

            return View(messages);
        }
    }
}
