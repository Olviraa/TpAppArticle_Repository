using ApiVenteArticles.Interface;
using ApiVenteArticles.Repositories;
using ApiVenteArticles.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsCommun;
using WebAppliClients.Models.ViewModel;

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
        [Route("List")]
        public ListViewModel GetProductsList()
        {
            var indexViewModel = _produitService.GetProductsView();

            return indexViewModel;
        }

        [HttpGet]
        [Route("{id}")]
        public Produit GetProduct(int id)
        {
            var product = _produitService.GetProduct(id);
            return product;
        }

        [HttpGet]
        [Route("view/{id}")]
        public ProduitViewModel GetProductView(int idVente, int id)
        {
            var produitViewModel = _produitService.GetProductView(idVente, id);

            return produitViewModel;
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
        public Produit UpdateProduct(Produit productToUpdate)

        {
            var updatedProduct = _produitService.UpdateProduct(productToUpdate.ID, productToUpdate.Nom, productToUpdate.Prix, productToUpdate.QuantiteDisponible);
            return updatedProduct;
        }

        [HttpPost]
        [Route("delete/{id}")]
        public void DeleteProduct(int id)
        {
             _produitService.DeleteProduct(id);
           
        }




    }
}
