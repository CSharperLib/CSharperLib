namespace CSharperLib.Extensions;

/// <summary>
/// IEnumerable Extensions
/// </summary>
public static class IEnumerableExtensions
{
    /// <summary>
    /// Determines whether a sequence is empty.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{TSource}"/> System.Collections.Generic.IEnumerable`1 to check for emptiness.</param>
    /// <returns><see langword="true"/> if the source sequence is empty; otherwise, <see langword="false"/>.</returns>
    public static bool None<TSource>(this IEnumerable<TSource> source)
    {
        return !source.Any();
    }

    /// <summary>
    /// Determines whether a sequence is empty or no elements of a sequence satisfies a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns><see langword="true"/> if the source sequence is empty or no elements passes the test in the specified predicate; otherwise, <see langword="false"/>.</returns>
    public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        return !source.Any(predicate);
    }
}
