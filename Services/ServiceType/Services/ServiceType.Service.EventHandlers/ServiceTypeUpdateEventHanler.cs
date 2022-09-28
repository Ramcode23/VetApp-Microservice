using MediatR;
using ServiceType.Service.EventHandlers.Commands;

namespace ServiceType.Service.EventHandlers;
public class ServiceTypeUpdateEventHanler : INotificationHandler<ServiceTypeUpdateCommand>
{
    public Task Handle(ServiceTypeUpdateCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
