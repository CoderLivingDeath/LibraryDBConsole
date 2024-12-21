using LibraryApp;
using LibraryApp.Controllers;
using LibraryApp.Interfaces;
using LibraryApp.Services;
using LibraryDB;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryDBConsole
{
    public class MainView
    {
        public bool IsStarted => _isStarted;

        private bool _isStarted = false;
        private bool _onDebug = false;

        private App _app;

        private Dictionary<string, Action<IServiceProvider, string[]>> _commands = new Dictionary<string, Action<IServiceProvider, string[]>>();

        public MainView()
        {

        }

        public void Initialize(App app, bool debug = false)
        {
            if (!app.IsStarting())
            {
                app.Start();
            }
            _app = app;

            EnableDebug();

            InitializeCommands();
            Start();
        }

        private void InitializeCommands()
        {
            Dictionary<string, Action<IServiceProvider, string[]>> commands = new Dictionary<string, Action<IServiceProvider, string[]>>();

            commands.Add("debug", DebugSwich);
            commands.Add("status", ShowStatusHandler);
            commands.Add("clear", ClearConsoleHandler);
            commands.Add("openconnection", OpenConnectionHandler);
            commands.Add("closeconnection", CloseConnectionHandler);
            commands.Add("setconnection", SetConnectionHandler);

            commands.Add("help", ShowHelpHandler);

            _commands = commands;
        }

        private void SetConnectionHandler(IServiceProvider provider, string[] args)
        {
            DbController? dbController = provider.GetService<DbController>();
            if (dbController == null) throw new Exception();

            Result result = dbController.SetNewConnection(args[0]);

            if (result.Status == ResultStatus.Error)
            {
                Console.WriteLine("==Error==");
                Console.WriteLine(result.ErrorMessage);
            }
        }

        private void CloseConnectionHandler(IServiceProvider provider, string[] args)
        {
            DbController? dbController = provider.GetService<DbController>();
            if (dbController == null) throw new Exception();

            Result result = dbController.CloseConnection();

            if(result.Status == ResultStatus.Error)
            {
                Console.WriteLine("==Error==");
                Console.WriteLine(result.ErrorMessage);
            }
        }

        private void OpenConnectionHandler(IServiceProvider provider, string[] args)
        {
            DbController? dbController = provider.GetService<DbController>();
            if (dbController == null) throw new Exception();

            Result result =dbController.OpenConnection();
            if (result.Status == ResultStatus.Error)
            {
                Console.WriteLine("==Error==");
                Console.WriteLine(result.ErrorMessage);
            }
        }

        private void ClearConsoleHandler(IServiceProvider provider, string[] args)
        {
            Console.Clear();
        }

        private void DebugSwich(IServiceProvider provider, string[] args)
        {
            if(_onDebug)
            {
                DisableDebug();
                Console.WriteLine("[Выключен режим DEBUG]");
            }
            else
            {
                Console.WriteLine("[Включен режим DEBUG]");
                EnableDebug();
            }
        }

        private void ShowHelpHandler(IServiceProvider provider, string[] args)
        {
            Console.WriteLine("Список комманд:");
            foreach (var command in _commands.Keys)
            {
                Console.WriteLine(command);
            }
        }

        private void ShowStatusHandler(IServiceProvider provider, string[] args)
        {
            DbController? dbController = provider.GetService<DbController>();
            if (dbController == null)
            {
                throw new Exception();
            }

            Result<ConnectionStatus> result = dbController.GetConnectionStatus();

            if(result.Status == ResultStatus.Error)
            {
                Console.WriteLine("===error===");
                Console.WriteLine(result.ErrorMessage);
            }

            if (result.Status == ResultStatus.Success)
            {
                ConnectionStatus status = result.Value;

                Console.WriteLine("Status:");
                Console.WriteLine($"Connections state: {status.ConnectionState}.");
                Console.WriteLine($"Connection string: {status.ConnectionString}.");
                Console.WriteLine($"DataBase {status.DataBase}.");
                Console.WriteLine($"Timeout: {status.ConnectionTimeout};");
            }
        }

        private void Start()
        {
            _isStarted = true;
            while (IsStarted)
            {
                Message message = ListenMessage();
                HandleMessage(message);
            }
        }

        private void HandleMessage(Message message)
        {
            var command = message.Text.Trim().Split().First().ToLower();
            
            var args = message.Text.Trim().Split().Skip(1).ToArray();

            if (_commands.TryGetValue(command, out Action<IServiceProvider, string[]>? action))
            {
                if (action == null) throw new Exception();

                action.Invoke(_app.GetServiceProvider(), args);
            }
            else
            {
                Console.WriteLine($"Такой команды несуществует: {command}");
            }
        }

        private Message ListenMessage()
        {
            Console.Write("Ввод: ");
            string? message = ConsoleHelper.ListenString();

            if (message == null)
            {
                throw new Exception();
            }

            return new Message(message);
        }

        public void EnableDebug()
        {
            if (_onDebug) return;

            ILogService? logService = _app.GetServiceProvider().GetService<ILogService>();
            if (logService == null)
            {
                throw new Exception();
            }

            logService.OnNewMessage += LogService_OnNewMessage;
            _onDebug = true;
        }

        public void DisableDebug()
        {
            if (!_onDebug) return;

            ILogService? logService = _app.GetServiceProvider().GetService<ILogService>();
            if (logService == null)
            {
                throw new Exception();
            }

            logService.OnNewMessage -= LogService_OnNewMessage;
            _onDebug = false;
        }

        private void LogService_OnNewMessage(LogMessage obj)
        {
            switch (obj.Type)
            {
                case LogType.System:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogType.Message:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            Console.Write("[DEBUG] ");
            Console.Write($"{obj.Type}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($": {obj.Message}");
        }

        ~MainView()
        {
            Console.WriteLine("desturct");
        }
    }

    public readonly struct Message
    {
        public readonly string Text;

        public Message(string text)
        {
            Text = text;
        }
    }
}
