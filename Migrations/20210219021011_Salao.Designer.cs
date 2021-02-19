﻿// <auto-generated />
using System;
using ContSelf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContSelf.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210219021011_Salao")]
    partial class Salao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ContSelf.Entidade.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Agendamento")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("decimal (18,4)");

                    b.Property<int?>("PagamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PagamentoId");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("ContSelf.Entidade.Custo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal (18,4)");

                    b.HasKey("Id");

                    b.ToTable("Custo");
                });

            modelBuilder.Entity("ContSelf.Entidade.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal (18,4)");

                    b.HasKey("Id");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("ContSelf.Entidade.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AgendaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal (18,4)");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("ContSelf.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AgendaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Aniversario")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ContSelf.Models.Funcionario", b =>
                {
                    b.Property<int>("CodFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AgendaId")
                        .HasColumnType("int");

                    b.Property<string>("Atividade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal?>("Salario")
                        .HasColumnType("decimal (18,4)");

                    b.HasKey("CodFuncionario");

                    b.HasIndex("AgendaId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("ContSelf.Entidade.Agenda", b =>
                {
                    b.HasOne("ContSelf.Entidade.Pagamento", "Pagamento")
                        .WithMany()
                        .HasForeignKey("PagamentoId");

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("ContSelf.Entidade.Servico", b =>
                {
                    b.HasOne("ContSelf.Entidade.Agenda", null)
                        .WithMany("Servicos")
                        .HasForeignKey("AgendaId");
                });

            modelBuilder.Entity("ContSelf.Models.Cliente", b =>
                {
                    b.HasOne("ContSelf.Entidade.Agenda", null)
                        .WithMany("Clientes")
                        .HasForeignKey("AgendaId");
                });

            modelBuilder.Entity("ContSelf.Models.Funcionario", b =>
                {
                    b.HasOne("ContSelf.Entidade.Agenda", null)
                        .WithMany("Profissional")
                        .HasForeignKey("AgendaId");
                });

            modelBuilder.Entity("ContSelf.Entidade.Agenda", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Profissional");

                    b.Navigation("Servicos");
                });
#pragma warning restore 612, 618
        }
    }
}
