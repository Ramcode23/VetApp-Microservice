using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceType.Service.EventHandlers.Exceptions
{
    public class ServiceTypeUpdateCommandException:Exception
    {
        public ServiceTypeUpdateCommandException(string message) : base(message) { }
       
    }
}
