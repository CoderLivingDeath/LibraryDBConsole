using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Interfaces;

namespace LibraryApp.Services
{
    public class DbConnectionService : IDbConnectionService
    {
        private IDbConnection _activeConnection;

        public DbConnectionService(string connectionString)
        {
            _activeConnection = new MySqlConnector.MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            _activeConnection.Open();
        }

        public void CloseConnection()
        {
            _activeConnection.Close();
        }

        public IDbConnection GetConnetion()
        {
            return _activeConnection;
        }

        public bool ConnectionIsOpen() => _activeConnection.State == ConnectionState.Open;
    }
}
