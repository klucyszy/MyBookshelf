using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Elibrary.Data.Migrations
{
    public partial class SeedFavBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Category", "CreateDate", "CreatedBy", "ISBN", "Title", "UpdateDate", "UpdatedBy" },
                values: new object[] { 1, "David Allen", 7, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", "ISBN-1", "Gettings Things Done", null, null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Category", "CreateDate", "CreatedBy", "ISBN", "Title", "UpdateDate", "UpdatedBy" },
                values: new object[] { 2, "Charles Duhigg", 7, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", "ISBN-2", "Siła Nawyku", null, null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Category", "CreateDate", "CreatedBy", "ISBN", "Title", "UpdateDate", "UpdatedBy" },
                values: new object[] { 3, "Daniel Kahneman", 7, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", "ISBN-3", "Pułapki Myślenia", null, null });

            migrationBuilder.InsertData(
                table: "UserFavoriteBooks",
                columns: new[] { "Id", "BookId", "Comment", "CreateDate", "CreatedBy", "Rate", "UpdateDate", "UpdatedBy", "UserId" },
                values: new object[] { 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, null, 2 });

            migrationBuilder.InsertData(
                table: "UserFavoriteBooks",
                columns: new[] { "Id", "BookId", "Comment", "CreateDate", "CreatedBy", "Rate", "UpdateDate", "UpdatedBy", "UserId" },
                values: new object[] { 2, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, null, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserFavoriteBooks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserFavoriteBooks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
