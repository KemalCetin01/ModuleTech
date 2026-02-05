using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

public static class ModelBuilderSnakeCaseExtension
{
    public static void UseSnakeCaseNaming(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // 🔹 Table name
            if (entity.GetTableName() != null)
            {
                entity.SetTableName(
                    SnakeCaseHelper.ToSnakeCase(entity.GetTableName()!)
                );
            }

            // 🔹 Columns
            foreach (var property in entity.GetProperties())
            {
                // Eğer [Column("xxx")] varsa dokunma
                if (property.GetColumnName(StoreObjectIdentifier.Table(
                        entity.GetTableName()!, entity.GetSchema())) != property.Name)
                    continue;

                property.SetColumnName(
                    SnakeCaseHelper.ToSnakeCase(property.Name)
                );
            }

            // 🔹 Primary Keys
            foreach (var key in entity.GetKeys())
            {
                key.SetName(
                    SnakeCaseHelper.ToSnakeCase(key.GetName()!)
                );
            }

            // 🔹 Foreign Keys
            foreach (var fk in entity.GetForeignKeys())
            {
                fk.SetConstraintName(
                    SnakeCaseHelper.ToSnakeCase(fk.GetConstraintName()!)
                );
            }

            // 🔹 Indexes
            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(
                    SnakeCaseHelper.ToSnakeCase(index.GetDatabaseName()!)
                );
            }
        }
    }
}
