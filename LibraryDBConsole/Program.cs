using LibraryApp.Controllers;
using LibraryApp.Interfaces;
using LibraryDB;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace LibraryDBConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            App.AppConfiguration config = new("server=127.0.0.1;uid=root;pwd=26569;database=sys");

            App app = new App(config);
            app.Start();

            ILogService logService = app.GetServiceProvider().GetService<ILogService>();

            logService.OnNewMessage += LogService_OnNewMessage;

            logService.LogSystem("Start app", typeof(Program));


            DbController dbController = app.GetServiceProvider().GetService<DbController>();
            dbController.OpenConnection();
            dbController.LogConnectionInfo();
            dbController.CloseConnection();


            logService.OnNewMessage -= LogService_OnNewMessage;

            ILogService logService2 = app.GetServiceProvider().GetService<ILogService>();
        }

        private static void LogService_OnNewMessage(LibraryApp.Services.LogMessage obj)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{obj.Type}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($": {obj.Message}");
        }
    }
}
