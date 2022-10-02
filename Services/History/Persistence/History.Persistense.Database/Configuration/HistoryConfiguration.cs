using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace History.Persistense.Database.Configuration
{
    public class HistoryConfiguration
    {
         public HistoryConfiguration(EntityTypeBuilder<Domain.History> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Date).IsRequired();
            entityBuilder.Property(x => x.ServiceTypeId).IsRequired();
            entityBuilder.Property(x => x.PetId).IsRequired();
            entityBuilder.Property(x => x.Remarks).IsRequired();
            entityBuilder.Property(x => x.Description).IsRequired();
      


        }
    }
}