using LibraryApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private IDbConnection _connection;
        public CompanyRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<Company>.Create(Company entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Company> IRepository<Company>.ReadAll()
        {
            throw new NotImplementedException();
        }

        Company IRepository<Company>.ReadById(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<Company>.Update(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
