using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ingredient.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddCalorieTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientUnits_Ingredients_IngredientId",
                table: "IngredientUnits");

            migrationBuilder.CreateTable(
                name: "Calorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calorie", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientUnits_Ingredients_IngredientId",
                table: "IngredientUnits",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientUnits_Ingredients_IngredientId",
                table: "IngredientUnits");

            migrationBuilder.DropTable(
                name: "Calorie");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientUnits_Ingredients_IngredientId",
                table: "IngredientUnits",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id");
        }
    }
}
