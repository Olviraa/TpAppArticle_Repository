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
        [Route("List")]
        public IActionResult ListeProduits()
        {
            ProduitService produitService = new ProduitService();
            var produits = produitService.GetProduit();
            ListViewModel listViewModel = new ListViewModel(produits);
            return View(listViewModel);
        }
        [HttpGet]
        [Route("Detail/{id}")]
        public IActionResult DetailProduit(int id)
        {
            ProduitService produitService = new ProduitService();
            var produit = produitService.GetProduit(id);
            return View(produit);
        }

        [HttpGet]
        [Route("Contact")]
        public IActionResult ContactAdmin()
        {
            return View();
        }
    }
}
