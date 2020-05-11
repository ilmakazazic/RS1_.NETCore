﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RS1_Ispit_asp.net_core.EF;
using System;

namespace RS1_Ispit_asp.net_core.Migrations
{
    [DbContext(typeof(MojContext))]
    [Migration("20200121153519_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.AkademskaGodina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.ToTable("AkademskaGodina");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Angazovan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AkademskaGodinaId");

                    b.Property<int>("NastavnikId");

                    b.Property<int>("PredmetId");

                    b.HasKey("Id");

                    b.HasIndex("AkademskaGodinaId");

                    b.HasIndex("NastavnikId");

                    b.HasIndex("PredmetId");

                    b.ToTable("Angazovan");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Nastavnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Nastavnik");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.OdrzaniCas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AngazovaniId");

                    b.Property<DateTime>("Datum");

                    b.HasKey("Id");

                    b.HasIndex("AngazovaniId");

                    b.ToTable("OdrzaniCas");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.OdrzaniCasDetalji", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BodoviNaCasu");

                    b.Property<int>("OdrzaniCasoviId");

                    b.Property<bool>("Prisutan");

                    b.Property<int>("SlusaPredmeteId");

                    b.HasKey("Id");

                    b.HasIndex("OdrzaniCasoviId");

                    b.HasIndex("SlusaPredmeteId");

                    b.ToTable("OdrzaniCasDetalji");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Predmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ECTS");

                    b.Property<int>("Godina");

                    b.Property<string>("Naziv");

                    b.Property<int>("Sifra");

                    b.HasKey("Id");

                    b.ToTable("Predmet");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.SlusaPredmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AngazovanId");

                    b.Property<DateTime?>("DatumOcjene");

                    b.Property<string>("Napomena");

                    b.Property<int?>("Ocjena");

                    b.Property<int>("UpisGodineId");

                    b.HasKey("Id");

                    b.HasIndex("AngazovanId");

                    b.HasIndex("UpisGodineId");

                    b.ToTable("SlusaPredmet");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrojIndeksa");

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.UpisGodine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AkademskaGodinaId");

                    b.Property<DateTime>("DatumUpisa");

                    b.Property<int>("GodinaStudija");

                    b.Property<int>("PolozioECTS");

                    b.Property<int>("SlusaECTS");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("AkademskaGodinaId");

                    b.HasIndex("StudentId");

                    b.ToTable("UpisGodine");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Angazovan", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.AkademskaGodina", "AkademskaGodina")
                        .WithMany()
                        .HasForeignKey("AkademskaGodinaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Nastavnik", "Nastavnik")
                        .WithMany()
                        .HasForeignKey("NastavnikId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.OdrzaniCas", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Angazovan", "Angazovani")
                        .WithMany()
                        .HasForeignKey("AngazovaniId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.OdrzaniCasDetalji", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.OdrzaniCas", "OdrzaniCasovi")
                        .WithMany()
                        .HasForeignKey("OdrzaniCasoviId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.SlusaPredmet", "SlusaPredmete")
                        .WithMany()
                        .HasForeignKey("SlusaPredmeteId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.SlusaPredmet", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Angazovan", "Angazovan")
                        .WithMany()
                        .HasForeignKey("AngazovanId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.UpisGodine", "UpisGodine")
                        .WithMany()
                        .HasForeignKey("UpisGodineId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.UpisGodine", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.AkademskaGodina", "AkademskaGodina")
                        .WithMany()
                        .HasForeignKey("AkademskaGodinaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
