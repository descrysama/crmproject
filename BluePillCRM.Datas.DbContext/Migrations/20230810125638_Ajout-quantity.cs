using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BluePillCRM.Datas.Migrations
{
    /// <inheritdoc />
    public partial class Ajoutquantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "quotes_products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "orders_products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "invoices_products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "quotes_products");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "orders_products");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "invoices_products");
        }
    }
}
