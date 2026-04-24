using Microsoft.AspNetCore.Mvc;
using TheMissChat.Data;
using System.Linq;

namespace TheMissChat.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }

        public IActionResult Index()
        {
            if (!IsAdmin())
                return Unauthorized();

            ViewBag.Users = _context.Users.ToList();
            ViewBag.Rooms = _context.ChatRooms.ToList();
            ViewBag.Messages = _context.Messages.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            if (!IsAdmin())
                return Unauthorized();

            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteRoom(int id)
        {
            if (!IsAdmin())
                return Unauthorized();

            var room = _context.ChatRooms.Find(id);
            if (room != null)
            {
                _context.ChatRooms.Remove(room);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteMessage(int id)
        {
            if (!IsAdmin())
                return Unauthorized();

            var msg = _context.Messages.Find(id);
            if (msg != null)
            {
                _context.Messages.Remove(msg);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
