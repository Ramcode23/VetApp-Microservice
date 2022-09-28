using MediatR;
using ServiceType.Service.EventHandlers.Commands;

namespace ServiceType.Service.EventHandlers;
public class ServiceTypeDeleteEventHanler : INotificationHandler<ServiceTypeDeleteCommand>
{
    public Task Handle(ServiceTypeDeleteCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
