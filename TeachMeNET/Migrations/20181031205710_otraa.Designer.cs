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
    [Migration("20181031205710_otraa")]
    partial class otraa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TeachMeNET.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Confirmed");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("ErrorMessage");

                    b.Property<int?>("InputId");

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

                    b.HasIndex("InputId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TeachMeNET.Models.User+InputModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("InputModel");
                });

            modelBuilder.Entity("TeachMeNET.Models.User", b =>
                {
                    b.HasOne("TeachMeNET.Models.User+InputModel", "Input")
                        .WithMany()
                        .HasForeignKey("InputId");
                });
#pragma warning restore 612, 618
        }
    }
}
