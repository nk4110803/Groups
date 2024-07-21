using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Meneger",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Owner",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meneger",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Events");
        }
    }
}
