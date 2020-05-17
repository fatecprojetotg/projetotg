using Microsoft.EntityFrameworkCore.Migrations;

namespace projetotg.Migrations
{
    public partial class AspUserNewPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewPassword",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewPassword",
                table: "AspNetUsers");
        }
    }
}
