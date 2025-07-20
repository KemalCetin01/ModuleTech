using System.ComponentModel.DataAnnotations;


namespace ModuleTech.Core.Caching.Helper;

public class RedisOption
{
    [Required(ErrorMessage = "Redis Server URL is required")]
    public string Server { get; set; } = null!;

    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Database ID is not valid")]
    public int DatabaseId { get; set; }
    
    [Range(1, double.MaxValue, ErrorMessage = "Localization Database ID is not valid")]
    public int? LocalizationDatabaseId { get; set; }
}