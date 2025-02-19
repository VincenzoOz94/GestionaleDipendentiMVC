﻿// <auto-generated />
using GestionaleDipendentiMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionaleDipendentiMVC.Migrations
{
    [DbContext(typeof(GestionaleDipendentiMVCContext))]
    [Migration("20240406075010_primaMigrazione")]
    partial class primaMigrazione
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("GestionaleDipendentiMVC.Models.Dipendente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RuoloId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Stipendio")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("RuoloId");

                    b.ToTable("Dipendente");
                });

            modelBuilder.Entity("GestionaleDipendentiMVC.Models.Ruolo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeRuolo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ruolo");
                });

            modelBuilder.Entity("GestionaleDipendentiMVC.Models.Dipendente", b =>
                {
                    b.HasOne("GestionaleDipendentiMVC.Models.Ruolo", "Ruolo")
                        .WithMany()
                        .HasForeignKey("RuoloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ruolo");
                });
#pragma warning restore 612, 618
        }
    }
}
