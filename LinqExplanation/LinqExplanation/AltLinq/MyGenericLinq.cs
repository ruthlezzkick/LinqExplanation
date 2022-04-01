using System;
using System.Collections.Generic;

namespace LinqExplanation.AltLinq
{
    public static class MyGenericLinq
    {

        public delegate bool GenericCheckIfConditionIsTrue<T>(T element);
        //public Func<T,bool>

        public static IEnumerable<T> GenericWhere<T>(IEnumerable<T> elements, GenericCheckIfConditionIsTrue<T> func)
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

        public static IEnumerable<T> GenericWhereByFunc<T>(IEnumerable<T> elements, Func<T,bool> func)
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
