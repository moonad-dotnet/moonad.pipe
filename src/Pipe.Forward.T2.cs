using System;
using System.Threading;
using System.Threading.Tasks;

namespace Moonad
{
    public static partial class PipeExtensions
    {
        public static void Pipe<T1, T2>(this (T1, T2) instance, Action<T1, T2> action) where T1 : notnull where T2 : notnull =>
            action(instance.Item1, instance.Item2);

        public static async Task Pipe<T1, T2>(this (T1, T2) instance, Func<T1, T2, Task> func) where T1: notnull where T2: notnull =>
            await func(instance.Item1, instance.Item2);

        public static async Task Pipe<T1, T2>(this Task<(T1, T2)> instance, Action<T1, T2> action) where T1: notnull where T2: notnull =>
            (await instance).Pipe(action);

        public static async Task Pipe<T1, T2>(this Task<(T1, T2)> instance, Func<T1, T2, Task> func) where T1: notnull where T2: notnull =>
            await (await instance).Pipe(func);

        public static async Task Pipe<T1, T2>(this (T1, T2) instance,
                                            Func<T1, T2, CancellationToken, Task> func,
                                            CancellationToken cancellationToken = default) where T1: notnull where T2: notnull =>
            await func(instance.Item1, instance.Item2, cancellationToken);

        public static async Task Pipe<T1, T2>(this Task<(T1, T2)> instance,
                                                   Func<T1, T2, CancellationToken, Task> func,
                                                   CancellationToken cancellationToken = default) where T1: notnull where T2: notnull =>
            await (await instance).Pipe(func, cancellationToken);

        public static U Pipe<T1, T2, U>(this (T1, T2) instance, Func<T1, T2, U> func) where T1 : notnull where T2 : notnull =>
            func(instance.Item1, instance.Item2);

        public static async Task<U> Pipe<T1, T2, U>(this (T1, T2) instance, Func<T1, T2, Task<U>> func) where T1 : notnull where T2 : notnull =>
            await func(instance.Item1, instance.Item2);

        public static async Task<U> Pipe<T1, T2, U>(this Task<(T1, T2)> instance, Func<T1, T2, U> func) where T1 : notnull where T2 : notnull =>
            (await instance).Pipe(func);

        public static async Task<U> Pipe<T1, T2, U>(this Task<(T1, T2)> instance, Func<T1, T2, Task<U>> func) where T1: notnull where T2: notnull =>
            await (await instance).Pipe(func);

        public static async Task<U> PipeAsync<T1, T2, U>(this (T1, T2) instance, 
                                                              Func<T1, T2, CancellationToken, Task<U>> func,
                                                              CancellationToken cancellationToken = default) where T1 : notnull where T2 : notnull =>
            await instance.Pipe(inst => func(inst.Item1, inst.Item2, cancellationToken));

        public static async Task<U> PipeAsync<T1, T2, U>(this Task<(T1, T2)> instance,
                                                              Func<T1, T2, CancellationToken, Task<U>> func,
                                                              CancellationToken cancellationToken = default) where T1 : notnull where T2 : notnull =>
            await (await instance).PipeAsync(func, cancellationToken);
    }
}
