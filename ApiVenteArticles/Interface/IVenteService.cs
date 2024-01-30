using ModelsCommun;

namespace ApiVenteArticles.Interface
{
    public interface IVenteService
    {
        public Vente AddVente(Vente vente);

        public Vente GetVente(int id);
        public List<Vente> GetVentes();

        public void DeleteVente(int id);

    }
}
