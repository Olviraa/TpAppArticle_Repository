using Microsoft.AspNetCore.Mvc;
using ModelsCommun;

namespace WebAppliClients.Controllers
{
    public class VentesController : Controller
    {
    
       [HttpPost("")]
       public IActionResult AjoutProduit(ProduitVendu produitdPanier)
       {
            //    //demande pour ajouter un produit au panier
            //    var addToCartRequest = new 

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
