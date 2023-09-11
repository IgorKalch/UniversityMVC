using Microsoft.AspNetCore.Mvc;
using UniversityApplication.User;

namespace WebUniversity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserContext _user;

        public HomeController(IUserContext user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            var user = _user.GetCurrentUser();

            if (user != null && (user.IsInRole("User") || user.IsInRole("Admin")))
            {
                return RedirectToAction("Index", "Course");
            }

            return View();
        }
    }
}
