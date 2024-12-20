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
    public class DbController
    {
        private IDbConnectionService _connectionService;
        private ILogService _logService;
        public DbController(IDbConnectionService connectionService, ILogService logService)
        {
            _connectionService = connectionService;
            _logService = logService;
        }

        public Result LogConnectionInfo()
        {
            try
            {
                var connection = _connectionService.GetConnetion();
                _logService.LogMessage($"\nConnection status: {connection.State};\nConnectionString: {connection.ConnectionString};\nDatabase: {connection.Database};\nConnection sql: {_connectionService.GetConnetion().GetType()}", typeof(DbController));
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
