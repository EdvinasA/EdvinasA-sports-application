using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SaveApp.Migrations
{
    public partial class RowNumberToRoutineExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkoutRoutine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Targets = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutRoutine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutRoutine_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkoutRoutineExercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExerciseId = table.Column<int>(type: "integer", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    NumberOfSets = table.Column<int>(type: "integer", nullable: true),
                    RowNumber = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    WorkoutRoutineEntityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutRoutineExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutRoutineExercise_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkoutRoutineExercise_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkoutRoutineExercise_WorkoutRoutine_WorkoutRoutineEntityId",
                        column: x => x.WorkoutRoutineEntityId,
                        principalTable: "WorkoutRoutine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRoutine_UserId",
                table: "WorkoutRoutine",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRoutineExercise_ExerciseId",
                table: "WorkoutRoutineExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRoutineExercise_UserId",
                table: "WorkoutRoutineExercise",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRoutineExercise_WorkoutRoutineEntityId",
                table: "WorkoutRoutineExercise",
                column: "WorkoutRoutineEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutRoutineExercise");

            migrationBuilder.DropTable(
                name: "WorkoutRoutine");
        }
    }
}
