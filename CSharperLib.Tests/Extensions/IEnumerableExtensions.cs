using System;
using CSharperLib.Extensions;
using Xunit;

namespace CSharperLib.Tests.Extensions;

public class IEnumerableExtensions
{
    // --- None ---

    [Theory]
    [InlineData(new object[] { new string[] { }, true })]
    [InlineData(new object[] { new string[] { "ABC" }, false })]
    public void None(string[] source, bool expecteed)
    {
        // Act
        bool result = source.None();

        // Assert
        Assert.Equal(expecteed, result);
    }

    public static readonly Func<string, bool> nonePredicate = (string value) => value != "";

    public static readonly object[][] NoneWithPredicateDate = {
        new object[] { new string[] { }, nonePredicate, true },
        new object[] { new string[] { "" }, nonePredicate, true },
        new object[] { new string[] { "", "ABC" }, nonePredicate, false }
    };

    [Theory, MemberData(nameof(NoneWithPredicateDate))]
    public void NoneWithPredicate(string[] source, Func<string, bool> predicate, bool expecteed)
    {
        // Act
        bool result = source.None(predicate);

        // Assert
        Assert.Equal(expecteed, result);
    }
}
