using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AcmHackathonBackend.Migrations
{
    /// <inheritdoc />
    public partial class dd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedAt", "Date", "Description", "FullDescription", "Image", "IsUpcoming", "Slug", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create cutting-edge AI solutions", "Join us for an exciting 48-hour hackathon focused on artificial intelligence and machine learning innovations. This event brings together developers, data scientists, and AI enthusiasts to create groundbreaking solutions.", "https://images.unsplash.com/photo-1540575467063-178a50c2df87", true, "ai-innovation-hackathon-2024", "AI Innovation Hackathon", null },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blockchain and DApp development", "A groundbreaking hackathon focused on Web3 technologies and blockchain development. Participants created innovative decentralized applications and smart contracts.", "https://images.unsplash.com/photo-1591115765373-5207764f72e7", false, "web3-development-challenge-2024", "Web3 Development Challenge", null }
                });

            migrationBuilder.InsertData(
                table: "Executives",
                columns: new[] { "Id", "CreatedAt", "Department", "Description", "Image", "Name", "Role", "UpdatedAt", "Year" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "Overseeing administrative tasks and maintaining effective communication between members and the executive council.", "https://media-hosting.imagekit.io//44e64f2b582f4dc0/secatary.png", "Nauman Asif", "General Secretary", null, "Final Year" },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "Managing financial operations and ensuring efficient allocation of resources for ACM activities and events.", "https://media-hosting.imagekit.io//37bc8bb9aff24dfe/treasurer.png", "Nadir Hussain", "Treasurer", null, "Final Year" }
                });

            migrationBuilder.InsertData(
                table: "EventPrizes",
                columns: new[] { "Id", "CreatedAt", "EventId", "Place", "Reward", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "1st Place", "$5000", null },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "2nd Place", "$3000", null },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "3rd Place", "$1000", null }
                });

            migrationBuilder.InsertData(
                table: "EventRules",
                columns: new[] { "Id", "CreatedAt", "Description", "EventId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teams must consist of 2-4 members", 1, null },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "All code must be written during the hackathon", 1, null },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Use of open-source libraries is allowed", 1, null },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Projects must incorporate AI/ML components", 1, null }
                });

            migrationBuilder.InsertData(
                table: "EventSchedules",
                columns: new[] { "Id", "CreatedAt", "Day", "EventId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Day 1", 1, null },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Day 2", 1, null }
                });

            migrationBuilder.InsertData(
                table: "EventSponsors",
                columns: new[] { "Id", "CreatedAt", "EventId", "Logo", "Name", "UpdatedAt", "Website" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://example.com/techcorp-logo.png", "TechCorp", null, "https://techcorp.com" },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://example.com/ai-solutions-logo.png", "AI Solutions", null, "https://aisolutions.com" }
                });

            migrationBuilder.InsertData(
                table: "EventVenues",
                columns: new[] { "Id", "Address", "CreatedAt", "EventId", "MapLink", "Name", "UpdatedAt" },
                values: new object[] { 1, "123 Innovation Street, Silicon Valley, CA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://maps.google.com/", "Tech Innovation Center", null });

            migrationBuilder.InsertData(
                table: "ExecutiveSocialLinks",
                columns: new[] { "Id", "CreatedAt", "ExecutiveId", "Github", "LinkedIn", "Twitter", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "https://github.com/naumanasif", "https://linkedin.com/in/naumanasif", null, null },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "https://github.com/nadirhussain", "https://linkedin.com/in/nadirhussain", null, null }
                });

            migrationBuilder.InsertData(
                table: "PrizeBenefits",
                columns: new[] { "Id", "CreatedAt", "Description", "EventPrizeId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Direct interview with tech partners", 1, null },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-year AI cloud credits", 1, null },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6-month AI cloud credits", 2, null },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-month AI cloud credits", 3, null }
                });

            migrationBuilder.InsertData(
                table: "ScheduleActivities",
                columns: new[] { "Id", "Activity", "CreatedAt", "EventScheduleId", "Time", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Opening Ceremony", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "09:00 AM", null },
                    { 2, "Team Formation", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "10:00 AM", null },
                    { 3, "Hacking Begins", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "11:00 AM", null },
                    { 4, "Project Submissions", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "02:00 PM", null },
                    { 5, "Presentations", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "04:00 PM", null },
                    { 6, "Awards Ceremony", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "06:00 PM", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventRules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventRules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventRules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EventRules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EventSponsors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventSponsors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventVenues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExecutiveSocialLinks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExecutiveSocialLinks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PrizeBenefits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PrizeBenefits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PrizeBenefits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PrizeBenefits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ScheduleActivities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ScheduleActivities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ScheduleActivities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ScheduleActivities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ScheduleActivities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ScheduleActivities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EventPrizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventPrizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventPrizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EventSchedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventSchedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Executives",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Executives",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
