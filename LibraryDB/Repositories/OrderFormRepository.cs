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
    public class OrderFormRepository : IRepository<OrderForm>
    {
        private DbConnectionProvider _connection;
        public OrderFormRepository(DbConnectionProvider connection)
        {
            _connection = connection;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<OrderForm>.Create(OrderForm entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<OrderForm> IRepository<OrderForm>.ReadAll()
        {
            throw new NotImplementedException();
        }

        OrderForm IRepository<OrderForm>.ReadById(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<OrderForm>.Update(OrderForm entity)
        {
            throw new NotImplementedException();
        }
    }
}
