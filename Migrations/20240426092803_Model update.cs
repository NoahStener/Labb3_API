using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3_API.Migrations
{
    /// <inheritdoc />
    public partial class Modelupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_UserInterestLinks_UserInterestLinkID",
                table: "Links");

            migrationBuilder.DropTable(
                name: "UserInterestLinks");

            migrationBuilder.RenameColumn(
                name: "UserInterestLinkID",
                table: "Links",
                newName: "UserInterestID");

            migrationBuilder.RenameIndex(
                name: "IX_Links_UserInterestLinkID",
                table: "Links",
                newName: "IX_Links_UserInterestID");

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    UserInterestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    InterestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => x.UserInterestID);
                    table.ForeignKey(
                        name: "FK_UserInterests_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInterests_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestID",
                keyValue: 103,
                column: "Description",
                value: "Watching or playing football");

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "UserInterestID", "InterestID", "UserID" },
                values: new object[,]
                {
                    { 1, 100, 1 },
                    { 2, 102, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_InterestID",
                table: "UserInterests",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_UserID",
                table: "UserInterests",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_UserInterests_UserInterestID",
                table: "Links",
                column: "UserInterestID",
                principalTable: "UserInterests",
                principalColumn: "UserInterestID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_UserInterests_UserInterestID",
                table: "Links");

            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.RenameColumn(
                name: "UserInterestID",
                table: "Links",
                newName: "UserInterestLinkID");

            migrationBuilder.RenameIndex(
                name: "IX_Links_UserInterestID",
                table: "Links",
                newName: "IX_Links_UserInterestLinkID");

            migrationBuilder.CreateTable(
                name: "UserInterestLinks",
                columns: table => new
                {
                    UserInterestLinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestID",
                keyValue: 103,
                column: "Description",
                value: "Following the different football leauges in Europe");

            migrationBuilder.InsertData(
                table: "UserInterestLinks",
                columns: new[] { "UserInterestLinkID", "InterestID", "UserID" },
                values: new object[,]
                {
                    { 1, 100, 1 },
                    { 2, 102, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInterestLinks_InterestID",
                table: "UserInterestLinks",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterestLinks_UserID",
                table: "UserInterestLinks",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_UserInterestLinks_UserInterestLinkID",
                table: "Links",
                column: "UserInterestLinkID",
                principalTable: "UserInterestLinks",
                principalColumn: "UserInterestLinkID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
