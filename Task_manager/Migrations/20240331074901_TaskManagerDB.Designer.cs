﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task_manager.Models;

#nullable disable

namespace Task_manager.Migrations
{
    [DbContext(typeof(TaskManagerContext))]
    [Migration("20240331074901_TaskManagerDB")]
    partial class TaskManagerDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task_manager.Models.DetailProjecet", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdProject")
                        .HasColumnType("int");

                    b.HasKey("IdUser", "IdProject")
                        .HasName("PK__DetailPr__EC5735EAD92DA646");

                    b.HasIndex("IdProject");

                    b.ToTable("DetailProjecet", (string)null);
                });

            modelBuilder.Entity("Task_manager.Models.Project", b =>
                {
                    b.Property<int>("IdProject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProject"));

                    b.Property<byte[]>("Assignee")
                        .HasMaxLength(1)
                        .HasColumnType("binary(1)")
                        .IsFixedLength();

                    b.Property<DateTime?>("DayCreate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Hide")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("binary(1)")
                        .IsFixedLength();

                    b.Property<int?>("IdLeader")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Status")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdProject")
                        .HasName("PK__Project__B9E13D247D2FAC3A");

                    b.ToTable("Project", (string)null);
                });

            modelBuilder.Entity("Task_manager.Models.Task", b =>
                {
                    b.Property<int>("IdTask")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTask"));

                    b.Property<int>("IdProject")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DayCreate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DayReceive")
                        .HasColumnType("datetime");

                    b.Property<string>("Descreption")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<byte[]>("Hide")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("binary(1)")
                        .IsFixedLength();

                    b.Property<string>("NameTask")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("IdTask", "IdProject")
                        .HasName("PK__Task__C454C2175F55D602");

                    b.HasIndex("IdProject");

                    b.ToTable("Task", (string)null);
                });

            modelBuilder.Entity("Task_manager.Models.Team", b =>
                {
                    b.Property<int>("IdTeam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTeam"));

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IdProject")
                        .HasColumnType("int");

                    b.HasKey("IdTeam", "IdUser", "IdProject")
                        .HasName("PK__Team__21F85FE2EA619857");

                    b.HasIndex("IdUser", "IdProject");

                    b.ToTable("Team", (string)null);
                });

            modelBuilder.Entity("Task_manager.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<byte[]>("Hide")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("binary(1)")
                        .IsFixedLength();

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdUser")
                        .HasName("PK__User__B7C92638036251C6");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Task_manager.Models.DetailProjecet", b =>
                {
                    b.HasOne("Task_manager.Models.Project", "IdProjectNavigation")
                        .WithMany("DetailProjecets")
                        .HasForeignKey("IdProject")
                        .IsRequired()
                        .HasConstraintName("FK__DetailPro__IdPro__4316F928");

                    b.HasOne("Task_manager.Models.User", "IdUserNavigation")
                        .WithMany("DetailProjecets")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK__DetailPro__IdUse__4222D4EF");

                    b.Navigation("IdProjectNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("Task_manager.Models.Task", b =>
                {
                    b.HasOne("Task_manager.Models.Project", "IdProjectNavigation")
                        .WithMany("Tasks")
                        .HasForeignKey("IdProject")
                        .IsRequired()
                        .HasConstraintName("FK__Task__IdProject__440B1D61");

                    b.Navigation("IdProjectNavigation");
                });

            modelBuilder.Entity("Task_manager.Models.Team", b =>
                {
                    b.HasOne("Task_manager.Models.DetailProjecet", "DetailProjecet")
                        .WithMany("Teams")
                        .HasForeignKey("IdUser", "IdProject")
                        .IsRequired()
                        .HasConstraintName("FK__Team__44FF419A");

                    b.Navigation("DetailProjecet");
                });

            modelBuilder.Entity("Task_manager.Models.DetailProjecet", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Task_manager.Models.Project", b =>
                {
                    b.Navigation("DetailProjecets");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Task_manager.Models.User", b =>
                {
                    b.Navigation("DetailProjecets");
                });
#pragma warning restore 612, 618
        }
    }
}
