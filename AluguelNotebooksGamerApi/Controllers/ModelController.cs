using AluguelNotebooksGamerApi.CQRS.Commands;
using AluguelNotebooksGamerApi.CQRS.Notifications;
using AluguelNotebooksGamerApi.CQRS.Queries;
using AluguelNotebooksGamerApi.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AluguelNotebooksGamerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var models = await mediator.Send(new GetModelsQuery());
            return Ok(models);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddModel([FromBody] Model model)
        {
            var modelResult = await mediator.Send(new AddModelCommand(model));

            await mediator.Publish(new ModelAddedNotification(modelResult));

            return CreatedAtRoute("GetModelById", new { id = modelResult.Id }, modelResult);
        }

        [HttpGet("{id:int}", Name = "GetModelById")]
        public async Task<IActionResult> GetModelById(int id)
        {
            var model = await mediator.Send(new GetModelByIdQuery(id));
            return Ok(model);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateModel(Model model)
        {
            var modelResult = await mediator.Send(new UpdateModelCommand(model));

            return CreatedAtRoute("GetModelById", new { id = modelResult.Id }, modelResult);
        }
    }
}
