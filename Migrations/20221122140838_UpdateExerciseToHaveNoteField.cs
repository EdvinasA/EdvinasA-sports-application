using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveApp.Migrations
{
    public partial class UpdateExerciseToHaveNoteField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Exercise",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Exercise");
        }
    }
}
