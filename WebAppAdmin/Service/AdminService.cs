﻿using ModelsCommun;
using WebAppAdmin.Repository;

namespace WebAppAdmin.Service
{
    public class AdminService
    {
        public List<Produit> GetListeProduitService()
        {
            List<Produit> listeProduits = new List<Produit>();
            APIRepo apiRepo = new APIRepo();
            listeProduits = apiRepo.GetProduits();
            
            return listeProduits;
        }
    }
}