using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SilverScreen.Migrations
{
    public partial class CreatingIdentityTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("411d4b6d-809c-49bb-9c90-b8e260a157fd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4828403c-29e7-4d23-8ad1-7ccb79e68204"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("01834ddc-2c97-4b04-b5af-762a2d27ddf1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0c3515b2-3c40-46e8-9810-04396e67c43f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0ea5f132-6780-42a2-b1d7-1bf4e92447ed"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("14945b09-6df9-4965-a461-91e63620d700"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2cf6e944-8110-43c1-913e-214800a10487"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3ea7c117-f140-4aa4-831d-b84deb9d15e1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("52882a06-5633-4e08-b444-93e4150592af"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5a849d49-a444-4738-b857-5a7c70098246"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5f4660bd-f50b-474a-8869-c4952f1366c7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("64babf59-cbc0-4c56-b6b6-0cf18dcca2e7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("698904c4-8e2c-493e-a526-e7d562532a18"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7199a4f8-a70c-40a5-bf5b-a496fc5b2e28"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7ddfbf82-517c-4883-9720-bfeb294147b6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7e34286b-58b9-4154-b606-1ab241553f98"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8d35702a-db58-49a8-9c52-e4353e490e89"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9505f5a7-2893-4824-b4b9-ee33f2c7638e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9fb3d00e-c6ef-4b8c-a6d9-32d16b38c518"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a483868a-980d-4e7b-bfed-7d95ef159eb5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("bf137eb8-0c91-4b19-a8d9-f59243bac658"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c5b87fa1-4f70-4a0c-86d1-248e26cdf058"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("da6dc3df-b04f-42ef-b8ac-94a4a79eb5dc"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("5d189687-de58-41a6-980b-18ec0e542ba0"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("be2e2aa5-4599-4a55-9d1f-471b17d7561d"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Movies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserLevel = table.Column<int>(type: "int", nullable: false),
                    LevelStartedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LevelEndedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("32d31283-a41d-4ff5-97a4-4a18736dafdd"), "فیلم" },
                    { new Guid("54cc677d-fba3-4806-9124-a2a2925f6125"), "سریال" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05a2607d-bda5-4567-a949-67de069cf923"), "رئالیتی شو" },
                    { new Guid("06bbedbc-d9a0-471d-b1a2-43ab610ee64f"), "علمی تخیلی" },
                    { new Guid("070072b1-42d5-4fbb-a8f9-9336fab15c21"), "عاشقانه" },
                    { new Guid("12057aaa-2af1-45a0-8092-8bf15c7cceef"), "تاریخی" },
                    { new Guid("12d2b823-66d4-440a-8afd-a0f1fdae2e74"), "فانتزی" },
                    { new Guid("16e44c16-e63f-4d80-a069-590067465d01"), "اکشن" },
                    { new Guid("198bf614-780e-4585-b957-a61e5d037673"), "جنگی" },
                    { new Guid("2a0e99ad-721f-473e-8fbb-6fee5c8b25ab"), "جنایی" },
                    { new Guid("2fb1082c-fb71-458d-a17d-9c7ddd278521"), "ترسناک" },
                    { new Guid("4fd3bbb2-45a9-44e8-bbcb-b43a4c1287a9"), "موزیکال" },
                    { new Guid("6205003b-da46-45af-9fc2-bcfbb7afc9bc"), "کمدی" },
                    { new Guid("62560c19-3393-4d22-a7f4-11108310937a"), "زندگی نامه" },
                    { new Guid("6fefbdc0-c716-48eb-8844-6d684023a09b"), "وسترن" },
                    { new Guid("7ed634fc-d323-4061-9a7b-519e624b8bdf"), "ماجراجویی" },
                    { new Guid("80a71835-793a-4955-b592-d6e65bc595b1"), "هیجان اگیز" },
                    { new Guid("82c492ad-8f05-4b9e-b82b-9e980732a2f4"), "انیمیشن" },
                    { new Guid("96cfda25-26f6-4d18-9398-1a40bb9a87a0"), "درام" },
                    { new Guid("98f4d8d7-fb9b-4989-834d-a991acd9b02c"), "مستند" },
                    { new Guid("ae30b149-a039-4ec9-97a6-ac76bba974ac"), "ورزشی" },
                    { new Guid("d5154255-3a5b-47b6-bda4-e4b90fdc35d3"), "خانوادگی" },
                    { new Guid("f90beee7-2b2b-4659-94c8-e65eef69686c"), "معمایی" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("9fcc999d-5efc-4495-8bb9-a89c0c904974"), "", "آلمانی" },
                    { new Guid("f9aecef6-784d-42cf-a294-20c9065cf9ad"), "", "انگلیسی" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("32d31283-a41d-4ff5-97a4-4a18736dafdd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("54cc677d-fba3-4806-9124-a2a2925f6125"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("05a2607d-bda5-4567-a949-67de069cf923"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("06bbedbc-d9a0-471d-b1a2-43ab610ee64f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("070072b1-42d5-4fbb-a8f9-9336fab15c21"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("12057aaa-2af1-45a0-8092-8bf15c7cceef"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("12d2b823-66d4-440a-8afd-a0f1fdae2e74"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("16e44c16-e63f-4d80-a069-590067465d01"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("198bf614-780e-4585-b957-a61e5d037673"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2a0e99ad-721f-473e-8fbb-6fee5c8b25ab"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2fb1082c-fb71-458d-a17d-9c7ddd278521"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4fd3bbb2-45a9-44e8-bbcb-b43a4c1287a9"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6205003b-da46-45af-9fc2-bcfbb7afc9bc"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("62560c19-3393-4d22-a7f4-11108310937a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6fefbdc0-c716-48eb-8844-6d684023a09b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7ed634fc-d323-4061-9a7b-519e624b8bdf"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("80a71835-793a-4955-b592-d6e65bc595b1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("82c492ad-8f05-4b9e-b82b-9e980732a2f4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("96cfda25-26f6-4d18-9398-1a40bb9a87a0"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("98f4d8d7-fb9b-4989-834d-a991acd9b02c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ae30b149-a039-4ec9-97a6-ac76bba974ac"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d5154255-3a5b-47b6-bda4-e4b90fdc35d3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f90beee7-2b2b-4659-94c8-e65eef69686c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("9fcc999d-5efc-4495-8bb9-a89c0c904974"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("f9aecef6-784d-42cf-a294-20c9065cf9ad"));

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("411d4b6d-809c-49bb-9c90-b8e260a157fd"), "فیلم" },
                    { new Guid("4828403c-29e7-4d23-8ad1-7ccb79e68204"), "سریال" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("01834ddc-2c97-4b04-b5af-762a2d27ddf1"), "معمایی" },
                    { new Guid("0c3515b2-3c40-46e8-9810-04396e67c43f"), "هیجان اگیز" },
                    { new Guid("0ea5f132-6780-42a2-b1d7-1bf4e92447ed"), "ماجراجویی" },
                    { new Guid("14945b09-6df9-4965-a461-91e63620d700"), "زندگی نامه" },
                    { new Guid("2cf6e944-8110-43c1-913e-214800a10487"), "کمدی" },
                    { new Guid("3ea7c117-f140-4aa4-831d-b84deb9d15e1"), "خانوادگی" },
                    { new Guid("52882a06-5633-4e08-b444-93e4150592af"), "اکشن" },
                    { new Guid("5a849d49-a444-4738-b857-5a7c70098246"), "جنگی" },
                    { new Guid("5f4660bd-f50b-474a-8869-c4952f1366c7"), "موزیکال" },
                    { new Guid("64babf59-cbc0-4c56-b6b6-0cf18dcca2e7"), "علمی تخیلی" },
                    { new Guid("698904c4-8e2c-493e-a526-e7d562532a18"), "ورزشی" },
                    { new Guid("7199a4f8-a70c-40a5-bf5b-a496fc5b2e28"), "ترسناک" },
                    { new Guid("7ddfbf82-517c-4883-9720-bfeb294147b6"), "انیمیشن" },
                    { new Guid("7e34286b-58b9-4154-b606-1ab241553f98"), "جنایی" },
                    { new Guid("8d35702a-db58-49a8-9c52-e4353e490e89"), "وسترن" },
                    { new Guid("9505f5a7-2893-4824-b4b9-ee33f2c7638e"), "عاشقانه" },
                    { new Guid("9fb3d00e-c6ef-4b8c-a6d9-32d16b38c518"), "فانتزی" },
                    { new Guid("a483868a-980d-4e7b-bfed-7d95ef159eb5"), "تاریخی" },
                    { new Guid("bf137eb8-0c91-4b19-a8d9-f59243bac658"), "درام" },
                    { new Guid("c5b87fa1-4f70-4a0c-86d1-248e26cdf058"), "مستند" },
                    { new Guid("da6dc3df-b04f-42ef-b8ac-94a4a79eb5dc"), "رئالیتی شو" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("5d189687-de58-41a6-980b-18ec0e542ba0"), "", "انگلیسی" },
                    { new Guid("be2e2aa5-4599-4a55-9d1f-471b17d7561d"), "", "آلمانی" }
                });
        }
    }
}
