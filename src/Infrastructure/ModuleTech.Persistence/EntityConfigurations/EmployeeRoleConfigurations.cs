﻿namespace ModuleTech.Persistence.EntityConfigurations
{
    public class EmployeeRoleConfigurations : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {
            builder.ToTable(nameof(EmployeeRole));
        }
    }
}
