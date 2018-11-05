﻿// <auto-generated />
using System;
using EmployeeManagementSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagementSystem.Migrations
{
    [DbContext(typeof(EmployeeModel))]
    partial class EmployeeModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeManagementSystem.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Contact")
                        .HasMaxLength(50);

                    b.Property<int>("Department");

                    b.Property<int>("Designation");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("SuperviserId")
                        .HasMaxLength(50);

                    b.Property<decimal>("WageRate");

                    b.HasKey("EmpId")
                        .HasName("PK_Employees");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeManagementSystem.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<int>("TypeOfTransaction");

                    b.HasKey("TransactionId")
                        .HasName("PK_Transactions");

                    b.ToTable("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}