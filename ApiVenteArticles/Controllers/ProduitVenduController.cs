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
        [Route("")]
        public List<ProduitVendu> GetProductsVendus()
        {
            var productsVendus = _produitVenduService.GetProductsVendre();
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
        [Route("add")]
        public ProduitVendu AddProduitVendu()
        {
            var quantite = Request.Form["quantite"];
            var idvente = Request.Form["idvente"];
            var idproduit = Request.Form["idprodui"];

            var addedProduitVendu = _produitVenduService.AddProduitVendre(int.Parse(quantite), int.Parse(idvente), int.Parse(idproduit));
            
            return addedProduitVendu;
        }

       

        [HttpPost]
        [Route("delete")]
        public void DeleteProduitVendu(int idproduit)
        {
            _produitVenduService.DeleteProduct(idproduit);
           
        }


    }
}
