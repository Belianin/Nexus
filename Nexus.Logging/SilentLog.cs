using Nexus.Logging.Utils;

namespace Nexus.Logging
{
    public class SilentLog : ILog
    {
        public void Dispose() {}
        public void Log(LogEvent logEvent) {}
        public void SetEnabled(LogLevel level, bool isEnabled) {}
    }
}