using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Dapper;
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

        public void ChangeDataBase(string dbName)
        {
            if (_сonnection == null)
            {
                throw new Exception();
            }

            _сonnection.ChangeDatabase(dbName);
        }

        public IEnumerable<string> GetAllDataBaseNames()
        {
            if(_сonnection == null)
            {
                throw new Exception();
            }

            var schemas = _сonnection.Query<string>("SELECT schema_name FROM information_schema.schemata");

            return schemas;
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
