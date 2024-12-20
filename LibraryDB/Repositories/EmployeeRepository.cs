using LibraryApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private IDbConnection _connection;
        public EmployeeRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<Employee>.Create(Employee entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Employee> IRepository<Employee>.ReadAll()
        {
            throw new NotImplementedException();
        }

        Employee IRepository<Employee>.ReadById(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<Employee>.Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
