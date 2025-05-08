using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Discount.Migrations
{
    /// <inheritdoc />
    public partial class mig_nameupdate_coupon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductionId",
                table: "Coupones",
                newName: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Coupones",
                newName: "ProductionId");
        }
    }
}
