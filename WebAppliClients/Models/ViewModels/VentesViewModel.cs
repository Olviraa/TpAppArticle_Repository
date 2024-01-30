

using ModelsCommun;

namespace WebAppliClients.Models.ViewModels
{
    // dans le panier (la vente) il y a une liste de produit

    public class VentesViewModel
    {
        public int ID { get; set; }
     
        //Id produit à envoyer à ma view

        List<Produit> IdProduit = new List<Produit>();

    }
}
