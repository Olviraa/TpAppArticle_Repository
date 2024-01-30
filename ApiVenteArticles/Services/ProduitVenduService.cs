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

        public List<ProduitVendu> GetProductsVendre()
        {
            return _dbContext.ProduitsVendus.Include(p => p.Produit).ToList();
        }

        public ProduitVendu GetProductVendre(int id)
        {
             return _dbContext.ProduitsVendus.Include(p => p.Produit).FirstOrDefault(p => p.ID == id);

        }


        public ProduitVendu AddProduitVendre(int idvente, int idproduit, int quantite)
        {
         
            var mavente = _dbContext.Ventes.Include(p => p.ProduitsVendus).ThenInclude(pv => pv.Produit).FirstOrDefault(x => x.ID == idvente);


            if (mavente == null)
            {
                // Ma vente n'existe pas , je cree
                mavente = new Vente();
                _dbContext.Ventes.Add(mavente);
                
            }

            //var listeproduits = mavente.ProduitsVendus.ToList();

            var existedeja = mavente.ProduitsVendus.Any(p => p.Produit.ID == idproduit);


            if (existedeja)
            {
                var produitvendu = mavente.ProduitsVendus.First(p => p.Produit.ID == idproduit);
                // On va rajouter la quatite de ce produit
                produitvendu.QuantiteVendue += quantite;
                _dbContext.SaveChanges();
                return produitvendu;
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
                mavente.Total = 
               

                _dbContext.SaveChanges();
                return produitvendu;
            } 
        }

        public void DeleteProduct(int id)
        {

            ProduitVendu productToDelete = _dbContext.ProduitsVendus.FirstOrDefault(pv => pv.ID == id);

            _dbContext.ProduitsVendus.Remove(productToDelete);
            _dbContext.SaveChanges();



        }

    }
}
