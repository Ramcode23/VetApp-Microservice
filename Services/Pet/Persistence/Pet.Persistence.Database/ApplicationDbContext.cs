using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pet.Persistence.Database.Configuration;

namespace Pet.Persistence.Database
{
    public class ApplicationDbContext:DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
  


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Database schema
        builder.HasDefaultSchema("Pet");

        // Model Contraints
        ModelConfig(builder);
    }


        public DbSet<Domain.Pet> Pets { get; set; }

    private void ModelConfig(ModelBuilder modelBuilder)
    {
        new PetConfiguration(modelBuilder.Entity<Domain.Pet>());

    }
}
}