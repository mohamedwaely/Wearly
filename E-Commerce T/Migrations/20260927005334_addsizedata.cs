using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce_T.Migrations
{
    /// <inheritdoc />
    public partial class addsizedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_Sizes_sizeId",
                table: "ProductVariants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "sizes");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "ProductVariants",
                newName: "IsActive");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sizes",
                table: "sizes",
                column: "id");

            migrationBuilder.InsertData(
                table: "sizes",
                columns: new[] { "id", "name", "type" },
                values: new object[,]
                {
                    { 1L, "L", 0 },
                    { 2L, "XL", 0 },
                    { 3L, "2XL", 0 },
                    { 4L, "3XL", 0 },
                    { 5L, "45", 1 },
                    { 6L, "46", 1 },
                    { 7L, "47", 1 },
                    { 8L, "48", 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_sizes_sizeId",
                table: "ProductVariants",
                column: "sizeId",
                principalTable: "sizes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_sizes_sizeId",
                table: "ProductVariants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sizes",
                table: "sizes");

            migrationBuilder.DeleteData(
                table: "sizes",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "sizes",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "sizes",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "sizes",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "sizes",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "sizes",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "sizes",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "sizes",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.RenameTable(
                name: "sizes",
                newName: "Sizes");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ProductVariants",
                newName: "isActive");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_Sizes_sizeId",
                table: "ProductVariants",
                column: "sizeId",
                principalTable: "Sizes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
