using Microsoft.EntityFrameworkCore.Metadata.Builders;
using  ServiceType.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceType.Persistence.Database.Configuration
{
    public class ServiceTypeConfiguration
    {
        public ServiceTypeConfiguration(EntityTypeBuilder <ServiceCategory> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired();

            var petCategories = new  List<ServiceCategory>();

            for (int i = 0; i < 5; i++)
            {
                petCategories.Add(new ServiceCategory { Id=i+1, Name = $" Service {i+1}" });
            }
            entityBuilder.HasData(petCategories);
        }

    }
}
