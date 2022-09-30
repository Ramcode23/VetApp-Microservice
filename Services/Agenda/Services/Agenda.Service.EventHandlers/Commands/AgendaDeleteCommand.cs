using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MediatR;


namespace Agenda.Service.EventHandlers.Commands
{
    public class AgendaDeleteCommand :INotification
    {
        public int Id { get; set; }

        

    }
}
