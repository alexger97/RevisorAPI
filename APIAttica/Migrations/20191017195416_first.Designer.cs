﻿// <auto-generated />
using System;
using APIAttica.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIAttica.Migrations
{
    [DbContext(typeof(ServerContext))]
    [Migration("20191017195416_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIAttica.Model.ElementInstrumentToUpload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HoldInstrumentId");

                    b.Property<string>("ImagePhoneSource");

                    b.Property<int?>("InstrumnetHeaderId");

                    b.Property<bool>("IsLoaded");

                    b.Property<int?>("NomenclatureId");

                    b.Property<string>("UserName");

                    b.Property<string>("XKey");

                    b.HasKey("Id");

                    b.HasIndex("HoldInstrumentId");

                    b.HasIndex("InstrumnetHeaderId");

                    b.HasIndex("NomenclatureId");

                    b.ToTable("ElementInstrumentToUpload");
                });

            modelBuilder.Entity("APIAttica.Model.ElementMaterialToUpload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Count");

                    b.Property<int?>("HoldMaterialId");

                    b.Property<bool>("IsLoaded");

                    b.Property<int?>("MaterialNomenclatureId");

                    b.Property<string>("Name");

                    b.Property<string>("Units");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("HoldMaterialId");

                    b.HasIndex("MaterialNomenclatureId");

                    b.ToTable("ElementMaterialToUploads");
                });

            modelBuilder.Entity("APIAttica.Model.HoldInstrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InventoryObjectId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("InventoryObjectId");

                    b.ToTable("HoldsInstrument");
                });

            modelBuilder.Entity("APIAttica.Model.HoldMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InventoryObjectId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("InventoryObjectId");

                    b.ToTable("HoldsMaterial");
                });

            modelBuilder.Entity("APIAttica.Model.InstrumentNomenclature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("InstrumentNomenclatures");
                });

            modelBuilder.Entity("APIAttica.Model.InstrumnetHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NomenclatureId");

                    b.Property<string>("XKey");

                    b.HasKey("Id");

                    b.HasIndex("NomenclatureId");

                    b.ToTable("InstrumnetHeader");
                });

            modelBuilder.Entity("APIAttica.Model.InventoryObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("InventoryObjectsMain");
                });

            modelBuilder.Entity("APIAttica.Model.MaterialNomenclature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Units");

                    b.HasKey("Id");

                    b.ToTable("MaterialNomenclatures");
                });

            modelBuilder.Entity("APIAttica.Model.TransactInstrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ElementInstrumentToUploadId");

                    b.Property<byte[]>("Image");

                    b.HasKey("Id");

                    b.HasIndex("ElementInstrumentToUploadId");

                    b.ToTable("TransactInstruments");
                });

            modelBuilder.Entity("APIAttica.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("APIAttica.Model.ElementInstrumentToUpload", b =>
                {
                    b.HasOne("APIAttica.Model.HoldInstrument", "HoldInstrument")
                        .WithMany()
                        .HasForeignKey("HoldInstrumentId");

                    b.HasOne("APIAttica.Model.InstrumnetHeader", "InstrumnetHeader")
                        .WithMany()
                        .HasForeignKey("InstrumnetHeaderId");

                    b.HasOne("APIAttica.Model.InstrumentNomenclature", "Nomenclature")
                        .WithMany()
                        .HasForeignKey("NomenclatureId");
                });

            modelBuilder.Entity("APIAttica.Model.ElementMaterialToUpload", b =>
                {
                    b.HasOne("APIAttica.Model.HoldMaterial", "HoldMaterial")
                        .WithMany()
                        .HasForeignKey("HoldMaterialId");

                    b.HasOne("APIAttica.Model.MaterialNomenclature", "MaterialNomenclature")
                        .WithMany()
                        .HasForeignKey("MaterialNomenclatureId");
                });

            modelBuilder.Entity("APIAttica.Model.HoldInstrument", b =>
                {
                    b.HasOne("APIAttica.Model.InventoryObject")
                        .WithMany("HoldInstruments")
                        .HasForeignKey("InventoryObjectId");
                });

            modelBuilder.Entity("APIAttica.Model.HoldMaterial", b =>
                {
                    b.HasOne("APIAttica.Model.InventoryObject")
                        .WithMany("HoldMaterials")
                        .HasForeignKey("InventoryObjectId");
                });

            modelBuilder.Entity("APIAttica.Model.InstrumnetHeader", b =>
                {
                    b.HasOne("APIAttica.Model.InstrumentNomenclature", "Nomenclature")
                        .WithMany()
                        .HasForeignKey("NomenclatureId");
                });

            modelBuilder.Entity("APIAttica.Model.TransactInstrument", b =>
                {
                    b.HasOne("APIAttica.Model.ElementInstrumentToUpload", "ElementInstrumentToUpload")
                        .WithMany()
                        .HasForeignKey("ElementInstrumentToUploadId");
                });
#pragma warning restore 612, 618
        }
    }
}
