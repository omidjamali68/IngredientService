﻿// <auto-generated />
using System;
using Ingredient.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ingredient.Persistence.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ingredient.Domain.Calories.Calorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Calories", (string)null);
                });

            modelBuilder.Entity("Ingredient.Domain.IngredientUnits.IngredientUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("UnitId");

                    b.ToTable("IngredientUnits");
                });

            modelBuilder.Entity("Ingredient.Domain.IngredientUnits.IngredientUnitCalorie", b =>
                {
                    b.Property<int>("CalorieId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientUnitId")
                        .HasColumnType("int");

                    b.Property<short>("Value")
                        .HasColumnType("smallint");

                    b.HasKey("CalorieId", "IngredientUnitId");

                    b.HasIndex("IngredientUnitId");

                    b.ToTable("IngredientUnitCalories", (string)null);
                });

            modelBuilder.Entity("Ingredient.Domain.Ingredients.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Ingredient.Domain.Units.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Ingredient.Domain.IngredientUnits.IngredientUnit", b =>
                {
                    b.HasOne("Ingredient.Domain.Ingredients.Ingredient", "Ingredient")
                        .WithMany("IngredientUnits")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ingredient.Domain.Units.Unit", "Unit")
                        .WithMany("IngredientUnits")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Ingredient.Domain.IngredientUnits.IngredientUnitCalorie", b =>
                {
                    b.HasOne("Ingredient.Domain.Calories.Calorie", "Calorie")
                        .WithMany("IngredientUnitCalories")
                        .HasForeignKey("CalorieId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Ingredient.Domain.IngredientUnits.IngredientUnit", "IngredientUnit")
                        .WithMany("IngredientUnitCalories")
                        .HasForeignKey("IngredientUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calorie");

                    b.Navigation("IngredientUnit");
                });

            modelBuilder.Entity("Ingredient.Domain.Calories.Calorie", b =>
                {
                    b.Navigation("IngredientUnitCalories");
                });

            modelBuilder.Entity("Ingredient.Domain.IngredientUnits.IngredientUnit", b =>
                {
                    b.Navigation("IngredientUnitCalories");
                });

            modelBuilder.Entity("Ingredient.Domain.Ingredients.Ingredient", b =>
                {
                    b.Navigation("IngredientUnits");
                });

            modelBuilder.Entity("Ingredient.Domain.Units.Unit", b =>
                {
                    b.Navigation("IngredientUnits");
                });
#pragma warning restore 612, 618
        }
    }
}
