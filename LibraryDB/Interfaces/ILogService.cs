using LibraryApp.Services;

namespace LibraryApp.Interfaces
{
    public interface ILogService
    {
        ICollection<LogMessage> LogMessages { get; }

        event Action<LogMessage> OnNewMessage;

        void Log(LogType type, string message, Type sender, Exception? ex = null);
        void LogMessage(string message, Type sender);
        void LogSystem(string message, Type sender);
        void LogWarning(string message, Type sender);
        void LogError(string message, Type sender, Exception ex);
    }
}