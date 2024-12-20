using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);

        TEntity ReadById(int id);

        IEnumerable<TEntity> ReadAll();

        void Update(TEntity entity);

        void Delete(int id);

    }
}
