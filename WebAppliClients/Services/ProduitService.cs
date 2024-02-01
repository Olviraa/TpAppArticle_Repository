using ModelsCommun;
using WebAppliClients.Models.ViewModel;
using WebAppliClients.Repository;

namespace WebAppliClients.Services
{
    public class ProduitService
    {
        private readonly AppelApiRepository _apiRepository;

        public ProduitService()
        {
            _apiRepository = new AppelApiRepository();
        }

        public ListViewModel GetProduitView()
        {
            var listeProduit = _apiRepository.GetListView();
            return listeProduit;
        }

        public ProduitViewModel GetProduit(int id) 
        {
         var produit = _apiRepository.GetProduit(id);

            return produit;
        }
    }
}
