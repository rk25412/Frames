﻿// <auto-generated />
using System;
using Frames.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Frames.Web.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211112172041_mig1211")]
    partial class mig1211
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Frames.Entities.Models.AdminBill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("LastMonthBill")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("LastMonthLeft")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AdminBills");
                });

            modelBuilder.Entity("Frames.Entities.Models.AdminBillFrameType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdminBillId")
                        .HasColumnType("int");

                    b.Property<string>("FrameName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FrameRate")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminBillId");

                    b.ToTable("AdminBillFrameTypes");
                });

            modelBuilder.Entity("Frames.Entities.Models.AdminFramesIn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("NoOfFrames")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AdminFramesIns");
                });

            modelBuilder.Entity("Frames.Entities.Models.AdminFramesOut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AdminFramesOuts");
                });

            modelBuilder.Entity("Frames.Entities.Models.AdminFramesOutNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdminFramesOutId")
                        .HasColumnType("int");

                    b.Property<int>("ItemTypeId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfFrames")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminFramesOutId");

                    b.HasIndex("ItemTypeId");

                    b.ToTable("AdminFramesOutNumbers");
                });

            modelBuilder.Entity("Frames.Entities.Models.AdminPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AdminPayments");
                });

            modelBuilder.Entity("Frames.Entities.Models.ItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("AdminPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WorkerPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("ItemTypes");
                });

            modelBuilder.Entity("Frames.Entities.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Frames.Entities.Models.WorkerBill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<bool>("Cleared")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerBills");
                });

            modelBuilder.Entity("Frames.Entities.Models.WorkerBillFrameTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FrameName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FrameRate")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("WorkerBillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkerBillId");

                    b.ToTable("WorkerBillFrameTypes");
                });

            modelBuilder.Entity("Frames.Entities.Models.WorkerFramesIn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("NoOfFrames")
                        .HasColumnType("int");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerFramesIns");
                });

            modelBuilder.Entity("Frames.Entities.Models.WorkerFramesOut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerFramesOuts");
                });

            modelBuilder.Entity("Frames.Entities.Models.WorkerFramesOutNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ItemTypeId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfFrames")
                        .HasColumnType("int");

                    b.Property<int>("WorkerFramesOutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("WorkerFramesOutId");

                    b.ToTable("WorkerFramesOutNumbers");
                });

            modelBuilder.Entity("Frames.Entities.Models.WorkerPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WorkerPayments");
                });

            modelBuilder.Entity("Frames.Entities.Models.AdminBillFrameType", b =>
                {
                    b.HasOne("Frames.Entities.Models.AdminBill", "AdminBill")
                        .WithMany("AdminBillFrameTypes")
                        .HasForeignKey("AdminBillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdminBill");
                });

            modelBuilder.Entity("Frames.Entities.Models.AdminFramesOutNumber", b =>
                {
                    b.HasOne("Frames.Entities.Models.AdminFramesOut", "AdminFramesOut")
                        .WithMany("AdminFramesOutNumbers")
                        .HasForeignKey("AdminFramesOutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Frames.Entities.Models.ItemType", "ItemType")
                        .WithMany()
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdminFramesOut");

                    b.Navigation("ItemType");
                });

            modelBuilder.Entity("Frames.Entities.Models.WorkerBill", b =>
                {
                    b.HasOne("Frames.Entities.Models.Worker", "Worker")
                        .WithMany("WorkerBills")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Frames.Entities.Models.WorkerBillFrameTypes", b =>
                {
                    b.HasOne("Frames.Entities.Models.WorkerBill", "WorkerBill")
                        .WithMany("WorkerBillFrameTypes")
                        .HasForeignKey("WorkerBillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkerBill");
                });

            modelBuilder.Entity("Frames.Entities.Models.WorkerFramesIn", b =>
                {
                    b.HasOne("Frames.Entities.Models.Worker", "Worker")
                        .WithMany("WorkerFramesIn")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Frames.Entities.Models.WorkerFramesOut", b =>
                {
                    b.HasOne("Frames.Entities.Models.Worker", "Worker")
                        .WithMany("WorkerFramesOut")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Frames.Entities.Models.WorkerFramesOutNumber", b =>
                {
                    b.HasOne("Frames.Entities.Models.ItemType", "ItemType")
                        .WithMany()
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Frames.Entities.Models.WorkerFramesOut", "WorkerFramesOut")
                        .WithMany("WorkerFramesOutNumbers")
                        .HasForeignKey("WorkerFramesOutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemType");

                    b.Navigation("WorkerFramesOut");
                });

            modelBuilder.Entity("Frames.Entities.Models.AdminBill", b =>
                {
                    b.Navigation("AdminBillFrameTypes");
                });

            modelBuilder.Entity("Frames.Entities.Models.AdminFramesOut", b =>
                {
                    b.Navigation("AdminFramesOutNumbers");
                });

            modelBuilder.Entity("Frames.Entities.Models.Worker", b =>
                {
                    b.Navigation("WorkerBills");

                    b.Navigation("WorkerFramesIn");

                    b.Navigation("WorkerFramesOut");
                });

            modelBuilder.Entity("Frames.Entities.Models.WorkerBill", b =>
                {
                    b.Navigation("WorkerBillFrameTypes");
                });

            modelBuilder.Entity("Frames.Entities.Models.WorkerFramesOut", b =>
                {
                    b.Navigation("WorkerFramesOutNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}