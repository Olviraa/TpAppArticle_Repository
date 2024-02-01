using ModelsCommun;
using WebAppliClients.Models.ViewModel;

namespace ApiVenteArticles.Interface
{
    public interface IProduitService
    {
        public Produit AddProduct(Produit newProduct);

        // Lecture liste simple
        public List<Produit> GetProducts();

        // Lecture liste avec retour idvente
        public ListViewModel GetProductsView();

        // Lecture simple d'un produit
        public Produit GetProduct(int id);

        // Lecture poussée d'un produit
        public ProduitViewModel GetProductView(int idVente, int id);

        public Produit UpdateProduct(int id, string nom, double prix, int quantiteDispo);

        public void DeleteProduct(int id);

    }
}
