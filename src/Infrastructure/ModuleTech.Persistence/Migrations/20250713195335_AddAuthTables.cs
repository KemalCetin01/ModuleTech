using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleTech.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DiscountRate = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Suffix = table.Column<string>(type: "text", nullable: true),
                    IdentityRefId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEmployee",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    LastDateEntry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EmployeeRoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmployee", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserEmployee_EmployeeRole_EmployeeRoleId",
                        column: x => x.EmployeeRoleId,
                        principalTable: "EmployeeRole",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserEmployee_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOTP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OtpCode = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    VerificationType = table.Column<int>(type: "integer", nullable: false, defaultValue: 1, comment: "1:email - 2:phone"),
                    VerificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OtpType = table.Column<int>(type: "integer", nullable: false, defaultValue: 1, comment: "1:signUp - 2:ResetPassword - 3:CreatePassword"),
                    Platform = table.Column<int>(type: "integer", nullable: false, defaultValue: 1, comment: "1:b2b - 3:employee")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOTP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOTP_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserB2B",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneCountryCode = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    UserEmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    CityId = table.Column<int>(type: "integer", nullable: true),
                    TownId = table.Column<int>(type: "integer", nullable: true),
                    SiteStatus = table.Column<int>(type: "integer", nullable: false),
                    UserStatus = table.Column<int>(type: "integer", nullable: false),
                    UserGroupRoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserB2B", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserB2B_UserEmployee_UserEmployeeId",
                        column: x => x.UserEmployeeId,
                        principalTable: "UserEmployee",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_UserB2B_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserResetPassword",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserOtpId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    ResetPasswordDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResetPassword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserResetPassword_UserOTP_UserOtpId",
                        column: x => x.UserOtpId,
                        principalTable: "UserOTP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserResetPassword_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserB2B_UserEmployeeId",
                table: "UserB2B",
                column: "UserEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEmployee_EmployeeRoleId",
                table: "UserEmployee",
                column: "EmployeeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOTP_UserId",
                table: "UserOTP",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResetPassword_UserId",
                table: "UserResetPassword",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResetPassword_UserOtpId",
                table: "UserResetPassword",
                column: "UserOtpId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserB2B");

            migrationBuilder.DropTable(
                name: "UserResetPassword");

            migrationBuilder.DropTable(
                name: "UserEmployee");

            migrationBuilder.DropTable(
                name: "UserOTP");

            migrationBuilder.DropTable(
                name: "EmployeeRole");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
