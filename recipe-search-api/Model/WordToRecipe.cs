using System;
using System.Collections.Generic;

namespace RecipeApi.Model;

public class WordToRecipe
{
    public int ID { get; set; }

    public int? wordId { get; set; }

    public int? recipeId { get; set; }

    public Recipe recipe { get; set; }

    public KeyWord keyWord { get; set; }
}
