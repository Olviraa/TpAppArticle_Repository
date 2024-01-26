using Microsoft.AspNetCore.Mvc;

namespace WebAppAdmin.Controllers
{
    [Route("/")]
    public class AdminController : Controller
    {
        // GET: AdminController
        [Route("")]
        public ActionResult AdminHome()
        {
            return View();
        }
        //[Route("Admin")]
        //public ActionResult AdminHome()
        //{
        //    return View();
        //}
        [HttpGet]
        [Route("Articles")]
        public ActionResult ListeArticles()
        {
            return View();
        }
        
    }
}
