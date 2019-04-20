using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreOracle.Migrations
{
    public partial class update_invoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TEST",
                schema: "NETCORE",
                table: "INVOICE",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TEST",
                schema: "NETCORE",
                table: "INVOICE");
        }
    }
}
