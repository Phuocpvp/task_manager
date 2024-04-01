using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task_manager.Models;

public partial class TaskManagerContext : DbContext
{
    public TaskManagerContext()
    {
    }

    public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetailProjecet> DetailProjecets { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-A8E5TJ9\\SQLEXPRESS;Database=TaskManager;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetailProjecet>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.IdProject }).HasName("PK__DetailPr__EC5735EAD92DA646");

            entity.ToTable("DetailProjecet");

            entity.Property(e => e.IdUser).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdProjectNavigation).WithMany(p => p.DetailProjecets)
                .HasForeignKey(d => d.IdProject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetailPro__IdPro__4316F928");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.DetailProjecets)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetailPro__IdUse__4222D4EF");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.IdProject).HasName("PK__Project__B9E13D247D2FAC3A");

            entity.ToTable("Project");

            entity.Property(e => e.Assignee)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.DayCreate).HasColumnType("datetime");
            entity.Property(e => e.Hide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => new { e.IdTask, e.IdProject }).HasName("PK__Task__C454C2175F55D602");

            entity.ToTable("Task");

            entity.Property(e => e.IdTask).ValueGeneratedOnAdd();
            entity.Property(e => e.DayCreate).HasColumnType("datetime");
            entity.Property(e => e.DayReceive).HasColumnType("datetime");
            entity.Property(e => e.Descreption).HasMaxLength(4000);
            entity.Property(e => e.Hide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.NameTask).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProjectNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdProject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Task__IdProject__440B1D61");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => new { e.IdTeam, e.IdUser, e.IdProject }).HasName("PK__Team__21F85FE2EA619857");

            entity.ToTable("Team");

            entity.Property(e => e.IdTeam).ValueGeneratedOnAdd();

            entity.HasOne(d => d.DetailProjecet).WithMany(p => p.Teams)
                .HasForeignKey(d => new { d.IdUser, d.IdProject })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Team__44FF419A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__B7C92638036251C6");

            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Hide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
