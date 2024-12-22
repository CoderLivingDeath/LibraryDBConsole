using LibraryApp.Infrastructure;
using LibraryApp.Models.Data;
using Dapper;
namespace LibraryApp.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private DbConnectionProvider _connection;
        public ClientRepository(DbConnectionProvider connection)
        {
            _connection = connection;
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Clients WHERE Id = @Id";
            _connection.GetConnection().Execute(query, new { Id = id });
        }

        public void Create(Client entity)
        {
            string query = "INSERT INTO Client (FirstName, SecondName, PhoneNumber) VALUES (@FirstName, @SecondName, @PhoneNumber)";
            _connection.GetConnection().Execute(query, entity);
        }

        public IEnumerable<Client> ReadAll()
        {
            string query = "SELECT * FROM Client";
            return _connection.GetConnection().Query<Client>(query);
        }

        public Client ReadById(int id)
        {
            string query = "SELECT * FROM Client WHERE Id = @Id";
            var client = _connection.GetConnection().QueryFirstOrDefault<Client>(query, new { Id = id });

            if (client == null)
            {
                throw new InvalidOperationException();
            }

            return client;
        }

        public void Update(Client entity)
        {
            string query = $"UPDATE Client SET FirstName = {entity.FirstName}, SecondName = {entity.SecondName}, PhoneNumber = {entity.PhoneNumber} WHERE Id = @Id";
            _connection.GetConnection().Execute(query, entity);
        }
    }
}
