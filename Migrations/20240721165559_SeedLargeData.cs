using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webScrapperApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedLargeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Scrapers",
                columns: new[] { "ScraperId", "Schedule", "ScraperName", "SourceUrl", "Status" },
                values: new object[,]
                {
                    { 1, "Daily", "Example Scraper 1", "http://example.com", true },
                    { 2, "Weekly", "Example Scraper 2", "http://example2.com", false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "password123", "Administrator", "admin" },
                    { 2, "user@example.com", "password123", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "LogId", "LogLevel", "Message", "ScraperId", "Timestamp" },
                values: new object[,]
                {
                    { 1, "Info", "Scraper started", 1, new DateTime(2024, 7, 21, 16, 55, 58, 757, DateTimeKind.Utc).AddTicks(6208) },
                    { 2, "Warning", "Scraper encountered an issue", 2, new DateTime(2024, 7, 21, 16, 55, 58, 757, DateTimeKind.Utc).AddTicks(6210) }
                });

            migrationBuilder.InsertData(
                table: "ScrapedData",
                columns: new[] { "ScrapedDataId", "ParsedData", "RawData", "ScraperId", "Timestamp" },
                values: new object[,]
                {
                    { 1, "Parsed data 1", "Raw data 1", 1, new DateTime(2024, 7, 21, 16, 55, 58, 757, DateTimeKind.Utc).AddTicks(6227) },
                    { 2, "Parsed data 2", "Raw data 2", 2, new DateTime(2024, 7, 21, 16, 55, 58, 757, DateTimeKind.Utc).AddTicks(6229) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "LogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "LogId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ScrapedData",
                keyColumn: "ScrapedDataId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ScrapedData",
                keyColumn: "ScrapedDataId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Scrapers",
                keyColumn: "ScraperId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scrapers",
                keyColumn: "ScraperId",
                keyValue: 2);
        }
    }
}
