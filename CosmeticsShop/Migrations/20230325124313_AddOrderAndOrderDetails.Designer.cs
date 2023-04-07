﻿// <auto-generated />
using System;
using CosmeticsShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CosmeticsShop.Migrations
{
    [DbContext(typeof(CosmeticsShopContext))]
    [Migration("20230325124313_AddOrderAndOrderDetails")]
    partial class AddOrderAndOrderDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CosmeticsShop.Models.CartItem", b =>
                {
                    b.Property<string>("ItemId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CartId")
                        .HasColumnType("longtext");

                    b.Property<int?>("CosmeticId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("CosmeticId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("CosmeticsShop.Models.Cosmetic", b =>
                {
                    b.Property<int>("CosmeticId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CosmeticCategory")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("CosmeticId");

                    b.ToTable("Cosmetics");
                });

            modelBuilder.Entity("CosmeticsShop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("SurName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CosmeticsShop.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int?>("CosmeticId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CosmeticId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("CosmeticsShop.Models.CartItem", b =>
                {
                    b.HasOne("CosmeticsShop.Models.Cosmetic", "Cosmetic")
                        .WithMany()
                        .HasForeignKey("CosmeticId");

                    b.Navigation("Cosmetic");
                });

            modelBuilder.Entity("CosmeticsShop.Models.OrderDetail", b =>
                {
                    b.HasOne("CosmeticsShop.Models.Cosmetic", "Cosmetic")
                        .WithMany()
                        .HasForeignKey("CosmeticId");

                    b.HasOne("CosmeticsShop.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cosmetic");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CosmeticsShop.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
