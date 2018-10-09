using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SquashBox.Data.Migrations
{
    public partial class addAppointmentsandProdSelectedforAppointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagName",
                table: "SpecialTags",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ShadeColor",
                table: "Products",
                newName: "CustomText");

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppointmentDate = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerPhoneNumber = table.Column<string>(nullable: true),
                    CustomerEmail = table.Column<string>(nullable: true),
                    isConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSelectedForAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppointmentId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSelectedForAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSelectedForAppointment_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSelectedForAppointment_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSelectedForAppointment_AppointmentId",
                table: "ProductSelectedForAppointment",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSelectedForAppointment_ProductId",
                table: "ProductSelectedForAppointment",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSelectedForAppointment");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SpecialTags",
                newName: "TagName");

            migrationBuilder.RenameColumn(
                name: "CustomText",
                table: "Products",
                newName: "ShadeColor");
        }
    }
}
