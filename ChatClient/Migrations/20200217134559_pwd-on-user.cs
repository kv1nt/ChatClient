using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatClient.Migrations
{
    public partial class pwdonuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserTable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserTable");
        }
    }
}
