using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using History.Persistense.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using History.Service.EventHandlers.Commands;
using History.Service.EventHandlers.Exceptions;

namespace History.Service.EventHandlers
{
    public class HistoryUpdateEventHanler : INotificationHandler<HistoryUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HistoryUpdateEventHanler> _logger;
        public HistoryUpdateEventHanler(ApplicationDbContext context,
            ILogger<HistoryUpdateEventHanler> logger
            )
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(HistoryUpdateCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- HistoryUpdateCommand started");
            var history = await _context.Histories.FirstOrDefaultAsync(c => c.Id == notification.Id);
            if (history == null)
            {

                _logger.LogError($"--- history {notification.Id} -is not exits");
                throw new HistoryUpdateCommandException($"--- history {notification.Id} -is not exits");
            }

            // history.Name = notification.CategoryName;
                history.Description = notification.Description;
                history.Date = notification.Date;
                history.PetId = notification.PetId;
                history.Remarks = notification.Remarks;
                history.ServiceTypeId = notification.ServiceTypeId;
                history.UpdatedBy = notification.UpdatedBy;
            await _context.SaveChangesAsync();

        }
    }
}
