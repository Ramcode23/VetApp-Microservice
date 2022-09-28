using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  ServiceType.Service.EventHandlers.Exceptions
{
    public class ServiceTypeCreateCommandException: Exception
    {
        public ServiceTypeCreateCommandException(string message) : base(message) { }
    }
}
