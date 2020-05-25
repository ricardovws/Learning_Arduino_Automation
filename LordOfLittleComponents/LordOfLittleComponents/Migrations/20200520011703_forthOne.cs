using Microsoft.EntityFrameworkCore.Migrations;

namespace LordOfLittleComponents.Migrations
{
    public partial class forthOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Teste",
                table: "TemperatureAndHumidity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Teste",
                table: "TemperatureAndHumidity",
                nullable: false,
                defaultValue: 0);
        }
    }
}
