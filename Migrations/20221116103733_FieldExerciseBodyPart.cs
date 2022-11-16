using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveApp.Migrations
{
    public partial class FieldExerciseBodyPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowNumber",
                table: "Exercise");

            migrationBuilder.AddColumn<string>(
                name: "ExerciseBodyPart",
                table: "Exercise",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseBodyPart",
                table: "Exercise");

            migrationBuilder.AddColumn<int>(
                name: "RowNumber",
                table: "Exercise",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
