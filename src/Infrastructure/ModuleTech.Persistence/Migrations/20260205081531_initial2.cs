using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleTech.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessUser_UserEmployee_UserEmployeeId",
                table: "BusinessUser");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessUser_User_UserId",
                table: "BusinessUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEmployee_EmployeeRole_EmployeeRoleId",
                table: "UserEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEmployee_User_UserId",
                table: "UserEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOTP_User_UserId",
                table: "UserOTP");

            migrationBuilder.DropForeignKey(
                name: "FK_UserResetPassword_UserOTP_UserOtpId",
                table: "UserResetPassword");

            migrationBuilder.DropForeignKey(
                name: "FK_UserResetPassword_User_UserId",
                table: "UserResetPassword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserResetPassword",
                table: "UserResetPassword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOTP",
                table: "UserOTP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEmployee",
                table: "UserEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeRole",
                table: "EmployeeRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessUser",
                table: "BusinessUser");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "UserResetPassword",
                newName: "user_reset_password");

            migrationBuilder.RenameTable(
                name: "UserOTP",
                newName: "user_otp");

            migrationBuilder.RenameTable(
                name: "UserEmployee",
                newName: "user_employee");

            migrationBuilder.RenameTable(
                name: "EmployeeRole",
                newName: "employee_role");

            migrationBuilder.RenameTable(
                name: "BusinessUser",
                newName: "business_user");

            migrationBuilder.RenameColumn(
                name: "Suffix",
                table: "user",
                newName: "suffix");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "user",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "user",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "user",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "user",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IdentityRefId",
                table: "user",
                newName: "identity_ref_id");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "user",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "user",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "user",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "user",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "user",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "product",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "product",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "product",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "product",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "product",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "product",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "product",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "product",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "product",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "product",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_reset_password",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserOtpId",
                table: "user_reset_password",
                newName: "user_otp_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_reset_password",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ResetPasswordDate",
                table: "user_reset_password",
                newName: "reset_password_date");

            migrationBuilder.RenameColumn(
                name: "IsUsed",
                table: "user_reset_password",
                newName: "is_used");

            migrationBuilder.RenameColumn(
                name: "ExpireDate",
                table: "user_reset_password",
                newName: "expire_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "user_reset_password",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_UserResetPassword_UserOtpId",
                table: "user_reset_password",
                newName: "ix_user_reset_password_user_otp_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserResetPassword_UserId",
                table: "user_reset_password",
                newName: "ix_user_reset_password_user_id");

            migrationBuilder.RenameColumn(
                name: "Platform",
                table: "user_otp",
                newName: "platform");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "user_otp",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "user_otp",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_otp",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VerificationType",
                table: "user_otp",
                newName: "verification_type");

            migrationBuilder.RenameColumn(
                name: "VerificationDate",
                table: "user_otp",
                newName: "verification_date");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_otp",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "OtpType",
                table: "user_otp",
                newName: "otp_type");

            migrationBuilder.RenameColumn(
                name: "OtpCode",
                table: "user_otp",
                newName: "otp_code");

            migrationBuilder.RenameColumn(
                name: "IsVerified",
                table: "user_otp",
                newName: "is_verified");

            migrationBuilder.RenameColumn(
                name: "ExpireDate",
                table: "user_otp",
                newName: "expire_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "user_otp",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_UserOTP_UserId",
                table: "user_otp",
                newName: "ix_user_otp_user_id");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "user_employee",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "LastDateEntry",
                table: "user_employee",
                newName: "last_date_entry");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "user_employee",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "EmployeeRoleId",
                table: "user_employee",
                newName: "employee_role_id");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "user_employee",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "user_employee",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_employee",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserEmployee_EmployeeRoleId",
                table: "user_employee",
                newName: "ix_user_employee_employee_role_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "employee_role",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "employee_role",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "employee_role",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "employee_role",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "employee_role",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "employee_role",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "DiscountRate",
                table: "employee_role",
                newName: "discount_rate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "employee_role",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "employee_role",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "employee_role",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "employee_role",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "business_user",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "UserStatus",
                table: "business_user",
                newName: "user_status");

            migrationBuilder.RenameColumn(
                name: "UserGroupRoleId",
                table: "business_user",
                newName: "user_group_role_id");

            migrationBuilder.RenameColumn(
                name: "UserEmployeeId",
                table: "business_user",
                newName: "user_employee_id");

            migrationBuilder.RenameColumn(
                name: "TownId",
                table: "business_user",
                newName: "town_id");

            migrationBuilder.RenameColumn(
                name: "SiteStatus",
                table: "business_user",
                newName: "site_status");

            migrationBuilder.RenameColumn(
                name: "PhoneCountryCode",
                table: "business_user",
                newName: "phone_country_code");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "business_user",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "business_user",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "business_user",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "business_user",
                newName: "country_id");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "business_user",
                newName: "city_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "business_user",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessUser_UserEmployeeId",
                table: "business_user",
                newName: "ix_business_user_user_employee_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user",
                table: "user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_product",
                table: "product",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_reset_password",
                table: "user_reset_password",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_otp",
                table: "user_otp",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_employee",
                table: "user_employee",
                column: "user_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_employee_role",
                table: "employee_role",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_business_user",
                table: "business_user",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_business_user_user_employee_user_employee_id",
                table: "business_user",
                column: "user_employee_id",
                principalTable: "user_employee",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_business_user_user_user_id",
                table: "business_user",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_employee_employee_role_employee_role_id",
                table: "user_employee",
                column: "employee_role_id",
                principalTable: "employee_role",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_employee_user_user_id",
                table: "user_employee",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_otp_user_user_id",
                table: "user_otp",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_reset_password_user_otp_user_otp_id",
                table: "user_reset_password",
                column: "user_otp_id",
                principalTable: "user_otp",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_reset_password_user_user_id",
                table: "user_reset_password",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_business_user_user_employee_user_employee_id",
                table: "business_user");

            migrationBuilder.DropForeignKey(
                name: "fk_business_user_user_user_id",
                table: "business_user");

            migrationBuilder.DropForeignKey(
                name: "fk_user_employee_employee_role_employee_role_id",
                table: "user_employee");

            migrationBuilder.DropForeignKey(
                name: "fk_user_employee_user_user_id",
                table: "user_employee");

            migrationBuilder.DropForeignKey(
                name: "fk_user_otp_user_user_id",
                table: "user_otp");

            migrationBuilder.DropForeignKey(
                name: "fk_user_reset_password_user_otp_user_otp_id",
                table: "user_reset_password");

            migrationBuilder.DropForeignKey(
                name: "fk_user_reset_password_user_user_id",
                table: "user_reset_password");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "pk_product",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_reset_password",
                table: "user_reset_password");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_otp",
                table: "user_otp");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_employee",
                table: "user_employee");

            migrationBuilder.DropPrimaryKey(
                name: "pk_employee_role",
                table: "employee_role");

            migrationBuilder.DropPrimaryKey(
                name: "pk_business_user",
                table: "business_user");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "user_reset_password",
                newName: "UserResetPassword");

            migrationBuilder.RenameTable(
                name: "user_otp",
                newName: "UserOTP");

            migrationBuilder.RenameTable(
                name: "user_employee",
                newName: "UserEmployee");

            migrationBuilder.RenameTable(
                name: "employee_role",
                newName: "EmployeeRole");

            migrationBuilder.RenameTable(
                name: "business_user",
                newName: "BusinessUser");

            migrationBuilder.RenameColumn(
                name: "suffix",
                table: "User",
                newName: "Suffix");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "User",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "User",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "User",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "User",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "User",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "identity_ref_id",
                table: "User",
                newName: "IdentityRefId");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "User",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                table: "User",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "User",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "User",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "User",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "url",
                table: "Product",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Product",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Product",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Product",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "Product",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "Product",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                table: "Product",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "Product",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Product",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "Product",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserResetPassword",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_otp_id",
                table: "UserResetPassword",
                newName: "UserOtpId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "UserResetPassword",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "reset_password_date",
                table: "UserResetPassword",
                newName: "ResetPasswordDate");

            migrationBuilder.RenameColumn(
                name: "is_used",
                table: "UserResetPassword",
                newName: "IsUsed");

            migrationBuilder.RenameColumn(
                name: "expire_date",
                table: "UserResetPassword",
                newName: "ExpireDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "UserResetPassword",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "ix_user_reset_password_user_otp_id",
                table: "UserResetPassword",
                newName: "IX_UserResetPassword_UserOtpId");

            migrationBuilder.RenameIndex(
                name: "ix_user_reset_password_user_id",
                table: "UserResetPassword",
                newName: "IX_UserResetPassword_UserId");

            migrationBuilder.RenameColumn(
                name: "platform",
                table: "UserOTP",
                newName: "Platform");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "UserOTP",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "UserOTP",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserOTP",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "verification_type",
                table: "UserOTP",
                newName: "VerificationType");

            migrationBuilder.RenameColumn(
                name: "verification_date",
                table: "UserOTP",
                newName: "VerificationDate");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "UserOTP",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "otp_type",
                table: "UserOTP",
                newName: "OtpType");

            migrationBuilder.RenameColumn(
                name: "otp_code",
                table: "UserOTP",
                newName: "OtpCode");

            migrationBuilder.RenameColumn(
                name: "is_verified",
                table: "UserOTP",
                newName: "IsVerified");

            migrationBuilder.RenameColumn(
                name: "expire_date",
                table: "UserOTP",
                newName: "ExpireDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "UserOTP",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "ix_user_otp_user_id",
                table: "UserOTP",
                newName: "IX_UserOTP_UserId");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "UserEmployee",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "last_date_entry",
                table: "UserEmployee",
                newName: "LastDateEntry");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "UserEmployee",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "employee_role_id",
                table: "UserEmployee",
                newName: "EmployeeRoleId");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                table: "UserEmployee",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "UserEmployee",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "UserEmployee",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "ix_user_employee_employee_role_id",
                table: "UserEmployee",
                newName: "IX_UserEmployee_EmployeeRoleId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "EmployeeRole",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "EmployeeRole",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "EmployeeRole",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "EmployeeRole",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "EmployeeRole",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "EmployeeRole",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "discount_rate",
                table: "EmployeeRole",
                newName: "DiscountRate");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                table: "EmployeeRole",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "EmployeeRole",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "EmployeeRole",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "EmployeeRole",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "BusinessUser",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "user_status",
                table: "BusinessUser",
                newName: "UserStatus");

            migrationBuilder.RenameColumn(
                name: "user_group_role_id",
                table: "BusinessUser",
                newName: "UserGroupRoleId");

            migrationBuilder.RenameColumn(
                name: "user_employee_id",
                table: "BusinessUser",
                newName: "UserEmployeeId");

            migrationBuilder.RenameColumn(
                name: "town_id",
                table: "BusinessUser",
                newName: "TownId");

            migrationBuilder.RenameColumn(
                name: "site_status",
                table: "BusinessUser",
                newName: "SiteStatus");

            migrationBuilder.RenameColumn(
                name: "phone_country_code",
                table: "BusinessUser",
                newName: "PhoneCountryCode");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "BusinessUser",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                table: "BusinessUser",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "BusinessUser",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "country_id",
                table: "BusinessUser",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "city_id",
                table: "BusinessUser",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "BusinessUser",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "ix_business_user_user_employee_id",
                table: "BusinessUser",
                newName: "IX_BusinessUser_UserEmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserResetPassword",
                table: "UserResetPassword",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOTP",
                table: "UserOTP",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEmployee",
                table: "UserEmployee",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeRole",
                table: "EmployeeRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessUser",
                table: "BusinessUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessUser_UserEmployee_UserEmployeeId",
                table: "BusinessUser",
                column: "UserEmployeeId",
                principalTable: "UserEmployee",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessUser_User_UserId",
                table: "BusinessUser",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEmployee_EmployeeRole_EmployeeRoleId",
                table: "UserEmployee",
                column: "EmployeeRoleId",
                principalTable: "EmployeeRole",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEmployee_User_UserId",
                table: "UserEmployee",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOTP_User_UserId",
                table: "UserOTP",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserResetPassword_UserOTP_UserOtpId",
                table: "UserResetPassword",
                column: "UserOtpId",
                principalTable: "UserOTP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserResetPassword_User_UserId",
                table: "UserResetPassword",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
