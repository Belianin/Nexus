using System;

namespace Nexus.Core
{
    public static class ResultExtensions
    {
        public static Result<T2> Then<T1, T2>(this Result<T1> result, Func<T1, Result<T2>> callback)
        {
            return result.IsFail ? result.Error : callback(result);
        }

        public static Result Then<T1>(this Result<T1> result, Func<T1, Result> callback)
        {
            return result.IsFail ? result : callback(result);
        }
    }
}