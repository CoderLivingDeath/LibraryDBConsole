using LibraryApp.Infrastructure;
using LibraryApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        void IRepository<Client>.Create(Client entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Client> IRepository<Client>.ReadAll()
        {
            throw new NotImplementedException();
        }

        Client IRepository<Client>.ReadById(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<Client>.Update(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
