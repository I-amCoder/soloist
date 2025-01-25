        using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AcmHackathonBackend.Migrations
{
    /// <inheritdoc />
    public partial class dataupdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedAt", "Date", "Description", "FullDescription", "Image", "IsUpcoming", "Slug", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exploring the future of data science", "A summit bringing together data scientists and industry leaders to discuss the latest trends and innovations in data science.", "https://images.unsplash.com/photo-1517430816045-df4b7de11d1d", false, "data-science-summit-2023", "Data Science Summit", null },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Securing the digital future", "Join experts and enthusiasts in the field of cybersecurity to explore the latest challenges and solutions in protecting digital assets.", "https://images.unsplash.com/photo-1504384308090-c894fdcc538d", true, "cybersecurity-conference-2024", "Cybersecurity Conference", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
