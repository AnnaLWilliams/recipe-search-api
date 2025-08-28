using RecipeApi.Commands;

namespace RecipeApi.DependencyInjection;

public static class MediatorInstaller
{
    public static void AddMediation(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddNewRecipe).Assembly));
    }
}