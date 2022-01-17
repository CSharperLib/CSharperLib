using System.Globalization;
using System.Text.RegularExpressions;

namespace CSharperLib.Extensions;

/// <summary>
/// String Extensions.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Indicates whether the specified string is <see langword="null"/> or empty.
    /// (CSharperLib)
    /// </summary>
    /// <param name="value"></param>
    /// <returns><see langword="true"/> if this <see langword="string"/> value is <see langword="null"/> or an empty string (""); otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this string? value)
    {
        return string.IsNullOrEmpty(value);
    }

    /// <summary>
    /// Indicates whether a specified string is <see langword="null"/>, empty, or consists only of white-space characters.
    /// (CSharperLib)
    /// </summary>
    /// <param name="value"></param>
    /// <returns><see langword="true"/> if this <see langword="string"/> value is <see langword="null"/> or an empty string (""), or if this <see langword="string"/> value consists exclusively of white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }


    /// <summary>
    /// Indicates whether the specified string is equivalent to a number using the <see langword="NumberStyle.Integer"/> style.
    /// (CSharperLib)
    /// </summary>
    /// <param name="value"></param>
    /// <returns><see langword="true"/> if this <see langword="string"/> is equivalent to a number using the <see langword="NumberStyle.Integer"/> style; otherwise <see langword="false"/>.</returns>
    public static bool IsInt(this string value)
    {
        return int.TryParse(value, out _);
    }

    /// <summary>
    /// Converts the specified string to an <see langword="int"/>.
    /// (CSharperLib)
    /// </summary>
    /// <param name="value"></param>
    /// <returns>An <see langword="int"/> equivalent to the number contained in the specified string using the <see langword="NumberStyle.Integer"/> style.</returns>
    public static int ToInt(this string value)
    {
        return int.Parse(value);
    }

    /// <summary>
    /// Indicates whether the specified string is equivalent to a number using the <see langword="NumberStyle.Number"/> style.
    /// (CSharperLib)
    /// </summary>
    /// <param name="value"></param>
    /// <returns><see langword="true"/> if this <see langword="string"/> is equivalent to a number using the <see langword="NumberStyle.Number"/> style; otherwise <see langword="false"/>.</returns>
    /// <remarks>The current culture is used.</remarks>
    public static bool IsIntNumber(this string value)
    {
        return int.TryParse(value, NumberStyles.Number, null, out _);
    }

    /// <summary>
    /// Converts the specified string to an <see langword="int"/>.
    /// (CSharperLib)
    /// </summary>
    /// <param name="value"></param>
    /// <returns>An <see langword="int"/> equivalent to the number contained in the specified string using the <see langword="NumberStyle.Number"/> style.</returns>
    /// <remarks>The current culture is used.</remarks>
    public static int ToIntNumber(this string value)
    {
        return int.Parse(value, NumberStyles.Number);
    }


    /// <summary>
    /// Removes all leading and trailing occurrences of a specified string from the current string.
    /// (CSharperLib)
    /// </summary>
    /// <param name="value"></param>
    /// <param name="trimString">The string to remove.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
    /// <returns>
    /// The <see langword="string"/> that remains after all occurrences of the trimString <see langword="string"/> are removed from the start and end of the current <see langword="string"/>.
    /// If no strings can be trimmed from the current instance, the method returns the current instance unchanged.
    /// </returns>
    public static string Trim(this string value, string trimString, bool? ignoreCase = false)
    {
        return value.TrimStart(trimString, ignoreCase).TrimEnd(trimString, ignoreCase);
    }

    /// <summary>
    /// Removes all the leading occurrences of a specified string from the current string.
    /// (CSharperLib)
    /// </summary>
    /// <param name="value"></param>
    /// <param name="trimString">The string to remove.</param>
    /// <param name="ignoreCase"></param>
    /// <returns>
    /// The <see langword="string"/> that remains after all occurrences of the trimString <see langword="string"/> are removed from the start of the current <see langword="string"/>.
    /// If no strings can be trimmed from the current instance, the method returns the current instance unchanged.
    /// </returns>
    public static string TrimStart(this string value, string trimString, bool? ignoreCase = false)
    {
        return Regex.Replace(value, $@"^({trimString})*", "", (ignoreCase is true ? RegexOptions.IgnoreCase : RegexOptions.None) | RegexOptions.Compiled);
    }

    /// <summary>
    /// Removes all the trailing occurrences of a specified string from the current string.
    /// (CSharperLib)
    /// </summary>
    /// <param name="value"></param>
    /// <param name="trimString">The string to remove.</param>
    /// <param name="ignoreCase"></param>
    /// <returns>
    /// The <see langword="string"/> that remains after all occurrences of the trimString <see langword="string"/> are removed from the end of the current <see langword="string"/>.
    /// If no strings can be trimmed from the current instance, the method returns the current instance unchanged.
    /// </returns>
    public static string TrimEnd(this string value, string trimString, bool? ignoreCase = false)
    {
        return Regex.Replace(value, $@"({trimString})*$", "", (ignoreCase == true ? RegexOptions.IgnoreCase : RegexOptions.None) | RegexOptions.Compiled);
    }


    /// <summary>
    /// Returns a new <see langword="string"/> in which all empty lines in the current instance have been deleted.
    /// (CSharperLib)
    /// </summary>
    /// <param name="value"></param>
    /// <returns>A new <see langword="string"/> that is equivalent to this <see langword="string"/> except for the removed empty lines and lines that consists exclusively of white-space characters.</returns>
    public static string RemoveEmptyLines(this string value)
    {
        return Regex.Replace(value, @"^\s*$[\r\n]*", "", RegexOptions.Multiline | RegexOptions.Compiled);
    }
}
