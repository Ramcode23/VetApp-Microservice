using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MediatR;


namespace Agenda.Service.EventHandlers.Commands
{
    public class AgendaCreateCommand:INotification
    {
    	public DateTime Date { get; set; }
        
    	public int OwnerId { get; set; }

    	public int PetId { get; set; }

    	public string Remarks { get; set; }

    	[Display(Name = "Is Available?")]
    	public bool IsAvailable { get; set; }
        
       public string CreatedBy { get; set; } = string.Empty;
    }
}
