using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InventoryModule.Migrations
{
    public partial class Ledgers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LedgerGroup",
                columns: table => new
                {
                    LedgerGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LedgerGroupName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerGroup", x => x.LedgerGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Ledger",
                columns: table => new
                {
                    LedgerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 400, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LedgerGroupId = table.Column<int>(nullable: false),
                    LedgerName = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledger", x => x.LedgerId);
                    table.ForeignKey(
                        name: "FK_Ledger_LedgerGroup_LedgerGroupId",
                        column: x => x.LedgerGroupId,
                        principalTable: "LedgerGroup",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_LedgerGroupId",
                table: "Ledger",
                column: "LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_LedgerName",
                table: "Ledger",
                column: "LedgerName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LedgerGroup_LedgerGroupName",
                table: "LedgerGroup",
                column: "LedgerGroupName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ledger");

            migrationBuilder.DropTable(
                name: "LedgerGroup");
        }
    }
}
