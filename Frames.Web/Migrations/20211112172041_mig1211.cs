using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frames.Web.Migrations
{
    public partial class mig1211 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "AdminBillFrameTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "AdminBillFrameTypes");
        }
    }
}
