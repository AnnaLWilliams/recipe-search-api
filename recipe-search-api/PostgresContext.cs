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

    public virtual DbSet<StopWord> StopWords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.ToTable("ingredient");

            entity.Property(e => e.Amount).HasColumnName("amount");
            entity
                .Property(e => e.ID)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.RecipeID).HasColumnName("recipe_id");
            entity.Property(e => e.Unit).HasColumnName("unit");
        });

        modelBuilder.Entity<KeyWord>(entity =>
        {
            entity.ToTable("key_word");

            entity
                .Property(e => e.ID)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Word).HasColumnName("word");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.ToTable("recipe");

            entity.Property(e => e.Description).HasColumnName("description");
            entity
                .Property(e => e.ID)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Instructions).HasColumnName("instructions");
            entity.Property(e => e.Location).HasColumnName("location");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<WordToRecipe>(entity =>
        {
            entity.ToTable("word_to_recipe");

            entity
                .Property(e => e.ID)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.RecipeID).HasColumnName("recipe_id");
            entity.Property(e => e.WordID).HasColumnName("word_id");
            entity.Property(e => e.Count).HasColumnName("count");
        });

        modelBuilder.Entity<StopWord>(entity =>
        {
            entity.ToTable("stop_word");

            entity
                .Property(e => e.ID)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Word).HasColumnName("word");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
