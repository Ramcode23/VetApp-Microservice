using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Identity.Service.EventHandlers.Responses;

namespace Identity.Service.EventHandlers.Commands
{
      public class UserLoginCommand : IRequest<IdentityAccess>
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}