using System;

namespace MonitoringSystem.Strategies
{
    public class HtmlFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp)
        {
            return $"<p><strong>{timestamp:HH:mm:ss}</strong> {message}</p>";
        }
    }
}