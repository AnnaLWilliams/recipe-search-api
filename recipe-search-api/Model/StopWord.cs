using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecipeApi.Model;

public class StopWord
{
    public int ID { get; set; }

    public string? word { get; set; }
}