using System.Data;

namespace LibraryApp.Interfaces
{
    public interface IDbConnectionService
    {
        bool ConnectionIsOpen();
        void CloseConnection();
        void SetNewConnection(string connectionString);
        IDbConnection GetConnetion();
        void OpenConnection();
        void ChangeDataBase(string dbName);
        IEnumerable<string> GetAllDataBaseNames();

    }
}