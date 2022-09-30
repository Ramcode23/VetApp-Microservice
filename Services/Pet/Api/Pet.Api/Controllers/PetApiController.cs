using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pet.Service.EventHandlers.Commands;
using Pet.Service.Queries;
using Pet.Service.Queries.DTOs;
using Service.Common.Collection;

namespace Pet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetApiController : ControllerBase
    {

                private readonly ILogger<PetApiController> _logger;
        private readonly IMediator _mediator;
        private readonly IPetQueryService _petQueryService;
        public PetApiController(
                    ILogger<PetApiController> logger,
                   IMediator mediator,
                   IPetQueryService petCategoryQueryService)
        {
            _logger = logger;
            _mediator = mediator;
            _petQueryService = petCategoryQueryService;
        }


        [HttpGet()]

        public async Task<DataCollection<PetDTo>> GetAll(int page = 1, int take = 10, string? ids = null)
        {
            IEnumerable<int> pets = null;

            if (!string.IsNullOrEmpty(ids))
            {
                pets = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _petQueryService.GetAllAsync(page, take, pets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PetDTo>> GetPetTypeById(int id)
        {
            var petType = await _petQueryService.GetAsync(id);
            if (petType != null)
            {
                return petType;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> PostPetType([FromBody] PetCreateCommand model)
        {

            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                await _mediator.Publish(model);
                return Ok(model);
            }
            catch (System.Exception)
            {

                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetType(int id, PetUpdateCommand model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            model.Id = id;
            await _mediator.Publish(model);

            return Ok();

        }


        
    }
}