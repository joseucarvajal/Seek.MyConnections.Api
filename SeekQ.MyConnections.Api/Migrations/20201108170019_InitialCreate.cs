using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeekQ.MyConnections.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false),
                    ConnectionNickName = table.Column<string>(maxLength: 20, nullable: false),
                    ConnectionFirstName = table.Column<string>(maxLength: 50, nullable: false),
                    ConnectionIsFirstNameVisible = table.Column<bool>(nullable: false),
                    ConnectionLastName = table.Column<string>(maxLength: 50, nullable: false),
                    ConnectionIsLastNameVisible = table.Column<bool>(nullable: false),
                    ConnectionAge = table.Column<int>(maxLength: 3, nullable: false),
                    ConnectionIsAgeVisible = table.Column<bool>(nullable: false),
                    ConnectionAvatar = table.Column<string>(maxLength: 50, nullable: false),
                    ConnectionIsAvatar = table.Column<bool>(nullable: false),
                    ConnectionUserId = table.Column<Guid>(nullable: false),
                    Blocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Connections_IdUser_ConnectionUserId",
                table: "Connections",
                columns: new[] { "IdUser", "ConnectionUserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connections");
        }
    }
}
