using System;
using System.Collections.Generic;

namespace LinqExplanation.AltLinq
{
    public static class MyExtLinq
    {
        public static IEnumerable<T> MyOwnWhere<T>(this IEnumerable<T> elements, Func<T,bool> func)
        {
            var resultList = new List<T>();
            foreach (var element in elements)
            {
                if (func(element))
                {
                    resultList.Add(element);
                }
            }
            return resultList;
        }
    }
}
