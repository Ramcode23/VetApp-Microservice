using MediatR;
using Microsoft.EntityFrameworkCore;
using Pet.Persistence.Database;
using Pet.Service.EventHandlers.Commands;

namespace Pet.Service.EventHandlers;

public class PetUpdateEventHandler :
INotificationHandler<PetUpdateCommand>
{

    private readonly ApplicationDbContext _context;

    public PetUpdateEventHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(PetUpdateCommand notification, CancellationToken cancellationToken)
    {
         var  petDb= await _context.Pets.FirstOrDefaultAsync(x=>x.Id==notification.Id);
 
            petDb.Name = notification.Name;
            petDb.Born = notification.Born;
            petDb.ImageUrl = notification.ImageUrl.FileName;
            petDb.OwnerId = notification.OwnerId;
            petDb.PetTypeId = notification.PetTypeId;
            petDb.Race = notification.Race;
            petDb.Remarks = notification.Remarks;
          
          
        
        
        await _context.SaveChangesAsync();
    }
}
