using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveApp.Migrations
{
    public partial class ExerciseTypeToExerciseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExerciseType",
                table: "Exercise",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseType",
                table: "Exercise");
        }
    }
}
