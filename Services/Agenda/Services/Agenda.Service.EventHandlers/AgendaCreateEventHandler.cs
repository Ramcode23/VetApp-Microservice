using MediatR;

using Agenda.Service.EventHandlers.Commands;
using Agenda.Persistense.Database;

namespace Agenda.Service.EventHandlers;

public class AgendaCreateEventHandler :
INotificationHandler<AgendaCreateCommand>
{

    private readonly ApplicationDbContext _context;

    public AgendaCreateEventHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(AgendaCreateCommand notification, CancellationToken cancellationToken)
    {
        await _context.AddAsync(new Domain.Agenda
        {
           
        
        });
        await _context.SaveChangesAsync();
    }
}
