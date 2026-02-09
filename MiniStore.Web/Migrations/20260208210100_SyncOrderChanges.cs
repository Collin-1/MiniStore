using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniStore.Web.Migrations
{
    /// <inheritdoc />
    public partial class SyncOrderChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProdcutNameSnapshot",
                table: "OrderItem",
                newName: "ProductNameSnapshot");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductNameSnapshot",
                table: "OrderItem",
                newName: "ProdcutNameSnapshot");
        }
    }
}
