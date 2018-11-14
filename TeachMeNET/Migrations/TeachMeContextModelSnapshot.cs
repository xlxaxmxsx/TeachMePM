﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeachMeNET.Models;

namespace TeachMeNET.Migrations
{
    [DbContext(typeof(TeachMeContext))]
    partial class TeachMeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TeachMeNET.Models.Entities.InicioSesionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("InicioSesiones");
                });

            modelBuilder.Entity("TeachMeNET.Models.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutMe")
                        .HasMaxLength(200);

                    b.Property<int>("Age");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Degree");

                    b.Property<string>("LinkedIn");

                    b.Property<bool>("MyHouse");

                    b.Property<bool>("Online");

                    b.Property<int>("Price1");

                    b.Property<int>("Price2");

                    b.Property<int>("Price3");

                    b.Property<int>("Price4");

                    b.Property<bool>("PublicSpace");

                    b.Property<bool>("ToHouse");

                    b.Property<string>("Topic1");

                    b.Property<string>("Topic2");

                    b.Property<string>("Topic3");

                    b.Property<string>("Topic4");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("TeachMeNET.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Confirmed");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<int>("InicioSesionId");

                    b.Property<DateTime>("LastLogin");

                    b.Property<string>("LastName1");

                    b.Property<string>("LastName2");

                    b.Property<string>("Name1");

                    b.Property<string>("Name2");

                    b.Property<string>("Name3");

                    b.Property<string>("PrefName");

                    b.Property<string>("StudentFlag");

                    b.Property<string>("TeacherFlag");

                    b.Property<DateTime>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TeachMeNET.Models.Entities.InicioSesionModel", b =>
                {
                    b.HasOne("TeachMeNET.Models.User", "User")
                        .WithOne("Input")
                        .HasForeignKey("TeachMeNET.Models.Entities.InicioSesionModel", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
