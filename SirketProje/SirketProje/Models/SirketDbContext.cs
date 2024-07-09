using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SirketProje.Models;

public partial class SirketDbContext : DbContext
{
    public SirketDbContext()
    {
    }

    public SirketDbContext(DbContextOptions<SirketDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departman> Departmen { get; set; }

    public virtual DbSet<Istihdam> Istihdams { get; set; }

    public virtual DbSet<Personel> Personels { get; set; }

    public virtual DbSet<Proje> Projes { get; set; }

    public virtual DbSet<Yonetir> Yonetirs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-2C6E5LJ;Database=SirketDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departman>(entity =>
        {
            entity.HasKey(e => e.DepartmanNo);

            entity.ToTable("Departman");

            entity.Property(e => e.DepartmanAdi)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DepartmanAdresi)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Istihdam>(entity =>
        {
            entity.HasKey(e => e.IstihdamNo);

            entity.ToTable("Istihdam");

            entity.Property(e => e.Tcno)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("TCNo");
        });

        modelBuilder.Entity<Personel>(entity =>
        {
            entity.HasKey(e => e.Tcno);

            entity.ToTable("Personel");

            entity.Property(e => e.Tcno)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("TCNo");
            entity.Property(e => e.PersonelAd)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PersonelCinsiyet)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PersonelDepartmanId).HasColumnName("PersonelDepartmanID");
            entity.Property(e => e.PersonelDogumTarihi).HasColumnType("date");
            entity.Property(e => e.PersonelMaas)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.PersonelSoyad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PersonelAdres)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Proje>(entity =>
        {
            entity.HasKey(e => e.ProjeNo);

            entity.ToTable("Proje");

            entity.Property(e => e.ProjeAdi)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProjeAdresi)
                .HasMaxLength(200)
                .IsFixedLength();
        });

        modelBuilder.Entity<Yonetir>(entity =>
        {
            entity.HasKey(e => e.PersonelYonetirId);

            entity.ToTable("Yonetir");

            entity.Property(e => e.Tcno)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("TCNo");
            entity.Property(e => e.YoneticiBaslangicTarihi).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
