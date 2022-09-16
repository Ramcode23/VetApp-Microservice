using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceType.Service.EventHandlers.Commands
{
    public class ServiceTypeDeleteCommand:INotification
    {
         public int Id { get; set; }
    }
}