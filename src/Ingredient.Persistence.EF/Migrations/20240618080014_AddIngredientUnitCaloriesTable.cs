using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ingredient.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddIngredientUnitCaloriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Calorie",
                table: "Calorie");

            migrationBuilder.RenameTable(
                name: "Calorie",
                newName: "Calories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calories",
                table: "Calories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "IngredientUnitCalories",
                columns: table => new
                {
                    CalorieId = table.Column<int>(type: "int", nullable: false),
                    IngredientUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientUnitCalories", x => new { x.CalorieId, x.IngredientUnitId });
                    table.ForeignKey(
                        name: "FK_IngredientUnitCalories_Calories_CalorieId",
                        column: x => x.CalorieId,
                        principalTable: "Calories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IngredientUnitCalories_IngredientUnits_IngredientUnitId",
                        column: x => x.IngredientUnitId,
                        principalTable: "IngredientUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUnitCalories_IngredientUnitId",
                table: "IngredientUnitCalories",
                column: "IngredientUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientUnitCalories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calories",
                table: "Calories");

            migrationBuilder.RenameTable(
                name: "Calories",
                newName: "Calorie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calorie",
                table: "Calorie",
                column: "Id");
        }
    }
}
