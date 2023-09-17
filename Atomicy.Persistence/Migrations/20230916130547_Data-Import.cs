using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atomicy.Persistence.Migrations
{
    public partial class DataImport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
           name: "DemandTypes",
           columns: table => new
           {
               DemandTypeId = table.Column<Guid>(nullable: false),
               CreatedBy = table.Column<string>(nullable: true),
               CreatedDate = table.Column<DateTime>(nullable: false),
               LastModifiedBy = table.Column<string>(nullable: true),
               LastModifiedDate = table.Column<DateTime>(nullable: true),
               Name = table.Column<string>(nullable: true)
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_DemandTypes", x => x.DemandTypeId);
           });

            migrationBuilder.CreateTable(
                name: "Demands",
                columns: table => new
                {
                    DemandId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    DemandTypeId = table.Column<Guid>(nullable: false),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    DemandDate = table.Column<DateTime>(nullable: false),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demands", x => x.DemandId);
                });

            migrationBuilder.CreateTable(
               name: "DemandConversation",
               columns: table => new
               {
                   DemandConversationId = table.Column<Guid>(nullable: false),
                   CreatedBy = table.Column<string>(nullable: true),
                   CreatedDate = table.Column<DateTime>(nullable: false),
                   LastModifiedBy = table.Column<string>(nullable: true),
                   LastModifiedDate = table.Column<DateTime>(nullable: true),
                   DemandId = table.Column<Guid>(nullable: false),
                   FirmId = table.Column<Guid>(nullable: false),
                   UserId = table.Column<Guid>(nullable: false),
                   FirmMessage = table.Column<string>(nullable: true),
                   CustomerMessage = table.Column<string>(nullable: true),
                   Read = table.Column<bool>(nullable: false),
                   Date = table.Column<DateTime>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_DemandConversation", x => x.DemandConversationId);
                   table.ForeignKey(
                       name: "FK_DemandConversation_Demands_DemandId",
                       column: x => x.DemandId,
                       principalTable: "Demands",
                       principalColumn: "DemandId",
                       onDelete: ReferentialAction.Cascade);
               });

            migrationBuilder.CreateIndex(
                name: "IX_DemandConversation_DemandId",
                table: "DemandConversation",
                column: "DemandId");

            migrationBuilder.CreateTable(
                name: "Firms",
                columns: table => new
                {
                    FirmId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    FirmName = table.Column<string>(nullable: true),
                    VanCount = table.Column<int>(nullable: false),
                    TruckCount = table.Column<int>(nullable: false),
                    BigTruckCount = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firms", x => x.FirmId);
                });

            migrationBuilder.CreateTable(
                name: "FirmComments",
                columns: table => new
                {
                    FirmCommentId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    FirmId = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmComments", x => x.FirmCommentId);
                    table.ForeignKey(
                        name: "FK_FirmComments_Firms_FirmId",
                        column: x => x.FirmId,
                        principalTable: "Firms",
                        principalColumn: "FirmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FirmVehicles",
                columns: table => new
                {
                    FirmVehicleId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    FirmId = table.Column<Guid>(nullable: false),
                    Plate = table.Column<string>(nullable: true),
                    DriverName = table.Column<string>(nullable: true),
                    DriverExperience = table.Column<int>(nullable: false),
                    DriverNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmVehicles", x => x.FirmVehicleId);
                    table.ForeignKey(
                        name: "FK_FirmVehicles_Firms_FirmId",
                        column: x => x.FirmId,
                        principalTable: "Firms",
                        principalColumn: "FirmId",
                        onDelete: ReferentialAction.Cascade);
                });



            migrationBuilder.CreateIndex(
                name: "IX_FirmComments_FirmId",
                table: "FirmComments",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_FirmVehicles_FirmId",
                table: "FirmVehicles",
                column: "FirmId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Demands_DemandTypes_DemandTypeId",
            //    table: "Demands",
            //    column: "DemandTypeId",
            //    principalTable: "DemandTypes",
            //    principalColumn: "DemandTypeId",
            //    onDelete: ReferentialAction.Cascade);
            migrationBuilder.CreateTable(
            name: "Reservations",
            columns: table => new
            {
                ReservationId = table.Column<Guid>(nullable: false),
                CreatedBy = table.Column<string>(nullable: true),
                CreatedDate = table.Column<DateTime>(nullable: false),
                LastModifiedBy = table.Column<string>(nullable: true),
                LastModifiedDate = table.Column<DateTime>(nullable: true),
                DemandId = table.Column<Guid>(nullable: false),
                UserId = table.Column<Guid>(nullable: false),
                FirmId = table.Column<Guid>(nullable: false),
                Note = table.Column<string>(nullable: true),
                ReservationDate = table.Column<DateTime>(nullable: false),
                Completed = table.Column<bool>(nullable: false),
                CarryDate = table.Column<DateTime>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                table.ForeignKey(
                    name: "FK_Reservations_Demands_DemandId",
                    column: x => x.DemandId,
                    principalTable: "Demands",
                    principalColumn: "DemandId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Reservations_Firms_FirmId",
                    column: x => x.FirmId,
                    principalTable: "Firms",
                    principalColumn: "FirmId",
                    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DemandId",
                table: "Reservations",
                column: "DemandId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FirmId",
                table: "Reservations",
                column: "FirmId");

            migrationBuilder.InsertData(
               table: "DemandTypes",
               columns: new[] { "DemandTypeId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
               values: new object[,]
               {
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Evimi Taşı" },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Parça Eşyamı Taşı" },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Ofisimi Taşı" }
               });

            migrationBuilder.InsertData(
                table: "Demands",
                columns: new[] { "DemandId", "Completed", "CreatedBy", "CreatedDate", "DemandDate", "DemandTypeId", "From", "LastModifiedBy", "LastModifiedDate", "Note", "To", "UserId" },
                values: new object[,]
                {
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 23, 22, 26, 339, DateTimeKind.Local).AddTicks(5213), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Bahçelievler", null, null, "Paketlemeyi de sizin yapmanızı istiyorum.", "Halkalı", new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b") },
                    { new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 23, 22, 26, 339, DateTimeKind.Local).AddTicks(5213), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Avcılar", null, null, "Paketlemeyi de sizin yapmanızı istiyorum.", "Bakırköy", new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b") }
                });

            migrationBuilder.InsertData(
                table: "DemandConversation",
                columns: new[] { "DemandConversationId", "CreatedBy", "CreatedDate", "CustomerMessage", "Date", "DemandId", "FirmId", "FirmMessage", "LastModifiedBy", "LastModifiedDate", "Read", "UserId" },
                values: new object[] { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 4, 23, 22, 26, 339, DateTimeKind.Local).AddTicks(5213), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Merhaba 3000 tl ye götürebiliriz.", null, null, false, new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b") });

            migrationBuilder.InsertData(
                table: "DemandConversation",
                columns: new[] { "DemandConversationId", "CreatedBy", "CreatedDate", "CustomerMessage", "Date", "DemandId", "FirmId", "FirmMessage", "LastModifiedBy", "LastModifiedDate", "Read", "UserId" },
                values: new object[] { new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hangi günler musaitsiniz?", new DateTime(2023, 9, 4, 23, 22, 26, 339, DateTimeKind.Local).AddTicks(5213), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, null, null, false, new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b") });

            migrationBuilder.InsertData(
                table: "Firms",
                columns: new[] { "FirmId", "BigTruckCount", "CreatedBy", "CreatedDate", "FirmName", "LastModifiedBy", "LastModifiedDate", "Note", "TruckCount", "VanCount" },
                values: new object[] { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), 10, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstanbul Nakliyat", null, null, "30 yıldır taşımacılık sektöründe faaliyet göstermekteyiz.", 10, 4 });

            migrationBuilder.InsertData(
                table: "Firms",
                columns: new[] { "FirmId", "BigTruckCount", "CreatedBy", "CreatedDate", "FirmName", "LastModifiedBy", "LastModifiedDate", "Note", "TruckCount", "VanCount" },
                values: new object[] { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstanbul Nakliyat", null, null, "10 yıldır müşterilerimize üst düzeyde hizmet vermekteyiz.", 5, 2 });

            migrationBuilder.InsertData(
                table: "FirmComments",
                columns: new[] { "FirmCommentId", "Comment", "CreatedBy", "CreatedDate", "FirmId", "LastModifiedBy", "LastModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), "Eşyalara zarar vermeden paketleme ve taşıma harikaydı. Tavsiye ederim.", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), null, null, new Guid("15efc991-e022-48a1-9394-d398a9fff76f") },
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Çok memnun kalmadım. Tavsiye etmiyorum.", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), null, null, new Guid("15efc991-e022-48a1-9394-d398a9fff76f") }
                });

            migrationBuilder.InsertData(
                table: "FirmVehicles",
                columns: new[] { "FirmVehicleId", "CreatedBy", "CreatedDate", "DriverExperience", "DriverName", "DriverNote", "FirmId", "LastModifiedBy", "LastModifiedDate", "Plate" },
                values: new object[,]
                {
                    { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Melih Gümüş", "Ehliyeti aldığından beri kaza geçirmemiş, deneyimli bir şöfördür.", new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), null, null, "34 DP 524" },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Güven Duman", "Sürücünün ilk yardım belgesi bulunmaktadır.", new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), null, null, "34 HGE 239" },
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Zafer Yener", "Sürücünün ilk yardım belgesi bulunmaktadır.", new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), null, null, "34 PT 6376" },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, "İsmet Yıldırım", "Sürücünün ilk yardım belgesi bulunmaktadır.", new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), null, null, "34 MVR 13" },
                    { new Guid("661a30f3-efe5-4474-73b9-08dbb62985d7"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Hakan Yakın", "Sürücünün ilk yardım belgesi bulunmaktadır.", new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), null, null, "34 DE 147" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CarryDate", "Completed", "CreatedBy", "CreatedDate", "DemandId", "FirmId", "LastModifiedBy", "LastModifiedDate", "Note", "ReservationDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("661a30f3-efe5-4474-73b9-08dbb62985d7"), new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), null, null, "Yola çıkmadan önce müşteri aranacak.", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b") },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"), new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), null, null, "10 bin tl ye anlaşıldı.", new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b") }
                });
        }
      
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FirmComments",
                keyColumn: "FirmCommentId",
                keyValue: new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"));

            migrationBuilder.DeleteData(
                table: "FirmComments",
                keyColumn: "FirmCommentId",
                keyValue: new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"));

            migrationBuilder.DeleteData(
                table: "FirmVehicles",
                keyColumn: "FirmVehicleId",
                keyValue: new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"));

            migrationBuilder.DeleteData(
                table: "FirmVehicles",
                keyColumn: "FirmVehicleId",
                keyValue: new Guid("661a30f3-efe5-4474-73b9-08dbb62985d7"));

            migrationBuilder.DeleteData(
                table: "FirmVehicles",
                keyColumn: "FirmVehicleId",
                keyValue: new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"));

            migrationBuilder.DeleteData(
                table: "FirmVehicles",
                keyColumn: "FirmVehicleId",
                keyValue: new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"));

            migrationBuilder.DeleteData(
                table: "FirmVehicles",
                keyColumn: "FirmVehicleId",
                keyValue: new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("661a30f3-efe5-4474-73b9-08dbb62985d7"));

            migrationBuilder.DeleteData(
                table: "Firms",
                keyColumn: "FirmId",
                keyValue: new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"));

            migrationBuilder.DeleteData(
                table: "Firms",
                keyColumn: "FirmId",
                keyValue: new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"));
        }
    }
}
