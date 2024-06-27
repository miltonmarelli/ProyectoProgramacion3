﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto.Infraestructure.Context;

#nullable disable

namespace Proyecto.Infraestructure.Migrations
{
    [DbContext(typeof(ProyectoDbContext))]
    [Migration("20240627024817_AddIdUserDto")]
    partial class AddIdUserDto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Proyecto.Domain.Models.CommercialInvoice", b =>
                {
                    b.Property<Guid>("IdOrden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ShoppingCartIdShoppingCart")
                        .HasColumnType("TEXT");

                    b.HasKey("IdOrden");

                    b.HasIndex("ClientId");

                    b.HasIndex("ShoppingCartIdShoppingCart");

                    b.ToTable("CommercialInvoices");
                });

            modelBuilder.Entity("Proyecto.Domain.Models.Producto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<double>("Descuento")
                        .HasColumnType("REAL");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<double>("PrecioUnitario")
                        .HasColumnType("REAL");

                    b.Property<int?>("Stock")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Proyecto.Domain.Models.ShoppingCart", b =>
                {
                    b.Property<Guid>("IdShoppingCart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Impuesto")
                        .HasColumnType("REAL");

                    b.HasKey("IdShoppingCart");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("Proyecto.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ShoppingCartProducto", b =>
                {
                    b.Property<Guid>("ProductoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ShoppingCartId")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductoId", "ShoppingCartId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartProducto");
                });

            modelBuilder.Entity("Proyecto.Domain.Models.Admin", b =>
                {
                    b.HasBaseType("Proyecto.Domain.Models.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Proyecto.Domain.Models.Client", b =>
                {
                    b.HasBaseType("Proyecto.Domain.Models.User");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Proyecto.Domain.Models.Dev", b =>
                {
                    b.HasBaseType("Proyecto.Domain.Models.User");

                    b.HasDiscriminator().HasValue("Dev");
                });

            modelBuilder.Entity("Proyecto.Domain.Models.CommercialInvoice", b =>
                {
                    b.HasOne("Proyecto.Domain.Models.Client", null)
                        .WithMany("CommercialInvoices")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto.Domain.Models.ShoppingCart", "ShoppingCart")
                        .WithMany()
                        .HasForeignKey("ShoppingCartIdShoppingCart")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("Proyecto.Domain.Models.ShoppingCart", b =>
                {
                    b.HasOne("Proyecto.Domain.Models.Client", null)
                        .WithOne("ShoppingCart")
                        .HasForeignKey("Proyecto.Domain.Models.ShoppingCart", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingCartProducto", b =>
                {
                    b.HasOne("Proyecto.Domain.Models.Producto", null)
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto.Domain.Models.ShoppingCart", null)
                        .WithMany()
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proyecto.Domain.Models.Client", b =>
                {
                    b.Navigation("CommercialInvoices");

                    b.Navigation("ShoppingCart")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
