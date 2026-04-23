using System;
using MonitoringSystem.Strategies;

namespace MonitoringSystem.Handlers
{
    public class EmailHandler : EventHandlerBase
    {
        private readonly string _emailAddress;

        public EmailHandler(IFormatStrategy strategy, string emailAddress = "admin@example.com")
            : base(strategy)
        {
            _emailAddress = emailAddress;
        }

        protected override void SendMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[EMAIL] Кому: {_emailAddress}");
            Console.WriteLine($"[EMAIL] Тема: Оповещение системы мониторинга");
            Console.WriteLine($"[EMAIL] Текст:\n{message}");
            Console.ResetColor();
        }

        protected override void LogResult()
        {
            Console.WriteLine($"[EMAIL] Письмо отправлено (имитация) в {DateTime.Now:T}");
        }
    }
}