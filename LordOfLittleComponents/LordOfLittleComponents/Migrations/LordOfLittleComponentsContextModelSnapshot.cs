﻿// <auto-generated />
using LordOfLittleComponents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LordOfLittleComponents.Migrations
{
    [DbContext(typeof(LordOfLittleComponentsContext))]
    partial class LordOfLittleComponentsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LordOfLittleComponents.Models.Commands", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComponentName");

                    b.Property<int>("Off");

                    b.Property<int>("On");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("LordOfLittleComponents.Models.TemperatureAndHumidity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Humidity");

                    b.Property<string>("Temperature");

                    b.HasKey("Id");

                    b.ToTable("TemperatureAndHumidity");
                });
#pragma warning restore 612, 618
        }
    }
}
