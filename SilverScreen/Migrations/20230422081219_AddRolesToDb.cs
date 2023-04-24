using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SilverScreen.Migrations
{
    public partial class AddRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a0c47c40-f010-4da7-bf7c-bb1772a0c45f", "e0ed4887-65e1-4867-aadf-51a469e5156a", "GoldenUser", "GOLDENUSER" },
                    { "b83d673a-b3f9-4e0a-826b-fbd354eb3aeb", "d9c621fd-8c58-46d4-9bc9-edb28305a01a", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("73e8b4d5-016b-4dae-851a-4d4335f9aa8f"), "سریال" },
                    { new Guid("a653e850-eeaf-45f4-9e03-f81e3ac64278"), "فیلم" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("10278de4-b04b-4cf5-af6c-28036f3cc7be"), "تاریخی" },
                    { new Guid("2a08f327-753c-49b8-a507-21d7745cb8ca"), "ماجراجویی" },
                    { new Guid("3cb0336d-c986-409b-85c8-e4f99b56c9c6"), "مستند" },
                    { new Guid("3d84f61b-c1c0-419b-a8e7-9979a537063d"), "فانتزی" },
                    { new Guid("48476c5e-79f9-43a3-9973-d402c63e8ad6"), "جنایی" },
                    { new Guid("4b09b3cd-c550-4e3e-9892-d1ea7fba319b"), "عاشقانه" },
                    { new Guid("4ee6fd25-11d4-41aa-8557-fe75c27292f0"), "کمدی" },
                    { new Guid("5caf13ed-b026-49c1-9cf7-da53b5a81d97"), "زندگی نامه" },
                    { new Guid("74b74e60-05f9-4068-a0b2-9f4ce36594ed"), "خانوادگی" },
                    { new Guid("75fdf7e2-d961-4bfe-ab0c-a151f2b41703"), "جنگی" },
                    { new Guid("8c7a55e8-6413-47c8-a57a-f640976e91b7"), "معمایی" },
                    { new Guid("90bb57ee-81fc-46b2-9fed-6e80711b0ced"), "وسترن" },
                    { new Guid("9977591c-8120-4200-885a-68aeef8d0ee9"), "هیجان اگیز" },
                    { new Guid("9daa5715-2912-43a5-8682-75deac25ba82"), "رئالیتی شو" },
                    { new Guid("a3b1337f-c000-4251-9ae5-ece1d56678cd"), "موزیکال" },
                    { new Guid("af4e8811-1442-42b5-b717-52f47f4824da"), "انیمیشن" },
                    { new Guid("b6617ed6-9b80-42f0-b097-d17aa4c1e6c6"), "علمی تخیلی" },
                    { new Guid("dadd483e-36e3-432d-ad59-2d53ecd9478e"), "ورزشی" },
                    { new Guid("ef8d754e-c05e-4356-8357-cb986c0d19e9"), "ترسناک" },
                    { new Guid("f6942543-0205-48a8-bdd9-88eea9a8fcf9"), "اکشن" },
                    { new Guid("fcfc6e62-a435-4b77-803c-35c7baf29f1a"), "درام" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("5a53220b-2fbd-42fc-adeb-876333e0e155"), "", "انگلیسی" },
                    { new Guid("bbf003ae-7612-43c7-a4c1-798cae797901"), "", "آلمانی" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0c47c40-f010-4da7-bf7c-bb1772a0c45f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b83d673a-b3f9-4e0a-826b-fbd354eb3aeb");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("73e8b4d5-016b-4dae-851a-4d4335f9aa8f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a653e850-eeaf-45f4-9e03-f81e3ac64278"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("10278de4-b04b-4cf5-af6c-28036f3cc7be"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2a08f327-753c-49b8-a507-21d7745cb8ca"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3cb0336d-c986-409b-85c8-e4f99b56c9c6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3d84f61b-c1c0-419b-a8e7-9979a537063d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("48476c5e-79f9-43a3-9973-d402c63e8ad6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4b09b3cd-c550-4e3e-9892-d1ea7fba319b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4ee6fd25-11d4-41aa-8557-fe75c27292f0"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5caf13ed-b026-49c1-9cf7-da53b5a81d97"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("74b74e60-05f9-4068-a0b2-9f4ce36594ed"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("75fdf7e2-d961-4bfe-ab0c-a151f2b41703"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8c7a55e8-6413-47c8-a57a-f640976e91b7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("90bb57ee-81fc-46b2-9fed-6e80711b0ced"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9977591c-8120-4200-885a-68aeef8d0ee9"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9daa5715-2912-43a5-8682-75deac25ba82"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a3b1337f-c000-4251-9ae5-ece1d56678cd"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("af4e8811-1442-42b5-b717-52f47f4824da"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b6617ed6-9b80-42f0-b097-d17aa4c1e6c6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("dadd483e-36e3-432d-ad59-2d53ecd9478e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ef8d754e-c05e-4356-8357-cb986c0d19e9"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f6942543-0205-48a8-bdd9-88eea9a8fcf9"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("fcfc6e62-a435-4b77-803c-35c7baf29f1a"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("5a53220b-2fbd-42fc-adeb-876333e0e155"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("bbf003ae-7612-43c7-a4c1-798cae797901"));

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
        }
    }
}
