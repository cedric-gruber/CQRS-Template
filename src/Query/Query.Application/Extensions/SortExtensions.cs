using $safeprojectname$.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Extensions
{
    internal static class SortExtensions
    {
        internal static IOrderedEnumerable<TSource> Sort<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, SortOrder sortOrder)
        {
            switch (sortOrder)
            {
                case SortOrder.Ascending: return source.OrderBy(keySelector);
                case SortOrder.Descending: return source.OrderByDescending(keySelector);
                default: throw new NotImplementedException($"The sortOrder enum value {sortOrder} is not implemented");
            }
        }
    }
}
