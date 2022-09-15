using MediatR;
using PetType.Service.EventHandlers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetType.Service.EventHandlers
{
    public class PetCategoryDeleteEventHanler : INotificationHandler<PetCategoryDeleteCommand>
    {
        public Task Handle(PetCategoryDeleteCommand notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
