﻿// <auto-generated />
using Cooprol.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cooprol.Data.Migrations
{
    [DbContext(typeof(CooprolContext))]
    [Migration("20230907024629_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Cooprol.Data.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("dateB")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("deductions")
                        .HasColumnType("int");

                    b.Property<int>("lProduced")
                        .HasColumnType("int");

                    b.Property<int>("toPay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bill", (string)null);
                });

            modelBuilder.Entity("Cooprol.Data.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("cellNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("numberCc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Producer", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}