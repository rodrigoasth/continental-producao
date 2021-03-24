﻿// <auto-generated />
using System;
using Continental.Producao.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SisCom.API.Migrations
{
    [DbContext(typeof(ProducaoContext))]
    partial class SisComContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Continental.Producao.Domain.Produtos.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Categoria")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Situacao")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Continental.Producao.Domain.SolicitacoesCompra.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProdutoId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Qtde")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("SolicitacaoCompraId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("SolicitacaoCompraId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Continental.Producao.Domain.SolicitacoesCompra.SolicitacaoCompra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<int>("Situacao")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("SolicitacaoCompra");
                });

            modelBuilder.Entity("Continental.Producao.Domain.Produtos.Produto", b =>
                {
                    b.OwnsOne("Continental.Producao.Domain.Core.Money", "PrecoUnitario", b1 =>
                        {
                            b1.Property<Guid>("ProdutoId")
                                .HasColumnType("TEXT");

                            b1.Property<double>("Value")
                                .HasColumnType("REAL")
                                .HasColumnName("PrecoUnitario");

                            b1.HasKey("ProdutoId");

                            b1.ToTable("Produto");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");
                        });

                    b.Navigation("PrecoUnitario");
                });

            modelBuilder.Entity("Continental.Producao.Domain.SolicitacoesCompra.Item", b =>
                {
                    b.HasOne("Continental.Producao.Domain.Produtos.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.HasOne("Continental.Producao.Domain.SolicitacoesCompra.SolicitacaoCompra", null)
                        .WithMany("Itens")
                        .HasForeignKey("SolicitacaoCompraId");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Continental.Producao.Domain.SolicitacoesCompra.SolicitacaoCompra", b =>
                {
                    b.OwnsOne("Continental.Producao.Domain.Core.Money", "TotalGeral", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("TEXT");

                            b1.Property<double>("Value")
                                .HasColumnType("REAL")
                                .HasColumnName("TotalGeral");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");
                        });

                    b.OwnsOne("Continental.Producao.Domain.SolicitacoesCompra.CondicaoPagamento", "CondicaoPagamento", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("TEXT");

                            b1.Property<int>("Valor")
                                .HasColumnType("INTEGER")
                                .HasColumnName("CondicaoPagamento");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");
                        });

                    b.OwnsOne("Continental.Producao.Domain.SolicitacoesCompra.NomeFornecedor", "NomeFornecedor", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Nome")
                                .HasColumnType("TEXT")
                                .HasColumnName("NomeFornecedor");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");
                        });

                    b.OwnsOne("Continental.Producao.Domain.SolicitacoesCompra.UsuarioSolicitante", "UsuarioSolicitante", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Nome")
                                .HasColumnType("TEXT")
                                .HasColumnName("UsuarioSolicitante");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");
                        });

                    b.Navigation("CondicaoPagamento");

                    b.Navigation("NomeFornecedor");

                    b.Navigation("TotalGeral");

                    b.Navigation("UsuarioSolicitante");
                });

            modelBuilder.Entity("Continental.Producao.Domain.SolicitacoesCompra.SolicitacaoCompra", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
