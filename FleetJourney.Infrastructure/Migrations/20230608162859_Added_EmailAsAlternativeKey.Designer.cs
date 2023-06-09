﻿// <auto-generated />
using System;
using FleetJourney.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FleetJourney.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230608162859_Added_EmailAsAlternativeKey")]
    partial class Added_EmailAsAlternativeKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FleetJourney.Domain.CarPool.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<uint>("CurrentMileage")
                        .HasColumnType("int unsigned");

                    b.Property<uint>("EndOfLifeMileage")
                        .HasColumnType("int unsigned");

                    b.Property<string>("LicensePlateNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<uint>("MaintenanceInterval")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasAlternateKey("LicensePlateNumber");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("CarPool", (string)null);
                });

            modelBuilder.Entity("FleetJourney.Domain.EmployeeInfo.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("FleetJourney.Domain.Trips.Trip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CarId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("char(36)");

                    b.Property<uint>("EndMileage")
                        .HasColumnType("int unsigned");

                    b.Property<bool>("IsPrivateTrip")
                        .HasColumnType("tinyint(1)");

                    b.Property<uint>("StartMileage")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Trips", (string)null);
                });

            modelBuilder.Entity("FleetJourney.Domain.Trips.Trip", b =>
                {
                    b.HasOne("FleetJourney.Domain.CarPool.Car", null)
                        .WithMany("Trips")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FleetJourney.Domain.EmployeeInfo.Employee", null)
                        .WithMany("Trips")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FleetJourney.Domain.CarPool.Car", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("FleetJourney.Domain.EmployeeInfo.Employee", b =>
                {
                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
