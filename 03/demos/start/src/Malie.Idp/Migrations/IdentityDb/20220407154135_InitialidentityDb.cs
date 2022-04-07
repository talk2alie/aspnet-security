using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Malie.Idp.Migrations.IdentityDb
{
    public partial class InitialidentityDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Subject = table.Column<string>(maxLength: 200, nullable: false),
                    UserName = table.Column<string>(maxLength: 200, nullable: true),
                    Password = table.Column<string>(maxLength: 200, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 250, nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Password", "Subject", "UserName" },
                values: new object[] { new Guid("ad23ce84-d9f8-4135-ab35-a8d03a831819"), true, "8a74278e-f308-4b12-99a7-1b50c0aac571", "Ali$@", "b7539694-97e7-4dfe-84da-b4256e1ff5c7", "alisa" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Password", "Subject", "UserName" },
                values: new object[] { new Guid("0adf529e-92eb-47bd-ba32-a6dc55589fc0"), true, "c509cb6c-ebaf-4d2a-b5ff-ea791d127927", "K@dij@", "d860efca-22d9-47fd-8249-791ba61b07c7", "kadija" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("9c9a4ced-cc05-4115-867d-1ebc6894c89f"), "c9c49fcf-d384-4b5f-9799-d9a3ccc3a69c", "given_name", new Guid("ad23ce84-d9f8-4135-ab35-a8d03a831819"), "Alisa" },
                    { new Guid("a663b155-3d53-4f6f-ad93-4f48498cfd74"), "d33fb3fd-4c04-4191-95fe-91845569786b", "family_name", new Guid("ad23ce84-d9f8-4135-ab35-a8d03a831819"), "Pussah" },
                    { new Guid("13c85610-335e-47d0-9382-b17b7b2f997a"), "fe00bb8f-4823-4d77-bc18-86542ccf07f9", "address", new Guid("ad23ce84-d9f8-4135-ab35-a8d03a831819"), "2220 S 66th Street, Norwood, Essignton EX 11001" },
                    { new Guid("0e0bd892-53da-4544-a7df-ca3b597e1fb1"), "9b994bce-2368-4aa6-b9a9-1fbaf1af6dee", "role", new Guid("ad23ce84-d9f8-4135-ab35-a8d03a831819"), "FreeUser" },
                    { new Guid("02689ed8-a008-40bb-b943-dd3d822bff72"), "a12a49fb-621f-4881-8dcd-cd2a561c1a33", "subscriptionlevel", new Guid("ad23ce84-d9f8-4135-ab35-a8d03a831819"), "FreeUser" },
                    { new Guid("e6a0e4a0-c60a-43dd-ab1d-1efa7dc27249"), "9c1d66f2-b41d-409b-a574-d25609bf5e4f", "country", new Guid("ad23ce84-d9f8-4135-ab35-a8d03a831819"), "us" },
                    { new Guid("cfe0c4d4-b14e-4cab-bf36-0feee7bbf582"), "746c1502-e395-4bd6-ae2d-a2c3522f26dc", "given_name", new Guid("0adf529e-92eb-47bd-ba32-a6dc55589fc0"), "Kadija" },
                    { new Guid("bbc52e08-f304-488b-bf67-09aeb93661e8"), "9e792d9b-9f93-4450-81f8-67eaa55906fc", "family_name", new Guid("0adf529e-92eb-47bd-ba32-a6dc55589fc0"), "Pussah" },
                    { new Guid("c4a53a33-2e61-4107-873c-d479a71cb416"), "8ca0e43d-9c61-468e-a6b3-288c515fce6b", "address", new Guid("0adf529e-92eb-47bd-ba32-a6dc55589fc0"), "2220 S 66th Street, Norwood, Essignton EX 11001" },
                    { new Guid("7ff64692-7a36-4b1e-95e4-da64b7585609"), "54a5bd94-5651-479e-9bc8-dc489bd76d60", "role", new Guid("0adf529e-92eb-47bd-ba32-a6dc55589fc0"), "PayingUser" },
                    { new Guid("7eb84ff9-3729-4b8e-83f5-fefb5109a2fb"), "052392b7-08df-4a02-b603-54f81f454f30", "subscriptionlevel", new Guid("0adf529e-92eb-47bd-ba32-a6dc55589fc0"), "PayingUser" },
                    { new Guid("8920b60c-5c0a-4864-bb94-425aecbf1e14"), "dbbd24ea-022a-429f-8a91-3d12fce37458", "country", new Guid("0adf529e-92eb-47bd-ba32-a6dc55589fc0"), "be" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Subject",
                table: "Users",
                column: "Subject",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
