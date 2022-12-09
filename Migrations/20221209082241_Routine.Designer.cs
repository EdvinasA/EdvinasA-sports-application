﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SaveApp.App.Workout.Repositories.Contexts;

#nullable disable

namespace SaveApp.Migrations
{
    [DbContext(typeof(ExerciseContext))]
    [Migration("20221209082241_Routine")]
    partial class Routine
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.ExerciseCategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ExerciseCategories");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.ExerciseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseCategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("ExerciseType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsSingleBodyPartExercise")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.ExerciseSetEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ExerciseEntityId")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int?>("Reps")
                        .HasColumnType("integer");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("integer");

                    b.Property<int?>("Weight")
                        .HasColumnType("integer");

                    b.Property<int?>("WorkoutExerciseEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseEntityId");

                    b.HasIndex("UserEntityId");

                    b.HasIndex("WorkoutExerciseEntityId");

                    b.ToTable("ExerciseSet");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.WorkoutEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BodyWeight")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Workout");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.WorkoutExerciseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<int>("RowNumber")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<int?>("WorkoutEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkoutEntityId");

                    b.ToTable("WorkoutExercise");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.ExerciseCategoryEntity", b =>
                {
                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.ExerciseEntity", b =>
                {
                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.ExerciseCategoryEntity", "ExerciseCategory")
                        .WithMany("Exercise")
                        .HasForeignKey("ExerciseCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.UserEntity", "User")
                        .WithMany("ExerciseEntity")
                        .HasForeignKey("UserId");

                    b.Navigation("ExerciseCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.ExerciseSetEntity", b =>
                {
                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.ExerciseEntity", "ExerciseEntity")
                        .WithMany()
                        .HasForeignKey("ExerciseEntityId");

                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.UserEntity", "UserEntity")
                        .WithMany("ExerciseSetEntity")
                        .HasForeignKey("UserEntityId");

                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.WorkoutExerciseEntity", "WorkoutExerciseEntity")
                        .WithMany("ExerciseSets")
                        .HasForeignKey("WorkoutExerciseEntityId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("ExerciseEntity");

                    b.Navigation("UserEntity");

                    b.Navigation("WorkoutExerciseEntity");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.WorkoutEntity", b =>
                {
                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.UserEntity", "UserEntity")
                        .WithMany("WorkoutEntity")
                        .HasForeignKey("UserEntityId");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.WorkoutExerciseEntity", b =>
                {
                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.ExerciseEntity", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId");

                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.WorkoutEntity", "WorkoutEntity")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutEntityId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("Exercise");

                    b.Navigation("User");

                    b.Navigation("WorkoutEntity");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.ExerciseCategoryEntity", b =>
                {
                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.UserEntity", b =>
                {
                    b.Navigation("ExerciseEntity");

                    b.Navigation("ExerciseSetEntity");

                    b.Navigation("WorkoutEntity");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.WorkoutEntity", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.WorkoutExerciseEntity", b =>
                {
                    b.Navigation("ExerciseSets");
                });
#pragma warning restore 612, 618
        }
    }
}
