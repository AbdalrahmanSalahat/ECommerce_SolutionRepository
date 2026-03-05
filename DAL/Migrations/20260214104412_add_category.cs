using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Categories_CategoryId",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Item",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_CategoryId",
                table: "Item",
                newName: "IX_Item_categoryId");

            migrationBuilder.AlterColumn<int>(
                name: "categoryId",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Categories_categoryId",
                table: "Item",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Categories_categoryId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Item",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_categoryId",
                table: "Item",
                newName: "IX_Item_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Item",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Categories_CategoryId",
                table: "Item",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
