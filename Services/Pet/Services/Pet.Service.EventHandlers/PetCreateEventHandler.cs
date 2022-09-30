using MediatR;
using Pet.Persistence.Database;
using Pet.Service.EventHandlers.Commands;

namespace Pet.Service.EventHandlers;

public class PetCreateEventHandler :
INotificationHandler<PetCreateCommand>
{

    private readonly ApplicationDbContext _context;

    public PetCreateEventHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(PetCreateCommand notification, CancellationToken cancellationToken)
    {
        await _context.AddAsync(new Domain.Pet
        {
            Name = notification.Name,
            Born = notification.Born,
            ImageUrl = notification.ImageUrl.FileName,
            OwnerId = notification.OwnerId,
            PetTypeId = notification.PetTypeId,
            Race = notification.Race,
            Remarks = notification.Remarks,
            CreatedAt= DateTime.UtcNow,
            CreatedBy=notification.CreatedBy
        
        });
        await _context.SaveChangesAsync();
    }
}
