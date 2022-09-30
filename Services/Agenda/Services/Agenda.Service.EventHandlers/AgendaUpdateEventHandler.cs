using MediatR;
using Microsoft.EntityFrameworkCore;
using Agenda.Service.EventHandlers.Commands;
using Agenda.Persistense.Database;

namespace Agenda.Service.EventHandlers;

public class AgendaUpdateEventHandler :
INotificationHandler<AgendaUpdateCommand>
{

    private readonly ApplicationDbContext _context;

    public AgendaUpdateEventHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(AgendaUpdateCommand notification, CancellationToken cancellationToken)
    {
         var  AgendaDb= await _context.Agendas.FirstOrDefaultAsync(x=>x.Id==notification.Id);
 
            AgendaDb.Date = notification.Date;
            AgendaDb.PetId = notification.PetId;
            AgendaDb.OwnerId = notification.OwnerId;
            AgendaDb.Remarks = notification.Remarks;
            AgendaDb.UpdatedBy = notification.UpdateddBy;
            AgendaDb.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }
}
