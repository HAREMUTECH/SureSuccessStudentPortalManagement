using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SureSuccessStudentPortal.Web.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SureSuccessStudentPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            if (loginDto.Password == Constant.Password && loginDto.Email == Constant.Email)
            {
                return RedirectToAction("Index", "StudentRegistration");
            }
            else
            {
                return View("login");
            }
        }
    }
}