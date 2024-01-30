<<<<<<< Updated upstream
﻿using ModelsCommun;

namespace ApiVenteArticles.Interface
{
    public interface IProduitVenduService
    {

        public List<ProduitVendu> GetProductsVendre();

        public ProduitVendu GetProductVendre(int id);
        public ProduitVendu AddProduitVendre(int idvente, int idproduit, int quantite);

        public void DeleteProduct(int id);

=======
﻿namespace ApiVenteArticles.Interface
{
    public class IProduitVenteService
    {
>>>>>>> Stashed changes
    }
}
