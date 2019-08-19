using Microsoft.EntityFrameworkCore.Migrations;

namespace Sampekey.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_T_SYSTEM_CastleId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION");

            migrationBuilder.DropForeignKey(
                name: "FK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_T_ENVIROMENT_KingdomId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION");

            migrationBuilder.RenameColumn(
                name: "CastleId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                newName: "SystemId");

            migrationBuilder.RenameColumn(
                name: "KingdomId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                newName: "EnviromentId");

            migrationBuilder.RenameIndex(
                name: "IX_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_CastleId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                newName: "IX_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_SystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_T_SYSTEM_SystemId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                column: "SystemId",
                principalTable: "T_SYSTEM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_T_ENVIROMENT_EnviromentId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                column: "EnviromentId",
                principalTable: "T_ENVIROMENT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_T_SYSTEM_SystemId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION");

            migrationBuilder.DropForeignKey(
                name: "FK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_T_ENVIROMENT_EnviromentId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION");

            migrationBuilder.RenameColumn(
                name: "SystemId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                newName: "CastleId");

            migrationBuilder.RenameColumn(
                name: "EnviromentId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                newName: "KingdomId");

            migrationBuilder.RenameIndex(
                name: "IX_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_SystemId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                newName: "IX_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_CastleId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_T_SYSTEM_CastleId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                column: "CastleId",
                principalTable: "T_SYSTEM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_T_ENVIROMENT_KingdomId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                column: "KingdomId",
                principalTable: "T_ENVIROMENT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
