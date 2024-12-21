using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using LibraryApp.Interfaces;

namespace LibraryApp.Services
{
    public class DbConnectionService : IDbConnectionService
    {
        private IDbConnection? _сonnection;
        private string _connectionString;

        public DbConnectionService()
        {

        }

        public DbConnectionService(string connectionString)
        {
            _connectionString = connectionString;
            _сonnection = new MySqlConnector.MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (_connectionString == null) throw new ArgumentNullException();
            _сonnection?.Open();
        }

        public void CloseConnection()
        {
            if (_connectionString == null) throw new ArgumentNullException();
            _сonnection?.Close();
        }

        public void SetNewConnection(string connectionString)
        {
            CloseConnection();
            _сonnection?.Dispose();
            _connectionString = connectionString;
            _сonnection = new MySqlConnector.MySqlConnection(connectionString);
        }

        public IDbConnection GetConnetion()
        {
            return _сonnection != null ? _сonnection : throw new ArgumentNullException();
        }

        public bool ConnectionIsOpen()
        {
            if (_connectionString == null) throw new ArgumentNullException();
            return _сonnection?.State == ConnectionState.Open;
        }
    }
}
