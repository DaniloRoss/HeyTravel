﻿// <auto-generated />
using System;
using HeyTravel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HeyTravel.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220201103458_viag")]
    partial class viag
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("HeyTravel.Models.Casi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CasiAttivi")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CasiGiornalieri")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PercentualeContagi")
                        .HasColumnType("TEXT");

                    b.Property<int>("Popolazione")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Stato")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Casi");
                });

            modelBuilder.Entity("HeyTravel.Models.Mare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mese")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Temperatura")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Mare");
                });

            modelBuilder.Entity("HeyTravel.Models.OreSole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("MediaGiornaliera")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mese")
                        .HasColumnType("TEXT");

                    b.Property<int>("TotaleMese")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("OreSole");
                });

            modelBuilder.Entity("HeyTravel.Models.Precipitazioni", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Giorni")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mese")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantità")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Precipitazioni");
                });

            modelBuilder.Entity("HeyTravel.Models.Temperature", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Max")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Media")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mese")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Min")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Temperature");
                });

            modelBuilder.Entity("HeyTravel.Models.Vaccini", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DosiTotali")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NuoveDosi")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PercentualeVaccini")
                        .HasColumnType("TEXT");

                    b.Property<string>("Stato")
                        .HasColumnType("TEXT");

                    b.Property<int>("Vaccinati")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Vaccini");
                });

            modelBuilder.Entity("HeyTravel.Models.Viaggi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CasiCovidID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PreciID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SoleID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatoArrivo")
                        .HasColumnType("TEXT");

                    b.Property<string>("StatoPartenza")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TempID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TmareID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VaccinatiID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CasiCovidID");

                    b.HasIndex("PreciID");

                    b.HasIndex("SoleID");

                    b.HasIndex("TempID");

                    b.HasIndex("TmareID");

                    b.HasIndex("VaccinatiID");

                    b.ToTable("Viaggio");
                });

            modelBuilder.Entity("HeyTravel.Models.Viaggi", b =>
                {
                    b.HasOne("HeyTravel.Models.Casi", "CasiCovid")
                        .WithMany()
                        .HasForeignKey("CasiCovidID");

                    b.HasOne("HeyTravel.Models.Precipitazioni", "Preci")
                        .WithMany()
                        .HasForeignKey("PreciID");

                    b.HasOne("HeyTravel.Models.OreSole", "Sole")
                        .WithMany()
                        .HasForeignKey("SoleID");

                    b.HasOne("HeyTravel.Models.Temperature", "Temp")
                        .WithMany()
                        .HasForeignKey("TempID");

                    b.HasOne("HeyTravel.Models.Mare", "Tmare")
                        .WithMany()
                        .HasForeignKey("TmareID");

                    b.HasOne("HeyTravel.Models.Vaccini", "Vaccinati")
                        .WithMany()
                        .HasForeignKey("VaccinatiID");

                    b.Navigation("CasiCovid");

                    b.Navigation("Preci");

                    b.Navigation("Sole");

                    b.Navigation("Temp");

                    b.Navigation("Tmare");

                    b.Navigation("Vaccinati");
                });
#pragma warning restore 612, 618
        }
    }
}