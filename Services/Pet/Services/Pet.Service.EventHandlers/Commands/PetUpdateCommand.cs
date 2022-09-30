using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Pet.Service.EventHandlers.Commands
{
    public class PetUpdateCommand : INotification
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageUrl { get; set; }

        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Race { get; set; }

        public DateTime Born { get; set; }
        public string Remarks { get; set; }
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string OwnerId { get; set; }
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public int PetTypeId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;

    }
}
