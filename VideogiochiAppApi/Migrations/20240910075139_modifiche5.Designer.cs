﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideogiochiAppApi.Data;

#nullable disable

namespace VideogiochiAppApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240910075139_modifiche5")]
    partial class modifiche5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VideogiochiAppApi.Model.Paese", b =>
                {
                    b.Property<int>("IdPaese")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Pk_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaese"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPaese");

                    b.ToTable("Paese");

                    b.HasData(
                        new
                        {
                            IdPaese = 1,
                            Name = "Italia"
                        },
                        new
                        {
                            IdPaese = 2,
                            Name = "USA"
                        });
                });

            modelBuilder.Entity("VideogiochiAppApi.Model.Proprietario", b =>
                {
                    b.Property<int>("IdProprietario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Pk_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProprietario"));

                    b.Property<int?>("Età")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdPaese")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProprietario");

                    b.HasIndex("IdPaese");

                    b.ToTable("Proprietario");

                    b.HasData(
                        new
                        {
                            IdProprietario = 1,
                            Età = 35,
                            IdPaese = 1,
                            Nome = "Mario"
                        },
                        new
                        {
                            IdProprietario = 2,
                            Età = 30,
                            IdPaese = 1,
                            Nome = "Luigi"
                        },
                        new
                        {
                            IdProprietario = 3,
                            Età = 28,
                            IdPaese = 2,
                            Nome = "John"
                        },
                        new
                        {
                            IdProprietario = 4,
                            Età = 45,
                            IdPaese = 2,
                            Nome = "Drake"
                        });
                });

            modelBuilder.Entity("VideogiochiAppApi.Model.Videogioco", b =>
                {
                    b.Property<int>("IdVideogioco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Pk_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVideogioco"));

                    b.Property<DateOnly?>("DataDiRilascio")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVideogioco");

                    b.ToTable("Videogioco");

                    b.HasData(
                        new
                        {
                            IdVideogioco = 1,
                            DataDiRilascio = new DateOnly(1985, 9, 13),
                            Nome = "Super Mario"
                        },
                        new
                        {
                            IdVideogioco = 2,
                            DataDiRilascio = new DateOnly(1986, 2, 21),
                            Nome = "The Legend of Zelda"
                        },
                        new
                        {
                            IdVideogioco = 3,
                            DataDiRilascio = new DateOnly(1981, 7, 9),
                            Nome = "Donkey Kong"
                        },
                        new
                        {
                            IdVideogioco = 4,
                            DataDiRilascio = new DateOnly(2016, 5, 3),
                            Nome = "Uncharted 4: A thief's end"
                        });
                });

            modelBuilder.Entity("VideogiochiAppApi.Model.VideogiocoProprietario", b =>
                {
                    b.Property<int>("IdVideogiocoProprietario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Pk_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVideogiocoProprietario"));

                    b.Property<int?>("IdProprietario")
                        .HasColumnType("int");

                    b.Property<int?>("IdVideogioco")
                        .HasColumnType("int");

                    b.HasKey("IdVideogiocoProprietario");

                    b.HasIndex("IdProprietario");

                    b.HasIndex("IdVideogioco");

                    b.ToTable("VideogiocoProprietario");

                    b.HasData(
                        new
                        {
                            IdVideogiocoProprietario = 1,
                            IdProprietario = 1,
                            IdVideogioco = 1
                        },
                        new
                        {
                            IdVideogiocoProprietario = 2,
                            IdProprietario = 2,
                            IdVideogioco = 2
                        },
                        new
                        {
                            IdVideogiocoProprietario = 3,
                            IdProprietario = 3,
                            IdVideogioco = 3
                        },
                        new
                        {
                            IdVideogiocoProprietario = 4,
                            IdProprietario = 4,
                            IdVideogioco = 1
                        },
                        new
                        {
                            IdVideogiocoProprietario = 5,
                            IdProprietario = 1,
                            IdVideogioco = 4
                        });
                });

            modelBuilder.Entity("VideogiochiAppApi.Model.Proprietario", b =>
                {
                    b.HasOne("VideogiochiAppApi.Model.Paese", "Paese")
                        .WithMany("Proprietario")
                        .HasForeignKey("IdPaese");

                    b.Navigation("Paese");
                });

            modelBuilder.Entity("VideogiochiAppApi.Model.VideogiocoProprietario", b =>
                {
                    b.HasOne("VideogiochiAppApi.Model.Proprietario", "Proprietario")
                        .WithMany("VideogiocoProprietario")
                        .HasForeignKey("IdProprietario");

                    b.HasOne("VideogiochiAppApi.Model.Videogioco", "Videogioco")
                        .WithMany("VideogiocoProprietario")
                        .HasForeignKey("IdVideogioco");

                    b.Navigation("Proprietario");

                    b.Navigation("Videogioco");
                });

            modelBuilder.Entity("VideogiochiAppApi.Model.Paese", b =>
                {
                    b.Navigation("Proprietario");
                });

            modelBuilder.Entity("VideogiochiAppApi.Model.Proprietario", b =>
                {
                    b.Navigation("VideogiocoProprietario");
                });

            modelBuilder.Entity("VideogiochiAppApi.Model.Videogioco", b =>
                {
                    b.Navigation("VideogiocoProprietario");
                });
#pragma warning restore 612, 618
        }
    }
}
