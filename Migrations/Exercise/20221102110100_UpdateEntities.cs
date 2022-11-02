using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveApp.Migrations.Exercise
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowNumber",
                table: "Workout");

            migrationBuilder.RenameColumn(
                name: "ExerciseName",
                table: "Workout",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "RowNumber",
                table: "Exercise",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowNumber",
                table: "Exercise");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Workout",
                newName: "ExerciseName");

            migrationBuilder.AddColumn<int>(
                name: "RowNumber",
                table: "Workout",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
