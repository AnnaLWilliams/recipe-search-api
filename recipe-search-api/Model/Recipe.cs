using System;
using System.Collections.Generic;

namespace RecipeApi.Model;

public class Recipe
{
    public int ID { get; set; }

    public string? name { get; set; }

    public string? description { get; set; }

    public string? instructions { get; set; }

    public string? location { get; set; }

    public List<Ingredient> ingredients { get; set; }
    public List<WordToRecipe> wordToRecipes { get; set; }
}
