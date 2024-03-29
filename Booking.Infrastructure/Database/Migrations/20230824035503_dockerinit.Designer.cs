﻿// <auto-generated />
using System;
using Booking.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Booking.Infrastructure.Database
{
    [DbContext(typeof(ClinicDatabase))]
    [Migration("20230824035503_dockerinit")]
    partial class dockerinit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("clinic_db")
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Booking.Domain.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ReservedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("SlotId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Appointments", "clinic_db");
                });

            modelBuilder.Entity("Booking.Domain.Entities.Slot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal?>("Cost")
                        .IsRequired()
                        .HasColumnType("numeric");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<string>("DoctorName")
                        .HasColumnType("text");

                    b.Property<bool?>("IsReserved")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Slots", "clinic_db");
                });
#pragma warning restore 612, 618
        }
    }
}
