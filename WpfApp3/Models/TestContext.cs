using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp3.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RoleUser> RoleUsers { get; set; }

    public virtual DbSet<StatusRequest> StatusRequests { get; set; }

    public virtual DbSet<TipsBu> TipsBus { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ЧУДОКОСТЯ-ПК\\SQLEXPRESS;DataBase=Test;TrustServerCertificate=True;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.ToTable("Request");

            entity.Property(e => e.Comment)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.StatusrRequest).WithMany(p => p.Requests)
                .HasForeignKey(d => d.StatusrRequestId)
                .HasConstraintName("FK_Request_StatusRequest");

            entity.HasOne(d => d.Tours).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ToursId)
                .HasConstraintName("FK_Request_Tours");

            entity.HasOne(d => d.Users).WithMany(p => p.Requests)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK_Request_Users");
        });

        modelBuilder.Entity<RoleUser>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StatusRequest>(entity =>
        {
            entity.ToTable("StatusRequest");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipsBu>(entity =>
        {
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameBus)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameTour)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Tours)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Tours_Country");

            entity.HasOne(d => d.TipsBus).WithMany(p => p.Tours)
                .HasForeignKey(d => d.TipsBusId)
                .HasConstraintName("FK_Tours_TipsBus");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.FullNameUsers)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.RoleUsers).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleUsersId)
                .HasConstraintName("FK_Users_RoleUsers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
