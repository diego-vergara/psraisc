using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradora",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dv = table.Column<string>(maxLength: 1, nullable: true),
                    Nombre = table.Column<string>(maxLength: 120, nullable: true),
                    Rut = table.Column<int>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fondo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdministradoraId = table.Column<long>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 20, nullable: true),
                    RazonSocial = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fondo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fondo_Administradora_AdministradoraId",
                        column: x => x.AdministradoraId,
                        principalTable: "Administradora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fondo_AdministradoraId",
                table: "Fondo",
                column: "AdministradoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fondo");

            migrationBuilder.DropTable(
                name: "Administradora");
        }
    }
}
