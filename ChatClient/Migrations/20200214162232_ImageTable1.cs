using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatClient.Migrations
{
    public partial class ImageTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagessTable",
                table: "ImagessTable");

            migrationBuilder.RenameTable(
                name: "ImagessTable",
                newName: "ImagesTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesTable",
                table: "ImagesTable",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesTable",
                table: "ImagesTable");

            migrationBuilder.RenameTable(
                name: "ImagesTable",
                newName: "ImagessTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagessTable",
                table: "ImagessTable",
                column: "Id");
        }
    }
}
