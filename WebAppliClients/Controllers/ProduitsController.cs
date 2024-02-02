using Microsoft.AspNetCore.Mvc;
using ModelsCommun;
using System.Diagnostics;
using WebAppliClients.Models;
using WebAppliClients.Models.ViewModel;
using WebAppliClients.Services;

namespace WebAppliClients.Controllers
{
    [Route("/")]
    public class ProduitsController : Controller
    {
        private readonly ILogger<ProduitsController> _logger;

        public ProduitsController(ILogger<ProduitsController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        public IActionResult PageAccueil()
        {
            return View();
        }

        [HttpGet]
        [Route("List/{venteId}")]
        public IActionResult ListeProduits(int venteId)
        {
            ProduitService produitService = new ProduitService();
            var listViewModel = produitService.GetProduitView();
            listViewModel.IdVente = venteId;
            ViewBag.IdPanier = venteId;
            return View(listViewModel);
        }
        [HttpGet]
        [Route("Detail/{venteId}/{id}")]
        public IActionResult DetailProduit(int venteId, int id)
        {
            ProduitService produitService = new ProduitService();
            var produit = produitService.GetProduit(id);
            produit.IdVente = venteId;
            ViewBag.IdPanier = venteId;
            return View(produit);
        }

        [HttpGet]
        [Route("Contact")]
        public IActionResult ContactAdmin()
        {
            return View();
        }

        [HttpGet]
        [Route("ContactSent")]
        public IActionResult ContactMerci()
        {
            return View();
        }
    }
}
