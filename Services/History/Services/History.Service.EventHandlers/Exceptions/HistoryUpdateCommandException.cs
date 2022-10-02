using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace History.Service.EventHandlers.Exceptions
{
    public class HistoryUpdateCommandException:Exception
    {
        public HistoryUpdateCommandException(string message) : base(message) { }
       
    }
}
