using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveApp.Migrations
{
    public partial class SingleBodyPartExerciseSPecification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSinglePartExercise",
                table: "ExerciseCategories");

            migrationBuilder.AddColumn<bool>(
                name: "IsSingleBodyPartExercise",
                table: "Exercise",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSingleBodyPartExercise",
                table: "Exercise");

            migrationBuilder.AddColumn<bool>(
                name: "IsSinglePartExercise",
                table: "ExerciseCategories",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
