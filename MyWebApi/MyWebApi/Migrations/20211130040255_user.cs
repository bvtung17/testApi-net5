using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApi.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayDat",
                table: "DonHang",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 30, 11, 2, 54, 706, DateTimeKind.Local).AddTicks(9625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 29, 14, 48, 45, 871, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayDat",
                table: "DonHang",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 29, 14, 48, 45, 871, DateTimeKind.Local).AddTicks(5589),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 30, 11, 2, 54, 706, DateTimeKind.Local).AddTicks(9625));
        }
    }
}
