using System;
using MonitoringSystem.Models;

namespace MonitoringSystem
{
    public class MetricEventArgs : EventArgs
    {
        public string EventType { get; }
        public MetricData Data { get; }

        public MetricEventArgs(string eventType, MetricData data)
        {
            EventType = eventType;
            Data = data;
        }
    }
}