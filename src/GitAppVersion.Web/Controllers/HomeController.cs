using Microsoft.AspNetCore.Mvc;

namespace GitAppVersion.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
