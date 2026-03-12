using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleTech.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAuthEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_reset_password");

            migrationBuilder.DropTable(
                name: "user_otp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_otp",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    expire_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_verified = table.Column<bool>(type: "boolean", nullable: false),
                    otp_code = table.Column<string>(type: "text", nullable: false),
                    otp_type = table.Column<int>(type: "integer", nullable: true, defaultValue: 1, comment: "1:signUp - 2:ResetPassword - 3:CreatePassword"),
                    phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    platform = table.Column<int>(type: "integer", nullable: true, defaultValue: 1, comment: "1:businessUser - 3:employee"),
                    verification_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    verification_type = table.Column<int>(type: "integer", nullable: true, defaultValue: 1, comment: "1:email - 2:phone")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_otp", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_otp_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_reset_password",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    user_otp_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    expire_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_used = table.Column<bool>(type: "boolean", nullable: false),
                    reset_password_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_reset_password", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_reset_password_user_otp_user_otp_id",
                        column: x => x.user_otp_id,
                        principalTable: "user_otp",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_reset_password_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_otp_user_id",
                table: "user_otp",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_reset_password_user_id",
                table: "user_reset_password",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_reset_password_user_otp_id",
                table: "user_reset_password",
                column: "user_otp_id",
                unique: true);
        }
    }
}
