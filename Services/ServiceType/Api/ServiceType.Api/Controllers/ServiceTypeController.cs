using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceType.Service.Queries;
using Service.Common.Collection;
using ServiceType.Service.Queries.DTOs;
using ServiceType.Service.EventHandlers.Commands;


namespace ServiceType.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceTypeController : ControllerBase
    {
        private readonly ILogger<ServiceTypeController> _logger;
        private readonly IMediator _mediator;
        private readonly IServiceTypeQueryService _serviceTypeQueryService;

        public ServiceTypeController(ILogger<ServiceTypeController> logger,
                                    IMediator mediator,
                                    IServiceTypeQueryService serviceTypeQueryService)
        {
            _logger = logger;
            _mediator = mediator;
            _serviceTypeQueryService = serviceTypeQueryService;
        }


        [HttpGet()]

        public async Task<DataCollection<ServiceTypeDTo>> GetAll(int page = 1, int take = 10, string? ids = null)
        {
            IEnumerable<int> serviceCategories = null;

            if (!string.IsNullOrEmpty(ids))
            {
                serviceCategories = ids.Split(',').Select(x => Convert.ToInt32(x));
            }
            
            return await _serviceTypeQueryService.GetAllAsync(
                            page, take, serviceCategories);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceTypeDTo>> GetPetTypeById(int id)
        {
            var petType = await _serviceTypeQueryService.GetAsync(id);
            if (petType != null)
            {
                return petType;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> PostPetType([FromBody] ServiceTypeCreateCommand model)
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
        public async Task<IActionResult> PutPetType(int id, ServiceTypeUpdateCommand model)
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
