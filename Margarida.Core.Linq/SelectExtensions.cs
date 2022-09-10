using System;
using System.Linq.Expressions;

namespace Margarida.Core.Linq
{
    public static class SelectExtensions
    {
        public static T Select<T>(this T instance, Action<T> action)
        {
            action(instance);
            return instance;
        }

        public static TResult Select<T,TResult>(this T instance, Func<T,TResult> function)
        {
            return function(instance);
        }
    }
}
