using Microsoft.EntityFrameworkCore.Migrations;

namespace LordOfLittleComponents.Migrations
{
    public partial class onemore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status_Enum",
                table: "Commands",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status_Enum",
                table: "Commands");
        }
    }
}
