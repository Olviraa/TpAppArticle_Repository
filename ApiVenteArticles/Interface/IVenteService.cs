using ModelsCommun;

namespace ApiVenteArticles.Interface
{
    public interface IVenteService
    {
        public Vente AddVente(Vente vente);

        public Vente GetVente(int id);

        public List<Vente> GetVentes();

        public bool ValiderVente(int idVente);

        public bool DeleteVente(int id);

        public Vente UpdateVente(int id, DateTime date, double total);

    }
}
