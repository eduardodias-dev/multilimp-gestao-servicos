﻿// <auto-generated />
using System;
using GestaoServicos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestaoServicos.Infra.Data.Migrations
{
    [DbContext(typeof(GestaoServicosDbContext))]
    [Migration("20220327143323_adicionada-tabela-funcionario")]
    partial class adicionadatabelafuncionario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23");

            modelBuilder.Entity("GestaoServicos.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPFCNPJ")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataMatricula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("GestaoServicos.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .HasColumnType("TEXT");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Complemento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Logradouro")
                        .HasColumnType("TEXT");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UF")
                        .HasColumnType("TEXT");

                    b.HasKey("EnderecoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("GestaoServicos.Domain.Entities.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TelefoneId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FuncionarioId");

                    b.HasIndex("TelefoneId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("GestaoServicos.Domain.Entities.OrdemServico", b =>
                {
                    b.Property<int>("OrdemServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataExecucao")
                        .HasColumnType("TEXT");

                    b.Property<double>("Desconto")
                        .HasColumnType("REAL");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Observacoes")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("REAL");

                    b.HasKey("OrdemServicoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("OrdemServicos");
                });

            modelBuilder.Entity("GestaoServicos.Domain.Entities.Telefone", b =>
                {
                    b.Property<int>("TelefoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<short>("DDD")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.HasKey("TelefoneId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("GestaoServicos.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("GestaoServicos.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Enderecos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestaoServicos.Domain.Entities.Funcionario", b =>
                {
                    b.HasOne("GestaoServicos.Domain.Entities.Telefone", "Telefone")
                        .WithMany()
                        .HasForeignKey("TelefoneId");
                });

            modelBuilder.Entity("GestaoServicos.Domain.Entities.OrdemServico", b =>
                {
                    b.HasOne("GestaoServicos.Domain.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestaoServicos.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");
                });

            modelBuilder.Entity("GestaoServicos.Domain.Entities.Telefone", b =>
                {
                    b.HasOne("GestaoServicos.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Telefones")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}