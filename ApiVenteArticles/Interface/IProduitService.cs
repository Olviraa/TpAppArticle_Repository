using ModelsCommun;

namespace ApiVenteArticles.Interface
{
    public interface IProduitService
    {
        public Produit AddProduct(Produit newProduct);
        public List<Produit> GetProducts();

        public Produit GetProduct(int id);

        public Produit UpdateProduct(int id, string nom, double prix, int quantiteDispo);

        public void DeleteProduct(int id);

    }
}
