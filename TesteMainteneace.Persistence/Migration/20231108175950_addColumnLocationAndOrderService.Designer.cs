﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TesteMainteneace.Persistence.Context;

#nullable disable

namespace TestMainteneace.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231108175950_addColumnLocationAndOrderService")]
    partial class addColumnLocationAndOrderService
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TesteMainteneace.Domain.Entities.LocalExecutation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Local")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("TesteMainteneace.Domain.Entities.OrderService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("LocalExecutationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LocalExecutationId");

                    b.ToTable("tab_order_service");
                });

            modelBuilder.Entity("TesteMainteneace.Domain.Entities.UserAuth", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Actived")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateTimeUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tab_user_auth");
                });

            modelBuilder.Entity("TesteMainteneace.Domain.Entities.OrderService", b =>
                {
                    b.HasOne("TesteMainteneace.Domain.Entities.LocalExecutation", "LocalExecutation")
                        .WithMany()
                        .HasForeignKey("LocalExecutationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocalExecutation");
                });
#pragma warning restore 612, 618
        }
    }
}
