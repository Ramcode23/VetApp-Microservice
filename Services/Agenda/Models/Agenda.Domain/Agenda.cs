using System.ComponentModel.DataAnnotations;
using Service.Common.Model;

namespace Agenda.Domain;
public class Agenda:BaseEntity
{
      

        [Display(Name = "Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string OwnerId { get; set; }
        public int PetId { get; set; }

        public string Remarks { get; set; }

        [Display(Name = "Is Available?")]
        public bool IsAvailable { get; set; }
}
