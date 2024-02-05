using ModelsCommun;
using WebAppAdmin.Repository;

namespace WebAppAdmin.Service
{
    public class AdminService
    {
        private readonly APIRepo _apiRepo;
        public AdminService(APIRepo apiRepo)
        {
            _apiRepo =  apiRepo;
        }
        public List<Produit> GetListeProduitService()
        {
            List<Produit> listeProduits = new List<Produit>();
            //APIRepo apiRepo = new APIRepo();
            listeProduits = _apiRepo.GetProduits();
            
            return listeProduits;
        }
        public Produit UpdateProduitService(Produit produitToUpdate)
        {
            
            //APIRepo apiRepo = new APIRepo();
            _apiRepo.UpdateProduit(produitToUpdate);
            return produitToUpdate;
        }

        internal Produit CreateProduitService(Produit produitCreated)
        {
            //APIRepo aPIRepo = new APIRepo();
            _apiRepo.CreateProduit(produitCreated);
            return produitCreated;
        }

        internal int DeleteProduitService(int idDeleted)
        {
            //APIRepo apiRepo = new APIRepo();
            _apiRepo.DeleteProduit(idDeleted);
            return idDeleted;
        }

        internal int DeleteVenteService(int idDeleted)
        {
            //APIRepo apiRepo = new APIRepo();
            _apiRepo.DeleteVente(idDeleted);
            return idDeleted;
        }

        internal List<Vente> GetHistoriqueService()
        {
            List<Vente> listeVentes = new List<Vente>();
            //APIRepo apiRepo = new APIRepo();
            listeVentes = _apiRepo.GetHistorique();

            return listeVentes;
        }
    }
}
