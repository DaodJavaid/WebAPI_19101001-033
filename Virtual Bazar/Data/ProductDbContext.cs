using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Virtual_Bazar.Models;

namespace Virtual_Bazar.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<ProductModel> Product_Detail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>()
                .Property(p => p.Id)
                .UseIdentityColumn()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<ProductModel>()
                .Property(p => p.Id)
                .ValueGeneratedNever();

            base.OnModelCreating(modelBuilder);
        }

        public void EnableIdentityInsertForProductDetail()
        {
            Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Product_Detail ON");
        }

        public void DisableIdentityInsertForProductDetail()
        {
            Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Product_Detail OFF");
        }
    }
}
