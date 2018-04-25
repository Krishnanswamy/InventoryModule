using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InventoryModule.Migrations
{
    public partial class UnitRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitofMeasureRelations",
                columns: table => new
                {
                    UnitofMeasureRelationsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlternateUnitId = table.Column<int>(nullable: false),
                    AlternateUnitValue = table.Column<decimal>(nullable: false),
                    PrimaryUnitId = table.Column<int>(nullable: false),
                    PrimaryUnitValue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitofMeasureRelations", x => x.UnitofMeasureRelationsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitofMeasureRelations");
        }
    }
}
