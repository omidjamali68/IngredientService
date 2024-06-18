using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ingredient.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddValuePropertyToIngredinetUnitCaloriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Value",
                table: "IngredientUnitCalories",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "IngredientUnitCalories");
        }
    }
}
