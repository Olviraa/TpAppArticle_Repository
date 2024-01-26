﻿// <auto-generated />
using System;
using ApiVenteArticles.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiVenteArticles.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20240126145112_initail")]
    partial class initail
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ModelsCommun.Produit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "nom");

                    b.Property<double>("Prix")
                        .HasColumnType("float")
                        .HasAnnotation("Relational:JsonPropertyName", "prix");

                    b.Property<int>("QuantiteDisponible")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "quantitedisponible");

                    b.HasKey("ID");

                    b.ToTable("Produits");

                    b.HasAnnotation("Relational:JsonPropertyName", "produit");
                });

            modelBuilder.Entity("ModelsCommun.ProduitVendu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ProduitID")
                        .HasColumnType("int");

                    b.Property<int>("QuantiteVendue")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "quantitevendue");

                    b.Property<int?>("VenteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProduitID");

                    b.HasIndex("VenteID");

                    b.ToTable("ProduitsVendus");
                });

            modelBuilder.Entity("ModelsCommun.Vente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "date");

                    b.Property<double>("Total")
                        .HasColumnType("float")
                        .HasAnnotation("Relational:JsonPropertyName", "total");

                    b.HasKey("ID");

                    b.ToTable("Ventes");
                });

            modelBuilder.Entity("ModelsCommun.ProduitVendu", b =>
                {
                    b.HasOne("ModelsCommun.Produit", "Produit")
                        .WithMany()
                        .HasForeignKey("ProduitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelsCommun.Vente", null)
                        .WithMany("ProduitsVendus")
                        .HasForeignKey("VenteID");

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("ModelsCommun.Vente", b =>
                {
                    b.Navigation("ProduitsVendus");
                });
#pragma warning restore 612, 618
        }
    }
}
