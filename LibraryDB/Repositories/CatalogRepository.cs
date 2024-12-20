using LibraryApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories
{
    public class CatalogRepository : IRepository<Catalog>
    {
        private IDbConnection _connection;
        public CatalogRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<Catalog>.Create(Catalog entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Catalog> IRepository<Catalog>.ReadAll()
        {
            throw new NotImplementedException();
        }

        Catalog IRepository<Catalog>.ReadById(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<Catalog>.Update(Catalog entity)
        {
            throw new NotImplementedException();
        }
    }
}
