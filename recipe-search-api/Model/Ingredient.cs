using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Model;

public class Ingredient
{
    public int ID { get; set; }

    public int? RecipeID { get; set; }
    public Recipe Recipe { get; set; }
    public string? Name { get; set; }

    public float? Amount { get; set; }

    public string? Unit { get; set; }

}
