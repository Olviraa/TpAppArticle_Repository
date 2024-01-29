using ModelsCommun;
using System.Text.Json;

namespace WebAppAdmin.Repository
{
    internal class APIRepo
    {
        private readonly string _apiUrl = "http://localhost:5101/";

        //public APIRepo(IConfiguration configuration)
        //{
        //    _apiUrl = configuration.GetValue<string>("ApiUrl");
        //}

        public List<Produit> GetProduits()
        {
            //prepa requete
            var client = new HttpClient();
            var urlGetProduits = _apiUrl + "api/Produit";

            //appel api
            var response = client.GetAsync(urlGetProduits).Result;

            //test code retour
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Erreur lors de l'appel de l'Api");
            }

            var json = response.Content.ReadAsStringAsync().Result;

            //déserialisation des données en json 
            List<Produit> produits = JsonSerializer.Deserialize<List<Produit>>(json);

            return produits;
        }
    }
}
