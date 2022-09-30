using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Service.Queries.DTOs
{
    public class AgendaDTO
    {
        
        public int Id { get; set; }

    	
    	public DateTime Date { get; set; }

    	public int OwnerId { get; set; }

    	public int PetId { get; set; }

    	public string Remarks { get; set; }

    	[Display(Name = "Is Available?")]
    	public bool IsAvailable { get; set; }
    }
}