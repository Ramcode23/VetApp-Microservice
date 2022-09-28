using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceType.Service.EventHandlers.Commands
{
    public class ServiceTypeUpdateCommand : INotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}