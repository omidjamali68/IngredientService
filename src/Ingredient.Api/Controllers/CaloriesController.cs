using Ingredient.Application.Services.Calories.Commands.Add;
using Ingredient.Application.Services.Calories.Commands.Update;
using Ingredient.Application.Services.Calories.Queries.GetAll;
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

        [HttpGet]
        public async Task<Result<GetCaloriesResponse>> GetAll(string? search, int page = 1)
        {
            return await mediator.Send(new GetCaloriesQuery(search, page));
        }

        [HttpPut("{id}")]
        public async Task<Result> Update(int id, UpdateCalorieDto dto)
        {
            return await mediator.Send(new  UpdateCalorieCommand(id, dto));
        }
    }
}
