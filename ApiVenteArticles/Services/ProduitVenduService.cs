using ApiVenteArticles.Interface;
using ApiVenteArticles.Repositories;
using Microsoft.EntityFrameworkCore;
using ModelsCommun;
using System.Diagnostics.Metrics;

namespace ApiVenteArticles.Services
{
    public class ProduitVenduService : IProduitVenduService
    {
        private readonly ApiDbContext _dbContext;

        public ProduitVenduService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProduitVendu> GetProductsVendre(int idVente)
        {
            var mavente = _dbContext.Ventes.Include(v => v.ProduitsVendus).ThenInclude(pv => pv.Produit).FirstOrDefault(v => v.ID == idVente);
            var listeProduitsVendus = mavente.ProduitsVendus.ToList();

            return listeProduitsVendus;
        }

        public ProduitVendu GetProductVendre(int id)
        {
             return _dbContext.ProduitsVendus.Include(p => p.Produit).FirstOrDefault(p => p.ID == id);

        }


        public int AddProduitVendre(int idvente, int idproduit, int quantite)
        {
         
            var mavente = _dbContext.Ventes.Include(p => p.ProduitsVendus).ThenInclude(pv => pv.Produit).FirstOrDefault(x => x.ID == idvente);


            if (mavente == null)
            {
                // Ma vente n'existe pas , je crée
                mavente = new Vente();
                mavente.Date = DateTime.Now;
                mavente.Total = 0; 
                mavente.ProduitsVendus = new List<ProduitVendu>();
                _dbContext.Ventes.Add(mavente);
                
            }

            //var listeproduits = mavente.ProduitsVendus.ToList();

            var existedeja = mavente.ProduitsVendus.Any(p => p.Produit.ID == idproduit);

            // si ajout du meme produit plusieurs fois dans le panier
            if (existedeja)
            {
                var produitvendu = mavente.ProduitsVendus.First(p => p.Produit.ID == idproduit);
                // On va rajouter la quatite de ce produit
                produitvendu.QuantiteVendue += quantite;
                _dbContext.SaveChanges();
                return mavente.ID;
            }
            else
            {
                // LE but est de rajouter un produit vendu
                var produitbase = _dbContext.Produits.Find(idproduit);

                var produitvendu = new ProduitVendu();
                produitvendu.Produit = produitbase;
                produitvendu.QuantiteVendue = quantite;

                //_dbContext.Ventes.Add(produitvendu);
                mavente.ProduitsVendus.Add(produitvendu);
               

                _dbContext.SaveChanges();
                return mavente.ID;
            } 
        }

        // Fonction pour rétirer un produit dans le Panier
        public bool DeleteProduitVendu(int idVente, int idProduit)
        {
            var maVente = _dbContext.Ventes.Include(p => p.ProduitsVendus).ThenInclude(pv => pv.Produit).FirstOrDefault(x => x.ID == idVente);

            if (maVente != null)
            {
                // Trouver le ProduitVendu dans la liste
                var produitVendu = maVente.ProduitsVendus.FirstOrDefault(pv => pv.Produit.ID == idProduit);

                if (produitVendu != null)
                {
                    // Retirer le ProduitVendu de la liste
                    maVente.ProduitsVendus.Remove(produitVendu);

                    // Enregistrez les modifications dans la base de données
                    _dbContext.SaveChanges();

                    return true;
                }
            }

            return false;
        }

    }
}
