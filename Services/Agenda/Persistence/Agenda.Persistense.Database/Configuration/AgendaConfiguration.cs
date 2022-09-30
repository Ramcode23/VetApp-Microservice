using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Persistense.Database.Configuration
{
    public class AgendaConfiguration
    {
        public AgendaConfiguration(EntityTypeBuilder<Domain.Agenda> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Date).IsRequired();
            entityBuilder.Property(x => x.OwnerId).IsRequired();
            entityBuilder.Property(x => x.PetId).IsRequired();
            entityBuilder.Property(x => x.Remarks).IsRequired();
      


        }
    }

}
