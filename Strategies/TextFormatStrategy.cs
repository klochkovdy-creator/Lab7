using System;

namespace MonitoringSystem.Strategies
{
    public class TextFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp)
        {
            return $"[{timestamp:HH:mm:ss}] {message}";
        }
    }
}