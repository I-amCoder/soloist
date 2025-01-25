using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcmHackathonBackend.Migrations
{
    /// <inheritdoc />
    public partial class dataupdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ExecutiveSocialLinks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Github", "LinkedIn", "Twitter" },
                values: new object[] { "https://github.com/anasraza", "https://linkedin.com/in/anasraza", "https://twitter.com/anasraza" });

            migrationBuilder.UpdateData(
                table: "Executives",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://plus.unsplash.com/premium_photo-1664536392896-cd1743f9c02c?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8cGVyc29ufGVufDB8fDB8fHww");

            migrationBuilder.UpdateData(
                table: "Executives",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://plus.unsplash.com/premium_photo-1690407617542-2f210cf20d7e?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTN8fHBlcnNvbnxlbnwwfHwwfHx8MA%3D%3D");

            migrationBuilder.UpdateData(
                table: "Executives",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://plus.unsplash.com/premium_photo-1689539137236-b68e436248de?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTd8fHBlcnNvbnxlbnwwfHwwfHx8MA%3D%3D");

            migrationBuilder.UpdateData(
                table: "Executives",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://images.unsplash.com/photo-1521566652839-697aa473761a?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fHBlcnNvbnxlbnwwfHwwfHx8MA%3D%3D");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ExecutiveSocialLinks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Github", "LinkedIn", "Twitter" },
                values: new object[] { "https://github.com/sarahchen", "https://linkedin.com/in/sarahchen", "https://twitter.com/sarahchen" });

            migrationBuilder.UpdateData(
                table: "Executives",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://media-hosting.imagekit.io//9e88ccb922834e77/president.png");

            migrationBuilder.UpdateData(
                table: "Executives",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://media-hosting.imagekit.io//4d6ac4d0ee2642d5/vp-internal.png");

            migrationBuilder.UpdateData(
                table: "Executives",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://media-hosting.imagekit.io//44e64f2b582f4dc0/secatary.png");

            migrationBuilder.UpdateData(
                table: "Executives",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://media-hosting.imagekit.io//37bc8bb9aff24dfe/treasurer.png");
        }
    }
}
