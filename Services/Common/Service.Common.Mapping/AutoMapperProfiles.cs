using Agenda.Service.Queries.DTOs;
using AutoMapper;
using Pet.Service.Queries.DTOs;
using PetType.Domain;
using PetType.Service.Queries.DTOs;

using Service.Common.Collection;
using ServiceType.Domain;
using ServiceType.Service.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            
           CreateMap<DataCollection<PetCategory>,DataCollection<PetCategoryDTo>>().ReverseMap();
            CreateMap<DataCollection<PetCategory>, DataCollection<PetCategoryDTo>>();
            CreateMap<PetCategory, PetCategoryDTo>().ReverseMap();
            CreateMap<PetCategory, PetCategoryDTo>();
          
          
           CreateMap<DataCollection<ServiceCategory>,DataCollection<ServiceTypeDTo>>().ReverseMap();
            CreateMap<DataCollection<ServiceCategory>, DataCollection<ServiceTypeDTo>>();
            CreateMap<ServiceCategory, ServiceTypeDTo>().ReverseMap();
            CreateMap<ServiceCategory, ServiceTypeDTo>();


           CreateMap<DataCollection<Pet.Domain.Pet>,DataCollection<PetDTo>>().ReverseMap();
            CreateMap<DataCollection<Pet.Domain.Pet>, DataCollection<PetDTo>>();
            CreateMap<Pet.Domain.Pet, PetDTo>().ReverseMap();
            CreateMap<Pet.Domain.Pet, PetDTo>();
       
           CreateMap<DataCollection<Agenda.Domain.Agenda>,DataCollection<AgendaDTO>>().ReverseMap();
            CreateMap<DataCollection<Agenda.Domain.Agenda>, DataCollection<AgendaDTO>>();
            CreateMap<Agenda.Domain.Agenda, AgendaDTO>().ReverseMap();
            CreateMap<Agenda.Domain.Agenda, AgendaDTO>();
       

        }
    }
}
