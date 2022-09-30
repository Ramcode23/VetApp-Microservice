using Agenda.Persistense.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Persistense.Database;
  public class ApplicationDbContext:DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
  
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Database schema
        builder.HasDefaultSchema("Agenda");

        // Model Contraints
        ModelConfig(builder);
    }


        public DbSet<Domain.Agenda> Agendas { get; set; }

    private void ModelConfig(ModelBuilder modelBuilder)
    {
        new AgendaConfiguration(modelBuilder.Entity<Domain.Agenda>());

    }
}