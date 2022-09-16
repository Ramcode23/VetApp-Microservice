using MediatR;
using ServiceType.Service.EventHandlers.Commands;

namespace ServiceType.Service.EventHandlers;
public class ServiceTypeCreateEventHanler : INotificationHandler<ServiceTypeCreateCommand>
{
    public Task Handle(ServiceTypeCreateCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
