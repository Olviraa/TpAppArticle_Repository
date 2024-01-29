using ApiVenteArticles.Interface;
using ApiVenteArticles.Repositories;
using ModelsCommun;

namespace ApiVenteArticles.Services
{
    public class ProduitService: IProduitService
    {

        private readonly ApiDbContext _dbContext;

        public ProduitService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Produit AddProduct(Produit newProduct)
        {
            _dbContext.Produits.Add(newProduct);
            _dbContext.SaveChanges();

            return newProduct;
        }

        public List<Produit> GetProducts()
        {
            return _dbContext.Produits.ToList();
        }

        public Produit GetProduct(int id)
        {
            return _dbContext.Produits.FirstOrDefault(p => p.ID == id);
        }

        public Produit UpdateProduct(int id, string nom, double prix, int quantiteDispo)
        {
            Produit productToUpdate = _dbContext.Produits.FirstOrDefault(p => p.ID == id);
            productToUpdate.Nom = nom;
            productToUpdate.Prix = prix;
            productToUpdate.QuantiteDisponible = quantiteDispo;

            _dbContext.SaveChanges();

            return productToUpdate;
        }

        public void DeleteProduct(int id)
        {

            Produit productToDelete = _dbContext.Produits.FirstOrDefault(p => p.ID == id);
            _dbContext.Produits.Remove(productToDelete);
            _dbContext.SaveChanges();

          

        }

    }
}
