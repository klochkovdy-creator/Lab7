using MonitoringSystem.Models;
using MonitoringSystem.Strategies;

namespace MonitoringSystem.Handlers
{
    public abstract class EventHandlerBase
    {
        protected IFormatStrategy _formatStrategy;

        protected EventHandlerBase(IFormatStrategy strategy)
        {
            _formatStrategy = strategy;
        }

        public void SetStrategy(IFormatStrategy strategy)
        {
            _formatStrategy = strategy;
        }

        public void ProcessEvent(MetricEventArgs e)
        {
            string formattedMessage = FormatMessage(e.EventType, e.Data);
            SendMessage(formattedMessage);
            LogResult();
        }

        protected virtual string FormatMessage(string eventType, MetricData data)
        {
            string rawMessage = $"{eventType}: {data}";
            return _formatStrategy.Format(rawMessage, data.Timestamp);
        }

        protected abstract void SendMessage(string message);

        protected virtual void LogResult()
        {
        }
    }
}