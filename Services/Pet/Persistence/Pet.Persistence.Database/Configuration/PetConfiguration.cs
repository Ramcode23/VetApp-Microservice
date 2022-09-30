using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Pet.Persistence.Database.Configuration
{
    public class PetConfiguration
    {
        public PetConfiguration(EntityTypeBuilder<Domain.Pet> entityBuilder)
        {
             entityBuilder.HasKey(x => x.Id);
             entityBuilder.Property(x => x.Name).IsRequired();
             entityBuilder.Property(x => x.Born).IsRequired();
             entityBuilder.Property(x => x.OwnerId).IsRequired();
             entityBuilder.Property(x => x.PetTypeId).IsRequired();
             entityBuilder.Property(x => x.Race).IsRequired();
             entityBuilder.Property(x => x.Race).IsRequired();


           
        }
    }
}