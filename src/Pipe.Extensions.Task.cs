using System;
using System.Threading;
using System.Threading.Tasks;

namespace Moonad
{
    public static partial class PipeExtensions
    {
        public static async Task<U> Pipe<T, U>(this T input, Func<T, Task<U>> func) where T : notnull =>
            await func(input);

        public static async Task<U> Pipe<T, U>(this T input, 
                                                    Func<T, CancellationToken, Task<U>> func, 
                                                    CancellationToken cancellationToken) where T : notnull =>
            await func(input, cancellationToken);

        public static async Task<U> Pipe<T, U>(this Task<T> input, Func<T, U> func) where T : notnull =>
            func(await input);

        public static async Task<U> Pipe<T, U>(this Task<T> input, Func<T, Task<U>> func) =>
            await func(await input);

        public static async Task<U> Pipe<T, U>(this Task<T> input, 
                                                    Func<T, CancellationToken, Task<U>> func, 
                                                    CancellationToken cancellationToken) where T : notnull =>
            await func(await input, cancellationToken);
    }
}
