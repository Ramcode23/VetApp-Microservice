using MediatR;
using History.Domain;
using History.Persistense.Database;
using History.Service.EventHandlers.Commands;

namespace History.Service.EventHandlers
{
    public class HistoryCreateEventHanler :
        INotificationHandler<HistoryCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public HistoryCreateEventHanler(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(HistoryCreateCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Domain.History {
                Description=notification.Description,
                Date=notification.Date,
                PetId=notification.PetId,
                Remarks=notification.Remarks,
                ServiceTypeId=notification.ServiceTypeId,
                CreatedBy=notification.CreatedBy
             });
            await _context.SaveChangesAsync();
        }
    }
}