
using Microsoft.Extensions.Logging;
using ModelsCommun;
using WebAppliClients.Repository;
using static WebAppliClients.Models.ViewModels.VentesViewModel;

namespace WebAppliClients.Services
{
    
    public class ProduitVenduService
    {
        private readonly AppelApiRepository _apiRepository;

        public ProduitVenduService()
        {
            _apiRepository = new AppelApiRepository();
        }

        // service pour controllerproduitvendu  
        public int AddProduitPanier(int IdVente, int IdProduit, int Quantite)
        {
            
            var idDeLaVente =_apiRepository.AddProduitVendu(IdVente, IdProduit, Quantite);

            //ProduitVenduViewModel addedProduitVenduViewModel = new ProduitVenduViewModel();
            //addedProduitVenduViewModel.IdProduit = addedProduitVendu.Produit.ID;
            //addedProduitVenduViewModel.IdVente = addedProduitVendu.ID;
            //addedProduitVenduViewModel.Quantite = addedProduitVendu.QuantiteVendue;

            return idDeLaVente;
        }

        public Vente GetListProduitVendu(int id)
        {
            var ventePanier = _apiRepository.GetListProduitVendu(id);
            return ventePanier;
        }

        public ProduitVendu GetProduitVendu(int id)
        {
            var produitVendu = _apiRepository.GetProduitVendu(id);
            return produitVendu;
        }

        public Vente CreatPanier()
        {
            var creatPanier = _apiRepository.PanierAremplir();
            return creatPanier;
        }
    }
}
