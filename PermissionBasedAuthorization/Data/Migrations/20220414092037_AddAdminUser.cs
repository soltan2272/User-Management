using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermissionBasedAuthorization.Data.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO[dbo].[Users] ([Id], [FirstName], [LastName], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES(N'79e21b68-2638-4199-81d2-b4fab02f0a1b', N'adminn', N'adminn', NULL, N'admin@admin', N'ADMIN@ADMIN', N'admin@admin', N'ADMIN@ADMIN', 1, N'AQAAAAEAACcQAAAAEMSR+25x1TfROZEcjAZ3iApULDLykgaxgW7RXwvAvUy9ito4NzMSoTXoD3pos4zzeg==', N'PKPDAVJUADPHHYSP7DTATKBE2QO72NXW', N'9db585be-f490-492b-a7e6-d6c94151a3de', NULL, 0, 0, NULL, 1, 0)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[Users] WHERE Id = '79e21b68-2638-4199-81d2-b4fab02f0a1b'");

        }
    }
}
