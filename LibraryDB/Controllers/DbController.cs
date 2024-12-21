using LibraryApp.Interfaces;
using LibraryApp.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    public record struct ConnectionStatus(string ConnectionState, string ConnectionString, string DataBase, string ConnectionTimeout);

    public class DbController
    {
        private IDbConnectionService _connectionService;
        private ILogService _logService;
        public DbController(IDbConnectionService connectionService, ILogService logService)
        {
            _connectionService = connectionService;
            _logService = logService;
        }

        public Result<ConnectionStatus> GetConnectionStatus()
        {
            try
            {
                IDbConnection connection = _connectionService.GetConnetion();
                string connectionState = connection.State.ToString();
                string connectionString = connection.ConnectionString;
                string database = connection.Database;
                string ConnectionTimeout = connection.ConnectionTimeout.ToString();

                ConnectionStatus status = new ConnectionStatus(connectionState,connectionString, database, ConnectionTimeout);

                _logService.LogMessage($"Get connection status.", typeof(DbController));

                return new Result<ConnectionStatus>()
                {
                    Value = status,
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                _logService.LogError($"error on get connection status.", typeof(DbController), ex);
                return new Result<ConnectionStatus>()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error,
                };
            }
        }

        public Result SetNewConnection(string connectionString)
        {
            try
            {
                _connectionService.SetNewConnection(connectionString);
                _logService.LogMessage($"set new connection with connection string: {connectionString}", typeof(DbController));

                return new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                _logService.LogError($"error on set new connection with connection string: {connectionString}", typeof(DbController), ex);
                return new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error,
                };
            }
        }

        public Result LogConnectionInfo()
        {
            try
            {
                var connection = _connectionService.GetConnetion();

                _logService.LogMessage($"\nConnection status: {connection.State};\nConnectionString: {connection.ConnectionString};\n" +
                    $"Database: {connection.Database};\nConnection sql: {_connectionService.GetConnetion().GetType()}", typeof(DbController));

                return new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                _logService.LogError("log error.", typeof(DbController), ex);
                return new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error,
                };
            }
        }

        public Result OpenConnection()
        {
            _logService.LogSystem("Opening database connection...", typeof(DbController));

            if (_connectionService.ConnectionIsOpen())
            {
                _logService.LogSystem("Connection already open.", typeof(DbController));
                return new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };
            }

            try
            {
                _connectionService.OpenConnection();
                _logService.LogSystem("Connection open.", typeof(DbController));
                return new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                _logService.LogError("Connection error.", typeof(DbController), ex);
                return new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error,
                };
            }
        }

        public Result CloseConnection()
        {
            _logService.LogSystem("Clossing database connection...", typeof(DbController));

            if (!_connectionService.ConnectionIsOpen())
            {
                _logService.LogSystem("Connection already close.", typeof(DbController));
                return new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };
            }

            try
            {
                _logService.LogSystem("Connection close.", typeof(DbController));
                _connectionService.CloseConnection();
                return new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                _logService.LogError("Connection error.", typeof(DbController), ex);
                return new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error,
                };
            }
        }

        public Result<IDbConnection> GetConnection()
        {
            _logService.LogSystem("Try get connection to databes...", typeof(DbController));
            try
            {
                _logService.LogSystem("Connection recivied.", typeof(DbController));
                return new Result<IDbConnection>()
                {
                    Value = _connectionService.GetConnetion(),
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                _logService.LogError("Connection error.", typeof(DbController), ex);
                return new Result<IDbConnection>()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error,
                };
            }
        }
    }
}
