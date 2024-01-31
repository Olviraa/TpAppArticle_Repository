using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsCommun
{
    public class Vente
    {
        // Id de la vente
        [JsonPropertyName("id")]
        public int ID {  get; set; }

        // La date de la vente
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        // Le total 
        [JsonPropertyName("total")]
        public double Total { get; set; }

        // Liste des produits vendus (pour permettre à EntityFramework de comprendre la logique de la vente)
        [JsonPropertyName("produitsVendus")]
        public List<ProduitVendu> ProduitsVendus { get; set; }

    }
}
