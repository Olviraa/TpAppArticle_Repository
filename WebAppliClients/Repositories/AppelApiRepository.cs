﻿
using ModelsCommun;
using System.Text;
using System.Text.Json;
using static WebAppliClients.Models.ViewModels.VentesViewModel;
using static WebAppliClients.Models.ViewModels.ListProduitVenduViewModel;

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

        public ProduitVendu AddProduitVendu(ProduitVenduViewModel wishlist)
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
            var addedProduitVendu = JsonSerializer.Deserialize<ProduitVendu>(json);

            return addedProduitVendu;
        }

        public List<ProduitVendu> GetListProduitVendu()
        {
            string url = $"{_baseUrl}/Panier";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var productJson = response.Content.ReadAsStringAsync().Result;
            List<ProduitVendu> panier = JsonSerializer.Deserialize<List<ProduitVendu>>(productJson);

            return panier;
        }

        public ProduitVendu GetProduitVendu(int id)
        {
            string url = $"{_baseUrl}/ProduitPanier/{id}";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var productJson = response.Content.ReadAsStringAsync().Result;
            ProduitVendu produitPanier = JsonSerializer.Deserialize<ProduitVendu>(productJson);

            return produitPanier;
        }

    }
}
