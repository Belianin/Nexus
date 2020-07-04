using System;
using System.Threading.Tasks;

namespace Nexus.Core
{
    public static class ResultExtensions
    {
        public static Result<T2> Then<T1, T2>(this Result<T1> result, Func<T1, Result<T2>> callback)
        {
            return result.IsFail ? result.Error : callback(result);
        }
        
        public static async Task<Result<T2>> Then<T1, T2>(this Result<T1> result, Func<T1, Task<Result<T2>>> callback)
        {
            return result.IsFail ? result.Error : await callback(result).ConfigureAwait(false);
        }
        
        public static async Task<Result<T2>> Then<T1, T2>(this Task<Result<T1>> task, Func<T1, Task<Result<T2>>> callback)
        {
            var result = await task.ConfigureAwait(false);
            return await result.Then(callback).ConfigureAwait(false);
        }

        public static Result Then<T1>(this Result<T1> result, Func<T1, Result> callback)
        {
            return result.IsFail ? result : callback(result);
        }
        
        public static async Task<Result> Then<T1>(this Result<T1> result, Func<T1, Task<Result>> callback)
        {
            return result.IsFail ? result : await callback(result).ConfigureAwait(false);
        }
        
        public static async Task<Result> Then<T1>(this Task<Result<T1>> task, Func<T1, Task<Result>> callback)
        {
            var result = await task.ConfigureAwait(false);
            return result.IsFail ? result : await callback(result).ConfigureAwait(false);
        }
    }
}