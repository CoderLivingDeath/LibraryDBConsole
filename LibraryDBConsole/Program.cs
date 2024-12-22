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
            App app = new App("server=127.0.0.1;uid = root; pwd=26569; database=library");

            view.Initialize(app, true);
        }
    }
}
