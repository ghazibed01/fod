using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace fod.Models
{
    public partial class GestionVisiteDBContext : DbContext
    {
        public GestionVisiteDBContext()
        {
        }

        public GestionVisiteDBContext(DbContextOptions<GestionVisiteDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Personnel> Personnel { get; set; } = null!;
        public virtual DbSet<RaisonVisite> RaisonVisites { get; set; } = null!;
        public virtual DbSet<Statut> Statuts { get; set; } = null!;
        public virtual DbSet<TypeVisite> TypeVisites { get; set; } = null!;
        public virtual DbSet<TypeVisiteur> TypeVisiteurs { get; set; } = null!;
        public virtual DbSet<Visite> Visites { get; set; } = null!;
        public virtual DbSet<Visiteur> Visiteurs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=GestionVisiteDB;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personnel>(entity =>
            {
                entity.Property(e => e.Nom).HasMaxLength(255);

                entity.Property(e => e.Poste).HasMaxLength(255);

                entity.Property(e => e.Prenom).HasMaxLength(255);

                entity.Property(e => e.Telephone).HasMaxLength(20);
            });

            modelBuilder.Entity<RaisonVisite>(entity =>
            {
                entity.Property(e => e.Nom).HasMaxLength(255);
            });

            modelBuilder.Entity<Statut>(entity =>
            {
                entity.Property(e => e.Nom).HasMaxLength(255);
            });

            modelBuilder.Entity<TypeVisite>(entity =>
            {
                entity.Property(e => e.Nom).HasMaxLength(255);
            });

            modelBuilder.Entity<TypeVisiteur>(entity =>
            {
                entity.Property(e => e.Nom).HasMaxLength(255);
            });

            modelBuilder.Entity<Visite>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__Visites__C5B69A4A02F6D497");

                entity.Property(e => e.Uid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateHeureDebut).HasColumnType("datetime");

                entity.Property(e => e.DateHeureFin).HasColumnType("datetime");

                entity.Property(e => e.PersonnelId).HasColumnName("Personnel_id");

                entity.Property(e => e.RaisonVisiteId).HasColumnName("Raison_visite_id");

                entity.Property(e => e.StatutId).HasColumnName("Statut_id");

                entity.Property(e => e.TypeVisiteId).HasColumnName("Type_visite_id");

                entity.Property(e => e.VisiteurId).HasColumnName("Visiteur_id");

                entity.HasOne(d => d.Personnel)
                    .WithMany(p => p.Visites)
                    .HasForeignKey(d => d.PersonnelId)
                    .HasConstraintName("FK_Personnel");

                entity.HasOne(d => d.RaisonVisite)
                    .WithMany(p => p.Visites)
                    .HasForeignKey(d => d.RaisonVisiteId)
                    .HasConstraintName("FK_RaisonVisite");

                entity.HasOne(d => d.Statut)
                    .WithMany(p => p.Visites)
                    .HasForeignKey(d => d.StatutId)
                    .HasConstraintName("FK_Statut");

                entity.HasOne(d => d.TypeVisite)
                    .WithMany(p => p.Visites)
                    .HasForeignKey(d => d.TypeVisiteId)
                    .HasConstraintName("FK_TypeVisite");

                entity.HasOne(d => d.Visiteur)
                    .WithMany(p => p.Visites)
                    .HasForeignKey(d => d.VisiteurId)
                    .HasConstraintName("FK_Visiteur");
            });

            modelBuilder.Entity<Visiteur>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Nom).HasMaxLength(255);

                entity.Property(e => e.Prenom).HasMaxLength(255);

                entity.Property(e => e.Telphone).HasMaxLength(20);

                entity.Property(e => e.TypeVisiteurId).HasColumnName("Type_visiteur_id");

                entity.HasOne(d => d.TypeVisiteur)
                    .WithMany(p => p.Visiteurs)
                    .HasForeignKey(d => d.TypeVisiteurId)
                    .HasConstraintName("FK_TypeVisiteur");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}