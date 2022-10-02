using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using History.Service.EventHandlers.Commands;
using History.Service.Queries;
using History.Service.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;

namespace History.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly ILogger<HistoryController> _logger;
        private readonly IMediator _mediator;
        private readonly IHistoryQueryService _historyQueryService;
        public HistoryController(
                    ILogger<HistoryController> logger,
                   IMediator mediator,
                   IHistoryQueryService historyQueryService)
        {
            _logger = logger;
            _mediator = mediator;
            _historyQueryService = historyQueryService;
        }


        [HttpGet()]

        public async Task<DataCollection<HistoryDTo>> GetAll(int page = 1, int take = 10, string? ids = null)
        {
            IEnumerable<int> histories = null;

            if (!string.IsNullOrEmpty(ids))
            {
                histories = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _historyQueryService.GetAllAsync(page, take, histories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistoryDTo>> GetPetTypeById(int id)
        {
            var petType = await _historyQueryService.GetAsync(id);
            if (petType != null)
            {
                return petType;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> PostPetType([FromBody] HistoryCreateCommand model)
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
        public async Task<IActionResult> PutPetType(int id, HistoryUpdateCommand model)
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