using Microsoft.EntityFrameworkCore.Migrations;

namespace Hub.Migrations
{
    public partial class productvaraianupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PImageId",
                table: "ProductVariant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PImageId",
                table: "ProductVariant",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
