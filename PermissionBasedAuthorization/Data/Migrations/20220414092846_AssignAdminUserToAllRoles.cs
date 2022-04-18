using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermissionBasedAuthorization.Data.Migrations
{
    public partial class AssignAdminUserToAllRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUserRoles] (UserId, RoleId) SELECT '79e21b68-2638-4199-81d2-b4fab02f0a1b', Id FROM [dbo].[AspNetRoles]");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUserRoles] WHERE UserId = '79e21b68-2638-4199-81d2-b4fab02f0a1b'");

        }
    }
}
