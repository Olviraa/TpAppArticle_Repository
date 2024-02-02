
using Microsoft.EntityFrameworkCore;
using ModelsCommun;

namespace ApiVenteArticles.Repositories
{
    public class ApiDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=LAPTOP-4C4P6UI8\\SQLEXPRESS;Database=StoreProject;Trusted_Connection=True;TrustServerCertificate=True");

        }
      
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Produit> Produits{ get; set; }

        public DbSet<ProduitVendu> ProduitsVendus{ get; set; }
        public DbSet<Vente> Ventes { get; set; }

    }



}
