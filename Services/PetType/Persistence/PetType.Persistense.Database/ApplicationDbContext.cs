using Microsoft.EntityFrameworkCore;
using PetType.Domain;
using PetType.Persistence.Database.Configuration;

namespace PetType.Persistense.Database;
public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
  


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Database schema
        builder.HasDefaultSchema("PetCategory");

        // Model Contraints
        ModelConfig(builder);
    }


        public DbSet<PetCategory> PetCategories { get; set; }

    private void ModelConfig(ModelBuilder modelBuilder)
    {
        new PetCategoryConfiguration(modelBuilder.Entity<PetCategory>());

    }


}
