using ApiVenteArticles.Interface;
using ApiVenteArticles.Repositories;
using ModelsCommun;
using WebAppliClients.Models.ViewModel;

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

        // Lecture d'une liste de produits simple
        public List<Produit> GetProducts()
        {
            return _dbContext.Produits.ToList();
        }

        // Lecture d'une liste de produit avec idvente
        public ListViewModel GetProductsView()
        {
            var listeproduit = _dbContext.Produits.ToList();
            var venteId = 0;
            var listViewModel = new ListViewModel(listeproduit, venteId);
            return listViewModel;
        }

        public Produit GetProduct(int id)
        {
            return _dbContext.Produits.FirstOrDefault(p => p.ID == id);
        }

        // Lecture d'un produit tout en gérant l'id de la vente
        public ProduitViewModel GetProductView(int venteid, int id)
        {
            var produit = _dbContext.Produits.FirstOrDefault(p => p.ID == id);
            var IdVente = venteid;
            ProduitViewModel produitViewModel = new ProduitViewModel(produit, IdVente);

            return produitViewModel;
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
