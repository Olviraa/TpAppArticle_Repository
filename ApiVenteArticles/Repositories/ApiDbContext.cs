
using Microsoft.EntityFrameworkCore;
using ModelsCommun;

namespace ApiVenteArticles.Repositories
{
    public class ApiDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=DESKTOP-DTUC5BR\\SQLEXPRESS;Database=VenteProduit;Trusted_Connection=True;TrustServerCertificate=True");

        }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Produit> Produits{ get; set; }

        public DbSet<ProduitVendu> ProduitsVendus{ get; set; }
        public DbSet<Vente> Ventes { get; set; }

    }



}
