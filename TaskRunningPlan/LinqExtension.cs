using System;
using System.Collections.Generic;
using System.Text;

namespace TaskRunningPlan
{
    public static class LinqExtension
    {
        public static void ForEach<T>(this IEnumerable<T> enumerators, Action<T> action)
        {
            foreach (var item in enumerators)
            {
                action(item);
            }
        }
    }
}
