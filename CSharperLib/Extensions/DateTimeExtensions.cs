namespace CSharperLib.Extensions;

/// <summary>
/// DateTime Extensions.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Returns the first day of the month for this instance.
    /// (CSharperLib)
    /// </summary>
    /// <returns>A new <see cref="DateTime"/> that indicates the first day of the month for this <see cref="DateTime"/> value.</returns>
    public static DateTime StartOfMonth(this DateTime value)
    {
        return new DateTime(value.Year, value.Month, 1);
    }

    /// <summary>
    /// Returns the first day of the year for this instance.
    /// (CSharperLib)
    /// </summary>
    /// <returns>A new <see cref="DateTime"/> that indicates the first day of the year for this <see cref="DateTime"/> value.</returns>
    public static DateTime StartOfYear(this DateTime value)
    {
        return new DateTime(value.Year, 1, 1);
    }


    /// <summary>
    /// Indicates whether this instance is within today.
    /// (CSharperLib)
    /// </summary>
    /// <returns><see langword="true"/> if this <see cref="DateTime"/> value is within today; otherwise, <see langword="false"/>.</returns>
    public static bool IsInToday(this DateTime value)
    {
        return value.Date == DateTime.Today;
    }

    /// <summary>
    /// Indicates whether this instance is within tomorrow.
    /// (CSharperLib)
    /// </summary>
    /// <returns><see langword="true"/> if this <see cref="DateTime"/> value is within tomorrow; otherwise, <see langword="false"/>.</returns>
    public static bool IsInTomorrow(this DateTime value)
    {
        return value.Date == DateTime.Today.AddDays(1);
    }

    /// <summary>
    /// Indicates whether this instance is within yesterday.
    /// (CSharperLib)
    /// </summary>
    /// <returns><see langword="true"/> if this <see cref="DateTime"/> value is within yesterday; otherwise, <see langword="false"/>.</returns>
    public static bool IsInYesterday(this DateTime value)
    {
        return value.Date == DateTime.Today.AddDays(-1);
    }
}
