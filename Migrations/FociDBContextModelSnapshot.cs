﻿// <auto-generated />
using FociWebapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FociWebapp.Migrations
{
    [DbContext(typeof(FociDBContext))]
    partial class FociDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("FociWebapp.Models.Meccs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fordulo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HazaiFelido")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HazaiNev")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HazaiVeg")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VendegFelido")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VendegNev")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VendegVeg")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Meccsek");
                });
#pragma warning restore 612, 618
        }
    }
}
