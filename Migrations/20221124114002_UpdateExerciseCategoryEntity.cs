using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveApp.Migrations
{
    public partial class UpdateExerciseCategoryEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseType",
                table: "ExerciseCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseType",
                table: "ExerciseCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
