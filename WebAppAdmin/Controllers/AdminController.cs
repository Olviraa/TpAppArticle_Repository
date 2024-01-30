﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet] //post,?
        [Route("Articles/{id}")]
        public ActionResult ArticleEdit(int id)
        {
            AdminService adminService = new AdminService();
            List<Produit> produits = new List<Produit>();
            produits = adminService.GetListeProduitService();
           
            return View(produits);
        }
        [HttpPost]
        [Route("Articles/{id}")]
        public ActionResult ArticleEditSend(int id)
        {
            int IdUpdated = id;
            string NomUpdated = Request.Form["produitNom"];
            int PrixUpdated = int.Parse(Request.Form["produitPrix"]);
            int QuantiteDisponibleUpdated = int.Parse(Request.Form["produitQuantiteDisponible"]);

            Produit produitUpdated = new Produit();
            produitUpdated.ID = IdUpdated;
            produitUpdated.Nom = NomUpdated;
            produitUpdated.Prix = PrixUpdated;
            produitUpdated.QuantiteDisponible = QuantiteDisponibleUpdated;


            AdminService adminService = new AdminService();
            
            adminService.UpdateProduitService(produitUpdated);

            return RedirectToAction("ListeArticles");
        }


    }
}
