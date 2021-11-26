﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SureSuccessStudentPortal.CreateService.Data;

namespace SureSuccessStudentPortal.CreateService.Migrations
{
    [DbContext(typeof(CreateServiceApplicationDbContext))]
    [Migration("20211125214656_Initial-Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SureSuccessStudentPortal.CreateService.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea317"),
                            Country = "Nigeria",
                            Email = "ade@gmail.com",
                            FirstName = "Abdulhamiid",
                            LastName = "Bankole",
                            PhoneNo = "08148738864",
                            State = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea319"),
                            Country = "Nigeria",
                            Email = "ade@gmail.com",
                            FirstName = "John",
                            LastName = "Tosin",
                            PhoneNo = "08145789548",
                            State = "Osun"
                        },
                        new
                        {
                            Id = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea318"),
                            Country = "Nigeria",
                            Email = "oyin@yahoo.com",
                            FirstName = "Live",
                            LastName = "Kunle",
                            PhoneNo = "08145788541",
                            State = "Ogun"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
