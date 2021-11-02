using System.Collections.Generic;
using System.Linq;

namespace JA.Candidates.API.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> obj) => obj != null && obj.Any();
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> obj) => !obj.IsNotNullOrEmpty();
    }
}
