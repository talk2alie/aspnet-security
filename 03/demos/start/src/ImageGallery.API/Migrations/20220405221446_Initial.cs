using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageGallery.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("136f358d-98fb-4961-855c-59d5a6d1fa19"),
                column: "OwnerId",
                value: "12345");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("1efe7a31-8dcc-4ff0-9b2d-5f148e2989cc"),
                column: "OwnerId",
                value: "678910");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                column: "OwnerId",
                value: "678910");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("2645bd94-3624-43fc-b21f-1209d730fc71"),
                column: "OwnerId",
                value: "12345");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3f41dc87-e8de-42ee-ac8d-355e4d3e1a2d"),
                column: "OwnerId",
                value: "12345");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5e0e1379-3e8e-4f51-99f1-1fb9ec3a19b0"),
                column: "OwnerId",
                value: "12345");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("939df3fd-de57-4caf-96dc-c5e110322a96"),
                column: "OwnerId",
                value: "678910");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("9f35e705-637a-4bbe-8c35-402b2ecf7128"),
                column: "OwnerId",
                value: "678910");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ab46efdb-0384-400c-89cb-95bba1c500e9"),
                column: "OwnerId",
                value: "12345");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ae03d971-40a6-4350-b8a9-7b12e1d93d71"),
                column: "OwnerId",
                value: "12345");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b24e3df5-0394-468d-9c1d-db1252fea920"),
                column: "OwnerId",
                value: "678910");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ce1d2b1c-7869-4df5-9a32-2cbaca8c3234"),
                column: "OwnerId",
                value: "678910");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d3118665-43e3-4905-8848-5e335a428dd5"),
                column: "OwnerId",
                value: "12345");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d70f656d-75a7-45fc-b385-e4daa834e6a8"),
                column: "OwnerId",
                value: "678910");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("136f358d-98fb-4961-855c-59d5a6d1fa19"),
                column: "OwnerId",
                value: "b7539694-97e7-4dfe-84da-b4256e1ff5c7");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("1efe7a31-8dcc-4ff0-9b2d-5f148e2989cc"),
                column: "OwnerId",
                value: "d860efca-22d9-47fd-8249-791ba61b07c7");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                column: "OwnerId",
                value: "d860efca-22d9-47fd-8249-791ba61b07c7");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("2645bd94-3624-43fc-b21f-1209d730fc71"),
                column: "OwnerId",
                value: "b7539694-97e7-4dfe-84da-b4256e1ff5c7");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3f41dc87-e8de-42ee-ac8d-355e4d3e1a2d"),
                column: "OwnerId",
                value: "b7539694-97e7-4dfe-84da-b4256e1ff5c7");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5e0e1379-3e8e-4f51-99f1-1fb9ec3a19b0"),
                column: "OwnerId",
                value: "b7539694-97e7-4dfe-84da-b4256e1ff5c7");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("939df3fd-de57-4caf-96dc-c5e110322a96"),
                column: "OwnerId",
                value: "d860efca-22d9-47fd-8249-791ba61b07c7");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("9f35e705-637a-4bbe-8c35-402b2ecf7128"),
                column: "OwnerId",
                value: "d860efca-22d9-47fd-8249-791ba61b07c7");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ab46efdb-0384-400c-89cb-95bba1c500e9"),
                column: "OwnerId",
                value: "b7539694-97e7-4dfe-84da-b4256e1ff5c7");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ae03d971-40a6-4350-b8a9-7b12e1d93d71"),
                column: "OwnerId",
                value: "b7539694-97e7-4dfe-84da-b4256e1ff5c7");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b24e3df5-0394-468d-9c1d-db1252fea920"),
                column: "OwnerId",
                value: "d860efca-22d9-47fd-8249-791ba61b07c7");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ce1d2b1c-7869-4df5-9a32-2cbaca8c3234"),
                column: "OwnerId",
                value: "d860efca-22d9-47fd-8249-791ba61b07c7");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d3118665-43e3-4905-8848-5e335a428dd5"),
                column: "OwnerId",
                value: "b7539694-97e7-4dfe-84da-b4256e1ff5c7");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d70f656d-75a7-45fc-b385-e4daa834e6a8"),
                column: "OwnerId",
                value: "d860efca-22d9-47fd-8249-791ba61b07c7");
        }
    }
}
