using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetType.Service.EventHandlers.Commands
{
    public class PetCategoryCreateCommand:INotification
    {
        public string CategoryName { get; set; }
    }
}
