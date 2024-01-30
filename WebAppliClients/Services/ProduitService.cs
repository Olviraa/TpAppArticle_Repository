using ModelsCommun;
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

        public List<Produit> GetProduit()
        {
            var listeProduit = _apiRepository.GetList();
            return listeProduit;
        }

        public Produit GetProduit(int id) 
        {
         var produit = _apiRepository.GetProduit(id);

            return produit;
        }
    }
}
