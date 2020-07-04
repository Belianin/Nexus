using System;
using System.Globalization;
using System.Linq;

namespace Nexus.Logging.Utils
{
    public static class LogFormatter
    {
        public static string Format(LogEvent logEvent)
        {
            return $"{logEvent.DateTime.ToString("yyyy-MM-dd HH:mm:ss,fff", CultureInfo.CurrentCulture)} " +
                   $"{TagsToString(logEvent)} " +
                   $"{logEvent.Message}";
        }

        public static bool IsLogLevel(string log, LogLevel level) => log.Contains($"[{level.ToString().ToUpper()}]");

        public static DateTime GetLogTime(string log) => DateTime.ParseExact(
            log.Substring(0, 23), "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture);

        private static string TagsToString(LogEvent logEvent)
        {
            var levelText = logEvent.Level.ToString().ToUpper();
            return logEvent.Context.Count == 0
                ? levelText
                : $"{levelText} {string.Join(" ", logEvent.Context.Select(t => $"[{t}]"))}";
        }
    }
}