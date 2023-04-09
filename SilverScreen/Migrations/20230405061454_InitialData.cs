using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SilverScreen.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
