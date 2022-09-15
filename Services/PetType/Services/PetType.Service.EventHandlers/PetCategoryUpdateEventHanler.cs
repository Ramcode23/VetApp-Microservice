using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetType.Persistense.Database;
using PetType.Service.EventHandlers.Commands;
using PetType.Service.EventHandlers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetType.Service.EventHandlers
{
    public class PetCategoryUpdateEventHanler : INotificationHandler<PetCategoryUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PetCategoryUpdateEventHanler> _logger;
        public PetCategoryUpdateEventHanler(ApplicationDbContext context,
            ILogger<PetCategoryUpdateEventHanler> logger
            )
        {
        _context=context;
            _logger=logger;
        }

        public async Task Handle(PetCategoryUpdateCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- PetCategoryUpdateCommand started");
            var petCategory= await _context.PetCategories.FirstOrDefaultAsync(c => c.Id == notification.Id);
            if (petCategory == null)
            {

                _logger.LogError($"--- PetCategory {notification.Id} -is not exits");
            throw new PetCategoryUpdateCommandException($"--- PetCategory {notification.Id} -is not exits");
            }

            petCategory.Name = notification.CategoryName;

            await _context.SaveChangesAsync();

        }
    }
}
