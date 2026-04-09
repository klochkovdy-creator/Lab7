using System;
using MonitoringSystem.Models;

namespace MonitoringSystem
{
    public class EventMonitor
    {
        public event MetricEventHandler OnMetricExceeded;

        public void CheckMetric(string metricName, double value, double threshold)
        {
            Console.WriteLine($"[Monitor] Проверка {metricName}: {value:F2} (порог {threshold:F2})");

            if (value > threshold)
            {
                var eventData = new MetricData(metricName, value, threshold, DateTime.Now);
                OnMetricExceeded?.Invoke(new MetricEventArgs(metricName + "_Exceeded", eventData));
            }
        }
    }
}