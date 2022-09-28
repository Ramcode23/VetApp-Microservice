using AutoMapper;
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
       

        }
    }
}
