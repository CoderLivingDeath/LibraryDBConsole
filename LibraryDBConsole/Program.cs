using LibraryApp.Controllers;
using LibraryApp.Interfaces;
using LibraryApp.Services;
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
            MainView view = new MainView();
            App app = new App("server=127.0.0.1;database=sys");

            Console.WriteLine("=== Команда help для отображение списко команд.");
            Console.WriteLine("=== Используйте команду SetConnection [connection string] для формирования корректного соединения с базой данных MySQL.");
            Console.WriteLine("=== Используй команду ChangeBD [database name] для изменения базы данных.");
            Console.WriteLine("=== Для отображение всех баз данных используйте команду GetAllDbnames.");
            Console.WriteLine("=== Для открытия и закрытия соединения используйте команду OpenConnection и CloseConnection.");
            Console.WriteLine("=== Для отображение логов используйте команду Debug.");
            Console.WriteLine("=== Для отображение статуса текущего соединение используйте команду Status.");

            view.Initialize(app, true);
        }
    }
}
