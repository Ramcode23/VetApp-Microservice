using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pet.Service.Queries.DTOs;
using Service.Common.Collection;
using Service.Common.Queries;

namespace Pet.Service.Queries
{
    public interface IPetQueryService:IQueryExtension<PetDTo>
    {

    }
}