using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.Service.Queries.DTOs
{
    public class PetDTo
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public String ImageUrl { get; set; }

        public string Race { get; set; }


        public DateTime Born { get; set; }
        public string Remarks { get; set; }

        public int OwnerId { get; set; }


        public int PetTypeId { get; set; }

        
    }
}