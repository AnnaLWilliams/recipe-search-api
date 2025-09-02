using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RecipeApi.Model;
using RecipeApi.Processing;

namespace RecipeApi.Commands;

public record AddNewRecipe(Recipe recipe) : IRequest<bool>;

public class AddNewRecipeHandler(PostgresContext postgresContext)
    : RequestHandlerBase<AddNewRecipe, bool>()
{
    public override async Task<bool> Handle(
        AddNewRecipe request,
        CancellationToken cancellationToken
    )
    {
        //Get list of ingredients as one string for key word parsing
        var ingredientsString = "";
        request.recipe.Ingredients.ForEach(i =>
        {
            ingredientsString.Concat($" {i.Name}");
        });
        //Get key words
        var keywordCounts = await KeyWordParse.ParseKeyWords(
            $"{request.recipe.Name} {request.recipe.Description} {request.recipe.Instructions} {ingredientsString}",
            postgresContext
        );

        //request.recipe.KeyWords = keywordCounts.Keys.Select(k => new KeyWord { Word = k }).ToList();

        var wordRecipePairs = keywordCounts
            .Select(kwc => new WordToRecipe
            {
                Recipe = request.recipe,
                KeyWord = new KeyWord { Word = kwc.Key },
                Count = kwc.Value,
            })
            .ToList();

        postgresContext.AddRange(wordRecipePairs);
        var saveResult = await postgresContext.SaveChangesAsync();
        return saveResult > 0;
    }
}
