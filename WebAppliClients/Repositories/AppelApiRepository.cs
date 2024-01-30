
using ModelsCommun;
using System.Text;
using System.Text.Json;
using static WebAppliClients.Models.ViewModels.VentesViewModel;

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

        public ProduitVenduViewModel AddProduitVendu(ProduitVenduViewModel wishlist)
        {
            string url = $"{_baseUrl}/produit/add";
            HttpClient client = new HttpClient();

            Dictionary<string, string> formData = new Dictionary<string, string>();
            formData["quantite"] = wishlist.Quantite.ToString(); //la quantite
            formData["idevente"] = wishlist.IdVente.ToString();
            formData["idproduit"] = wishlist.IdProduit.ToString();

            FormUrlEncodedContent formContent = new FormUrlEncodedContent(formData);

            var productJson = JsonSerializer.Serialize(wishlist);
            var produitPanier = new StringContent(productJson, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, formContent).Result;


            // Appelez l'API pour ajouter au panier


            // Gérez la réponse ici selon les besoins
            return null;
        }
    }
}
