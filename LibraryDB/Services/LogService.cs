using LibraryApp.Interfaces;

namespace LibraryApp.Services
{
    public class LogService : ILogService
    {
        public ICollection<LogMessage> LogMessages => _logMessages;
        private ICollection<LogMessage> _logMessages;

        public event Action<LogMessage> OnNewMessage;

        public LogService()
        {
            _logMessages = new List<LogMessage>();
        }

        public void Log(LogType type, string message, Type sender, Exception? ex = null)
        {
            LogMessage newMessage = new LogMessage(message, type, ex, DateTime.Now, sender);

            LogMessages.Add(newMessage);
            OnNewMessage?.Invoke(newMessage);
        }

        public void LogMessage(string message, Type sender) => Log(LogType.Message, message, sender);
        public void LogSystem(string message, Type sender) => Log(LogType.System, message, sender);
        public void LogWarning(string message, Type sender) => Log(LogType.Warning, message, sender);
        public void LogError(string message, Type sender, Exception ex) => Log(LogType.Error, message, sender, ex);
    }

    public readonly struct LogMessage
    {
        public readonly string Message;

        public readonly LogType Type;

        public readonly Exception? Exception;

        public readonly DateTime Date;

        public readonly Type Sender;

        public LogMessage(string message, LogType type, Exception? exception, DateTime date, Type sender)
        {
            Message = message;
            Type = type;
            Exception = exception;
            Date = date;
            Sender = sender;
        }
    }

    public enum LogType
    {
        Message, System, Warning, Error
    }
}
