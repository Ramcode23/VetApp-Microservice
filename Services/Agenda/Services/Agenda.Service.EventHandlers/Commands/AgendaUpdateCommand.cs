using System.ComponentModel.DataAnnotations;
using MediatR;


namespace Agenda.Service.EventHandlers.Commands
{
    public class AgendaUpdateCommand : INotification
    {
        public int Id { get; set; }
    	public DateTime Date { get; set; }

    	public string OwnerId { get; set; }

    	public int PetId { get; set; }

    	public string Remarks { get; set; }

    	[Display(Name = "Is Available?")]
    	public bool IsAvailable { get; set; }

	    public string UpdateddBy { get; set; } = string.Empty;

    }
}
