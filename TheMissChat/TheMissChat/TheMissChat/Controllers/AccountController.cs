using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheMissChat.Data;
using TheMissChat.Models;

namespace TheMissChat.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }

            HttpContext.Session.SetString("Username", user.Username);

            return RedirectToAction("Index", "Chat");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            if (_context.Users.Any(u => u.Username == username))
            {
                ViewBag.Error = "Username already exists";
                return View();
            }

            var newUser = new User
            {
                Username = username,
                Password = password
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            HttpContext.Session.SetString("Username", newUser.Username);

            return RedirectToAction("Index", "Chat");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
