
using Microsoft.Extensions.Logging;
using ModelsCommun;
using System.Text;
using System.Text.Json;
using WebAppliClients.Models.ViewModel;
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

        // Pour récuperer la liste de produit avec l'ID de la vente
        public ListViewModel GetListView()
        {
            string url = $"{_baseUrl}/produit/list";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var productJson = response.Content.ReadAsStringAsync().Result;
            ListViewModel listeProduitView = JsonSerializer.Deserialize<ListViewModel>(productJson);

            return listeProduitView;
        }

        public ProduitViewModel GetProduit(int id)
        {
            string url = $"{_baseUrl}/produit/view/{id}";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var productJson = response.Content.ReadAsStringAsync().Result;
            ProduitViewModel produit = JsonSerializer.Deserialize<ProduitViewModel>(productJson);

            return produit;
        }

        public int AddProduitVendu(int venteId, int produitId, int quantite)
        {
            string url = $"{_baseUrl}/produitvendu/add/{venteId}/{produitId}/{quantite}";
            HttpClient client = new HttpClient();

            var panierData = new PanierData
            {
                VenteId = venteId,
                ProduitId = produitId,
                Quantite = quantite
            };

            var productJson = JsonSerializer.Serialize(panierData);
            var content = new StringContent(productJson, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, content).Result;

            var IdVente = response.Content.ReadAsStringAsync().Result;
            int monIdVente = JsonSerializer.Deserialize<int>(IdVente);

            return monIdVente;

        }

        public Vente GetListProduitVendu(int id)
        {
            string url = $"{_baseUrl}/vente/{id}";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var venteJson = response.Content.ReadAsStringAsync().Result;
            Vente ventePanier = JsonSerializer.Deserialize<Vente>(venteJson);

            return ventePanier;
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

        //public ProduitVendu GetProduitVenduSelect()
        //{
        //   return null;
        //}
    }
}
