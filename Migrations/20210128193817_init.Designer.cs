﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Nagy_Cristina.Data;

namespace Proiect_Nagy_Cristina.Migrations
{
    [DbContext(typeof(Proiect_Nagy_CristinaContextV2))]
    [Migration("20210128193817_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Proiect_Nagy_Cristina.Models.Appointment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableTimeDateID")
                        .HasColumnType("int");

                    b.Property<int>("ChildrenID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AvailableTimeDateID");

                    b.HasIndex("ChildrenID");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("Proiect_Nagy_Cristina.Models.AvailableTimeDate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Availabilty")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("AvailableTimeDate");
                });

            modelBuilder.Entity("Proiect_Nagy_Cristina.Models.Children", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNP")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Insurance")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.HasIndex("DoctorID");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("Proiect_Nagy_Cristina.Models.Doctor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("Proiect_Nagy_Cristina.Models.Appointment", b =>
                {
                    b.HasOne("Proiect_Nagy_Cristina.Models.AvailableTimeDate", "AvailableTimeDate")
                        .WithMany("Appointments")
                        .HasForeignKey("AvailableTimeDateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_Nagy_Cristina.Models.Children", "Children")
                        .WithMany("Appointments")
                        .HasForeignKey("ChildrenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proiect_Nagy_Cristina.Models.Children", b =>
                {
                    b.HasOne("Proiect_Nagy_Cristina.Models.Doctor", "Doctor")
                        .WithMany("Childrens")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}