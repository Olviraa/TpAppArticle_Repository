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
       public IActionResult AddProduitPanier(int venteId, int produitId, int quantity)
       {

            // CREATION DE LA VENTE

                //ProduitVenduService produitVenduCrée = new ProduitVenduService();
                // produitVenduCrée.CreatPanier();

            // RECEPTION DU produitVendu DU PRODUITVENDUSERVICE

            //int QuantiteDispo = int.Parse(Request.Form["QuantiteDisponible"]);
            

            ProduitVenduService produitVenduReçu = new ProduitVenduService();
            var IdDeLaVente = produitVenduReçu.AddProduitPanier(venteId, produitId, quantity) ;

            //return View(produitVenduTosend);

            return RedirectToAction("ListeProduits", "Produits", new { venteId = IdDeLaVente });

       }

        [HttpPost]
        [Route("")]
        public IActionResult ProduitAupDateDuPanier()
        {

            return null;
        }

        [HttpGet]
        [Route("PanierList/{id}")]
        public IActionResult ProduitsVendus(int id)
        {
            ProduitVenduService produitVenduService = new ProduitVenduService();
            var ventePanier = produitVenduService.GetListProduitVendu(id);          
            return View(ventePanier);
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
