using ModelsCommun;

namespace WebAppliClients.Models.ViewModel
{
    public class ListViewModel
    {
        public List<Produit> ListProduit { get; set; }
        public ListViewModel(List<Produit> listProduit) 
        {
            ListProduit = listProduit;
        }
    }
}
