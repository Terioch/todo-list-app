using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoListApp.Migrations
{
    public partial class AddedPriceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "TodoItems",
                newName: "Name");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "TodoItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TodoItems",
                newName: "Text");
        }
    }
}
