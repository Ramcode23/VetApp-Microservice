using History.Persistense.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace History.Persistense.Database;
public class ApplicationDbContext:DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
  
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Database schema
        builder.HasDefaultSchema("History");

        // Model Contraints
        ModelConfig(builder);
    }

        public DbSet<Domain.History> Histories { get; set; }

    private void ModelConfig(ModelBuilder modelBuilder)
    {
        new HistoryConfiguration(modelBuilder.Entity<Domain.History>());

    }


}
