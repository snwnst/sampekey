using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sampekey.Migrations
{
    public partial class CreateMultiSystemsPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_ENVIROMENT",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ENVIROMENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_PERMISSION",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateRegister = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PERMISSION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_SYSTEM",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SYSTEM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                columns: table => new
                {
                    KingdomId = table.Column<string>(nullable: false),
                    CastleId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    PermissionId = table.Column<string>(nullable: false),
                    Value = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION", x => new { x.KingdomId, x.CastleId, x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_T_SYSTEM_CastleId",
                        column: x => x.CastleId,
                        principalTable: "T_SYSTEM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_T_ENVIROMENT_KingdomId",
                        column: x => x.KingdomId,
                        principalTable: "T_ENVIROMENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_T_PERMISSION_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "T_PERMISSION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_T_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "T_ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_CastleId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                column: "CastleId");

            migrationBuilder.CreateIndex(
                name: "IX_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_PermissionId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_RoleId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION");

            migrationBuilder.DropTable(
                name: "T_SYSTEM");

            migrationBuilder.DropTable(
                name: "T_ENVIROMENT");

            migrationBuilder.DropTable(
                name: "T_PERMISSION");
        }
    }
}
