using Microsoft.EntityFrameworkCore.Migrations;

namespace LordOfLittleComponents.Migrations
{
    public partial class thirdOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Teste",
                table: "TemperatureAndHumidity",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Teste",
                table: "TemperatureAndHumidity");
        }
    }
}
