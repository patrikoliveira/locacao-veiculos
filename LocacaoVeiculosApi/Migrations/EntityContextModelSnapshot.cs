﻿// <auto-generated />
using System;
using LocacaoVeiculosApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LocacaoVeiculosApi.Migrations
{
    [DbContext(typeof(EntityContext))]
    partial class EntityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("marcas");
                });

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("modelos");
                });

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CpfMatricula")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CapacidadePortaMalas")
                        .HasColumnType("integer")
                        .HasColumnName("capacidade_porta_malas");

                    b.Property<int>("CapacidadeTanque")
                        .HasColumnType("integer")
                        .HasColumnName("capacidade_tanque");

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("integer");

                    b.Property<int>("Combustivel")
                        .HasColumnType("integer");

                    b.Property<int?>("MarcaId")
                        .HasColumnType("integer");

                    b.Property<int?>("ModeloId")
                        .HasColumnType("integer");

                    b.Property<string>("Placa")
                        .HasColumnType("text")
                        .HasColumnName("placa");

                    b.Property<float>("ValorHora")
                        .HasColumnType("real")
                        .HasColumnName("valor_hora");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("MarcaId");

                    b.HasIndex("ModeloId");

                    b.ToTable("veiculos");
                });

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Veiculo", b =>
                {
                    b.HasOne("LocacaoVeiculosApi.Domain.Entities.Categoria", "Categoria")
                        .WithMany("Veiculos")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("LocacaoVeiculosApi.Domain.Entities.Marca", "Marca")
                        .WithMany("Veiculos")
                        .HasForeignKey("MarcaId");

                    b.HasOne("LocacaoVeiculosApi.Domain.Entities.Modelo", "Modelo")
                        .WithMany()
                        .HasForeignKey("ModeloId");

                    b.Navigation("Categoria");

                    b.Navigation("Marca");

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Marca", b =>
                {
                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
