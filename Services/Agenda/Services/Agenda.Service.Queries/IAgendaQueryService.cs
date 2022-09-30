using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Service.Queries.DTOs;
using Service.Common.Queries;

namespace Agenda.Service.Queries
{
    public interface IAgendaQueryService:IQueryExtension<AgendaDTO>
    {
        
    }
}