using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace RecipeApi.Controllers;

[ApiController]
public abstract class RecipeControllerBase(IMediator mediator) : ControllerBase
{
    protected readonly IMediator mediator = mediator;
}