using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class FirstMigration_Created_Base_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "ContactForms",
                columns: table => new
                {
                    ContactFormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactFormName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactFormPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactFormEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactFormMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForms", x => x.ContactFormId);
                });

            migrationBuilder.CreateTable(
                name: "HotelAbouts",
                columns: table => new
                {
                    AboutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelAbouts", x => x.AboutId);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationStartDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationEndDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomArea = table.Column<int>(type: "int", nullable: false),
                    RoomPrice = table.Column<int>(type: "int", nullable: false),
                    RoomAbout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomStatus = table.Column<bool>(type: "bit", nullable: false),
                    RoomCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "ContactForms");

            migrationBuilder.DropTable(
                name: "HotelAbouts");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Staffs");
        }
    }
}
