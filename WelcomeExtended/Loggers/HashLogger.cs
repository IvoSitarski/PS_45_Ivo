using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeExtended.Loggers
{
    public class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _name;

        public HashLogger(string name)
        {
            _logMessages = new ConcurrentDictionary<int, string>();
            _name = name;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine("-- LOGGER --");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"{logLevel}");
            messageToBeLogged.AppendFormat(" [{0}]", _name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($"{formatter(state, exception)}");
            Console.WriteLine("-- LOGGER --");
            Console.ResetColor();
            _logMessages[eventId.Id] = message;
        }
        public void PrintAllLogMessages()
        {
            foreach (var entry in _logMessages)
            {
                Console.WriteLine($"Log ID: {entry.Key} - Message: {entry.Value}");
            }
        }

        public void PrintLogMessage(int eventId)
        {
            if (_logMessages.TryGetValue(eventId, out var message))
            {
                Console.WriteLine($"Log Event ID: {eventId} - Message: {message}");
            }
            else
            {
                Console.WriteLine($"Log Event ID: {eventId} not found.");
            }
        }
    }
}
