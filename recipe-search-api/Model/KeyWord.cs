using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecipeApi.Model;

public class KeyWord
{
    public int ID { get; set; }

    public string? Word { get; set; }

    public List<Recipe> Recipes { get; set; }
}
