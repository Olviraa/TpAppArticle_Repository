using System.Text.Json.Serialization;

namespace ModelsCommun
{
    public class Produit
    {
        // Id du produit
        [JsonPropertyName("id")]
        public int ID { get; set; }
        // Nom du produit
        [JsonPropertyName("nom")]
        public string Nom { get; set; }
        // Prix du produit
        [JsonPropertyName("prix")]
        public double Prix { get; set; }
        // Quantite disponible du produit
        [JsonPropertyName("quantitedisponible")]
        public int QuantiteDisponible { get; set; }
    }
}
