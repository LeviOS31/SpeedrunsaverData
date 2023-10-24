using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Usertokes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_userId",
                table: "UserTokens",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTokens");
        }
    }
}
