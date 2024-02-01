
﻿using ModelsCommun;

namespace ApiVenteArticles.Interface
{
    public interface IProduitVenduService
    {

        public List<ProduitVendu> GetProductsVendre(int venteId);

        public ProduitVendu GetProductVendre(int id);
        public int AddProduitVendre(int idvente, int idproduit, int quantite);

        public bool DeleteProduitVendu(int idVente,int idProduit);

    }
}


