﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fod.Models;

#nullable disable

namespace fod.Migrations.GestionVisiteDB
{
    [DbContext(typeof(GestionVisiteDBContext))]
    [Migration("20240502130540_SecondMIGRATION")]
    partial class SecondMIGRATION
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("fod.Models.Personnel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Poste")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Prenom")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telephone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Personnel");
                });

            modelBuilder.Entity("fod.Models.RaisonVisite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("RaisonVisites");
                });

            modelBuilder.Entity("fod.Models.Statut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Statuts");
                });

            modelBuilder.Entity("fod.Models.TypeVisite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("TypeVisites");
                });

            modelBuilder.Entity("fod.Models.TypeVisiteur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("TypeVisiteurs");
                });

            modelBuilder.Entity("fod.Models.Visite", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime?>("DateHeureDebut")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateHeureFin")
                        .HasColumnType("datetime");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonnelId")
                        .HasColumnType("int")
                        .HasColumnName("Personnel_id");

                    b.Property<int?>("RaisonVisiteId")
                        .HasColumnType("int")
                        .HasColumnName("Raison_visite_id");

                    b.Property<int?>("StatutId")
                        .HasColumnType("int")
                        .HasColumnName("Statut_id");

                    b.Property<int?>("TypeVisiteId")
                        .HasColumnType("int")
                        .HasColumnName("Type_visite_id");

                    b.Property<int?>("VisiteurId")
                        .HasColumnType("int")
                        .HasColumnName("Visiteur_id");

                    b.HasKey("Uid")
                        .HasName("PK__Visites__C5B69A4A02F6D497");

                    b.HasIndex("PersonnelId");

                    b.HasIndex("RaisonVisiteId");

                    b.HasIndex("StatutId");

                    b.HasIndex("TypeVisiteId");

                    b.HasIndex("VisiteurId");

                    b.ToTable("Visites");
                });

            modelBuilder.Entity("fod.Models.Visiteur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nom")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Prenom")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telphone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("TypeVisiteurId")
                        .HasColumnType("int")
                        .HasColumnName("Type_visiteur_id");

                    b.HasKey("Id");

                    b.HasIndex("TypeVisiteurId");

                    b.ToTable("Visiteurs");
                });

            modelBuilder.Entity("fod.Models.Visite", b =>
                {
                    b.HasOne("fod.Models.Personnel", "Personnel")
                        .WithMany("Visites")
                        .HasForeignKey("PersonnelId")
                        .HasConstraintName("FK_Personnel");

                    b.HasOne("fod.Models.RaisonVisite", "RaisonVisite")
                        .WithMany("Visites")
                        .HasForeignKey("RaisonVisiteId")
                        .HasConstraintName("FK_RaisonVisite");

                    b.HasOne("fod.Models.Statut", "Statut")
                        .WithMany("Visites")
                        .HasForeignKey("StatutId")
                        .HasConstraintName("FK_Statut");

                    b.HasOne("fod.Models.TypeVisite", "TypeVisite")
                        .WithMany("Visites")
                        .HasForeignKey("TypeVisiteId")
                        .HasConstraintName("FK_TypeVisite");

                    b.HasOne("fod.Models.Visiteur", "Visiteur")
                        .WithMany("Visites")
                        .HasForeignKey("VisiteurId")
                        .HasConstraintName("FK_Visiteur");

                    b.Navigation("Personnel");

                    b.Navigation("RaisonVisite");

                    b.Navigation("Statut");

                    b.Navigation("TypeVisite");

                    b.Navigation("Visiteur");
                });

            modelBuilder.Entity("fod.Models.Visiteur", b =>
                {
                    b.HasOne("fod.Models.TypeVisiteur", "TypeVisiteur")
                        .WithMany("Visiteurs")
                        .HasForeignKey("TypeVisiteurId")
                        .HasConstraintName("FK_TypeVisiteur");

                    b.Navigation("TypeVisiteur");
                });

            modelBuilder.Entity("fod.Models.Personnel", b =>
                {
                    b.Navigation("Visites");
                });

            modelBuilder.Entity("fod.Models.RaisonVisite", b =>
                {
                    b.Navigation("Visites");
                });

            modelBuilder.Entity("fod.Models.Statut", b =>
                {
                    b.Navigation("Visites");
                });

            modelBuilder.Entity("fod.Models.TypeVisite", b =>
                {
                    b.Navigation("Visites");
                });

            modelBuilder.Entity("fod.Models.TypeVisiteur", b =>
                {
                    b.Navigation("Visiteurs");
                });

            modelBuilder.Entity("fod.Models.Visiteur", b =>
                {
                    b.Navigation("Visites");
                });
#pragma warning restore 612, 618
        }
    }
}
