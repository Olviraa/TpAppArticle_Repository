using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsCommun
{
    public class ProduitVendu
    {
        // Id de produit vendu ou produit par vente
        [JsonPropertyName("id")]
        public int ID { get; set; }

        // La quantité vendu
        [JsonPropertyName("quantitevendue")]
        public int QuantiteVendue { get; set; }

        // et le produit en question pour les propriétés (pour faire comprendre à EntityFramework)
        [JsonPropertyName("produit")]
        public Produit Produit { get; set; }

    }
}
