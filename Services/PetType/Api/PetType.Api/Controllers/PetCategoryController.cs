using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetType.Service.EventHandlers.Commands;
using PetType.Service.Queries;
using PetType.Service.Queries.DTOs;
using Service.Common.Collection;

namespace PetType.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetCategoryController : ControllerBase
    {
        private readonly ILogger<PetCategoryController> _logger;
        private readonly IMediator _mediator;
        private readonly IPetCategoryQueryService _petCategoryQueryService;
        public PetCategoryController(
                    ILogger<PetCategoryController> logger,
                   IMediator mediator,
                   IPetCategoryQueryService petCategoryQueryService)
        {
            _logger = logger;
            _mediator = mediator;
            _petCategoryQueryService = petCategoryQueryService;
        }


        [HttpGet()]

        public async Task<DataCollection<PetCategoryDTo>> GetAll(int page = 1, int take = 10, string? ids = null)
        {
            IEnumerable<int> petCategories = null;

            if (!string.IsNullOrEmpty(ids))
            {
                petCategories = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _petCategoryQueryService.GetAllAsync(page, take, petCategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PetCategoryDTo>> GetPetTypeById(int id)
        {
            var petType = await _petCategoryQueryService.GetAsync(id);
            if (petType != null)
            {
                return petType;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> PostPetType([FromBody] PetCategoryCreateCommand model)
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
        public async Task<IActionResult> PutPetType(int id, PetCategoryUpdateCommand model)
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
