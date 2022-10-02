using History.Service.EventHandlers.Commands;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace History.Service.EventHandlers
{
    public class HistoryDeleteEventHanler : INotificationHandler<HistoryDeleteCommand>
    {
        public Task Handle(HistoryDeleteCommand notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
