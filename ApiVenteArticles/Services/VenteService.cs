﻿using ApiVenteArticles.Interface;
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

        public void DeleteVente(int id)
        {

            Vente venteToDelete = _dbContext.Ventes.Include(p => p.ProduitsVendus).FirstOrDefault(p => p.ID == id);   
            _dbContext.Ventes.Remove(venteToDelete);
           _dbContext.SaveChanges();

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
