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
    public class BookRepository : IRepository<Book>
    {
        private DbConnectionProvider _connection;
        public BookRepository(DbConnectionProvider connection)
        {
            _connection = connection;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<Book>.Create(Book entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Book> IRepository<Book>.ReadAll()
        {
            throw new NotImplementedException();
        }

        Book IRepository<Book>.ReadById(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<Book>.Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
