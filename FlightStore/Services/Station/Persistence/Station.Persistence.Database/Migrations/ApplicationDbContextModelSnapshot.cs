﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Station.Persistence.Database;

namespace Station.Persistence.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Station")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Station.Model.StationNode", b =>
                {
                    b.Property<int>("StationNodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StationNodeId");

                    b.HasIndex("StationNodeId");

                    b.ToTable("Stations");

                    b.HasData(
                        new
                        {
                            StationNodeId = 1,
                            Code = "AXM",
                            Name = "Armenia"
                        },
                        new
                        {
                            StationNodeId = 2,
                            Code = "BAQ",
                            Name = "Barranquilla"
                        },
                        new
                        {
                            StationNodeId = 3,
                            Code = "BOG",
                            Name = "Bogota"
                        },
                        new
                        {
                            StationNodeId = 4,
                            Code = "BGA",
                            Name = "Bucaramanga"
                        },
                        new
                        {
                            StationNodeId = 5,
                            Code = "CLO",
                            Name = "Cali"
                        },
                        new
                        {
                            StationNodeId = 6,
                            Code = "CUC",
                            Name = "Cucuta"
                        },
                        new
                        {
                            StationNodeId = 7,
                            Code = "CTG",
                            Name = "Cartagena"
                        },
                        new
                        {
                            StationNodeId = 8,
                            Code = "LET",
                            Name = "Leticia"
                        },
                        new
                        {
                            StationNodeId = 9,
                            Code = "MDE",
                            Name = "Medellin"
                        },
                        new
                        {
                            StationNodeId = 10,
                            Code = "PEI",
                            Name = "Pereira"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
