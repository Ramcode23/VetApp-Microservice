using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Common.Queries;
using ServiceType.Service.Queries.DTOs;

namespace ServiceType.Service.Queries
{
    public interface IServiceTypeQueryService:IQueryExtension<ServiceTypeDTo>
    {
        
    }
}