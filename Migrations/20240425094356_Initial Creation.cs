using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserInterestLinks",
                columns: table => new
                {
                    UserInterestLinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    InterestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterestLinks", x => x.UserInterestLinkID);
                    table.ForeignKey(
                        name: "FK_UserInterestLinks_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInterestLinks_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserInterestLinkID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkID);
                    table.ForeignKey(
                        name: "FK_Links_UserInterestLinks_UserInterestLinkID",
                        column: x => x.UserInterestLinkID,
                        principalTable: "UserInterestLinks",
                        principalColumn: "UserInterestLinkID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestID", "Description", "Title" },
                values: new object[,]
                {
                    { 100, "Playing video games", "Gaming" },
                    { 101, "Any type of exercise like running, sports or gym", "Exercise" },
                    { 102, "Reading books", "Reading" },
                    { 103, "Following the different football leauges in Europe", "Football" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { 1, "1234567", "Noah" },
                    { 2, "1234567", "Simon" },
                    { 3, "1234567", "Casper" },
                    { 4, "1234567", "Svante" }
                });

            migrationBuilder.InsertData(
                table: "UserInterestLinks",
                columns: new[] { "UserInterestLinkID", "InterestID", "UserID" },
                values: new object[,]
                {
                    { 1, 100, 1 },
                    { 2, 102, 2 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkID", "URL", "UserInterestLinkID" },
                values: new object[,]
                {
                    { 50, "www.youtube.com", 1 },
                    { 51, "www.transfermarkt.com", 1 },
                    { 52, "www.books.com", 2 },
                    { 53, "www.running.com", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_UserInterestLinkID",
                table: "Links",
                column: "UserInterestLinkID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterestLinks_InterestID",
                table: "UserInterestLinks",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterestLinks_UserID",
                table: "UserInterestLinks",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "UserInterestLinks");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
