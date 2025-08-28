using MediatR;
using RecipeApi.Model;

namespace RecipeApi.Commands;

public record AddNewRecipe(Recipe recipe) : IRequest<bool>;

public class AddNewRecipeHandler(
    //IHttpClientFactory httpClientFactory
)
    : RequestHandlerBase<AddNewRecipe, bool>(
        //httpClientFactory
    )
{
    public override async Task<bool> Handle(AddNewRecipe request, CancellationToken cancellationToken)
    {
        return true;
    }        
}