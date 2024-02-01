
using ModelsCommun;
using System.Text;
using System.Text.Json;
using static WebAppliClients.Models.ViewModels.VentesViewModel;

namespace WebAppliClients.Repository
{
    public class AppelApiRepository
    {
        private string _baseUrl = "http://localhost:5101/api";
        //private string _baseUrl = "http://localhost:5282/api";

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
            formData["quantite"] = wishlist.Quantite.ToString();
            formData["idevente"] = wishlist.IdVente.ToString();
            formData["idproduit"] = wishlist.IdProduit.ToString();

            FormUrlEncodedContent formContent = new FormUrlEncodedContent(formData);

            var response = client.PostAsync(url, formContent).Result;
            var json = response.Content.ReadAsStringAsync().Result;
             JsonSerializer.Serialize(wishlist);

            return wishlist;

        }

        public List<ProduitVendu> GetListProduitVendu()
        {
            string url = $"{_baseUrl}/produitvendu";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var productJson = response.Content.ReadAsStringAsync().Result;
            List<ProduitVendu> produitsVendus = JsonSerializer.Deserialize<List<ProduitVendu>>(productJson);

            return produitsVendus;
        }

        public ProduitVendu GetProduitVendu(int id)
        {
            string url = $"{_baseUrl}/produitvendu/{id}";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var productJson = response.Content.ReadAsStringAsync().Result;
            ProduitVendu produitVendu = JsonSerializer.Deserialize<ProduitVendu>(productJson);

            return produitVendu;
        }

        internal Vente PanierAremplir()
        {
            throw new NotImplementedException();
        }
    }
}
