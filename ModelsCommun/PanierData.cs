using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsCommun
{
    public class PanierData
    {
        [JsonPropertyName("venteid")]
        public int VenteId { get; set; } = 0;

        [JsonPropertyName("produitid")]
        public int ProduitId { get; set; } = 0;

        [JsonPropertyName("quantite")]
        public int Quantite { get; set; } = 0;
    }
}
