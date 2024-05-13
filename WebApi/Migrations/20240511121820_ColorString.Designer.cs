﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240511121820_ColorString")]
    partial class ColorString
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("WebApi.Models.Topping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ToppingImage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ToppingImageString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ToppingName")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ToppingPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Toppings");
                });
#pragma warning restore 612, 618
        }
    }
}
