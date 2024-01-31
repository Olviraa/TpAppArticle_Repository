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
       public IActionResult AddProduitPanier(int IdProduit, int IdVente, int Quantite)
       {
            // RECEPTION DU produitVendu DU PRODUITVENDUSERVICE
            ProduitVenduService produitVenduReçu = new ProduitVenduService();
            var produitVenduTosend = produitVenduReçu.AddProduitPanier(IdProduit, IdVente, Quantite);

            return View(produitVenduTosend);
       }

    }
}
