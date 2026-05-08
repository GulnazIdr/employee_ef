using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeEF.Models;

public partial class TitlePersonalIdrisovaContext : DbContext
{
    public TitlePersonalIdrisovaContext()
    {
    }

    public TitlePersonalIdrisovaContext(DbContextOptions<TitlePersonalIdrisovaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=title_personal_idrisova;Username=postgres;Password=12");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("employee_pkey");

            entity.ToTable("employee");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Birthday);
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(60)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(60)
                .HasColumnName("lastname");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(60)
                .HasColumnName("patronymic");
            entity.Property(e => e.Telephone)
                .HasMaxLength(60)
                .HasColumnName("telephone");
            entity.Property(e => e.TitleId).HasColumnName("title_id");

            entity.HasOne(d => d.Title).WithMany(p => p.Employees)
                .HasForeignKey(d => d.TitleId)
                .HasConstraintName("employee_title_id_fkey");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.TitleId).HasName("title_pkey");

            entity.ToTable("title");

            entity.Property(e => e.TitleId).HasColumnName("title_id");
            entity.Property(e => e.TitleName)
                .HasMaxLength(60)
                .HasColumnName("title_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
