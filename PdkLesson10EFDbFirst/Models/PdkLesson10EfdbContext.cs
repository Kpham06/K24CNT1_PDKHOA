using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PdkLesson10EFDbFirst.Models;

public partial class PdkLesson10EfdbContext : DbContext
{
    public PdkLesson10EfdbContext()
    {
    }

    public PdkLesson10EfdbContext(DbContextOptions<PdkLesson10EfdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PdkMember> PdkMembers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KHOAPHAM\\SQLEXPRESS;Database=PdkLesson10EFDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PdkMember>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PdkMember");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.PdkEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PdkFullName).HasMaxLength(50);
            entity.Property(e => e.PdkPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PdkPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PdkUserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
