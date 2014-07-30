using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exprGrammar
{
    static class Extensions
    {
        /// <summary>
        /// Wraps this object instance into an IEnumerable&lt;T&gt;
        /// consisting of a single item.
        /// </summary>
        /// <typeparam name="T"> Type of the wrapped object.</typeparam>
        /// <param name="item"> The object to wrap.</param>
        /// <returns>
        /// An IEnumerable&lt;T&gt; consisting of a single item.
        /// </returns>
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }
    }
}
