﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainHoppers.Data;

#nullable disable

namespace TrainHoppers.Data.Migrations
{
    [DbContext(typeof(TrainHoppersContext))]
    [Migration("20241115074011_asodas")]
    partial class asodas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrainHoppers.Core.Domain.Ability", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AbilityDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AbilityLevel")
                        .HasColumnType("int");

                    b.Property<string>("AbilityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AbilityRechargeTime")
                        .HasColumnType("int");

                    b.Property<int>("AbilityStatus")
                        .HasColumnType("int");

                    b.Property<int>("AbilityType")
                        .HasColumnType("int");

                    b.Property<int>("AbilityUseTime")
                        .HasColumnType("int");

                    b.Property<int>("AbilityXP")
                        .HasColumnType("int");

                    b.Property<int>("AbilityXPUntilNextLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("TrainHoppers.Core.Domain.FileToDatabase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AbilityID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("FilesToDatabase");
                });
#pragma warning restore 612, 618
        }
    }
}
