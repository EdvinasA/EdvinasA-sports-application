﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaveApp.App.Workout.Repositories.Contexts;

#nullable disable

namespace SaveApp.Migrations
{
    [DbContext(typeof(ExerciseContext))]
    [Migration("20221112133513_UpdateEntites")]
    partial class UpdateEntites
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.ExerciseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RowNumber")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.ExerciseSetEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ExerciseEntityId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseType")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Reps")
                        .HasColumnType("int");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("int");

                    b.Property<int?>("Weigth")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutExerciseEntityId")
                        .HasColumnType("int");

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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.WorkoutEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BodyWeight")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Workout");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.WorkoutExerciseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("RowNumber")
                        .HasColumnType("int");

                    b.Property<int?>("WorkoutEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutEntityId");

                    b.ToTable("WorkoutExercise");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.ExerciseEntity", b =>
                {
                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.UserEntity", "User")
                        .WithMany("ExerciseEntity")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.ExerciseSetEntity", b =>
                {
                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.ExerciseEntity", "ExerciseEntity")
                        .WithMany("ExerciseSetsEntities")
                        .HasForeignKey("ExerciseEntityId");

                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.UserEntity", "UserEntity")
                        .WithMany("ExerciseSetEntity")
                        .HasForeignKey("UserEntityId");

                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.WorkoutExerciseEntity", "WorkoutExerciseEntity")
                        .WithMany("ExerciseSets")
                        .HasForeignKey("WorkoutExerciseEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaveApp.App.Workout.Repositories.Entities.WorkoutEntity", null)
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutEntityId");

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("SaveApp.App.Workout.Repositories.Entities.ExerciseEntity", b =>
                {
                    b.Navigation("ExerciseSetsEntities");
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
