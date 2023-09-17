﻿// <auto-generated />
using System;
using Atomicy.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Atomicy.Persistence.Migrations
{
    [DbContext(typeof(AtomicyDbContext))]
    partial class AtomicyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Atomicy.Domain.Entities.Demand", b =>
                {
                    b.Property<Guid>("DemandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DemandDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DemandTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DemandId");

                    b.ToTable("Demands");

                    b.HasData(
                        new
                        {
                            DemandId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            Completed = false,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DemandDate = new DateTime(2023, 9, 4, 23, 22, 26, 339, DateTimeKind.Local).AddTicks(5213),
                            DemandTypeId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            From = "Bahçelievler",
                            Note = "Paketlemeyi de sizin yapmanızı istiyorum.",
                            To = "Halkalı",
                            UserId = new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b")
                        },
                        new
                        {
                            DemandId = new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                            Completed = false,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DemandDate = new DateTime(2023, 9, 4, 23, 22, 26, 339, DateTimeKind.Local).AddTicks(5213),
                            DemandTypeId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            From = "Avcılar",
                            Note = "Paketlemeyi de sizin yapmanızı istiyorum.",
                            To = "Bakırköy",
                            UserId = new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b")
                        });
                });

            modelBuilder.Entity("Atomicy.Domain.Entities.DemandConversation", b =>
                {
                    b.Property<Guid>("DemandConversationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DemandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FirmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirmMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DemandConversationId");

                    b.HasIndex("DemandId");

                    b.ToTable("DemandConversation");

                    b.HasData(
                        new
                        {
                            DemandConversationId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 9, 4, 23, 22, 26, 339, DateTimeKind.Local).AddTicks(5213),
                            DemandId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            FirmId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            FirmMessage = "Merhaba 3000 tl ye götürebiliriz.",
                            Read = false,
                            UserId = new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b")
                        },
                        new
                        {
                            DemandConversationId = new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerMessage = "Hangi günler musaitsiniz?",
                            Date = new DateTime(2023, 9, 4, 23, 22, 26, 339, DateTimeKind.Local).AddTicks(5213),
                            DemandId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            FirmId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            Read = false,
                            UserId = new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b")
                        });
                });

            modelBuilder.Entity("Atomicy.Domain.Entities.DemandType", b =>
                {
                    b.Property<Guid>("DemandTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DemandTypeId");

                    b.ToTable("DemandTypes");

                    b.HasData(
                        new
                        {
                            DemandTypeId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Evimi Taşı"
                        },
                        new
                        {
                            DemandTypeId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Parça Eşyamı Taşı"
                        },
                        new
                        {
                            DemandTypeId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ofisimi Taşı"
                        });
                });

            modelBuilder.Entity("Atomicy.Domain.Entities.Firm", b =>
                {
                    b.Property<Guid>("FirmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BigTruckCount")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirmName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TruckCount")
                        .HasColumnType("int");

                    b.Property<int>("VanCount")
                        .HasColumnType("int");

                    b.HasKey("FirmId");

                    b.ToTable("Firms");

                    b.HasData(
                        new
                        {
                            FirmId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            BigTruckCount = 10,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirmName = "İstanbul Nakliyat",
                            Note = "30 yıldır taşımacılık sektöründe faaliyet göstermekteyiz.",
                            TruckCount = 10,
                            VanCount = 4
                        },
                        new
                        {
                            FirmId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            BigTruckCount = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirmName = "İstanbul Nakliyat",
                            Note = "10 yıldır müşterilerimize üst düzeyde hizmet vermekteyiz.",
                            TruckCount = 5,
                            VanCount = 2
                        });
                });

            modelBuilder.Entity("Atomicy.Domain.Entities.FirmComment", b =>
                {
                    b.Property<Guid>("FirmCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FirmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FirmCommentId");

                    b.HasIndex("FirmId");

                    b.ToTable("FirmComments");

                    b.HasData(
                        new
                        {
                            FirmCommentId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Comment = "Eşyalara zarar vermeden paketleme ve taşıma harikaydı. Tavsiye ederim.",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirmId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            UserId = new Guid("15efc991-e022-48a1-9394-d398a9fff76f")
                        },
                        new
                        {
                            FirmCommentId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            Comment = "Çok memnun kalmadım. Tavsiye etmiyorum.",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirmId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            UserId = new Guid("15efc991-e022-48a1-9394-d398a9fff76f")
                        });
                });

            modelBuilder.Entity("Atomicy.Domain.Entities.FirmVehicle", b =>
                {
                    b.Property<Guid>("FirmVehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DriverExperience")
                        .HasColumnType("int");

                    b.Property<string>("DriverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FirmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Plate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FirmVehicleId");

                    b.HasIndex("FirmId");

                    b.ToTable("FirmVehicles");

                    b.HasData(
                        new
                        {
                            FirmVehicleId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DriverExperience = 21,
                            DriverName = "Melih Gümüş",
                            DriverNote = "Ehliyeti aldığından beri kaza geçirmemiş, deneyimli bir şöfördür.",
                            FirmId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Plate = "34 DP 524"
                        },
                        new
                        {
                            FirmVehicleId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DriverExperience = 15,
                            DriverName = "Güven Duman",
                            DriverNote = "Sürücünün ilk yardım belgesi bulunmaktadır.",
                            FirmId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Plate = "34 HGE 239"
                        },
                        new
                        {
                            FirmVehicleId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DriverExperience = 12,
                            DriverName = "Zafer Yener",
                            DriverNote = "Sürücünün ilk yardım belgesi bulunmaktadır.",
                            FirmId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Plate = "34 PT 6376"
                        },
                        new
                        {
                            FirmVehicleId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DriverExperience = 26,
                            DriverName = "İsmet Yıldırım",
                            DriverNote = "Sürücünün ilk yardım belgesi bulunmaktadır.",
                            FirmId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Plate = "34 MVR 13"
                        },
                        new
                        {
                            FirmVehicleId = new Guid("661a30f3-efe5-4474-73b9-08dbb62985d7"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DriverExperience = 12,
                            DriverName = "Hakan Yakın",
                            DriverNote = "Sürücünün ilk yardım belgesi bulunmaktadır.",
                            FirmId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Plate = "34 DE 147"
                        });
                });

            modelBuilder.Entity("Atomicy.Domain.Entities.Reservation", b =>
                {
                    b.Property<Guid>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CarryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DemandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FirmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReservationId");

                    b.HasIndex("DemandId");

                    b.HasIndex("FirmId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = new Guid("661a30f3-efe5-4474-73b9-08dbb62985d7"),
                            CarryDate = new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Completed = false,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DemandId = new Guid("5145dd9c-b73e-4b8b-0100-08dbb5b79e8a"),
                            FirmId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Note = "Yola çıkmadan önce müşteri aranacak.",
                            ReservationDate = new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b")
                        },
                        new
                        {
                            ReservationId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            CarryDate = new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Completed = false,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DemandId = new Guid("5145dd9c-b73e-4b8b-0100-08dbb5b79e8a"),
                            FirmId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            Note = "10 bin tl ye anlaşıldı.",
                            ReservationDate = new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b")
                        });
                });

            modelBuilder.Entity("Atomicy.Domain.Entities.DemandConversation", b =>
                {
                    b.HasOne("Atomicy.Domain.Entities.Demand", null)
                        .WithMany("DemandConversations")
                        .HasForeignKey("DemandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Atomicy.Domain.Entities.FirmComment", b =>
                {
                    b.HasOne("Atomicy.Domain.Entities.Firm", "Firm")
                        .WithMany()
                        .HasForeignKey("FirmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Atomicy.Domain.Entities.FirmVehicle", b =>
                {
                    b.HasOne("Atomicy.Domain.Entities.Firm", "Firm")
                        .WithMany()
                        .HasForeignKey("FirmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Atomicy.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Atomicy.Domain.Entities.Demand", "Demand")
                        .WithMany()
                        .HasForeignKey("DemandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Atomicy.Domain.Entities.Firm", "Firm")
                        .WithMany()
                        .HasForeignKey("FirmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
