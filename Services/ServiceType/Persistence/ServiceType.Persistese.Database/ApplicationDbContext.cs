using Microsoft.EntityFrameworkCore;
using ServiceType.Domain;
using ServiceType.Persistence.Database.Configuration;

namespace ServiceType.Persistese.Database;
public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Database schema
        builder.HasDefaultSchema("ServiceCategories");

        // Model Contraints
        ModelConfig(builder);
    }


    public DbSet<ServiceCategory> ServiceCategories { get; set; }

    private void ModelConfig(ModelBuilder modelBuilder)
    {
        new ServiceTypeConfiguration(modelBuilder.Entity<ServiceCategory>());

    }


}
