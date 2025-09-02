using System;
using System.Collections.Generic;

namespace RecipeApi.Model;

public class Recipe
{
    public int ID { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Instructions { get; set; }

    public string? Location { get; set; }

    public List<Ingredient> Ingredients { get; set; }
    public List<KeyWord> KeyWords { get; set; }
}
