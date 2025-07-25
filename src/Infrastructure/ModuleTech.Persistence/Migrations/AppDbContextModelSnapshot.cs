﻿// <auto-generated />
using System;
using ModuleTech.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ModuleTech.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ModuleTech.Domain.EmployeeRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("DiscountRate")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("EmployeeRole", (string)null);
                });

            modelBuilder.Entity("ModuleTech.Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ModuleTech.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdentityRefId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Suffix")
                        .HasColumnType("text");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ModuleTech.Domain.UserB2B", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int?>("CityId")
                        .HasColumnType("integer");

                    b.Property<int?>("CountryId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("PhoneCountryCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<int>("SiteStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("TownId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UserEmployeeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserGroupRoleId")
                        .HasColumnType("uuid");

                    b.Property<int>("UserStatus")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("UserEmployeeId");

                    b.ToTable("UserB2B", (string)null);
                });

            modelBuilder.Entity("ModuleTech.Domain.UserEmployee", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("EmployeeRoleId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastDateEntry")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("EmployeeRoleId");

                    b.ToTable("UserEmployee", (string)null);
                });

            modelBuilder.Entity("ModuleTech.Domain.UserOTP", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("OtpCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OtpType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasComment("1:signUp - 2:ResetPassword - 3:CreatePassword");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<int?>("Platform")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasComment("1:b2b - 3:employee");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("VerificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("VerificationType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasComment("1:email - 2:phone");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserOTP", (string)null);
                });

            modelBuilder.Entity("ModuleTech.Domain.UserResetPassword", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ResetPasswordDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserOtpId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserOtpId")
                        .IsUnique();

                    b.ToTable("UserResetPassword", (string)null);
                });

            modelBuilder.Entity("ModuleTech.Domain.UserB2B", b =>
                {
                    b.HasOne("ModuleTech.Domain.UserEmployee", "UserEmployee")
                        .WithMany("UserB2Bs")
                        .HasForeignKey("UserEmployeeId");

                    b.HasOne("ModuleTech.Domain.User", "User")
                        .WithOne()
                        .HasForeignKey("ModuleTech.Domain.UserB2B", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserEmployee");
                });

            modelBuilder.Entity("ModuleTech.Domain.UserEmployee", b =>
                {
                    b.HasOne("ModuleTech.Domain.EmployeeRole", "EmployeeRole")
                        .WithMany("UserEmployees")
                        .HasForeignKey("EmployeeRoleId");

                    b.HasOne("ModuleTech.Domain.User", "User")
                        .WithOne()
                        .HasForeignKey("ModuleTech.Domain.UserEmployee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeRole");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ModuleTech.Domain.UserOTP", b =>
                {
                    b.HasOne("ModuleTech.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ModuleTech.Domain.UserResetPassword", b =>
                {
                    b.HasOne("ModuleTech.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("ModuleTech.Domain.UserOTP", "UserOTP")
                        .WithOne("UserResetPassword")
                        .HasForeignKey("ModuleTech.Domain.UserResetPassword", "UserOtpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserOTP");
                });

            modelBuilder.Entity("ModuleTech.Domain.EmployeeRole", b =>
                {
                    b.Navigation("UserEmployees");
                });

            modelBuilder.Entity("ModuleTech.Domain.UserEmployee", b =>
                {
                    b.Navigation("UserB2Bs");
                });

            modelBuilder.Entity("ModuleTech.Domain.UserOTP", b =>
                {
                    b.Navigation("UserResetPassword");
                });
#pragma warning restore 612, 618
        }
    }
}
