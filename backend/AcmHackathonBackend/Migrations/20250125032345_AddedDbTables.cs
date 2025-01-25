using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AcmHackathonBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedDbTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUpcoming = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Executives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Hackathon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DemoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GithubLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventPrizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Reward = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPrizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventPrizes_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRules_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSchedules_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventSponsors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSponsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSponsors_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventVenues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MapLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVenues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventVenues_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExecutiveSocialLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExecutiveId = table.Column<int>(type: "int", nullable: false),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Github = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutiveSocialLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExecutiveSocialLinks_Executives_ExecutiveId",
                        column: x => x.ExecutiveId,
                        principalTable: "Executives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFeatures_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTechnologies_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrizeBenefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventPrizeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrizeBenefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrizeBenefits_EventPrizes_EventPrizeId",
                        column: x => x.EventPrizeId,
                        principalTable: "EventPrizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventScheduleId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleActivities_EventSchedules_EventScheduleId",
                        column: x => x.EventScheduleId,
                        principalTable: "EventSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Executives",
                columns: new[] { "Id", "CreatedAt", "Department", "Description", "Image", "Name", "Role", "UpdatedAt", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(8611), "Computer Science", "Leading ACM's vision for innovative hackathons and tech events. Passionate about creating inclusive tech communities and fostering innovation through collaborative events.", "https://media-hosting.imagekit.io//9e88ccb922834e77/president.png", "Anas Raza", "President", null, "Final Year" },
                    { 2, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(8616), "Computer Science", "Managing internal operations and coordinating with different departments to ensure smooth execution of ACM initiatives.", "https://media-hosting.imagekit.io//4d6ac4d0ee2642d5/vp-internal.png", "Farwa Toor", "VP Internal", null, "Final Year" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "DemoLink", "Description", "GithubLink", "Hackathon", "Image", "IsFeatured", "Status", "Team", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 25, 3, 23, 45, 23, DateTimeKind.Utc).AddTicks(9326), "https://demo.healthtech.com", "An intelligent healthcare assistant that uses machine learning to provide personalized medical advice and symptom analysis.", "https://github.com/healthtech/ai-assistant", "AI Innovation Hackathon 2024", "https://images.unsplash.com/photo-1576091160399-112ba8d25d1d", true, "Winner", "HealthTech Innovators", "AI-Powered Healthcare Assistant", null },
                    { 2, new DateTime(2025, 1, 25, 3, 23, 45, 23, DateTimeKind.Utc).AddTicks(9517), "https://demo.smartcity.io", "A comprehensive platform for monitoring and optimizing city resources using IoT sensors and blockchain technology.", "https://github.com/ecotech/smart-city", "Web3 Development Challenge 2024", "https://images.unsplash.com/photo-1480714378408-67cf0d13bc1b", true, "Runner Up", "EcoTech Solutions", "Sustainable Smart City Platform", null },
                    { 3, new DateTime(2025, 1, 25, 3, 23, 45, 23, DateTimeKind.Utc).AddTicks(9519), "https://demo.educhain.io", "A blockchain-based platform for verifiable credentials and peer-to-peer learning.", "https://github.com/educhain/platform", "Web3 Development Challenge 2024", "https://images.unsplash.com/photo-1501504905252-473c47e087f8", false, "Completed", "EduChain", "Decentralized Education Platform", null }
                });

            migrationBuilder.InsertData(
                table: "ExecutiveSocialLinks",
                columns: new[] { "Id", "CreatedAt", "ExecutiveId", "Github", "LinkedIn", "Twitter", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(9852), 1, "https://github.com/sarahchen", "https://linkedin.com/in/sarahchen", "https://twitter.com/sarahchen", null },
                    { 2, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(9854), 2, "https://github.com/farwatoor", "https://linkedin.com/in/farwatoor", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProjectFeatures",
                columns: new[] { "Id", "CreatedAt", "Description", "ProjectId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(6487), "Real-time symptom analysis", 1, null },
                    { 2, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(6489), "Medical history tracking", 1, null },
                    { 3, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(6491), "Emergency alert system", 1, null },
                    { 4, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(6492), "Integration with healthcare providers", 1, null },
                    { 5, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(6493), "Real-time resource monitoring", 2, null },
                    { 6, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(6494), "Predictive maintenance", 2, null },
                    { 7, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(6495), "Citizen engagement portal", 2, null },
                    { 8, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(6495), "Blockchain-based voting system", 2, null }
                });

            migrationBuilder.InsertData(
                table: "ProjectTechnologies",
                columns: new[] { "Id", "CreatedAt", "Name", "ProjectId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(5139), "Python", 1, null },
                    { 2, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(5143), "TensorFlow", 1, null },
                    { 3, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(5144), "React", 1, null },
                    { 4, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(5145), "Node.js", 1, null },
                    { 5, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(5146), "Solidity", 2, null },
                    { 6, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(5146), "React", 2, null },
                    { 7, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(5147), "AWS", 2, null },
                    { 8, new DateTime(2025, 1, 25, 3, 23, 45, 24, DateTimeKind.Utc).AddTicks(5148), "IoT", 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventPrizes_EventId",
                table: "EventPrizes",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRules_EventId",
                table: "EventRules",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_IsUpcoming",
                table: "Events",
                column: "IsUpcoming");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Slug",
                table: "Events",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventSchedules_EventId",
                table: "EventSchedules",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSponsors_EventId",
                table: "EventSponsors",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVenues_EventId",
                table: "EventVenues",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Executives_Role",
                table: "Executives",
                column: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveSocialLinks_ExecutiveId",
                table: "ExecutiveSocialLinks",
                column: "ExecutiveId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrizeBenefits_EventPrizeId",
                table: "PrizeBenefits",
                column: "EventPrizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFeatures_ProjectId",
                table: "ProjectFeatures",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IsFeatured",
                table: "Projects",
                column: "IsFeatured");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechnologies_ProjectId",
                table: "ProjectTechnologies",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleActivities_EventScheduleId",
                table: "ScheduleActivities",
                column: "EventScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventRules");

            migrationBuilder.DropTable(
                name: "EventSponsors");

            migrationBuilder.DropTable(
                name: "EventVenues");

            migrationBuilder.DropTable(
                name: "ExecutiveSocialLinks");

            migrationBuilder.DropTable(
                name: "PrizeBenefits");

            migrationBuilder.DropTable(
                name: "ProjectFeatures");

            migrationBuilder.DropTable(
                name: "ProjectTechnologies");

            migrationBuilder.DropTable(
                name: "ScheduleActivities");

            migrationBuilder.DropTable(
                name: "Executives");

            migrationBuilder.DropTable(
                name: "EventPrizes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "EventSchedules");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
