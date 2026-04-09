using System;
using MonitoringSystem.Strategies;

namespace MonitoringSystem.Handlers
{
    public class ConsoleHandler : EventHandlerBase
    {
        public ConsoleHandler(IFormatStrategy strategy) : base(strategy) { }

        protected override void SendMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[CONSOLE] {message}");
            Console.ResetColor();
        }

        protected override void LogResult()
        {
            Console.WriteLine($"[CONSOLE] Сообщение выведено в консоль в {DateTime.Now:T}");
        }
    }
}