using System.Text;
using System.Text.RegularExpressions;

namespace RubiconTask.Helpers.ServiceHelpers;

/// <summary>
/// Helper methods for generating slug.
/// </summary>
public static class BlogPostServiceHelpers
{
    /// <summary>
    /// Generates the slug.
    /// </summary>
    /// <param name="title">Title from which to generate slug.</param>
    /// <returns>Generated slug.</returns>
    public static string GenerateSlug(this string title) 
    { 
        var str = title.ToLowerInvariant();
        var stringBuilder = new StringBuilder();
        foreach (var letter in str)
        {
            stringBuilder.Append(RemapInternationalCharToAscii(letter));
        }
        str = stringBuilder.ToString();
        // Replaces everything that isn't a letter or a number with a empty char.           
        str = Regex.Replace(str, @"[^a-z0-9\s/g-]", ""); 
        // convert multiple spaces into one space.
        str = Regex.Replace(str, @"\s+", " ").Trim(); 
        // replaces every hyphen with a -.
        str = Regex.Replace(str, @"\s", "-"); // hyphens   
        return str; 
    }

    /// <summary>
    /// Changes internation letter to english alphabet.
    /// </summary>
    /// <param name="c">Character to check.</param>
    /// <returns>Changed letter or the same letter that was passed in.</returns>
    private static string RemapInternationalCharToAscii(char c)
    {
        var s = c.ToString();
        if ("àåáâäãåą".Contains(s))
        {
            return "a";
        }
        else if ("èéêëę".Contains(s))
        {
            return "e";
        }
        else if ("ìíîïı".Contains(s))
        {
            return "i";
        }
        else if ("òóôõöøőð".Contains(s))
        {
            return "o";
        }
        else if ("ùúûüŭů".Contains(s))
        {
            return "u";
        }
        else if ("çćčĉ".Contains(s))
        {
            return "c";
        }
        else if ("żźž".Contains(s))
        {
            return "z";
        }
        else if ("śşšŝ".Contains(s))
        {
            return "s";
        }
        else if ("ñń".Contains(s))
        {
            return "n";
        }
        else if ("ýÿ".Contains(s))
        {
            return "y";
        }
        else if ("ğĝ".Contains(s))
        {
            return "g";
        }
        else if (c == 'ř')
        {
            return "r";
        }
        else if (c == 'ł')
        {
            return "l";
        }
        else if (c == 'đ')
        {
            return "d";
        }
        else if (c == 'ß')
        {
            return "ss";
        }
        else if (c == 'þ')
        {
            return "th";
        }
        else if (c == 'ĥ')
        {
            return "h";
        }
        else if (c == 'ĵ')
        {
            return "j";
        }
        else
        {
            return c.ToString();
        }
    }
}