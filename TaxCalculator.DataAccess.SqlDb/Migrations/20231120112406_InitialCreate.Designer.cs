﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxCalculator.DataAccess.SqlDb;

#nullable disable

namespace TaxCalculator.DataAccess.SqlDb.Migrations
{
    [DbContext(typeof(TaxDbContext))]
    [Migration("20231120112406_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaxCalculator.DataAccess.SqlDb.DbModels.TaxBand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HighRange")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LowRange")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TaxBands", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HighRange = 5000,
                            IsActive = true,
                            LowRange = 0,
                            Name = "Tax Band A",
                            Range = 0
                        },
                        new
                        {
                            Id = 2,
                            HighRange = 20000,
                            IsActive = true,
                            LowRange = 5000,
                            Name = "Tax Band B",
                            Range = 20
                        },
                        new
                        {
                            Id = 3,
                            HighRange = 2147483647,
                            IsActive = true,
                            LowRange = 20000,
                            Name = "Tax Band C",
                            Range = 40
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
