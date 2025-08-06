namespace ModuleTech.Persistence.EntityConfigurations;

public class BusinessUserConfigurations : IEntityTypeConfiguration<BusinessUser>
{
    public void Configure(EntityTypeBuilder<BusinessUser> builder)
    {
        builder.ToTable(nameof(BusinessUser));
        builder.HasOne(x => x.User).WithOne();
        builder.HasKey(x => x.UserId);

        builder.Property(x => x.PhoneCountryCode).HasMaxLength(8);
        builder.Property(x => x.Phone).HasMaxLength(15);
    }
}