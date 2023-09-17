using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atomicy.Persistence.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Demands_DemandTypeId",
                table: "Demands",
                column: "DemandTypeId");

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
        }
    }
}
