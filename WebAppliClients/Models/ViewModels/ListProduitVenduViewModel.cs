using ModelsCommun;

namespace WebAppliClients.Models.ViewModels
{
    public class ListProduitVenduViewModel
    {
       
            public List<ProduitVendu> ListProduitVendu { get; set; }
            public ListProduitVenduViewModel(List<ProduitVendu> listProduitVendu)
            {
                ListProduitVendu = listProduitVendu;
            }

    }
}
