using System.ComponentModel;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ModuleTech.Persistence.Extensions;

public static class ModelBuilderEnumExtensions
{
    /// <summary>
    /// Modeldeki tüm enum tipindeki kolonlara otomatik açıklama yazar.
    /// Int-backed enum: "Ad=1, Ad2=2"
    /// [Description]-li enum: "Ad=description_value, ..."
    /// </summary>
    public static ModelBuilder ApplyEnumComments(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                var clrType = property.ClrType;
                var enumType = Nullable.GetUnderlyingType(clrType) ?? clrType;

                if (!enumType.IsEnum)
                    continue;

                var comment = GenerateEnumDescription(enumType);
                property.SetComment(comment);
            }
        }

        return modelBuilder;
    }

    private static string GenerateEnumDescription(Type enumType)
    {
        var parts = Enum.GetValues(enumType)
            .Cast<object>()
            .Select(value =>
            {
                var name = value.ToString()!;
                var field = enumType.GetField(name);
                var description = field?.GetCustomAttribute<DescriptionAttribute>()?.Description;

                return description != null
                    ? $"{description}={name}"
                    : $"{Convert.ToInt32(value)}={name}";
            });

        return string.Join(" - ", parts);
    }
}
