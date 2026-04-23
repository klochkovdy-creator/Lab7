using System;
using MonitoringSystem;
using MonitoringSystem.Handlers;
using MonitoringSystem.Strategies;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Система мониторинга событий ===\n");

        var monitor = new EventMonitor();

        var consoleTextHandler = new ConsoleHandler(new TextFormatStrategy());
        var consoleJsonHandler = new ConsoleHandler(new JsonFormatStrategy());
        var fileHtmlHandler = new FileHandler(new HtmlFormatStrategy(), "alerts.html");
        var emailHandler = new EmailHandler(new TextFormatStrategy(), "team@example.com");

        monitor.OnMetricExceeded += consoleTextHandler.ProcessEvent;
        monitor.OnMetricExceeded += consoleJsonHandler.ProcessEvent;
        monitor.OnMetricExceeded += fileHtmlHandler.ProcessEvent;
        monitor.OnMetricExceeded += emailHandler.ProcessEvent;  

        Console.WriteLine("--- Проверка метрик ---");
        monitor.CheckMetric("CPU", 85.5, 80.0);
        monitor.CheckMetric("Memory", 60.0, 75.0);
        monitor.CheckMetric("Network", 120.0, 100.0);

        Console.WriteLine("\n--- Меняем стратегию для консольного обработчика на JSON ---");
        consoleTextHandler.SetStrategy(new JsonFormatStrategy());
        monitor.CheckMetric("CPU", 92.0, 80.0);

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}