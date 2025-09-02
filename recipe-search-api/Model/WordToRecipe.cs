using System;
using System.Collections.Generic;

namespace RecipeApi.Model;

public class WordToRecipe
{
    public int ID { get; set; }

    public int? WordID { get; set; }
    public KeyWord KeyWord { get; set; }
    public int? RecipeID { get; set; }
    public Recipe Recipe { get; set; }
    public int? Count { get; set; }
}
