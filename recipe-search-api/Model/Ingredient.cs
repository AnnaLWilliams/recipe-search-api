using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Model;

public class Ingredient
{
    public int ID { get; set; }

    public int? recipeId { get; set; }

    public string? name { get; set; }

    public float? amount { get; set; }

    public string? unit { get; set; }

    public Recipe recipe { get; set; }
}
