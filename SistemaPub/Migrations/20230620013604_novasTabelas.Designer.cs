﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaPub.Database;

#nullable disable

namespace SistemaPub.Migrations
{
    [DbContext(typeof(PubContext))]
    [Migration("20230620013604_novasTabelas")]
    partial class novasTabelas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaPub.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SistemaPub.Models.Comanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Comandas");
                });

            modelBuilder.Entity("SistemaPub.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Estoque")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Espeto de Porco",
                            Preco = 7.00m
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Espeto de Frango com Bacon",
                            Preco = 8.00m
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Coxinha de Frango",
                            Preco = 7.00m
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Batata Frita",
                            Preco = 14.00m
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Itaipava 600 ml",
                            Preco = 7.50m
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Budweiser",
                            Preco = 10.00m
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Heineken",
                            Preco = 17.00m
                        },
                        new
                        {
                            Id = 8,
                            Nome = "Spaten",
                            Preco = 12.00m
                        },
                        new
                        {
                            Id = 9,
                            Nome = "Dose de Ypioca Ouro",
                            Preco = 4.00m
                        },
                        new
                        {
                            Id = 10,
                            Nome = "Dose de 51",
                            Preco = 4.00m
                        },
                        new
                        {
                            Id = 11,
                            Nome = "Dose de Jack Daniel's",
                            Preco = 14m
                        });
                });

            modelBuilder.Entity("SistemaPub.Models.ProdutoComanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ComandaId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComandaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutosComandas");
                });

            modelBuilder.Entity("SistemaPub.Models.Comanda", b =>
                {
                    b.HasOne("SistemaPub.Models.Cliente", "Cliente")
                        .WithOne("Comanda")
                        .HasForeignKey("SistemaPub.Models.Comanda", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SistemaPub.Models.ProdutoComanda", b =>
                {
                    b.HasOne("SistemaPub.Models.Comanda", "Comanda")
                        .WithMany("ProdutosComanda")
                        .HasForeignKey("ComandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaPub.Models.Produto", "Produto")
                        .WithMany("ProdutosComanda")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comanda");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("SistemaPub.Models.Cliente", b =>
                {
                    b.Navigation("Comanda")
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaPub.Models.Comanda", b =>
                {
                    b.Navigation("ProdutosComanda");
                });

            modelBuilder.Entity("SistemaPub.Models.Produto", b =>
                {
                    b.Navigation("ProdutosComanda");
                });
#pragma warning restore 612, 618
        }
    }
}
