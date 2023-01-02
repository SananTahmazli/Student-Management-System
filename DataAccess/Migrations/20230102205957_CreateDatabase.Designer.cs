﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230102205957_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UpdatedUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(2023, 1, 2, 20, 59, 57, 329, DateTimeKind.Utc).AddTicks(9810),
                            CreatedUserId = 1,
                            Name = "Admin",
                            UpdatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedTime = new DateTime(2023, 1, 2, 20, 59, 57, 329, DateTimeKind.Utc).AddTicks(9832),
                            CreatedUserId = 1,
                            Name = "User",
                            UpdatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        });
                });

            modelBuilder.Entity("DataAccess.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("integer");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Major")
                        .HasColumnType("text");

                    b.Property<int>("PaymentForMonth")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UpdatedUserId")
                        .HasColumnType("integer");

                    b.Property<int>("YearlyPayment")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("integer");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Hash")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("Salt")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UpdatedUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(2023, 1, 2, 20, 59, 57, 330, DateTimeKind.Utc).AddTicks(555),
                            CreatedUserId = 1,
                            FullName = "Admin",
                            Hash = "9�3c�Ӥ0�Y�h>+���z2n�[|\r6",
                            RoleId = 1,
                            Salt = "WKPN5JbQDEu0bFMZcLs13RGDUiB6ahx4rIhVEovqJFqhUXA6Jaeh+E0aVOtRRIkfpFHpWKN1KuAJ8vmREfSdXQve7+59go2aeQ/dCX6PvjE1e7ofmksCTWM6NMsbbh53SoaPvMuwc3+IRJZUeo/bmyedR47uJAOQVksPDGQRbzD4vcnC1WTi//D9pTfURrbZBKr3s8NwzEqJvAFQIZnYdDZu8Z+CdyLaItgGOgNqBLDD/kBRXtIYyxrC9zOu3q3/FcmJD5Mo9W364IdnwTplkOj0PNaOk0Shq4hJ5g900HFSyWxkadvCTyWb8KhBeUXvn2QtQRD0Yz/LHkOlBAaU",
                            UpdatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.HasOne("DataAccess.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DataAccess.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
