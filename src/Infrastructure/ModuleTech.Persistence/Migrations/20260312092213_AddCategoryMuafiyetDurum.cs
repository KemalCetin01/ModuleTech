using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleTech.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryMuafiyetDurum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "muafiyet_durum",
                table: "category",
                type: "integer",
                nullable: true,
                comment: "GurultuMuafiyeti=gurultu_muafiyeti, HavaEmisyonuMuafiyeti=hava_emisyonu_muafiyeti");

            migrationBuilder.AlterColumn<int>(
                name: "user_status",
                table: "business_user",
                type: "integer",
                nullable: false,
                comment: "Active=1, Inactive=2, Deleted=3",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "site_status",
                table: "business_user",
                type: "integer",
                nullable: false,
                comment: "Open=1, Closed=2",
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "muafiyet_durum",
                table: "category");

            migrationBuilder.AlterColumn<int>(
                name: "user_status",
                table: "business_user",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Active=1, Inactive=2, Deleted=3");

            migrationBuilder.AlterColumn<int>(
                name: "site_status",
                table: "business_user",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Open=1, Closed=2");
        }
    }
}
