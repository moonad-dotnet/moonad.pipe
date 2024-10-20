using System;
using System.Threading;
using System.Threading.Tasks;

namespace Moonad
{
    public static partial class PipeExtensions
    {
        public static void Pipe<T>(this T instance, Action<T> action) where T : notnull =>
            action(instance);

        public static async Task Pipe<T>(this Task<T> instance, Action<T> action) where T : notnull =>
            action(await instance);

        public static async Task Pipe<T>(this T instance, Func<T, Task> func) where T : notnull =>
            await func(instance);

        public static async Task Pipe<T>(this T instance, 
                                              Func<T, CancellationToken, Task> func, 
                                              CancellationToken cancellationToken = default) where T : notnull =>
            await func(instance, cancellationToken);

        public static async Task Pipe<T>(this Task<T> instance, Func<T, Task> func) where T : notnull =>
            await func(await instance);

        public static async Task Pipe<T>(this Task<T> instance,
                                              Func<T, CancellationToken, Task> func,
                                              CancellationToken cancellationToken = default) where T : notnull =>
            await func(await instance, cancellationToken);

        public static U Pipe<T, U>(this T instance, Func<T, U> func) where T : notnull =>
            func(instance);

        public static async Task<U> Pipe<T, U>(this T instance, Func<T, Task<U>> func) where T : notnull =>
            await func(instance);

        public static async Task<U> Pipe<T, U>(this T instance,
                                                    Func<T, CancellationToken, Task<U>> func,
                                                    CancellationToken cancellationToken) where T : notnull =>
            await func(instance, cancellationToken);

        public static async Task<U> Pipe<T, U>(this Task<T> instance, Func<T, U> func) where T : notnull =>
            func(await instance);

        public static async Task<U> Pipe<T, U>(this Task<T> instance, Func<T, Task<U>> func) where T : notnull =>
            await func(await instance);

        public static async Task<U> Pipe<T, U>(this Task<T> instance,
                                                    Func<T, CancellationToken, Task<U>> func,
                                                    CancellationToken cancellationToken) where T : notnull =>
            await func(await instance, cancellationToken);
    }
}
