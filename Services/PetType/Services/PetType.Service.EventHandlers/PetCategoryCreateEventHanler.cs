using MediatR;
using PetType.Domain;
using PetType.Persistense.Database;
using PetType.Service.EventHandlers.Commands;

namespace PetType.Service.EventHandlers
{
    public class PetCategoryCreateEventHanler :
        INotificationHandler<PetCategoryCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public PetCategoryCreateEventHanler(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(PetCategoryCreateCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new PetCategory { Name = notification.CategoryName });
            await _context.SaveChangesAsync();
        }
    }
}