using System;

namespace Margarida.Core.Linq
{
    public static class SelectExtension
    {
        public static T Select<T>(this T instance, Action<T> action)
        {
            action(instance);
            return instance;
        }
    }
}
