namespace CSharperLib.Tests.Extensions;

public class DateTimeExtensions
{
    // --- StartOfMonth ---

    [Fact]
    public void StartOfMonth_DateTime_StartOfMonth()
    {
        // Arrange
        var now = DateTime.Now;

        // Act
        var startOfMonth = now.StartOfMonth();

        // Assert
        Assert.Equal(new DateTime(now.Year, now.Month, 1), startOfMonth);
    }


    // --- StartOfYear ---

    [Fact]
    public void StartOfYear_DateTime_StartOfYear()
    {
        // Arrange
        var now = DateTime.Now;

        // Act
        var StartOfYear = now.StartOfYear();

        // Assert
        Assert.Equal(new DateTime(now.Year, 1, 1), StartOfYear);
    }


    // --- IsInToday ---

    public static readonly object[][] IsInTodayData = {
        new object[] { DateTime.MinValue, false },
        new object[] { DateTime.Now.AddYears(-1), false },
        new object[] { DateTime.Now.AddMonths(-1), false },
        new object[] { DateTime.Now.AddDays(-2), false },
        new object[] { DateTime.Now.AddDays(-1), false },
        new object[] { DateTime.Now, true },
        new object[] { DateTime.Now.AddDays(1), false },
        new object[] { DateTime.Now.AddDays(2), false },
        new object[] { DateTime.Now.AddMonths(1), false },
        new object[] { DateTime.Now.AddYears(1), false },
        new object[] { DateTime.MaxValue, false }
    };

    [Theory, MemberData(nameof(IsInTodayData))]
    public void IsInToday(DateTime value, bool expected)
    {
        // Act
        bool isInToday = value.IsInToday();

        // Assert
        Assert.Equal(expected, isInToday);
    }


    // --- IsInTomorrow ---

    public static readonly object[][] IsInTomorrowData = {
        new object[] { DateTime.MinValue, false },
        new object[] { DateTime.Now.AddYears(-1), false },
        new object[] { DateTime.Now.AddMonths(-1), false },
        new object[] { DateTime.Now.AddDays(-2), false },
        new object[] { DateTime.Now.AddDays(-1), false },
        new object[] { DateTime.Now, false },
        new object[] { DateTime.Now.AddDays(1), true },
        new object[] { DateTime.Now.AddDays(2), false },
        new object[] { DateTime.Now.AddMonths(1), false },
        new object[] { DateTime.Now.AddYears(1), false },
        new object[] { DateTime.MaxValue, false }
    };

    [Theory, MemberData(nameof(IsInTomorrowData))]
    public void IsInTomorrow(DateTime value, bool expected)
    {
        // Act
        bool isInTomorrow = value.IsInTomorrow();

        // Assert
        Assert.Equal(expected, isInTomorrow);
    }


    // --- IsInYesterday ---

    public static readonly object[][] IsInYesterdayData = {
        new object[] { DateTime.MinValue, false },
        new object[] { DateTime.Now.AddYears(-1), false },
        new object[] { DateTime.Now.AddMonths(-1), false },
        new object[] { DateTime.Now.AddDays(-2), false },
        new object[] { DateTime.Now.AddDays(-1), true },
        new object[] { DateTime.Now, false },
        new object[] { DateTime.Now.AddDays(1), false },
        new object[] { DateTime.Now.AddDays(2), false },
        new object[] { DateTime.Now.AddMonths(1), false },
        new object[] { DateTime.Now.AddYears(1), false },
        new object[] { DateTime.MaxValue, false }
    };

    [Theory, MemberData(nameof(IsInYesterdayData))]
    public void IsInYesterday(DateTime value, bool expected)
    {
        // Act
        bool isInYesterday = value.IsInYesterday();

        // Assert
        Assert.Equal(expected, isInYesterday);
    }
}
