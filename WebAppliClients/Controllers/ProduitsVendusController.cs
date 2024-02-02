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
            ViewBag.IdPanier = id;
            return View(ventePanier);
        }
        [HttpGet]
        [Route("Panier/{id}")]
        public IActionResult DetailProduitVendu(int id)
        {
            ProduitVenduService produitService = new ProduitVenduService();
            var produitVendu = produitService.GetProduitVendu(id);
            ViewBag.IdPanier = id;
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
            ViewBag.IdPanier = venteId;
            // Rediriger vers la vue du panier après la suppression
            return RedirectToAction("ProduitsVendus", "ProduitsVendus", new { id = venteId });
        }

        [HttpPost]
        [Route("ValiderCommande")]
        public IActionResult ValiderCommande(int venteId)
        {

            ProduitVenduService produitVenduService = new ProduitVenduService();

            //Liste des (des ID) produit à valider
            var listechecked = Request.Form.ToList();
            var nombre = listechecked.Count;
            

            // Je recupère la liste des produits de la vente
            var ventePanier = produitVenduService.GetListProduitVendu(venteId);
            var listeproduit = ventePanier.ProduitsVendus.ToList();

            // Je crée une liste de produits à rétirer de la vente
            List<ProduitVendu> listeproduitsup = new List<ProduitVendu>();

            bool cocher;

            foreach (var produiselectionne  in listeproduit)
            {
                cocher = false;

                for (int i = 0; i < nombre -1; i++)
                {
                    var item = listechecked.ElementAtOrDefault(i);
                    if (produiselectionne.Produit.ID == int.Parse(item.Key))
                    {
                        cocher = true;
                    }
                }

                if (!cocher)
                {
                    listeproduitsup.Add(produiselectionne);
                }
            }
            

            // Je retire les produit si il y en a
            foreach (var item in listeproduitsup)
            {
                produitVenduService.DeleteProduitPanier(venteId, item.Produit.ID);
            }


            // puis je valide la vrai vente
            var retour = produitVenduService.ValiderVente(venteId);
            ViewBag.IdPanier = venteId;

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
            ViewBag.IdPanier = venteId;
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
