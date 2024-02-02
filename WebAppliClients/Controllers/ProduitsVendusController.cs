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
        //[HttpGet]
        //[Route("")] // Panier et idvente
        //public IActionResult ProduitsVendusAcocher()
        //{
        //    ProduitVenduService produitCocherService = new ProduitVenduService();
        //    var produitsVendu = produitCocherService.GetProduitVenduSelect();
        //    return View(produitsVendu);
        //}

        [HttpPost]
        [Route("SupprimerDuPanier")]
        public IActionResult SupprimerDuPanier(int venteId, int produitId)
        {
            ProduitVenduService produitVenduService = new ProduitVenduService();
            produitVenduService.DeleteProduitPanier(venteId, produitId);
            // Rediriger vers la vue du panier après la suppression
            return RedirectToAction("ProduitsVendus", "ProduitsVendus", new { id = venteId });
        }

        [HttpPost]
        [Route("ValiderCommande")]
        public IActionResult ValiderCommande(int venteId)
        {
            ProduitVenduService produitVenduService = new ProduitVenduService();

            var retour = produitVenduService.ValiderVente(venteId);

            // Rediriger vers la vue commande avec succes
            if (retour)
            {
                return RedirectToAction("CommandeSucces", "ProduitsVendus");
            }
            else
            {
                return RedirectToAction("ProduitsVendus", "ProduitsVendus", new { id = venteId });
            }
        }

        [HttpPost]
        [Route("AnnulerCommande")]
        public IActionResult AnnulerCommande(int venteId)
        {
            ProduitVenduService produitVenduService = new ProduitVenduService();
            produitVenduService.DeleteVente(venteId);
            // Rediriger vers la vue catalogue après la suppression
            return RedirectToAction("ProduitsVendus", "ProduitsVendus", new { id = 0 });
        }

        [HttpGet]
        [Route("Succes")]
        public IActionResult CommandeSucces()
        {
            return View();
        }


        [HttpPost]
        [Route("")]
        public IActionResult ProduitToUpDateDuPanier()
        {

            return null;
        }
    }
}
