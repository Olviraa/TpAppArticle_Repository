
using ModelsCommun;
using System.Text;
using System.Text.Json;

namespace WebAppliClients.Repository
{
    public class AppelApiRepository
    {
        private string _baseUrl = "http://localhost:5101/api";

        public List<Produit> GetList()
        {
            string url = $"{_baseUrl}/produit";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var productJson = response.Content.ReadAsStringAsync().Result;
            List<Produit> listeProduit = JsonSerializer.Deserialize<List<Produit>>(productJson);

            return listeProduit;
        }

        public Produit GetProduit(int id)
        {
            string url = $"{_baseUrl}/produit/{id}";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var productJson = response.Content.ReadAsStringAsync().Result;
            Produit produit = JsonSerializer.Deserialize<Produit>(productJson);

            return produit;
        }

        public Produit Vente(Produit wishlist)
        {
            string url = $"{_baseUrl}/produit/panier";
            HttpClient client = new HttpClient();
            var productJson = JsonSerializer.Serialize(wishlist);
            var produitPanier = new StringContent(productJson, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, produitPanier).Result;


            // Appelez l'API pour ajouter au panier

            // Gérez la réponse ici selon les besoins
            return null;
        }
    }
}
