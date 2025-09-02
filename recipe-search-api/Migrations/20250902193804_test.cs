using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace recipe_search_api.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "key_word",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    word = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_key_word", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recipe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    instructions = table.Column<string>(type: "text", nullable: true),
                    location = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stop_word",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    word = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stop_word", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ingredient",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    recipe_id = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    amount = table.Column<float>(type: "real", nullable: true),
                    unit = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient", x => x.id);
                    table.ForeignKey(
                        name: "FK_ingredient_recipe_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "recipe",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "KeyWordRecipe",
                columns: table => new
                {
                    KeyWordsID = table.Column<int>(type: "integer", nullable: false),
                    RecipesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyWordRecipe", x => new { x.KeyWordsID, x.RecipesID });
                    table.ForeignKey(
                        name: "FK_KeyWordRecipe_key_word_KeyWordsID",
                        column: x => x.KeyWordsID,
                        principalTable: "key_word",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeyWordRecipe_recipe_RecipesID",
                        column: x => x.RecipesID,
                        principalTable: "recipe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "word_to_recipe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    word_id = table.Column<int>(type: "integer", nullable: true),
                    KeyWordID = table.Column<int>(type: "integer", nullable: false),
                    recipe_id = table.Column<int>(type: "integer", nullable: true),
                    count = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_word_to_recipe", x => x.id);
                    table.ForeignKey(
                        name: "FK_word_to_recipe_key_word_KeyWordID",
                        column: x => x.KeyWordID,
                        principalTable: "key_word",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_word_to_recipe_recipe_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "recipe",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_recipe_id",
                table: "ingredient",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_KeyWordRecipe_RecipesID",
                table: "KeyWordRecipe",
                column: "RecipesID");

            migrationBuilder.CreateIndex(
                name: "IX_word_to_recipe_KeyWordID",
                table: "word_to_recipe",
                column: "KeyWordID");

            migrationBuilder.CreateIndex(
                name: "IX_word_to_recipe_recipe_id",
                table: "word_to_recipe",
                column: "recipe_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredient");

            migrationBuilder.DropTable(
                name: "KeyWordRecipe");

            migrationBuilder.DropTable(
                name: "stop_word");

            migrationBuilder.DropTable(
                name: "word_to_recipe");

            migrationBuilder.DropTable(
                name: "key_word");

            migrationBuilder.DropTable(
                name: "recipe");
        }
    }
}
