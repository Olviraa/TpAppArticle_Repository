using ModelsCommun;
using System.Text.Json.Serialization;

namespace WebAppliClients.Models.ViewModel
{
    public class ListViewModel
    {
        [JsonPropertyName("listproduit")]
        public List<Produit> ListProduit { get; set; }

        // Id de la vente à véhiculer partout où on va
        [JsonPropertyName("idvente")]
        public int IdVente { get; set; }
        public ListViewModel(List<Produit> listProduit, int venteId) 
        {
            ListProduit = listProduit;
            IdVente = venteId;
        }

        public ListViewModel()
        {
            // COnstructeur vide de chez le vide
        }
    }
}
