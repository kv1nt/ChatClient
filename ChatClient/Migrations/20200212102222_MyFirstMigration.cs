using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatClient.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessagesTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    RecipientId = table.Column<string>(nullable: true),
                    MessageText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessagesTable");

            migrationBuilder.DropTable(
                name: "UserTable");
        }
    }
}
