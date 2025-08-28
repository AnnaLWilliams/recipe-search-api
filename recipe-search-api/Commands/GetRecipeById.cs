using MediatR;
using RecipeApi.Model;

namespace RecipeApi.Commands;

public record GetRecipeById(int id) : IRequest<Recipe>;

public class GetRecipeByIdHandler(
    //IHttpClientFactory httpClientFactory
)
    : RequestHandlerBase<GetRecipeById, Recipe>(
        //httpClientFactory
    )
{
    public override async Task<Recipe> Handle(GetRecipeById request, CancellationToken cancellationToken)
    {
        return new Recipe();
    }
}