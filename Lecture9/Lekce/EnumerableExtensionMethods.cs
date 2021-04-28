using System.Collections.Generic;

namespace Lesson09
{
    public static class EnumerableExtensionMethods
    {
        public static T Second<T>(this IEnumerable<T> collection)
        {
            using (var enumerator = collection.GetEnumerator()) // IDisposable
            {
                enumerator.MoveNext();
                var firstItem = enumerator.Current;

                enumerator.MoveNext();
                return enumerator.Current;
            }
        }
    }
}
