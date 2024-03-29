﻿using ModelsCommun;

namespace WebAppliClients.Models.ViewModels
{
    // dans le panier (la vente) il y a une liste de produit

    public class VentesViewModel
    {
        //public List<ProduitVendu> ProduitsVendus { get; set; }

        //public VentesViewModel(List<ProduitVendu> listProduit)
        //{
        //    ProduitsVendus = listProduit;
        //}

        public class ProduitVenduViewModel
        {
            public int ID { get; set; }
            public int IdProduit { get; set; }
            public int IdVente { get; set; }
            public int Quantite { get; set; }
            public Produit Produit { get; set; }

            public ProduitVendu ProduitVendu { get; set; }
        }
    }

}
