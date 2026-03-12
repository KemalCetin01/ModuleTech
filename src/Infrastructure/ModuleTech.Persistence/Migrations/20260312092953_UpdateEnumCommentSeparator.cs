using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleTech.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEnumCommentSeparator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "muafiyet_durum",
                table: "category",
                type: "integer",
                nullable: true,
                comment: "gurultu_muafiyeti=GurultuMuafiyeti - hava_emisyonu_muafiyeti=HavaEmisyonuMuafiyeti",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldComment: "gurultu_muafiyeti=GurultuMuafiyeti, hava_emisyonu_muafiyeti=HavaEmisyonuMuafiyeti");

            migrationBuilder.AlterColumn<int>(
                name: "user_status",
                table: "business_user",
                type: "integer",
                nullable: false,
                comment: "1=Active - 2=Inactive - 3=Deleted",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "1=Active, 2=Inactive, 3=Deleted");

            migrationBuilder.AlterColumn<int>(
                name: "site_status",
                table: "business_user",
                type: "integer",
                nullable: false,
                comment: "1=Open - 2=Closed",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "1=Open, 2=Closed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "muafiyet_durum",
                table: "category",
                type: "integer",
                nullable: true,
                comment: "gurultu_muafiyeti=GurultuMuafiyeti, hava_emisyonu_muafiyeti=HavaEmisyonuMuafiyeti",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldComment: "gurultu_muafiyeti=GurultuMuafiyeti - hava_emisyonu_muafiyeti=HavaEmisyonuMuafiyeti");

            migrationBuilder.AlterColumn<int>(
                name: "user_status",
                table: "business_user",
                type: "integer",
                nullable: false,
                comment: "1=Active, 2=Inactive, 3=Deleted",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "1=Active - 2=Inactive - 3=Deleted");

            migrationBuilder.AlterColumn<int>(
                name: "site_status",
                table: "business_user",
                type: "integer",
                nullable: false,
                comment: "1=Open, 2=Closed",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "1=Open - 2=Closed");
        }
    }
}
