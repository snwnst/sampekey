using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sampekey.Migrations
{
    public partial class InitialCreate : Migration
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
                name: "T_ROLE",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ROLE", x => x.Id);
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
                name: "T_USER",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_ROLE_CLAIM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ROLE_CLAIM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_ROLE_CLAIM_T_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "T_ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                columns: table => new
                {
                    EnviromentId = table.Column<string>(nullable: false),
                    SystemId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    PermissionId = table.Column<string>(nullable: false),
                    Value = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION", x => new { x.EnviromentId, x.SystemId, x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_T_SYSTEM_SystemId",
                        column: x => x.SystemId,
                        principalTable: "T_SYSTEM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_T_ENVIROMENT_EnviromentId",
                        column: x => x.EnviromentId,
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

            migrationBuilder.CreateTable(
                name: "T_USER_CLAIM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USER_CLAIM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_USER_CLAIM_T_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "T_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_USER_LOGIN",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USER_LOGIN", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_T_USER_LOGIN_T_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "T_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_USER_ROLE",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USER_ROLE", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_T_USER_ROLE_T_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "T_ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_USER_ROLE_T_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "T_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_USER_TOKEN",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USER_TOKEN", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_T_USER_TOKEN_T_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "T_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_SystemId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_PermissionId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_T_ENVIROMENT_SYSTEM_ROLE_PERMISSION_RoleId",
                table: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "T_ROLE",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_T_ROLE_CLAIM_RoleId",
                table: "T_ROLE_CLAIM",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "T_USER",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "T_USER",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_T_USER_CLAIM_UserId",
                table: "T_USER_CLAIM",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_T_USER_LOGIN_UserId",
                table: "T_USER_LOGIN",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_T_USER_ROLE_RoleId",
                table: "T_USER_ROLE",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ENVIROMENT_SYSTEM_ROLE_PERMISSION");

            migrationBuilder.DropTable(
                name: "T_ROLE_CLAIM");

            migrationBuilder.DropTable(
                name: "T_USER_CLAIM");

            migrationBuilder.DropTable(
                name: "T_USER_LOGIN");

            migrationBuilder.DropTable(
                name: "T_USER_ROLE");

            migrationBuilder.DropTable(
                name: "T_USER_TOKEN");

            migrationBuilder.DropTable(
                name: "T_SYSTEM");

            migrationBuilder.DropTable(
                name: "T_ENVIROMENT");

            migrationBuilder.DropTable(
                name: "T_PERMISSION");

            migrationBuilder.DropTable(
                name: "T_ROLE");

            migrationBuilder.DropTable(
                name: "T_USER");
        }
    }
}
