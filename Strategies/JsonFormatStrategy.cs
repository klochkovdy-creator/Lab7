using System;

namespace MonitoringSystem.Strategies
{
    public class JsonFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp)
        {
            string escapedMessage = message.Replace("\"", "\\\"");
            return $"{{\"Timestamp\":\"{timestamp:o}\",\"Message\":\"{escapedMessage}\"}}";
        }
    }
}