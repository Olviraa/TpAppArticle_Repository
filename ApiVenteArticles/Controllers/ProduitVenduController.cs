using ApiVenteArticles.Interface;
using ApiVenteArticles.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsCommun;

namespace ApiVenteArticles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitVenduController : ControllerBase
    {

        IProduitVenduService _produitVenduService;

        public ProduitVenduController(IProduitVenduService produitVenduService)
        {
            _produitVenduService = produitVenduService;
        }

        [HttpGet]
        [Route("{idVente}")]
        public List<ProduitVendu> GetProductsVendus(int idVente)
        {
            var productsVendus = _produitVenduService.GetProductsVendre(idVente);
            return productsVendus;
        }

        [HttpGet]
        [Route("{id}")]
        public ProduitVendu GetProductVedu(int id)
        {
            var productVendu = _produitVenduService.GetProductVendre(id);
            return productVendu;
        }

        [HttpPost]
        [Route("add/{idVente}/{idProduit}/{quantite}")]
        public int AddProduitVendu(int idVente, int idProduit, int quantite)
        {
            return _produitVenduService.AddProduitVendre(idVente, idProduit, quantite);
        }

       

        [HttpPost]
        [Route("delete/{idVente}/{idProduit}")]
        public bool DeleteProduitVendu(int idVente, int idProduit)
        {
            return _produitVenduService.DeleteProduitVendu(idVente, idProduit);
           
        }


    }
}
