using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pdk2410900044_exam.Models;

public partial class PdkStudent2410900044DbContext : DbContext
{
    public PdkStudent2410900044DbContext()
    {
    }

    public PdkStudent2410900044DbContext(DbContextOptions<PdkStudent2410900044DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PdkStudent> PdkStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KHOAPHAM\\SQLEXPRESS;Database=PdkStudent_2410900044_Db;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PdkStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PdkStude__3214EC07DBAADDAE");

            entity.ToTable("PdkStudent");

            entity.Property(e => e.PdkEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PdkName).HasMaxLength(100);
            entity.Property(e => e.PdkPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
