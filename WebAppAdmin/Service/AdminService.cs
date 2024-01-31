using ModelsCommun;
using WebAppAdmin.Repository;

namespace WebAppAdmin.Service
{
    public class AdminService
    {
        public List<Produit> GetListeProduitService()
        {
            List<Produit> listeProduits = new List<Produit>();
            APIRepo apiRepo = new APIRepo();
            listeProduits = apiRepo.GetProduits();
            
            return listeProduits;
        }
        public Produit UpdateProduitService(Produit produitToUpdate)
        {
            //Produit produit = new Produit();
            APIRepo apiRepo = new APIRepo();
            //produit =
                apiRepo.UpdateProduit(produitToUpdate);
            return produitToUpdate;
        }

        internal Produit CreateProduitService(Produit produitCreated)
        {
            APIRepo aPIRepo = new APIRepo();
            aPIRepo.CreateProduit(produitCreated);
            return produitCreated;
        }

        internal int DeleteProduitService(int idDeleted)
        {
            APIRepo apiRepo = new APIRepo();
            apiRepo.DeleteProduit(idDeleted);
            return idDeleted;
        }

        internal int DeleteVenteService(int idDeleted)
        {
            APIRepo apiRepo = new APIRepo();
            apiRepo.DeleteVente(idDeleted);
            return idDeleted;
        }

        internal List<Vente> GetHistoriqueService()
        {
            List<Vente> listeVentes = new List<Vente>();
            APIRepo apiRepo = new APIRepo();
            listeVentes = apiRepo.GetHistorique();

            return listeVentes;
        }
    }
}
