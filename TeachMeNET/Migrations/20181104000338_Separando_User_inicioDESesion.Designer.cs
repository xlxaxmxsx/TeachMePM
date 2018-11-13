﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeachMeNET.Models;

namespace TeachMeNET.Migrations
{
    [DbContext(typeof(TeachMeContext))]
    [Migration("20181104000338_Separando_User_inicioDESesion")]
    partial class Separando_User_inicioDESesion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("TeachMeNET.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Confirmed");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("ErrorMessage");

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
