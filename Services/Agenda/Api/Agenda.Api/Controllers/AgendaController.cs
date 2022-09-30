using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Service.EventHandlers.Commands;
using Agenda.Service.Queries;
using Agenda.Service.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;

namespace Agenda.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendaController : ControllerBase
    {

        private readonly ILogger<AgendaController> _logger;
        private readonly IMediator _mediator;
        private readonly IAgendaQueryService _agendaQueryService;
        public AgendaController(ILogger<AgendaController> logger,
                                IMediator mediator,
                                IAgendaQueryService agendaQueryService)
        {
            _logger = logger;
            _mediator = mediator;
            _agendaQueryService = agendaQueryService;
        }

 [HttpGet()]

        public async Task<DataCollection<AgendaDTO>> GetAll(int page = 1, int take = 10, string? ids = null)
        {
            IEnumerable<int> agendas = null;

            if (!string.IsNullOrEmpty(ids))
            {
                agendas = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _agendaQueryService.GetAllAsync(page, take, agendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgendaDTO>> GetAgendaTypeById(int id)
        {
            var AgendaType = await _agendaQueryService.GetAsync(id);
            if (AgendaType != null)
            {
                return AgendaType;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> PostAgendaType([FromBody] AgendaCreateCommand model)
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
        public async Task<IActionResult> PutAgendaType(int id, AgendaUpdateCommand model)
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
