using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_members_roles_roles_RoleId",
                table: "members_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_members_roles_usermembers_UserMemberId",
                table: "members_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_members_roles",
                table: "members_roles");

            migrationBuilder.RenameTable(
                name: "members_roles",
                newName: "usermembers_roles");

            migrationBuilder.RenameIndex(
                name: "IX_members_roles_UserMemberId",
                table: "usermembers_roles",
                newName: "IX_usermembers_roles_UserMemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usermembers_roles",
                table: "usermembers_roles",
                columns: new[] { "RoleId", "UserMemberId" });

            migrationBuilder.AddForeignKey(
                name: "FK_usermembers_roles_roles_RoleId",
                table: "usermembers_roles",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usermembers_roles_usermembers_UserMemberId",
                table: "usermembers_roles",
                column: "UserMemberId",
                principalTable: "usermembers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usermembers_roles_roles_RoleId",
                table: "usermembers_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_usermembers_roles_usermembers_UserMemberId",
                table: "usermembers_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usermembers_roles",
                table: "usermembers_roles");

            migrationBuilder.RenameTable(
                name: "usermembers_roles",
                newName: "members_roles");

            migrationBuilder.RenameIndex(
                name: "IX_usermembers_roles_UserMemberId",
                table: "members_roles",
                newName: "IX_members_roles_UserMemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_members_roles",
                table: "members_roles",
                columns: new[] { "RoleId", "UserMemberId" });

            migrationBuilder.AddForeignKey(
                name: "FK_members_roles_roles_RoleId",
                table: "members_roles",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_members_roles_usermembers_UserMemberId",
                table: "members_roles",
                column: "UserMemberId",
                principalTable: "usermembers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
