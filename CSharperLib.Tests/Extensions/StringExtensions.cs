using System.Globalization;

namespace CSharperLib.Tests.Extensions;

public class StringExtensions
{
    public StringExtensions()
    {
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");
    }


    // --- IsNullOrEmpty ---

    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData(" ", false)]
    [InlineData("\t", false)]
    [InlineData("\r", false)]
    [InlineData("\n", false)]
    [InlineData("\r\n", false)]
    [InlineData("ABC", false)]
    public void IsNullOrEmpty(string value, bool expected)
    {
        // Act
        bool result = value.IsNullOrEmpty();

        // Assert
        Assert.Equal(expected, result);
    }


    // --- IsNullOrWhiteSpace ---

    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData(" ", true)]
    [InlineData("\t", true)]
    [InlineData("\r", true)]
    [InlineData("\n", true)]
    [InlineData("\r\n", true)]
    [InlineData("ABC", false)]
    public void IsNullOrWhiteSpace(string value, bool expected)
    {
        // Act
        bool result = value.IsNullOrWhiteSpace();

        // Assert
        Assert.Equal(expected, result);
    }


    // --- IsInt ---

    [Theory]
    [InlineData("", false)]
    [InlineData("0", true)]
    [InlineData("123", true)]
    public void IsInt(string value, bool expected)
    {
        // Act
        bool isInt = value.IsInt();

        // Assert
        Assert.Equal(expected, isInt);
    }


    // --- ToInt ---

    [Theory]
    [InlineData("0", 0)]
    [InlineData("123", 123)]
    public void ToInt(string value, int expected)
    {
        // Act
        int result = value.ToInt();

        // Assert
        Assert.Equal(expected, result);
    }


    // --- IsIntNumber ---

    [Theory]
    [InlineData("", false)]
    [InlineData("0", true)]
    [InlineData("123", true)]
    [InlineData("123,456.", true)]
    [InlineData("123.456,", false)]
    public void IsIntNumber(string value, bool expected)
    {
        // Act
        bool isIntNumber = value.IsIntNumber();

        // Assert
        Assert.Equal(expected, isIntNumber);
    }


    // --- ToIntNumber ---

    [Theory]
    [InlineData("0", 0)]
    [InlineData("123", 123)]
    [InlineData("123,456.", 123_456)]
    public void ToIntNumber(string value, int expected)
    {
        // Act
        int result = value.ToIntNumber();

        // Assert
        Assert.Equal(expected, result);
    }


    // --- Trim ---

    [Theory]
    [InlineData("", "xyz", "")]
    [InlineData(" ", "xyz", " ")]
    [InlineData("xyz", "xyz", "")]
    [InlineData(" xyz", "xyz", " ")]
    [InlineData("xyz ", "xyz", " ")]
    [InlineData(" xyz ", "xyz", " xyz ")]
    [InlineData("xyzABC", "xyz", "ABC")]
    [InlineData("ABCxyz", "xyz", "ABC")]
    [InlineData("xyzABCxyz", "xyz", "ABC")]
    [InlineData("xyz ABC", "xyz", " ABC")]
    [InlineData("ABC xyz", "xyz", "ABC ")]
    [InlineData("xyz ABC xyz", "xyz", " ABC ")]
    [InlineData("XYZ ABC XYZ", "xyz", "XYZ ABC XYZ")]
    [InlineData("xyzxyz ABC xyzxyz", "xyz", " ABC ")]
    [InlineData("xyzXYZ ABC XYZxyz", "xyz", "XYZ ABC XYZ")]
    [InlineData("XYZxyz ABC xyzXYZ", "xyz", "XYZxyz ABC xyzXYZ")]
    [InlineData("XYZXYZ ABC XYZXYZ", "xyz", "XYZXYZ ABC XYZXYZ")]
    public void Trim(string value, string trimString, string expected)
    {
        // Act
        string result = value.Trim(trimString);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", "xyz", "")]
    [InlineData(" ", "xyz", " ")]
    [InlineData("xyz", "xyz", "")]
    [InlineData(" xyz", "xyz", " ")]
    [InlineData("xyz ", "xyz", " ")]
    [InlineData(" xyz ", "xyz", " xyz ")]
    [InlineData("xyzABC", "xyz", "ABC")]
    [InlineData("ABCxyz", "xyz", "ABC")]
    [InlineData("xyzABCxyz", "xyz", "ABC")]
    [InlineData("xyz ABC", "xyz", " ABC")]
    [InlineData("ABC xyz", "xyz", "ABC ")]
    [InlineData("xyz ABC xyz", "xyz", " ABC ")]
    [InlineData("XYZ ABC XYZ", "xyz", " ABC ")]
    [InlineData("xyzxyz ABC xyzxyz", "xyz", " ABC ")]
    [InlineData("xyzXYZ ABC XYZxyz", "xyz", " ABC ")]
    [InlineData("XYZxyz ABC xyzXYZ", "xyz", " ABC ")]
    [InlineData("XYZXYZ ABC XYZXYZ", "xyz", " ABC ")]
    public void Trim_IgnoreCase(string value, string trimString, string expected)
    {
        // Act
        string result = value.Trim(trimString, ignoreCase: true);

        // Assert
        Assert.Equal(expected, result);
    }


    // --- TrimEnd ---

    [Theory]
    [InlineData("", "xyz", "")]
    [InlineData(" ", "xyz", " ")]
    [InlineData("xyz", "xyz", "")]
    [InlineData(" xyz", "xyz", " ")]
    [InlineData("xyz ", "xyz", "xyz ")]
    [InlineData(" xyz ", "xyz", " xyz ")]
    [InlineData("xyzABC", "xyz", "xyzABC")]
    [InlineData("ABCxyz", "xyz", "ABC")]
    [InlineData("xyzABCxyz", "xyz", "xyzABC")]
    [InlineData("xyz ABC", "xyz", "xyz ABC")]
    [InlineData("ABC xyz", "xyz", "ABC ")]
    [InlineData("xyz ABC xyz", "xyz", "xyz ABC ")]
    [InlineData("XYZ ABC XYZ", "xyz", "XYZ ABC XYZ")]
    [InlineData("xyzxyz ABC xyzxyz", "xyz", "xyzxyz ABC ")]
    [InlineData("xyzXYZ ABC XYZxyz", "xyz", "xyzXYZ ABC XYZ")]
    [InlineData("XYZxyz ABC xyzXYZ", "xyz", "XYZxyz ABC xyzXYZ")]
    [InlineData("XYZXYZ ABC XYZXYZ", "xyz", "XYZXYZ ABC XYZXYZ")]
    public void TrimEnd(string value, string trimString, string expected)
    {
        // Act
        string result = value.TrimEnd(trimString);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", "xyz", "")]
    [InlineData(" ", "xyz", " ")]
    [InlineData("xyz", "xyz", "")]
    [InlineData(" xyz", "xyz", " ")]
    [InlineData("xyz ", "xyz", "xyz ")]
    [InlineData(" xyz ", "xyz", " xyz ")]
    [InlineData("xyzABC", "xyz", "xyzABC")]
    [InlineData("ABCxyz", "xyz", "ABC")]
    [InlineData("xyzABCxyz", "xyz", "xyzABC")]
    [InlineData("xyz ABC", "xyz", "xyz ABC")]
    [InlineData("ABC xyz", "xyz", "ABC ")]
    [InlineData("xyz ABC xyz", "xyz", "xyz ABC ")]
    [InlineData("XYZ ABC XYZ", "xyz", "XYZ ABC ")]
    [InlineData("xyzxyz ABC xyzxyz", "xyz", "xyzxyz ABC ")]
    [InlineData("xyzXYZ ABC XYZxyz", "xyz", "xyzXYZ ABC ")]
    [InlineData("XYZxyz ABC xyzXYZ", "xyz", "XYZxyz ABC ")]
    [InlineData("XYZXYZ ABC XYZXYZ", "xyz", "XYZXYZ ABC ")]
    public void TrimEnd_IgnoreCase(string value, string trimString, string expected)
    {
        // Act
        string result = value.TrimEnd(trimString, ignoreCase: true);

        // Assert
        Assert.Equal(expected, result);
    }


    // --- TrimStart ---

    [Theory]
    [InlineData("", "xyz", "")]
    [InlineData(" ", "xyz", " ")]
    [InlineData("xyz", "xyz", "")]
    [InlineData(" xyz", "xyz", " xyz")]
    [InlineData("xyz ", "xyz", " ")]
    [InlineData(" xyz ", "xyz", " xyz ")]
    [InlineData("xyzABC", "xyz", "ABC")]
    [InlineData("ABCxyz", "xyz", "ABCxyz")]
    [InlineData("xyzABCxyz", "xyz", "ABCxyz")]
    [InlineData("xyz ABC", "xyz", " ABC")]
    [InlineData("ABC xyz", "xyz", "ABC xyz")]
    [InlineData("xyz ABC xyz", "xyz", " ABC xyz")]
    [InlineData("XYZ ABC XYZ", "xyz", "XYZ ABC XYZ")]
    [InlineData("xyzxyz ABC xyzxyz", "xyz", " ABC xyzxyz")]
    [InlineData("xyzXYZ ABC XYZxyz", "xyz", "XYZ ABC XYZxyz")]
    [InlineData("XYZxyz ABC xyzXYZ", "xyz", "XYZxyz ABC xyzXYZ")]
    [InlineData("XYZXYZ ABC XYZXYZ", "xyz", "XYZXYZ ABC XYZXYZ")]
    public void TrimStart(string value, string trimString, string expected)
    {
        // Act
        string result = value.TrimStart(trimString);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", "xyz", "")]
    [InlineData(" ", "xyz", " ")]
    [InlineData("xyz", "xyz", "")]
    [InlineData(" xyz", "xyz", " xyz")]
    [InlineData("xyz ", "xyz", " ")]
    [InlineData(" xyz ", "xyz", " xyz ")]
    [InlineData("xyzABC", "xyz", "ABC")]
    [InlineData("ABCxyz", "xyz", "ABCxyz")]
    [InlineData("xyzABCxyz", "xyz", "ABCxyz")]
    [InlineData("xyz ABC", "xyz", " ABC")]
    [InlineData("ABC xyz", "xyz", "ABC xyz")]
    [InlineData("xyz ABC xyz", "xyz", " ABC xyz")]
    [InlineData("XYZ ABC XYZ", "xyz", " ABC XYZ")]
    [InlineData("xyzxyz ABC xyzxyz", "xyz", " ABC xyzxyz")]
    [InlineData("xyzXYZ ABC XYZxyz", "xyz", " ABC XYZxyz")]
    [InlineData("XYZxyz ABC xyzXYZ", "xyz", " ABC xyzXYZ")]
    [InlineData("XYZXYZ ABC XYZXYZ", "xyz", " ABC XYZXYZ")]
    public void TrimStart_IgnoreCase(string value, string trimString, string expected)
    {
        // Act
        string result = value.TrimStart(trimString, ignoreCase: true);

        // Assert
        Assert.Equal(expected, result);
    }


    // --- Join ---

    [Fact]
    public void Join_StringCollection_String()
    {
        // Arrange
        var stringList = new List<string>() { "ABC", "XYZ" };

        // Act
        string result = stringList.Join(", ");

        // Assert
        Assert.Equal("ABC, XYZ", result);
    }


    // --- RemoveEmptyLines ---

    [Theory]
    [InlineData("", "")]
    [InlineData(" ", "")]
    [InlineData("ABC", "ABC")]
    [InlineData("\t", "")]
    [InlineData("\r", "")]
    [InlineData("\n", "")]
    [InlineData("\r\n", "")]
    [InlineData("\r\n\r\n", "")]
    [InlineData("\r\nABC\r\n", "ABC\r\n")]
    [InlineData("ABC\r\n\r\n", "ABC\r\n")]
    [InlineData("\r\nABC\r\n\r\n", "ABC\r\n")]
    [InlineData("\r\n\r\nABC\r\n\r\n\r\n", "ABC\r\n")]
    [InlineData("\r\n123\r\n\r\nABC\r\n\r\nXYZ\r\n\r\n", "123\r\nABC\r\nXYZ\r\n")]
    public void RemoveEmptyLines(string value, string expected)
    {
        // Act
        string result = value.RemoveEmptyLines();

        // Assert
        Assert.Equal(expected, result);
    }
}
