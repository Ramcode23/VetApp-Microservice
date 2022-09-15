using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetType.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetType.Persistence.Database.Configuration
{
    public class PetCategoryConfiguration
    {
        public PetCategoryConfiguration(EntityTypeBuilder <PetCategory> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired();

            var petCategories = new  List<PetCategory>();

            for (int i = 0; i < 5; i++)
            {
                petCategories.Add(new PetCategory { Id=i+1, Name = $" PetCategory {i}" });
            }
            entityBuilder.HasData(petCategories);
        }

    }
}
