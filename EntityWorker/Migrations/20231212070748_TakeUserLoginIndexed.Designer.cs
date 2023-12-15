﻿// <auto-generated />
using System;
using EntityWorker.Foundation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityWorker.Migrations
{
    [DbContext(typeof(TaskDbContext))]
    [Migration("20231212070748_TakeUserLoginIndexed")]
    partial class TakeUserLoginIndexed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Task", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EstimateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserIssueId")
                        .HasColumnType("int");

                    b.Property<int?>("UserWorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserIssueId");

                    b.HasIndex("UserWorkerId");

                    b.ToTable("TaskList", (string)null);
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Login");

                    b.ToTable("UserList", (string)null);
                });

            modelBuilder.Entity("Domain.Task", b =>
                {
                    b.HasOne("Domain.User", "UserIssue")
                        .WithMany("IssueTasks")
                        .HasForeignKey("UserIssueId");

                    b.HasOne("Domain.User", "UserWorker")
                        .WithMany("WoredTasks")
                        .HasForeignKey("UserWorkerId");

                    b.Navigation("UserIssue");

                    b.Navigation("UserWorker");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("IssueTasks");

                    b.Navigation("WoredTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
