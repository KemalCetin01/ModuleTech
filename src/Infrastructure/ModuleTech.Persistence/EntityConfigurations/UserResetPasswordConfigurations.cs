namespace ModuleTech.Persistence.EntityConfigurations
{
    public class UserResetPasswordConfigurations : IEntityTypeConfiguration<UserResetPassword>
    {
        public void Configure(EntityTypeBuilder<UserResetPassword> builder)
        {
            builder.ToTable(nameof(UserResetPassword));
        }
    }
}
