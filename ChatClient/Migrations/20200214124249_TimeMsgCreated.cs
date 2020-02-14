using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatClient.Migrations
{
    public partial class TimeMsgCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeMsgCreated",
                table: "MessagesTable",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeMsgCreated",
                table: "MessagesTable");
        }
    }
}
