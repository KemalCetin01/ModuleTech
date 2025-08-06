using ModuleTech.Domain.Enums;

namespace ModuleTech.Persistence.EntityConfigurations;

public class UserOTPConfigurations : IEntityTypeConfiguration<UserOTP>
{
    public void Configure(EntityTypeBuilder<UserOTP> builder)
    {
        builder.ToTable(nameof(UserOTP));
        builder.Property(x => x.VerificationType).HasDefaultValue(VerificationTypeEnum.Email).HasComment("1:email - 2:phone");
        builder.Property(x => x.Platform).HasDefaultValue(UserTypeEnum.BusinessUser).HasComment("1:businessUser - 3:employee");
        builder.Property(x => x.OtpType).HasDefaultValue(OtpTypeEnum.SignUp).HasComment("1:signUp - 2:ResetPassword - 3:CreatePassword");
        builder.Property(x => x.Phone).HasMaxLength(15);
    }
}
