using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Interfaces;
using LibraryApp.Services;
using Microsoft.Data.SqlClient;

namespace LibraryApp.Infrastructure
{
    public class DbConnectionProvider
    {
        private IDbConnectionService _connectionService;

        public DbConnectionProvider(IDbConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public IDbConnection GetConnection()
        {
            return _connectionService.GetConnetion();
        }
    }
}
