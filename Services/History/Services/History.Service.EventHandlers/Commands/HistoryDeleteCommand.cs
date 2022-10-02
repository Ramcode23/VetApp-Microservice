using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace History.Service.EventHandlers.Commands
{
    public class HistoryDeleteCommand:INotification
    {
        public int Id { get; set; }
    }
}
