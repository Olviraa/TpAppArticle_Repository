using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppliClients.Models;

namespace WebAppliClients.Controllers
{
    [Route("/")]
    public class ClientsController : Controller
    {
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(ILogger<ClientsController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        public IActionResult PageAccueil()
        {
            return View();
        }

        [Route("List")]
        public IActionResult ProductsList()
        {

            return View();
        }

        [Route("Detail")]
        public IActionResult ProductDetail()
        {

            return View();
        }
        [Route("Contact")]
        public IActionResult ContactAdmin()
        {
            return View();
        }
        /*
        [Route("/")]
        public IActionResult WishList()
        {
            return View();
        }*/


    }
}
