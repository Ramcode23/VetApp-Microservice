using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Pet.Service.EventHandlers.Commands
{
    public class PetDeleteCommand : INotification
    {
        public int Id { get; set; }

        

    }
}
