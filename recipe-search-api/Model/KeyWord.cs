using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecipeApi.Model;

public class KeyWord
{
    public int ID { get; set; }

    public string? word { get; set; }

    public List<WordToRecipe> wordToRecipes { get; set; }
}
