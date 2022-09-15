using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetType.Service.EventHandlers.Exceptions
{
    public class PetCategoryCreateCommandException: Exception
    {
        public PetCategoryCreateCommandException(string message) : base(message) { }
    }
}
