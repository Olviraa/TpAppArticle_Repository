using Microsoft.AspNetCore.Mvc;

namespace WebAppAdmin.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
