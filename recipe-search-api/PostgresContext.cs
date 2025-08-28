using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Model;

namespace RecipeApi;

public partial class PostgresContext : DbContext
{
    public PostgresContext() { }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options) { }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<KeyWord> KeyWords { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<WordToRecipe> WordToRecipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.ToTable("ingredient");

            entity.Property(e => e.amount).HasColumnName("amount");
            entity
                .Property(e => e.ID)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.name).HasColumnName("name");
            entity.Property(e => e.recipeId).HasColumnName("recipe_id");
            entity.Property(e => e.unit).HasColumnName("unit");
        });

        modelBuilder.Entity<KeyWord>(entity =>
        {
            entity.ToTable("key_word");

            entity
                .Property(e => e.ID)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.word).HasColumnName("word");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.ToTable("recipe");

            entity.Property(e => e.description).HasColumnName("description");
            entity
                .Property(e => e.ID)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.instructions).HasColumnName("instructions");
            entity.Property(e => e.location).HasColumnName("location");
            entity.Property(e => e.name).HasColumnName("name");
        });

        modelBuilder.Entity<WordToRecipe>(entity =>
        {
            entity.ToTable("word_to_recipe");

            entity
                .Property(e => e.ID)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.recipeId).HasColumnName("recipe_id");
            entity.Property(e => e.wordId).HasColumnName("word_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
