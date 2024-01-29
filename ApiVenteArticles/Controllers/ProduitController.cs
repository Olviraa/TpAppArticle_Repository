using ApiVenteArticles.Interface;
using ApiVenteArticles.Repositories;
using ApiVenteArticles.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsCommun;

namespace ApiVenteArticles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {

        IProduitService _produitService;
        //ProduitService produitService = new ProduitService(new Repositories.ApiDbContext());

        public ProduitController(IProduitService produitService)
        {
            _produitService = produitService;
        }

        [HttpGet]
        [Route("")]
        public List<Produit> GetProducts()
        {
            var products = _produitService.GetProducts();
            return products;
        }

        [HttpGet]
        [Route("{id}")]
        public Produit GetProduct(int id)
        {
            var product = _produitService.GetProduct(id);
            return product;
        }

        [HttpPost]
        [Route("add")]
        public Produit AddProduct(Produit newProduct)
        {
            var addedProduct = _produitService.AddProduct(newProduct);
            return addedProduct;
        }

        [HttpPost]
        [Route("update")]

        public Produit UpdateProduct(int id, string nom, double prix, int quantitedispo)

        {
            var updatedProduct = _produitService.UpdateProduct(id, nom, prix, quantitedispo);
            return updatedProduct;
        }

        [HttpPost]
        [Route("delete")]
        public void DeleteProduct(int id)
        {
             _produitService.DeleteProduct(id);
           
        }




    }
}
