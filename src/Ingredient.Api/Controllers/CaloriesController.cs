using Ingredient.Application.Services.Calories.Commands.Add;
using Ingredient.Domain.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ingredient.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaloriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CaloriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<Result<int>> Add(string title)
        {
            return await mediator.Send(new AddCalorieCommand(title));
        }
    }
}
