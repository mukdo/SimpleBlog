using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Web.Migrations.Framework
{
    public partial class commentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogComposeId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogComposeId",
                table: "Comments");
        }
    }
}
