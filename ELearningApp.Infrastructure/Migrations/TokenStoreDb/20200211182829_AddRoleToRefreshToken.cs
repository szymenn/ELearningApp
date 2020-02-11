using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearningApp.Infrastructure.Migrations.TokenStoreDb
{
    public partial class AddRoleToRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Tokens",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Tokens");
        }
    }
}
