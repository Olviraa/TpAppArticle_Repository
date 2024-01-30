using Microsoft.AspNetCore.Mvc;
using ModelsCommun;
using WebAppliClients.Services;

namespace WebAppliClients.Controllers
{
    
    [Route("/")]
    public class ProduitsVendusController : Controller
    {
    
       [HttpPost]
       [Route("Panier")]
       public IActionResult AddProduitPanier(ProduitVendu produitdPanier)
       {
            //demande pour ajouter un produit au panier

            ProduitService produitService = new ProduitService();
            //var produit = produitService.


            //if (response.IsSuccessStatusCode)
            //{
            //    // Ajout réussi au panier
            //    TempData["Message"] = "Produit ajouté au panier avec succès.";
            //}
            //else
            //{
            //    // Gestion des erreurs
            //    TempData["Message"] = "Erreur lors de l'ajout au panier.";
            //}
            return View();
       }

    }
}
