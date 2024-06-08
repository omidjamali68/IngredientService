using Ingredient.Application.Services.Units.Commands.Add;
using Ingredient.Application.Services.Units.Queries.GetAll;
using Ingredient.Domain.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ingredient.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IMediator  _mediator;

        public UnitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Result> Add(AddUnitCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<Result> GetAll(string? searchKey, int page = 1)
        {
            return await _mediator.Send(new GetUnitsQuery (searchKey, page));
        }
    }
}
