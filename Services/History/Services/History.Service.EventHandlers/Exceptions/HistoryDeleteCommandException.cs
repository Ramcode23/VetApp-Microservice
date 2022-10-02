using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace History.Service.EventHandlers.Exceptions
{
    public class HistoryDeleteCommandException:Exception
    {
        public HistoryDeleteCommandException(string message) : base(message) { }

    }
}
