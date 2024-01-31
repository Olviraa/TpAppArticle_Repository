
using WebAppliClients.Repository;
using static WebAppliClients.Models.ViewModels.VentesViewModel;

namespace WebAppliClients.Services
{
    
    public class ProduitVenduService
    {
        private readonly AppelApiRepository _apiRepository;

        // service pour controllerproduitvendu  
        public ProduitVenduViewModel AddProduitPanier(int IdProduit, int IdVente, int Quantite)
        {
            ProduitVenduViewModel produitVendu = new ProduitVenduViewModel();
            
            produitVendu.IdProduit = IdProduit;
            produitVendu.IdVente = IdVente;
            produitVendu.Quantite = Quantite;
            var addedProduitVendu =_apiRepository.AddProduitVendu(produitVendu);

            ProduitVenduViewModel addedProduitVenduViewModel = new ProduitVenduViewModel();
            addedProduitVenduViewModel.IdProduit = addedProduitVendu.Produit.ID;
            addedProduitVenduViewModel.IdVente = addedProduitVendu.ID;
            addedProduitVenduViewModel.Quantite = addedProduitVendu.QuantiteVendue;

            return addedProduitVenduViewModel;
        }
    }
}
