using Microsoft.AspNetCore.Mvc;
using ModelsCommun;
using WebAppAdmin.Repository;
using WebAppAdmin.Service;
using WebAppAdmin.Views.Admin;

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
            AdminService adminService = new AdminService();
            List<Produit> produits = new List<Produit>();
            produits = adminService.GetListeProduitService();
            //MyViewModel model = new MyViewModel();
            //model = produits;
            return View(produits);
        }
        
    }
}
