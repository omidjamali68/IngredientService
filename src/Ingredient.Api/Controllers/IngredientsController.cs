﻿using Ingredient.Application.Services.Ingredients.Commands.Add;
using Ingredient.Application.Services.Ingredients.Queries.GetAll;
using Ingredient.Domain.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ingredient.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IMediator mediator;

        public IngredientsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<Result<Guid>> Add(AddIngredientCommand request)
        {
            return await mediator.Send(request);
        }

        [HttpGet]
        public async Task<Result<GetIngredientsResponse>> GetAll(string? search, int page = 1)
        {
            return await mediator.Send(new GetIngredientsQuery(search, page));
        }
    }
}