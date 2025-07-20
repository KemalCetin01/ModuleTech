using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleTech.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VerificationType",
                table: "UserOTP",
                type: "integer",
                nullable: true,
                defaultValue: 1,
                comment: "1:email - 2:phone",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1,
                oldComment: "1:email - 2:phone");

            migrationBuilder.AlterColumn<int>(
                name: "Platform",
                table: "UserOTP",
                type: "integer",
                nullable: true,
                defaultValue: 1,
                comment: "1:b2b - 3:employee",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1,
                oldComment: "1:b2b - 3:employee");

            migrationBuilder.AlterColumn<int>(
                name: "OtpType",
                table: "UserOTP",
                type: "integer",
                nullable: true,
                defaultValue: 1,
                comment: "1:signUp - 2:ResetPassword - 3:CreatePassword",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1,
                oldComment: "1:signUp - 2:ResetPassword - 3:CreatePassword");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VerificationType",
                table: "UserOTP",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                comment: "1:email - 2:phone",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 1,
                oldComment: "1:email - 2:phone");

            migrationBuilder.AlterColumn<int>(
                name: "Platform",
                table: "UserOTP",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                comment: "1:b2b - 3:employee",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 1,
                oldComment: "1:b2b - 3:employee");

            migrationBuilder.AlterColumn<int>(
                name: "OtpType",
                table: "UserOTP",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                comment: "1:signUp - 2:ResetPassword - 3:CreatePassword",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 1,
                oldComment: "1:signUp - 2:ResetPassword - 3:CreatePassword");
        }
    }
}
