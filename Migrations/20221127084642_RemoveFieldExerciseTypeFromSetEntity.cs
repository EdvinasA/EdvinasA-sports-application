using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveApp.Migrations
{
    public partial class RemoveFieldExerciseTypeFromSetEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseCategories_ExerciseCategoryId",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "ExerciseType",
                table: "ExerciseSet");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseCategoryId",
                table: "Exercise",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseCategories_ExerciseCategoryId",
                table: "Exercise",
                column: "ExerciseCategoryId",
                principalTable: "ExerciseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseCategories_ExerciseCategoryId",
                table: "Exercise");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseType",
                table: "ExerciseSet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseCategoryId",
                table: "Exercise",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseCategories_ExerciseCategoryId",
                table: "Exercise",
                column: "ExerciseCategoryId",
                principalTable: "ExerciseCategories",
                principalColumn: "Id");
        }
    }
}
