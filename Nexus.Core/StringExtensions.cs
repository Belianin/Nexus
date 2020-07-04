using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nexus.Core
{
    public static class StringExtensions
    {
        public static Result<T> TryDeserialize<T>(this string value)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        
        public static bool EqualsIgnoreCase(this string str, string other) =>
            str.Equals(other, StringComparison.InvariantCultureIgnoreCase);
        
        public static IEnumerable<string> Chunk(this string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}