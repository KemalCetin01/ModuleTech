using System.Text;
using System.Text.RegularExpressions;

public static class SnakeCaseHelper
{
    public static string ToSnakeCase(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        var startUnderscores = Regex.Match(input, @"^_+");
        var snake = Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2")
                          .Replace("-", "_")
                          .ToLowerInvariant();

        return startUnderscores + snake;
    }
}
