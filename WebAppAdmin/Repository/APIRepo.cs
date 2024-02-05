using ModelsCommun;
using System.Text;
using System.Text.Json;

namespace WebAppAdmin.Repository
{
    public class APIRepo
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
        public Produit UpdateProduit(Produit produit)
        {
            //prepa requete
            var client = new HttpClient();
            var urlUpdateProduit = _apiUrl + "api/Produit/update";

            //serialisation des données en json 
            var jsonUpdateProduit = JsonSerializer.Serialize(produit);
            var content = new StringContent(jsonUpdateProduit, Encoding.UTF8, "application/json");

            //appel api
            var response = client.PostAsync(urlUpdateProduit, content).Result;

            //test code retour
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Erreur lors de l'appel de l'Api");
            }
            
            return produit;
        }

        internal Produit CreateProduit(Produit produitCreated)
        {
            //prepa requete
            var client = new HttpClient();
            var urlCreateProduit = _apiUrl + "api/Produit/add";

            //serialisation des données en json 
            var jsonUpdateProduit = JsonSerializer.Serialize(produitCreated);
            var content = new StringContent(jsonUpdateProduit, Encoding.UTF8, "application/json");

            //appel api
            var response = client.PostAsync(urlCreateProduit, content).Result;

            //test code retour
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Erreur lors de l'appel de l'Api");
            }

            return produitCreated;

        }

        internal int DeleteProduit(int idDeleted)
        {
            //prepa requete
            var client = new HttpClient();
            var urlDeleteProduit = _apiUrl + "api/Produit/delete/" + idDeleted;
                        
            //appel api
            var response = client.PostAsync(urlDeleteProduit, null).Result;

            //test code retour
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Erreur lors de l'appel de l'Api");
            }

            return idDeleted;


        }

        internal int DeleteVente(int idDeleted)
        {
            //prepa requete
            var client = new HttpClient();
            var urlDeleteVente = _apiUrl + "api/Vente/delete/" + idDeleted;

            //appel api
            var response = client.PostAsync(urlDeleteVente, null).Result;

            //test code retour
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Erreur lors de l'appel de l'Api");
            }

            return idDeleted;
        }

        internal List<Vente> GetHistorique()
        {
            //prepa requete
            var client = new HttpClient();
            var urlGetVentes = _apiUrl + "api/Vente";

            //appel api
            var response = client.GetAsync(urlGetVentes).Result;

            //test code retour
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Erreur lors de l'appel de l'Api");
            }

            var json = response.Content.ReadAsStringAsync().Result;

            //déserialisation des données en json 
            List<Vente> ventes = JsonSerializer.Deserialize<List<Vente>>(json);

            return ventes;
        }
    }
}
