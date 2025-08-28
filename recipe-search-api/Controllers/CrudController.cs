using System.Formats.Asn1;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using RecipeApi.Model;
using RecipeApi.Dto;
using RecipeApi.Commands;
namespace RecipeApi.Controllers;

/// <summary>
/// Manages recipes
/// </summary>
[Consumes("application/json")]
[Produces("application/json")]
[SwaggerTag("Sends a sql command to the recipe database")]
public sealed class CrudController(
    ILogger<CrudController> logger,
    IMediator mediator
) : RecipeControllerBase(mediator)
{
    /// <summary>
    /// Adds a recipe to the database
    /// </summary>
    /// <param name="recipe">The recipe to be added</param>
    /// <param name="cancellationToken">An optional cancellation token</param>
    /// <returns></returns>
    [HttpPost]
    [Route("api/v1/RecipeCrud")]
    [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponce), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostRecipeAsync(
        [FromBody] Recipe recipe,
        CancellationToken cancellationToken = default
    )
    {
        _ = await mediator.Send(
            new AddNewRecipe(recipe),
            cancellationToken
        );

        return new NoContentResult();
    }

    [HttpGet]
    [Route("api/v1/RecipeCrud")]
    [ProducesResponseType(typeof(Recipe), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponce), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorResponce), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetRecipeByIdAsync(
       int recipeId,
       CancellationToken cancellationToken = default
    )
    {
        var returnedRecipe = await mediator.Send(
            new GetRecipeById(recipeId),
            cancellationToken
        );

        return returnedRecipe == null
            ? new NotFoundObjectResult(
                new ErrorResponce
                {
                    Code = 404,
                    Errors = new string[1] { $"Recipe not found for id# {recipeId}." }
                }
            )
            : new OkObjectResult(returnedRecipe);
    }

    [HttpDelete]
    [Route("api/v1/RecipeCrud")]
    [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponce), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorResponce), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteRecipeByIdAsync(
        int recipeId,
        CancellationToken cancellationToken = default
    )
    {
        throw new NotImplementedException();
    }

}