using Microsoft.AspNetCore.Mvc;

namespace WebAppliClients.Controllers
{
    public class VentesController : Controller
    {
        [Route("/")]
        public IActionResult Vente(int id, int Quantite)
        {
                //    //demande pour ajouter au panier
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

                return View("Index", "Product");
        }
    }
}
