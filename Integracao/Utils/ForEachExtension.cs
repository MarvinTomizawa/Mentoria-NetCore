using System;
using System.Collections.Generic;

namespace Integracao.Utils
{
    public static class ForEachExtension
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach(var item in source)
            {
                action(item);
            }
        }
    }
}
