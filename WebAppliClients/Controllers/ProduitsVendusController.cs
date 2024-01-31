using Microsoft.AspNetCore.Mvc;
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


        [HttpGet]
        [Route("Panier")]
        public IActionResult ProduitsVendus()
        {
            ProduitVenduService produitVenduService = new ProduitVenduService();
            var produitsVendus = produitVenduService.GetListProduitVendu();
            ListProduitVenduViewModel listproduitvenduVM = new ListProduitVenduViewModel(produitsVendus);
            return View(listproduitvenduVM);
        }
        [HttpGet]
        [Route("PanierDetail/{id}")]
        public IActionResult DetailProduitVendu(int id)
        {
            ProduitVenduService produitService = new ProduitVenduService();
            var produitVendu = produitService.GetProduitVendu(id);
            return View(produitVendu);
        }


    }
}
