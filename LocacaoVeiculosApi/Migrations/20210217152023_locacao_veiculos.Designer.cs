﻿// <auto-generated />
using System;
using LocacaoVeiculosApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LocacaoVeiculosApi.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20210217152023_locacao_veiculos")]
    partial class locacao_veiculos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ChecklistId")
                        .HasColumnType("integer");

                    b.Property<double?>("CustosAdicional")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataHoraColetaPrevista")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataHoraColetaRealizada")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataHoraEntregaPrevista")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataHoraEntregaRealizada")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("HorasLocacao")
                        .HasColumnType("double precision");

                    b.Property<int?>("OperadorId")
                        .HasColumnType("integer");

                    b.Property<bool?>("RealizadaVistoria")
                        .HasColumnType("boolean");

                    b.Property<double>("SubTotal")
                        .HasColumnType("double precision");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("integer");

                    b.Property<double>("ValorHora")
                        .HasColumnType("double precision");

                    b.Property<double?>("ValorTotal")
                        .HasColumnType("double precision");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ChecklistId");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Checklist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Amassados")
                        .HasColumnType("boolean");

                    b.Property<bool>("Arranhoes")
                        .HasColumnType("boolean");

                    b.Property<bool>("CarroLimpo")
                        .HasColumnType("boolean");

                    b.Property<bool>("TanqueCheio")
                        .HasColumnType("boolean");

                    b.Property<int>("TanqueLitroPendente")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Checklists");
                });

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Modelos");
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
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CapacidadePortaMalas")
                        .HasColumnType("integer");

                    b.Property<int>("CapacidadeTanque")
                        .HasColumnType("integer");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("integer");

                    b.Property<int>("Combustivel")
                        .HasColumnType("integer");

                    b.Property<int>("MarcaId")
                        .HasColumnType("integer");

                    b.Property<int>("ModeloId")
                        .HasColumnType("integer");

                    b.Property<string>("Placa")
                        .HasColumnType("text");

                    b.Property<float>("ValorHora")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("MarcaId");

                    b.HasIndex("ModeloId");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Agendamento", b =>
                {
                    b.HasOne("LocacaoVeiculosApi.Domain.Entities.Checklist", "Checklist")
                        .WithMany()
                        .HasForeignKey("ChecklistId");

                    b.Navigation("Checklist");
                });

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Veiculo", b =>
                {
                    b.HasOne("LocacaoVeiculosApi.Domain.Entities.Categoria", "Categoria")
                        .WithMany("Veiculos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocacaoVeiculosApi.Domain.Entities.Marca", "Marca")
                        .WithMany("Veiculos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocacaoVeiculosApi.Domain.Entities.Modelo", "Modelo")
                        .WithMany("Veiculos")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("LocacaoVeiculosApi.Domain.Entities.Modelo", b =>
                {
                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
