using Microsoft.EntityFrameworkCore.Migrations;

namespace MissingPersonsRegistry.Data.Migrations
{
    public partial class Add_imgage_to_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Persons",
                type: "nvarchar(400)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Persons");
        }
    }
}
