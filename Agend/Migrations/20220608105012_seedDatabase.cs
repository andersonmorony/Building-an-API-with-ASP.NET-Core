using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agend.Migrations
{
    public partial class seedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agends_Peoples_PeopleId",
                table: "Agends");

            migrationBuilder.DropForeignKey(
                name: "FK_Agends_ServiceTypes_ServiceTypeId",
                table: "Agends");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTypeId",
                table: "Agends",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PeopleId",
                table: "Agends",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Peoples",
                columns: new[] { "Id", "Firstname", "Lastname" },
                values: new object[] { 1, "Anderson", "Ramos" });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[] { 1, true, "Depilation" });

            migrationBuilder.InsertData(
                table: "Agends",
                columns: new[] { "Id", "Day", "PeopleId", "ServiceTypeId" },
                values: new object[] { 1, new DateTime(2022, 6, 8, 7, 50, 11, 565, DateTimeKind.Local).AddTicks(60), 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Agends_Peoples_PeopleId",
                table: "Agends",
                column: "PeopleId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agends_ServiceTypes_ServiceTypeId",
                table: "Agends",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agends_Peoples_PeopleId",
                table: "Agends");

            migrationBuilder.DropForeignKey(
                name: "FK_Agends_ServiceTypes_ServiceTypeId",
                table: "Agends");

            migrationBuilder.DeleteData(
                table: "Agends",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Peoples",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTypeId",
                table: "Agends",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PeopleId",
                table: "Agends",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Agends_Peoples_PeopleId",
                table: "Agends",
                column: "PeopleId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agends_ServiceTypes_ServiceTypeId",
                table: "Agends",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
