
using WebAppliClients.Repository;
using static WebAppliClients.Models.ViewModels.VentesViewModel;

namespace WebAppliClients.Services
{
    
    public class ProduitVenduService
    {
        private readonly AppelApiRepository _apiRepository;
        // services pour api
        public ProduitVenduViewModel AddProduitPanier(int IdProduit, int IdVente, int Quantite)
        {
            ProduitVenduViewModel produitVendu = new ProduitVenduViewModel();
            
            produitVendu.IdProduit = IdProduit;
            produitVendu.IdVente = IdVente;
            produitVendu.Quantite = Quantite;
            _apiRepository.AddProduitVendu(produitVendu);

            return produitVendu;

        }
    }
}
