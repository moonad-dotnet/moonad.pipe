using System;

namespace Moonad
{
    public static partial class PipeExtensions
    {
        public static U Pipe<T, U>(this T input, Func<T, U> func) where T : notnull =>
            func(input);

        public static void Pipe<T>(this T input, Action<T> action) =>
            action(input);
    }
}
