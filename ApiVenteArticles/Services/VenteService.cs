using ApiVenteArticles.Interface;
using ApiVenteArticles.Repositories;
using Microsoft.EntityFrameworkCore;
using ModelsCommun;

namespace ApiVenteArticles.Services
{
    public class VenteService: IVenteService
    {
        private readonly ApiDbContext _dbContext;

        public VenteService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Vente AddVente(Vente vente)
        {
            _dbContext.Ventes.Add(vente);
            _dbContext.SaveChanges();

            return vente;
        }

        public List<Vente> GetVentes()
        {
            return _dbContext.Ventes.Include(p => p.ProduitsVendus).ThenInclude(pv => pv.Produit).ToList();
        }

        public Vente GetVente(int id)
        {
            var mavente = _dbContext.Ventes.Include(p => p.ProduitsVendus).ThenInclude(pv => pv.Produit).FirstOrDefault(p => p.ID == id);
            if (mavente == null)
            {
                mavente = new Vente();
                mavente.ProduitsVendus = new List<ProduitVendu>();
                return mavente;
            }
            return mavente;
        }

        public bool ValiderVente(int idVente)
        {
            // Rechercher si la vente existe dans la base de donnée
            var venteAValider = _dbContext.Ventes.Include(v => v.ProduitsVendus).ThenInclude(pv => pv.Produit).FirstOrDefault(v => v.ID == idVente);

            if (venteAValider != null)
            {
                // Récupérer les produits liés à cette vente
                var produitsVendus = venteAValider.ProduitsVendus;

                // Vérifier si la quantité vendue ne dépasse pas la quantité disponible pour chaque produit
                foreach (var produitVendu in produitsVendus)
                {
                    if (produitVendu.QuantiteVendue > produitVendu.Produit.QuantiteDisponible)
                    {
                        // La quantité vendue est supérieure à la quantité disponible, annuler la validation
                        return false;
                    }
                }

                // Mettre à jour la quantité disponible des produits vendus
                foreach (var produitVendu in produitsVendus)
                {
                    produitVendu.Produit.QuantiteDisponible -= produitVendu.QuantiteVendue;
                }

                // Calculer la somme totale des produits vendus
                double sommeTotale = produitsVendus.Sum(pv => pv.Produit.Prix * pv.QuantiteVendue);

                // Mettre à jour la quantité totale de la vente
                venteAValider.Total = sommeTotale;

                // Enregistrer les modifications dans la base de données
                _dbContext.SaveChanges();

                return true;
            }
            //_dbContext.Ventes.Remove();
            return false;
        }

        public bool DeleteVente(int idVente)
        {

            var venteToDelete = _dbContext.Ventes.Include(v => v.ProduitsVendus).FirstOrDefault(v => v.ID == idVente);

            if (venteToDelete != null)
            {
                // Récupérer les produits liés à cette vente
                var produitsVendus = venteToDelete.ProduitsVendus;

                // Supprimer les produits vendus en une seule opération
                _dbContext.ProduitsVendus.RemoveRange(produitsVendus);

                // Ensuite, supprimer la vente elle-même
                _dbContext.Ventes.Remove(venteToDelete);

                // Enregistrer les modifications dans la base de données
                _dbContext.SaveChanges();

                return true;
            }
            //_dbContext.Ventes.Remove();
            return false;

        }

        public Vente UpdateVente(int id, DateTime date, double total)
        {
            Vente venteToUpdate = _dbContext.Ventes.FirstOrDefault(v => v.ID == id);
            venteToUpdate.Total = total;
            venteToUpdate.Date = date;

            _dbContext.SaveChanges();

            return venteToUpdate;
        }

    }
}
