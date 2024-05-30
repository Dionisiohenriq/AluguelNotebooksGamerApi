using AluguelNotebooksGamerApi.CQRS.Commands;
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

        [HttpPost]
        public async Task<IActionResult> AddModel([FromBody] Model model)
        {
            await mediator.Send(new AddModelCommand(model));

            return StatusCode(201);
        }
    }
}
