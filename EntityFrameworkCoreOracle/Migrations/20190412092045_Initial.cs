using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreOracle.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "NETCORE");

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                schema: "NETCORE",
                columns: table => new
                {
                    CUSTOMERID = table.Column<int>(nullable: false),
                    FIRSTNAME = table.Column<string>(nullable: true),
                    LASTNAME = table.Column<string>(nullable: true),
                    ADDRESS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.CUSTOMERID);
                });

            migrationBuilder.CreateTable(
                name: "INVOICE",
                schema: "NETCORE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    DATE = table.Column<DateTime>(nullable: false),
                    CUSTOMERID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INVOICE_01",
                        column: x => x.CUSTOMERID,
                        principalSchema: "NETCORE",
                        principalTable: "CUSTOMER",
                        principalColumn: "CUSTOMERID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_INVOICE_01",
                schema: "NETCORE",
                table: "INVOICE",
                column: "CUSTOMERID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INVOICE",
                schema: "NETCORE");

            migrationBuilder.DropTable(
                name: "CUSTOMER",
                schema: "NETCORE");
        }
    }
}
