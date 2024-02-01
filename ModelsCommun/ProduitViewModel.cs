using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsCommun
{
    public class ProduitViewModel
    {
        [JsonPropertyName("produit")]
        public Produit Produit { get; set; }

        // Id de la vente à véhiculer partout où on va
        [JsonPropertyName("idvente")]
        public int IdVente { get; set; }
        public ProduitViewModel(Produit produit, int venteId)
        {
            Produit = produit;
            IdVente = venteId;
        }

        public ProduitViewModel()
        {

        }
    }
}
