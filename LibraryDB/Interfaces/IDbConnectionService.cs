using System.Data;

namespace LibraryApp.Interfaces
{
    public interface IDbConnectionService
    {
        bool ConnectionIsOpen();
        void CloseConnection();
        IDbConnection GetConnetion();
        void OpenConnection();
    }
}