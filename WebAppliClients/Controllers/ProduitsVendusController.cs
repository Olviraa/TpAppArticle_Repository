﻿using Microsoft.AspNetCore.Mvc;
using ModelsCommun;
using WebAppliClients.Services;
using WebAppliClients.Models.ViewModels;

namespace WebAppliClients.Controllers
{
    
    [Route("/")]
    public class ProduitsVendusController : Controller
    {
    
       [HttpPost]
       [Route("Panier")]
       public IActionResult AddProduitPanier(int IdProduit, int IdVente, int Quantite)
       {
            // RECEPTION DU produitVendu DU PRODUITVENDUSERVICE

            int QuantiteDispo = int.Parse(Request.Form["QuantiteDisponible"]);

            ProduitVenduService produitVenduReçu = new ProduitVenduService();
            var produitVenduTosend = produitVenduReçu.AddProduitPanier(IdProduit, IdVente, QuantiteDispo) ;

            return View(produitVenduTosend);
       }
        [HttpPost]
        [Route("")]
        public IActionResult ProduitAupDateDuPanier()
        {

            return null;
        }

        [HttpGet]
        [Route("PanierList")]
        public IActionResult ProduitsVendus()
        {
            ProduitVenduService produitVenduService = new ProduitVenduService();
            var produitsVendus = produitVenduService.GetListProduitVendu();          
            return View(produitsVendus);
        }
        [HttpGet]
        [Route("Panier/{id}")]
        public IActionResult DetailProduitVendu(int id)
        {
            ProduitVenduService produitService = new ProduitVenduService();
            var produitVendu = produitService.GetProduitVendu(id);
            return View(produitVendu);
        }


    }
}
