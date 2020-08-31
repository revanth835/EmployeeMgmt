﻿// <auto-generated />
using System;
using AppDemo.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppDemo.Migrations
{
    [DbContext(typeof(SQLiteContext))]
    partial class SQLiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("AppDemo.Services.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfJoining")
                        .HasColumnType("TEXT");

                    b.Property<string>("Department")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("Skillsets")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EmployeeDBModel");
                });
#pragma warning restore 612, 618
        }
    }
}