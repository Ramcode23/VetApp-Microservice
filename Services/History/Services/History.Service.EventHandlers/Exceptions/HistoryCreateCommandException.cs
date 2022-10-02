using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace History.Service.EventHandlers.Exceptions
{
    public class HistoryCreateCommandException: Exception
    {
        public HistoryCreateCommandException(string message) : base(message) { }
    }
}
