using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using History.Service.Queries.DTOs;
using Service.Common.Queries;

namespace History.Service.Queries
{
    public interface IHistoryQueryService:IQueryExtension<HistoryDTo>
    {
        
    }
}